using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;

namespace JR.P262605.API.Aligner
{
    public class AlignerModel
    {
        private readonly CancellationTokenSource CancellationTokenSource = new();
        private readonly List<ADS.AdsItem> ADSItems;
        private readonly ILogger Logger;
        private readonly AlignerConfiguration Configuration;
        private TCP.Client TCPClient { get; set; } = new();
        private ADS.Client ADSClient { get; set; }
        private string LastTxMessage { get; set; } = "";
        private bool Busy { get; set; }
        public API.AlignerAPIOut APIOut { get; set; } = new(nameof(APIOut));
        public API.AlignerAPIIn APIIn { get; set; } = new(nameof(APIIn));
        public bool ADSConnected { get; private set; }

        public AlignerModel(ILogger logger, IConfiguration configuration)
        {
            // Set Logger
            Logger = logger;

            // Get Configuration
            Configuration = configuration.GetSection("AlignerConfiguration").Get<AlignerConfiguration>();

            ADSClient = new(Logger);

            ADSItems = new()
            {
                new(nameof(APIOut.HeartbeatEcho), "Stn10_12_Aligner.APIOut.HeartbeatEcho", ADS.AdsConnectionType.WriteOnly, APIOut),
                new(nameof(APIOut.Connected), "Stn10_12_Aligner.APIOut.Connected", ADS.AdsConnectionType.WriteOnly, APIOut),
                new(nameof(APIOut.StartAckOK), "Stn10_12_Aligner.APIOut.StartAckOK", ADS.AdsConnectionType.WriteOnly, APIOut),
                new(nameof(APIOut.StartAckNOK), "Stn10_12_Aligner.APIOut.StartAckNOK", ADS.AdsConnectionType.WriteOnly, APIOut),
                new(nameof(APIOut.Done), "Stn10_12_Aligner.APIOut.Done", ADS.AdsConnectionType.WriteOnly, APIOut),
                new(nameof(APIOut.Error), "Stn10_12_Aligner.APIOut.Error", ADS.AdsConnectionType.WriteOnly, APIOut),
                new(nameof(APIOut.UnableToMove), "Stn10_12_Aligner.APIOut.UnableToMove", ADS.AdsConnectionType.WriteOnly, APIOut),
                new(nameof(APIOut.CommandError), "Stn10_12_Aligner.APIOut.CommandError", ADS.AdsConnectionType.WriteOnly, APIOut),
                new(nameof(APIOut.ChuckVacuumSensor), "Stn10_12_Aligner.APIOut.ChuckVacuumSensor", ADS.AdsConnectionType.WriteOnly, APIOut),
                new(nameof(APIOut.ChuckVacuumSwitch), "Stn10_12_Aligner.APIOut.ChuckVacuumSwitch", ADS.AdsConnectionType.WriteOnly, APIOut),
                new(nameof(APIOut.MotionError), "Stn10_12_Aligner.APIOut.MotionError", ADS.AdsConnectionType.WriteOnly, APIOut),
                new(nameof(APIOut.MotionLimitsViolation), "Stn10_12_Aligner.APIOut.MotionLimitsViolation", ADS.AdsConnectionType.WriteOnly, APIOut),
                new(nameof(APIOut.NotHomed), "Stn10_12_Aligner.APIOut.NotHomed", ADS.AdsConnectionType.WriteOnly, APIOut),
                new(nameof(APIOut.MacroRunning), "Stn10_12_Aligner.APIOut.MacroRunning", ADS.AdsConnectionType.WriteOnly, APIOut),
                new(nameof(APIOut.MotionInProgress), "Stn10_12_Aligner.APIOut.MotionInProgress", ADS.AdsConnectionType.WriteOnly, APIOut),
                new(nameof(APIOut.ServoOff), "Stn10_12_Aligner.APIOut.ServoOff", ADS.AdsConnectionType.WriteOnly, APIOut),
                new(nameof(APIOut.FileError), "Stn10_12_Aligner.APIOut.FileError", ADS.AdsConnectionType.WriteOnly, APIOut),
                new(nameof(APIOut.PinsVacuumSwitch), "Stn10_12_Aligner.APIOut.PinsVacuumSwitch", ADS.AdsConnectionType.WriteOnly, APIOut),

                new(nameof(APIIn.Heartbeat), "Stn10_12_Aligner.APIIn.Heartbeat", ADS.AdsConnectionType.ReadOnly, APIIn),
                new(nameof(APIIn.Start), "Stn10_12_Aligner.APIIn.Start", ADS.AdsConnectionType.ReadOnly, APIIn),
                new(nameof(APIIn.Command), "Stn10_12_Aligner.APIIn.Command", ADS.AdsConnectionType.ReadOnly, APIIn),
                new(nameof(APIIn.Data1), "Stn10_12_Aligner.APIIn.Data1", ADS.AdsConnectionType.ReadOnly, APIIn),
                new(nameof(APIIn.Data2), "Stn10_12_Aligner.APIIn.Data2", ADS.AdsConnectionType.ReadOnly, APIIn),
                new(nameof(APIIn.Data3), "Stn10_12_Aligner.APIIn.Data3", ADS.AdsConnectionType.ReadOnly, APIIn),
                new(nameof(APIIn.Data4), "Stn10_12_Aligner.APIIn.Data4", ADS.AdsConnectionType.ReadOnly, APIIn),
            };

            // Start Interface if Enabled
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
                            TCPClient.Delimiter = (byte)'\u000D';
                            TCPClient.DelimiterDataReceived += TCPClient_DelimiterDataReceived;

                            try
                            {
                                Logger?.LogInformation($"{Configuration.Name} TCP {Configuration.TCPEndpoint} - Attempting to Connect TCP Client...");
                                TCPClient.Connect(Address[0], int.Parse(Address[1]));

                                SendInfoMode(1).Wait();
                                Task.Delay(250).Wait();
                                SendRestore().Wait();
                                Task.Delay(250).Wait();

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
                            string[] EndPoint = Configuration.ADSEndpoint.Split(':');
                            ADSClient.Connect(EndPoint[0], int.Parse(EndPoint[1]));
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

            try
            {
                if (e.PropertyName != nameof(APIOut.HeartbeatEcho))
                {
                    Logger?.LogTrace($"Aligner PLC Write - {AdsTag.Name}.{e.PropertyName} = {e.Value}");
                }

                ADSClient.Write($"{AdsTag.Name}.{e.PropertyName}", e.Value);
            }
            catch
            {
                Logger?.LogError($"Aligner ADS - Unable to write to symbol {e.PropertyName} = {e.Value}");
            }
        }

        private void APIIn_AdsTagChanged(object sender, ADS.AdsTagChangedEventArgs e)
        {
            // Log Data Changes
            if (e.PropertyName != nameof(APIIn.Heartbeat))
            {
                ADS.IAdsTag AdsTag = (ADS.IAdsTag)sender;
                Logger?.LogTrace($"Aligner PLC Read - {AdsTag.Name}.{e.PropertyName} = {e.Value}");
            }

            if (ADSConnected)
            {
                // Update Heartbeat
                if (e.PropertyName == nameof(APIIn.Heartbeat))
                {
                    APIOut.HeartbeatEcho = APIIn.Heartbeat;

                    if (!APIIn.Start && APIOut.Done)
                    {
                        Logger?.LogInformation($"{Configuration.Name} ADS {Configuration.ADSEndpoint} - Reset API Out Handshake");

                        APIOut.ResetHandshake();
                    }
                }

                // Start Trigger
                if (e.PropertyName == nameof(APIIn.Start))
                {
                    if (APIIn.Start)
                    {
                        _ = ADSClient.Read($"{APIIn.Name}.{nameof(APIIn.Command)}");
                        _ = ADSClient.Read($"{APIIn.Name}.{nameof(APIIn.Data1)}");
                        _ = ADSClient.Read($"{APIIn.Name}.{nameof(APIIn.Data2)}");
                        _ = ADSClient.Read($"{APIIn.Name}.{nameof(APIIn.Data3)}");
                        _ = ADSClient.Read($"{APIIn.Name}.{nameof(APIIn.Data4)}");

                        Busy = Task.Run(async () => await ExecuteCommand(APIIn.Command, APIIn.Data1, APIIn.Data2)).Result;
                    }
                    else
                    {
                        Logger?.LogInformation($"{Configuration.Name} ADS {Configuration.ADSEndpoint} - Reset API Out Handshake");

                        APIOut.ResetHandshake();
                    }
                }
            }
        }

        private void TCPClient_DelimiterDataReceived(object sender, TCP.Message e)
        {
            string RxMessage = e.MessageString.Replace("\n", "");
            Logger?.LogTrace($"Aligner TCP {Configuration.TCPEndpoint} Rx {RxMessage}");

            if (LastTxMessage.Contains("STP"))
            {
                Logger?.LogInformation($"Aligner TCP {Configuration.TCPEndpoint} - Received STP Response");

                Busy = AckResponse(RxMessage);
            }

            if (LastTxMessage.Contains("SON"))
            {
                Logger?.LogInformation($"Aligner TCP {Configuration.TCPEndpoint} - Received SON Response");

                Busy = AckResponse(RxMessage);
            }

            if (LastTxMessage.Contains("SOF"))
            {
                Logger?.LogInformation($"Aligner TCP {Configuration.TCPEndpoint} - Received SOF Response");

                Busy = AckResponse(RxMessage);
            }

            if (LastTxMessage.Contains("HOM"))
            {
                Logger?.LogInformation($"Aligner TCP {Configuration.TCPEndpoint} - Received HOM Response");

                Busy = StatusResponse(RxMessage);
            }

            if (LastTxMessage.Contains("STA"))
            {
                Logger?.LogInformation($"Aligner TCP {Configuration.TCPEndpoint} - Received STA Response");

                Busy = StatusResponse(RxMessage);
            }

            if (LastTxMessage.Contains("CVF") || LastTxMessage.Contains("CVN"))
            {
                Logger?.LogInformation($"Aligner TCP {Configuration.TCPEndpoint} - Received CVF Response");

                Busy = AckResponse(RxMessage);
            }

            if (LastTxMessage.Contains("PVF") || LastTxMessage.Contains("PVN"))
            {
                Logger?.LogInformation($"Aligner TCP {Configuration.TCPEndpoint} - Received PVF Response");

                Busy = AckResponse(RxMessage);
            }

            if (LastTxMessage.Contains("INF"))
            {
                Logger?.LogInformation($"Aligner TCP {Configuration.TCPEndpoint} - Received INF Response");

                Busy = AckResponse(RxMessage);
            }

            if (LastTxMessage.Contains("BAL"))
            {
                Logger?.LogInformation($"Aligner TCP {Configuration.TCPEndpoint} - Received BAL Response");

                Busy = StatusResponse(RxMessage);
            }

            if (LastTxMessage.Contains("CSW"))
            {
                Logger?.LogInformation($"Aligner TCP {Configuration.TCPEndpoint} - Received CSW Response");

                Busy = AckResponse(RxMessage);
            }

            if (LastTxMessage.Contains("WSZ"))
            {
                Logger?.LogInformation($"Aligner TCP {Configuration.TCPEndpoint} - Received WSZ Response");

                Busy = AckResponse(RxMessage);
            }

            if (LastTxMessage.Contains("_WT"))
            {
                Logger?.LogInformation($"Aligner TCP {Configuration.TCPEndpoint} - Received _WT Response");

                Busy = AckResponse(RxMessage);
            }

            if (LastTxMessage.Contains("RMP"))
            {
                Logger?.LogInformation($"Aligner TCP {Configuration.TCPEndpoint} - Received RMP Response");
                Busy = AckResponse(RxMessage);

                Logger?.LogInformation($"{Configuration.Name} ADS {Configuration.ADSEndpoint} - Reset API Out Handshake");
                APIOut.ResetHandshake();
            }
        }

        private async Task<bool> ExecuteCommand(int command, int data1, int data2)
        {
            return command switch
            {
                0 => await SendStop(),
                1 => await SendServo(Convert.ToBoolean(data1)),
                2 => await SendHome(),
                3 => await SendStatus(),
                4 => await SendVacuum(data1, Convert.ToBoolean(data2)),
                5 => await SendInfoMode(data1),
                6 => await SendAlign(data1),
                7 => await SendSpeed(data1),
                8 => await SendWaferSize(data1),
                9 => await SendWaferType(data1),
                10 => await SendRestore(),
                _ => false,
            };
        }

        private bool StatusResponse(string message)
        {
            if (message.Contains(">"))
            {
                if (message.Length == 1)
                {
                    APIOut.StartAckOK = true;
                    return true;
                }
                else
                {
                    DecodeStatus(message.Replace(">", ""));
                    APIOut.Done = true;
                }
            }
            else
            {
                if (message.Length == 1)
                {
                    APIOut.StartAckNOK = true;
                }
                else
                {
                    DecodeStatus(message.Replace("?", ""));
                    APIOut.Done = true;
                }
            }
            return false;
        }

        private bool AckResponse(string message)
        {
            if (message.Contains(">"))
            {
                if (message.Length == 1)
                {
                    APIOut.StartAckOK = true;
                    APIOut.Done = true;
                }
                else
                {
                    APIOut.StartAckNOK = true;
                    APIOut.Done = true;
                }
            }
            else
            {
                APIOut.StartAckNOK = true;
                APIOut.Done = true;
            }

            return false;
        }

        private void DecodeStatus(string status)
        {
            BitArray BitArray = Reverse(ConvertHexToBitArray(status));

            APIOut.UnableToMove = BitArray.Get(0);
            APIOut.CommandError = BitArray.Get(1);
            APIOut.ChuckVacuumSensor = BitArray.Get(2);
            APIOut.ChuckVacuumSwitch = BitArray.Get(3);
            APIOut.MotionError = BitArray.Get(4);
            APIOut.MotionLimitsViolation = BitArray.Get(5);
            APIOut.NotHomed = BitArray.Get(6);
            APIOut.MacroRunning = BitArray.Get(7);
            APIOut.MotionInProgress = BitArray.Get(8);
            APIOut.ServoOff = BitArray.Get(10);
            APIOut.FileError = BitArray.Get(13);
            APIOut.PinsVacuumSwitch = BitArray.Get(15);
        }

        public static BitArray Reverse(BitArray array)
        {
            BitArray BitArray = new(array);

            int length = BitArray.Length;
            int mid = (length / 2);

            for (int i = 0; i < mid; i++)
            {
                bool bit = BitArray[i];
                BitArray[i] = BitArray[length - i - 1];
                BitArray[length - i - 1] = bit;
            }

            return BitArray;
        }

        public static BitArray ConvertHexToBitArray(string hexData)
        {
            BitArray BitArray = new(4 * hexData.Length);

            for (int i = 0; i < hexData.Length; i++)
            {
                byte @byte = byte.Parse(hexData[i].ToString(), NumberStyles.HexNumber);

                for (int j = 0; j < 4; j++)
                {
                    BitArray.Set(i * 4 + j, (@byte & (1 << (3 - j))) != 0);
                }
            }

            return BitArray;
        }

        private async Task<bool> SendStop()
        {
            Logger?.LogInformation($"Aligner TCP {Configuration.TCPEndpoint} - Sent Stop Command");
            return await SendMessage($"STP", true);
        }

        private async Task<bool> SendServo(bool status)
        {
            Logger?.LogInformation($"Aligner TCP {Configuration.TCPEndpoint} - Sent Servo Command - Servo {status}");
            return status ? await SendMessage("SON") : await SendMessage("SOF");
        }

        private async Task<bool> SendInfoMode(int mode)
        {
            Logger?.LogInformation($"Aligner TCP {Configuration.TCPEndpoint} - Sent Info Mode Command - Mode {mode}");
            return await SendMessage($"INF {mode}");
        }

        private async Task<bool> SendHome()
        {
            Logger?.LogInformation($"Aligner TCP {Configuration.TCPEndpoint} - Sent Home Command");
            return await SendMessage("HOM");
        }

        private async Task<bool> SendStatus()
        {
            Logger?.LogInformation($"Aligner TCP {Configuration.TCPEndpoint} - Sent Status Request");
            return await SendMessage($"STA");
        }

        private async Task<bool> SendVacuum(int component, bool status)
        {
            return component == 0
                ? status ? await SendMessage("CVN") : await SendMessage("CVF")
                : status ? await SendMessage("PVN") : await SendMessage("PVF");
        }

        private async Task<bool> SendAlign(int method)
        {
            Logger?.LogInformation($"Aligner TCP {Configuration.TCPEndpoint} - Sent Align Command - Method {method}");
            return await SendMessage($"BAL {method}");
        }

        private async Task<bool> SendSpeed(int speed)
        {
            Logger?.LogInformation($"Aligner TCP {Configuration.TCPEndpoint} - Sent Speed Set Command - Speed {speed}");
            return await SendMessage($"CSW {speed}");
        }

        private async Task<bool> SendWaferSize(int size)
        {
            Logger?.LogInformation($"Aligner TCP {Configuration.TCPEndpoint} - Sent Wafer Size Set Command - Size {size}");
            return await SendMessage($"WSZ {size}");
        }

        private async Task<bool> SendWaferType(int type)
        {
            Logger?.LogInformation($"Aligner TCP {Configuration.TCPEndpoint} - Sent Wafer Type Set Command - Size {type}");
            return await SendMessage($"_WT {type}");
        }

        private async Task<bool> SendRestore()
        {
            Logger?.LogInformation($"Aligner TCP {Configuration.TCPEndpoint} - Sent Parameter Restore Command");
            return await SendMessage("RMP");
        }

        private async Task<bool> SendMessage(string message, bool force = false)
        {
            if (TCPClient.Connected)
            {
                if (!Busy || force)
                {
                    try
                    {
                        LastTxMessage = message.Replace((char)TCPClient.Delimiter, '\u0000');
                        await TCPClient.WriteLineAsync(LastTxMessage);
                        Logger?.LogTrace($"{Configuration.Name} TCP {Configuration.TCPEndpoint} Tx {LastTxMessage}");
                        return true;
                    }
                    catch
                    {
                        Logger?.LogError($"Aligner TCP {Configuration.TCPEndpoint} - Unable to Send Command {message}");
                        APIOut.Error = 3;
                    }
                }
                else
                {
                    Logger?.LogWarning($"Aligner TCP {Configuration.TCPEndpoint} - Busy Unable to Send Command {message}");
                    APIOut.Error = 2;
                }
            }
            else
            {
                Logger?.LogWarning($"Aligner TCP {Configuration.TCPEndpoint} - Unable to Send Commad - Client Not Connected");
                APIOut.Error = 1;
            }

            return false;
        }
    }
}