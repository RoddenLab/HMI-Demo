using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace JR.P262605.API.Lumetrics
{
    public class LumetricsModel
    {
        private readonly CancellationTokenSource CancellationTokenSource = new();
        private readonly List<ADS.AdsItem> ADSItems;
        private readonly ILogger Logger;
        private readonly LumetricsConfiguration Configuration;
        private TCP.Client TCPClient { get; set; } = new();
        private ADS.Client ADSClient { get; set; }
        private string LastTxMessage { get; set; } = "";
        private bool Busy { get; set; }
        public bool ADSConnected { get; private set; }
        private API.LumetricsAPIIn APIIn { get; set; } = new(nameof(APIIn));
        private API.LumetricsAPIOut APIOut { get; set; } = new(nameof(APIOut));

        public LumetricsModel(ILogger logger, IConfiguration configuration)
        {
            // Set Logger
            Logger = logger;

            // Get Configuration
            Configuration = configuration.GetSection("LumetricsConfiguration").Get<LumetricsConfiguration>();

            ADSClient = new(Logger);

            ADSItems = new()
            {
                new(nameof(APIOut.HeartbeatEcho), "Stn10_18_Lumetrics.APIOut.HeartbeatEcho", ADS.AdsConnectionType.WriteOnly, APIOut),
                new(nameof(APIOut.Connected), "Stn10_18_Lumetrics.APIOut.Connected", ADS.AdsConnectionType.WriteOnly, APIOut),
                new(nameof(APIOut.Done), "Stn10_18_Lumetrics.APIOut.Done", ADS.AdsConnectionType.WriteOnly, APIOut),
                new(nameof(APIOut.Error), "Stn10_18_Lumetrics.APIOut.Error", ADS.AdsConnectionType.WriteOnly, APIOut),
                new(nameof(APIOut.Measurement), "Stn10_18_Lumetrics.APIOut.Measurement", ADS.AdsConnectionType.WriteOnly, APIOut),

                new(nameof(APIIn.Heartbeat), "Stn10_18_Lumetrics.APIIn.Heartbeat", ADS.AdsConnectionType.ReadOnly, APIIn),
                new(nameof(APIIn.Start), "Stn10_18_Lumetrics.APIIn.Start", ADS.AdsConnectionType.ReadOnly, APIIn)
            };

            if (Configuration.Enabled)
            {
                StartADSClientMonitor();
                StartTCPClientMonitor();
            }

            APIIn.AdsTagChanged += APIIn_AdsTagChanged;
            APIOut.AdsTagChanged += APIOut_AdsTagChanged;
        }

        private void StartTCPClientMonitor()
        {
            _ = Task.Run(async () =>
            {
                while (true)
                {
                    if (ADSConnected)
                    {
                        _ = ADSClient.Read($"{APIOut.Name}.{nameof(APIOut.Connected)}");

                        if (!TCPClient.Connected)
                        {
                            if (APIOut.Connected)
                            {
                                Logger?.LogInformation($"{Configuration.Name} TCP {Configuration.TCPEndpoint} - Disconnected from TCP Server");
                                APIOut.Connected = false;
                            }

                            string[] Address = Configuration.TCPEndpoint.Split(':');

                            TCPClient = new();
                            TCPClient.DataReceived += TCPClient_DataReceived;
                            TCPClient.DataSent += TCPClient_DataSent;

                            try
                            {
                                Logger?.LogInformation($"{Configuration.Name} TCP {Configuration.TCPEndpoint} - Attempting to Connect TCP Client...");
                                TCPClient.Connect(Address[0], int.Parse(Address[1]));

                                Task.Delay(500).Wait();

                                Logger?.LogInformation($"{Configuration.Name} TCP {Configuration.TCPEndpoint} - Connected to TCP Server");
                                APIOut.Connected = true;
                            }
                            catch (Exception Exception)
                            {
                                Logger?.LogError($"{Configuration.Name} TCP {Configuration.TCPEndpoint} - Unable to Connect TCP Client - {Exception.Message}");
                                TCPClient.Disconnect();
                            }
                        }
                        else if (!APIOut.Connected)
                        {
                            Logger?.LogInformation($"{Configuration.Name} TCP {Configuration.TCPEndpoint} - Connected to TCP Server");
                            APIOut.Connected = true;
                        }
                    }
                    else
                    {
                        if (TCPClient.Connected)
                        {
                            Logger?.LogInformation($"{Configuration.Name} TCP {Configuration.TCPEndpoint} - Disconnecting TCP Until PLC Connection Active");
                            TCPClient.Disconnect();
                            TCPClient = new();
                        }
                    }

                    await Task.Delay(2500);
                }
            }, CancellationTokenSource.Token);
        }

        private void StartADSClientMonitor()
        {
            _ = Task.Run(async () =>
            {
                ADSConnected = false;

                while (true)
                {
                    if (!ADSClient.Connected)
                    {
                        if (ADSConnected)
                        {
                            Logger?.LogInformation($"{Configuration.Name} ADS {Configuration.ADSEndpoint} - Disconnected from ADS Server");
                            ADSConnected = false;
                        }

                        try
                        {
                            Logger?.LogInformation($"{Configuration.Name} ADS {Configuration.ADSEndpoint} - Attempting to Connect ADS Client...");
                            string[] Endpoint = Configuration.ADSEndpoint.Split(':');
                            ADSClient.Connect(Endpoint[0], int.Parse(Endpoint[1]));
                            Logger?.LogInformation($"{Configuration.Name} ADS {Configuration.ADSEndpoint} - Connected to ADS Server");

                            Logger?.LogInformation($"{Configuration.Name} ADS {Configuration.ADSEndpoint} - Subscribing to ADS Tags...");
                            if (ADSClient.Subscribe(ADSItems))
                            {
                                Logger?.LogInformation($"{Configuration.Name} ADS {Configuration.ADSEndpoint} - Subscribed to ADS Tags");
                                Logger?.LogInformation($"{Configuration.Name} ADS {Configuration.ADSEndpoint} - Connected to ADS Server");
                                ADSConnected = true;
                            }
                        }
                        catch (Exception Exception)
                        {
                            Logger?.LogError($"{Configuration.Name} ADS {Configuration.ADSEndpoint} - Unable to Connect to ADS Client - {Exception.Message}");
                            ADSClient.Disconnect();
                        }
                    }
                    else if (ADSClient.Connected && !ADSConnected)
                    {
                        Logger?.LogInformation($"{Configuration.Name} ADS {Configuration.ADSEndpoint} - Disconnecting ADS Client");
                        ADSClient.Disconnect();
                        Logger?.LogInformation($"{Configuration.Name} ADS {Configuration.ADSEndpoint} - ADS Client Disconected");
                    }

                    await Task.Delay(2500);
                }
            }, CancellationTokenSource.Token);
        }

        private void APIOut_AdsTagChanged(object sender, ADS.AdsTagChangedEventArgs e)
        {
            ADS.AdsTag AdsTag = (ADS.AdsTag)sender;

            if (ADSConnected)
            {
                try
                {
                    if (e.PropertyName != nameof(APIOut.HeartbeatEcho))
                    {
                        Logger?.LogTrace($"{Configuration.Name} PLC Write - {AdsTag.Name}.{e.PropertyName} = {e.Value}");
                    }

                    ADSClient.Write($"{AdsTag.Name}.{ e.PropertyName}", e.Value);
                }
                catch
                {
                    Logger?.LogError($"{Configuration.Name} ADS - Unable to write to symbol {e.PropertyName} = {e.Value}");
                }
            }
            else
            {
                Logger?.LogDebug($"{Configuration.Name} ADS {Configuration.ADSEndpoint} - Unable to Write to Symbol - ADS Client Not Connected");
            }
        }

        private void APIIn_AdsTagChanged(object sender, ADS.AdsTagChangedEventArgs e)
        {
            // Log Data Changes
            if (e.PropertyName != nameof(APIIn.Heartbeat))
            {
                ADS.IAdsTag AdsTag = (ADS.IAdsTag)sender;
                Logger?.LogTrace($"{Configuration.Name} PLC Read - {AdsTag.Name}.{e.PropertyName} = {e.Value}");
            }

            if (ADSConnected)
            {
                // Update Heartbeat
                if (e.PropertyName == nameof(APIIn.Heartbeat))
                {
                    APIOut.HeartbeatEcho = APIIn.Heartbeat;

                    if (!APIIn.Start && APIOut.Done)
                    {
                        APIOut.ResetHandshake();
                    }
                }

                // Start Trigger for Measurement
                if (e.PropertyName == nameof(APIIn.Start))
                {
                    if (APIIn.Start)
                    {
                        //send the appropriate command to the Lumetrics equipment
                        // [STX]SDT[ETX]
                        //
                        Busy = Task.Run(async () => await SendMessage("\x02" + "SDT" + "\x03")).Result;
                    }
                    else
                    {
                        APIOut.ResetHandshake();
                    }
                }
            }
        }

        private void TCPClient_DataReceived(object sender, TCP.Message e)
        {
            string RxMessage = e.MessageString;
            Logger?.LogTrace($"{Configuration.Name} TCP {Configuration.TCPEndpoint} Rx {RxMessage}");

            //here we need to check if we are interested in a particular response from the lumetrics machine
            //[STX]ACK,SDT,3,400.20,37.29,118.61,1.5,1.5,1.5,1[ETX]
            if (RxMessage.StartsWith("\x02" + "ACK,SDT") && RxMessage.EndsWith("\x03"))
            {
                RxMessage = RxMessage.Replace("\x02", "");
                RxMessage = RxMessage.Replace("\x03", "");
                RxMessage = RxMessage.Replace("ACK,SDT,", "");
                //now we are only left with a string of numbers
                /*
                The order of values is: number of layers, 
                the thickness values for those layers (optical thickness), refractive indices for each layer,
                and the current switch channel.
                */
                //for now just return the whole string to caller
                APIOut.Measurement = RxMessage;
            }
            else
            {
                APIOut.Measurement = "Not Interested Msg:" + RxMessage;
            }



            APIOut.Done = true;
            Busy = false;
        }

        private void TCPClient_DataSent(object sender, TCP.Message e)
        {
            LastTxMessage = e.MessageString.Replace("\r", "");
            Logger?.LogTrace($"{Configuration.Name} TCP {Configuration.TCPEndpoint} Tx {LastTxMessage}");
        }

        private async Task<bool> SendMessage(string message, bool force = false)
        {
            if (TCPClient.Connected)
            {
                if (!Busy || force)
                {
                    try
                    {
                        await TCPClient.WriteAsync(message);
                        return true;
                    }
                    catch
                    {
                        Logger?.LogError($"{Configuration.Name} TCP {Configuration.TCPEndpoint} - Unable to Send Command {message}");
                        APIOut.Error = 3;
                    }
                }
                else
                {
                    Logger?.LogWarning($"{Configuration.Name} TCP {Configuration.TCPEndpoint} - Busy Unable to Send Command {message}");
                    APIOut.Error = 2;
                }
            }
            else
            {
                Logger?.LogWarning($"{Configuration.Name} TCP {Configuration.TCPEndpoint} - Unable to Send Commad - Client Not Connected");
                APIOut.Error = 1;
            }

            return false;
        }
    }
}