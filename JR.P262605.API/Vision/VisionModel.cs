using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace JR.P262605.API.Vision
{
    public class VisionModel
    {
        private readonly CancellationTokenSource CancellationTokenSource = new();
        private readonly List<ADS.AdsItem> ADSItems;
        private readonly ILogger Logger;
        private readonly VisionConfiguration Configuration;
        private TCP.Client TCPClient { get; set; } = new();
        private ADS.Client ADSClient { get; set; }
        private string LastTxMessage { get; set; } = "";
        private bool Busy { get; set; }
        public bool ADSConnected { get; private set; }
        private API.VisionAPIIn APIIn { get; set; } = new(nameof(APIIn));
        private API.VisionAPIOut APIOut { get; set; } = new(nameof(APIOut));

        public enum Position
        {
            Top,
            Bottom
        }

        public VisionModel(ILogger logger, IConfiguration configuration, Position position)
        {
            // Set Logger
            Logger = logger;

            // Get Configuration
            Configuration = position switch
            {
                Position.Top => configuration.GetSection("TopVisionConfiguration").Get<VisionConfiguration>(),
                Position.Bottom => configuration.GetSection("BottomVisionConfiguration").Get<VisionConfiguration>(),
                _ => throw new ArgumentOutOfRangeException(nameof(position)),
            };

            // Create ADS Client
            ADSClient = new(Logger);

            if (position == Position.Bottom)
            {
                ADSItems = new()
                {
                    new(nameof(APIOut.HeartbeatEcho), "Stn10_14_BottomCamera.APIOut.HeartbeatEcho", ADS.AdsConnectionType.WriteOnly, APIOut),
                    new(nameof(APIOut.Connected), "Stn10_14_BottomCamera.APIOut.Connected", ADS.AdsConnectionType.WriteOnly, APIOut),
                    new(nameof(APIOut.Done), "Stn10_14_BottomCamera.APIOut.Done", ADS.AdsConnectionType.WriteOnly, APIOut),
                    new(nameof(APIOut.Error), "Stn10_14_BottomCamera.APIOut.Error", ADS.AdsConnectionType.WriteOnly, APIOut),
                    new(nameof(APIOut.OCRCode), "Stn10_14_BottomCamera.APIOut.OCRCode", ADS.AdsConnectionType.WriteOnly, APIOut),

                    new(nameof(APIIn.Heartbeat), "Stn10_14_BottomCamera.APIIn.Heartbeat", ADS.AdsConnectionType.ReadOnly, APIIn),
                    new(nameof(APIIn.Start), "Stn10_14_BottomCamera.APIIn.Start", ADS.AdsConnectionType.ReadOnly, APIIn)
                };
            }
            else
            {
                ADSItems = new()
                {
                    new(nameof(APIOut.HeartbeatEcho), "Stn10_15_TopCamera.APIOut.HeartbeatEcho", ADS.AdsConnectionType.WriteOnly, APIOut),
                    new(nameof(APIOut.Connected), "Stn10_15_TopCamera.APIOut.Connected", ADS.AdsConnectionType.WriteOnly, APIOut),
                    new(nameof(APIOut.Done), "Stn10_15_TopCamera.APIOut.Done", ADS.AdsConnectionType.WriteOnly, APIOut),
                    new(nameof(APIOut.Error), "Stn10_15_TopCamera.APIOut.Error", ADS.AdsConnectionType.WriteOnly, APIOut),
                    new(nameof(APIOut.OCRCode), "Stn10_15_TopCamera.APIOut.OCRCode", ADS.AdsConnectionType.WriteOnly, APIOut),

                    new(nameof(APIIn.Heartbeat), "Stn10_15_TopCamera.APIIn.Heartbeat", ADS.AdsConnectionType.ReadOnly, APIIn),
                    new(nameof(APIIn.Start), "Stn10_15_TopCamera.APIIn.Start", ADS.AdsConnectionType.ReadOnly, APIIn)
                };
            }

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
                            if (Address.Length != 2) { throw new ArgumentOutOfRangeException(nameof(Configuration.TCPEndpoint), $"{ Configuration.Name } TCP { Configuration.TCPEndpoint} - Improper TCP Endpoint Provided!"); }

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

                // Start Trigger
                if (e.PropertyName == nameof(APIIn.Start))
                {
                    if (APIIn.Start)
                    {
                        Busy = Task.Run(async () => await SendMessage("t")).Result;
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

            APIOut.OCRCode = RxMessage;
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