using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;

namespace JR.P262605.API.Robot
{
    public class RobotModel
    {
        private readonly CancellationTokenSource CancellationTokenSource = new();
        private readonly List<ADS.AdsItem> ADSItems;
        private readonly ILogger Logger;
        private readonly RobotConfiguration Configuration;
        private TCP.Client TCPClient { get; set; } = new();
        private ADS.Client ADSClient { get; set; }
        private string LastTxMessage { get; set; } = "";
        private bool Busy { get; set; }
        public bool ADSConnected { get; private set; }
        public RobotAPIOut APIOut { get; set; } = new(nameof(APIOut));
        public RobotAPIIn APIIn { get; set; } = new(nameof(APIIn));

        public RobotModel(ILogger logger, IConfiguration configuration)
        {
            // Set Logger
            Logger = logger;

            // Get Configuration
            Configuration = configuration.GetSection("RobotConfiguration").Get<RobotConfiguration>();

            // Create ADS Client
            ADSClient = new(Logger);

            ADSItems = new()
            {
                new(nameof(APIOut.HeartbeatEcho), "Stn10_11_Robot.APIOut.HeartbeatEcho", ADS.AdsConnectionType.WriteOnly, APIOut),
                new(nameof(APIOut.Connected), "Stn10_11_Robot.APIOut.Connected", ADS.AdsConnectionType.WriteOnly, APIOut),
                new(nameof(APIOut.StartAckOK), "Stn10_11_Robot.APIOut.StartAckOK", ADS.AdsConnectionType.WriteOnly, APIOut),
                new(nameof(APIOut.StartAckNOK), "Stn10_11_Robot.APIOut.StartAckNOK", ADS.AdsConnectionType.WriteOnly, APIOut),
                new(nameof(APIOut.Done), "Stn10_11_Robot.APIOut.Done", ADS.AdsConnectionType.WriteOnly, APIOut),
                new(nameof(APIOut.Error), "Stn10_11_Robot.APIOut.Error", ADS.AdsConnectionType.WriteOnly, APIOut),
                new(nameof(APIOut.Data), "Stn10_11_Robot.APIOut.Data", ADS.AdsConnectionType.WriteOnly, APIOut),
                new(nameof(APIOut.Mapping), "Stn10_11_Robot.APIOut.Mapping", ADS.AdsConnectionType.WriteOnly, APIOut),
                new(nameof(APIOut.UnableToMove), "Stn10_11_Robot.APIOut.UnableToMove", ADS.AdsConnectionType.WriteOnly, APIOut),
                new(nameof(APIOut.CommandError), "Stn10_11_Robot.APIOut.CommandError", ADS.AdsConnectionType.WriteOnly, APIOut),
                new(nameof(APIOut.VacuumSensor), "Stn10_11_Robot.APIOut.VacuumSensor", ADS.AdsConnectionType.WriteOnly, APIOut),
                new(nameof(APIOut.VacuumSwitch), "Stn10_11_Robot.APIOut.VacuumSwitch", ADS.AdsConnectionType.WriteOnly, APIOut),
                new(nameof(APIOut.MotionError), "Stn10_11_Robot.APIOut.MotionError", ADS.AdsConnectionType.WriteOnly, APIOut),
                new(nameof(APIOut.SoftwareLimit), "Stn10_11_Robot.APIOut.SoftwareLimit", ADS.AdsConnectionType.WriteOnly, APIOut),
                new(nameof(APIOut.NotHomed), "Stn10_11_Robot.APIOut.NotHomed", ADS.AdsConnectionType.WriteOnly, APIOut),
                new(nameof(APIOut.MacroRunning), "Stn10_11_Robot.APIOut.MacroRunning", ADS.AdsConnectionType.WriteOnly, APIOut),
                new(nameof(APIOut.InMotion), "Stn10_11_Robot.APIOut.InMotion", ADS.AdsConnectionType.WriteOnly, APIOut),
                new(nameof(APIOut.ServoOff), "Stn10_11_Robot.APIOut.ServoOff", ADS.AdsConnectionType.WriteOnly, APIOut),
                new(nameof(APIOut.InTeachMode), "Stn10_11_Robot.APIOut.InTeachMode", ADS.AdsConnectionType.WriteOnly, APIOut),
                new(nameof(APIOut.InSearchMode), "Stn10_11_Robot.APIOut.InSearchMode", ADS.AdsConnectionType.WriteOnly, APIOut),
                new(nameof(APIOut.FileError), "Stn10_11_Robot.APIOut.FileError", ADS.AdsConnectionType.WriteOnly, APIOut),
                new(nameof(APIOut.InTeachScanMode), "Stn10_11_Robot.APIOut.InTeachScanMode", ADS.AdsConnectionType.WriteOnly, APIOut),
                new(nameof(APIOut.Position), "Stn10_11_Robot.APIOut.Position", ADS.AdsConnectionType.WriteOnly, APIOut),

                new(nameof(APIIn.Heartbeat), "Stn10_11_Robot.APIIn.Heartbeat", ADS.AdsConnectionType.ReadOnly, APIIn),
                new(nameof(APIIn.Start), "Stn10_11_Robot.APIIn.Start", ADS.AdsConnectionType.ReadOnly, APIIn),
                new(nameof(APIIn.Stop), "Stn10_11_Robot.APIIn.Stop", ADS.AdsConnectionType.ReadOnly, APIIn),
                new(nameof(APIIn.Command), "Stn10_11_Robot.APIIn.Command", ADS.AdsConnectionType.ReadOnly, APIIn),
                new(nameof(APIIn.Station), "Stn10_11_Robot.APIIn.Station", ADS.AdsConnectionType.ReadOnly, APIIn),
                new(nameof(APIIn.Slot), "Stn10_11_Robot.APIIn.Slot", ADS.AdsConnectionType.ReadOnly, APIIn),
                new(nameof(APIIn.Data1), "Stn10_11_Robot.APIIn.Data1", ADS.AdsConnectionType.ReadOnly, APIIn),
                new(nameof(APIIn.Data2), "Stn10_11_Robot.APIIn.Data2", ADS.AdsConnectionType.ReadOnly, APIIn),
            };

            if (Configuration.Enabled)
            {
                StartADSClientMonitor();
                StartTCPClientMonitor();
            }

            APIIn.AdsTagChanged += APIIn_AdsTagChanged;
            APIOut.AdsTagChanged += APIOut_AdsTagChanged;
        }

        private void APIOut_AdsTagChanged(object sender, ADS.AdsTagChangedEventArgs e)
        {
            ADS.AdsTag AdsTag = (ADS.AdsTag)sender;

            if (ADSConnected)
            {
                try
                {
                    if (!APIOut.Connected)
                    {

                    }

                    if (e.PropertyName != nameof(APIOut.HeartbeatEcho))
                    {
                        Logger?.LogTrace($"Robot PLC Write - {AdsTag.Name}.{e.PropertyName} = {e.Value}");
                    }

                    ADSClient.Write($"{AdsTag.Name}.{e.PropertyName}", e.Value);
                }
                catch
                {
                    Logger?.LogError($"Robot ADS - Unable to write to symbol {e.PropertyName} = {e.Value}");
                }
            }
            else
            {
                Logger?.LogDebug($"Robot ADS {Configuration.ADSEndpoint} - Unable to Write to Symbol - ADS Client Not Connected");
            }
        }

        private void APIIn_AdsTagChanged(object sender, ADS.AdsTagChangedEventArgs e)
        {
            // Log Data Changes
            if (e.PropertyName != nameof(APIIn.Heartbeat))
            {
                ADS.IAdsTag AdsTag = (ADS.IAdsTag)sender;
                Logger?.LogTrace($"Robot PLC Read - {AdsTag.Name}.{e.PropertyName} = {e.Value}");
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
                        _ = ADSClient.Read($"{APIIn.Name}.{nameof(APIIn.Command)}");
                        _ = ADSClient.Read($"{APIIn.Name}.{nameof(APIIn.Station)}");
                        _ = ADSClient.Read($"{APIIn.Name}.{nameof(APIIn.Slot)}");
                        _ = ADSClient.Read($"{APIIn.Name}.{nameof(APIIn.Data1)}");
                        _ = ADSClient.Read($"{APIIn.Name}.{nameof(APIIn.Data2)}");

                        Busy = Task.Run(async () => await ExecuteCommand(APIIn.Command, APIIn.Station, APIIn.Slot, APIIn.Data1, APIIn.Data2)).Result;
                    }
                    else
                    {
                        APIOut.ResetHandshake();
                    }
                }

                // Stop Trigger
                if (e.PropertyName == nameof(APIIn.Stop))
                {
                    if (APIIn.Stop)
                    {
                        Task.Run(async () => await ExecuteCommand(0, "", 0, 0, 0));
                    }
                }
            }
        }

        private void TCPClient_DelimiterDataReceived(object sender, TCP.Message e)
        {
            string RxMessage = e.MessageString.Replace("\n", "");
            Logger?.LogTrace($"Robot TCP {Configuration.TCPEndpoint} Rx {RxMessage}");

            if (LastTxMessage.Contains("CPO"))
            {
                Logger?.LogInformation($"{Configuration.Name} TCP {Configuration.TCPEndpoint} - Received CPO Response");
                Busy = PositionResponse(RxMessage);
            }

            if (LastTxMessage.Contains("CSW"))
            {
                Logger?.LogInformation($"{Configuration.Name} TCP {Configuration.TCPEndpoint} - Received CSW Response");
                Busy = AckResponse(RxMessage);
            }

            if (LastTxMessage.Contains("EOT"))
            {
                Logger?.LogInformation($"{Configuration.Name} TCP {Configuration.TCPEndpoint} - Received EOT Response");
                Busy = AckResponse(RxMessage);
            }

            if (LastTxMessage.Contains("GET"))
            {
                Logger?.LogInformation($"{Configuration.Name} TCP {Configuration.TCPEndpoint} - Received GET Response");
                Busy = StatusResponse(RxMessage);
            }

            if (LastTxMessage.Contains("HOM"))
            {
                Logger?.LogInformation($"{Configuration.Name} TCP {Configuration.TCPEndpoint} - Received HOM Response");
                Busy = StatusResponse(RxMessage);
            }

            if (LastTxMessage.Contains("INP"))
            {
                Logger?.LogInformation($"{Configuration.Name} TCP {Configuration.TCPEndpoint} - Received INP Response");
                Busy = InputResponse(RxMessage);
            }

            if (LastTxMessage.Contains("MAP"))
            {
                Logger?.LogInformation($"{Configuration.Name} TCP {Configuration.TCPEndpoint} - Received MAP Response");
                Busy = MappingResponse(RxMessage);
            }

            if (LastTxMessage.Contains("MTS"))
            {
                Logger?.LogInformation($"{Configuration.Name} TCP {Configuration.TCPEndpoint} - Received MTS Response");
                Busy = StatusResponse(RxMessage);
            }

            if (LastTxMessage.Contains("MVA"))
            {
                Logger?.LogInformation($"{Configuration.Name} TCP {Configuration.TCPEndpoint} - Received MVA Response");
                Busy = StatusResponse(RxMessage);
            }

            if (LastTxMessage.Contains("MVR"))
            {
                Logger?.LogInformation($"{Configuration.Name} TCP {Configuration.TCPEndpoint} - Received MVR Response");
                Busy = StatusResponse(RxMessage);
            }

            if (LastTxMessage.Contains("MTH"))
            {
                Logger?.LogInformation($"{Configuration.Name} TCP {Configuration.TCPEndpoint} - Recieved MTH Response");
                Busy = StatusResponse(RxMessage);
            }

            if (LastTxMessage.Contains("OUT"))
            {
                Logger?.LogInformation($"{Configuration.Name} TCP {Configuration.TCPEndpoint} - Received OUT Response");
                Busy = OutputResponse(RxMessage);
            }

            if (LastTxMessage.Contains("PUT"))
            {
                Logger?.LogInformation($"{Configuration.Name} TCP {Configuration.TCPEndpoint} - Received PUT Response");
                Busy = StatusResponse(RxMessage);
            }

            if (LastTxMessage.Contains("SCN"))
            {
                Logger?.LogInformation($"{Configuration.Name} TCP {Configuration.TCPEndpoint} - Received SCN Response");
                Busy = StatusResponse(RxMessage);
            }

            if (LastTxMessage.Contains("SON"))
            {
                Logger?.LogInformation($"{Configuration.Name} TCP {Configuration.TCPEndpoint} - Received SON Response");
                Busy = AckResponse(RxMessage);
            }

            if (LastTxMessage.Contains("SOF"))
            {
                Logger?.LogInformation($"{Configuration.Name} TCP {Configuration.TCPEndpoint} - Received SOF Response");
                Busy = AckResponse(RxMessage);
            }

            if (LastTxMessage.Contains("SPO"))
            {
                Logger?.LogInformation($"{Configuration.Name} TCP {Configuration.TCPEndpoint} - Received SPO Response");
                Busy = AckResponse(RxMessage);
            }

            if (LastTxMessage.Contains("STA"))
            {
                Logger?.LogInformation($"{Configuration.Name} TCP {Configuration.TCPEndpoint} - Received STA Response");
                Busy = StatusResponse(RxMessage);
            }

            if (LastTxMessage.Contains("STP"))
            {
                Logger?.LogInformation($"{Configuration.Name} TCP {Configuration.TCPEndpoint} - Received STP Response");
                Busy = AckResponse(RxMessage);
            }

            if (LastTxMessage.Contains("TCH"))
            {
                Logger?.LogInformation($"{Configuration.Name} TCP {Configuration.TCPEndpoint} - Received TCH Response");
                Busy = AckResponse(RxMessage);
            }

            if (LastTxMessage.Contains("VON"))
            {
                Logger?.LogInformation($"{Configuration.Name} TCP {Configuration.TCPEndpoint} - Received VON Response");
                Busy = AckResponse(RxMessage);
            }

            if (LastTxMessage.Contains("VOF"))
            {
                Logger?.LogInformation($"{Configuration.Name} TCP {Configuration.TCPEndpoint} - Received VOF Response");
                Busy = AckResponse(RxMessage);
            }
        }

        private async Task<bool> ExecuteCommand(int command, string station, int slot, int data1, int data2)
        {
            return command switch
            {
                0 => await SendSTP(),
                1 => await SendSON(Convert.ToBoolean(data1)),
                2 => await SendHOM(),
                3 => await SendSTA(),
                4 => await SendVON(Convert.ToBoolean(data1)),
                5 => await SendINF(data1),
                6 => await SendMAP(),
                7 => data2 > 0 ? await SendOUT(data1, Convert.ToBoolean(data2)) : await SendOUT(data1),
                8 => await SendCSW(data1),
                9 => await SendSCN(station),
                10 => await SendGET(station, slot),
                11 => await SendPUT(station, slot),
                12 => await SendMTS(station),
                13 => await SendINP(data1),
                14 => await SendMVR(data1, data2),
                15 => await SendMTH(),
                16 => await SendMVA(data1, data2),
                17 => await SendCPO(),
                18 => await SendSPO(station, data1, data2),
                19 => await SendTCH(station),
                20 => await SendEOT(),
                _ => false,
            };
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
                                Task.Delay(250).Wait();
                                SendINF(1).Wait();

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
                while (true)
                {
                    if (!ADSClient.Connected)
                    {
                        if (ADSConnected)
                        {
                            Logger?.LogInformation($"Robot ADS {Configuration.ADSEndpoint} - Disconnected from ADS Server");
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
                            Logger?.LogError($"Robot ADS {Configuration.ADSEndpoint} - Unable to Connect to ADS Client - {Exception.Message}");
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

        private bool MappingResponse(string message)
        {
            if (message.Contains(">"))
            {
                if (message.Length == 1)
                {
                    Logger?.LogWarning($"Robot TCP {Configuration.TCPEndpoint} - Unable to Decode Wafer Mapping - No Mapping Sent from Robot");
                    APIOut.Error = 5;
                    APIOut.StartAckNOK = true;
                    APIOut.Done = true;
                }
                else if (message.Length == 26)
                {
                    try
                    {
                        APIOut.Mapping = DecodeMapping(message.Replace(">", ""));
                    }
                    catch (Exception Exception)
                    {
                        Logger?.LogWarning($"Robot TCP {Configuration.TCPEndpoint} - Unable to Decode Wafer Mapping - {Exception.Message}");
                        APIOut.Data = 0;
                        APIOut.Error = 4;
                        APIOut.Done = true;
                    }

                    APIOut.StartAckOK = true;
                    APIOut.Done = true;
                }
                else
                {
                    Logger?.LogWarning($"Robot TCP {Configuration.TCPEndpoint} - Unable to Decode Wafer Mapping - Improper Length {message.Length - 1}");
                    APIOut.Error = 7;
                    APIOut.StartAckNOK = true;
                    APIOut.Done = true;
                }
            }
            else
            {
                Logger?.LogWarning($"Robot TCP {Configuration.TCPEndpoint} - Unable to Decode Wafer Mapping - Robot Returned General Error");
                APIOut.Error = 6;
                APIOut.StartAckNOK = true;
                APIOut.Done = true;
            }

            return false;
        }

        private bool InputResponse(string message)
        {
            if (message.Contains(">"))
            {
                string[] SplitMessage = LastTxMessage.Split(" ");

                if (SplitMessage.Length == 2)
                {
                    APIOut.Data = int.Parse(SplitMessage[1]);
                    APIOut.StartAckOK = true;
                }
                else
                {
                    Logger?.LogWarning($"Robot TCP {Configuration.TCPEndpoint} - Unable to Return Input Status - Improper Response Structure {message}");
                    APIOut.Error = 8;
                    APIOut.StartAckNOK = true;
                }
            }
            else
            {
                Logger?.LogWarning($"Robot TCP {Configuration.TCPEndpoint} - Unable to Return Input Status - Robot Returned Generic Error {message}");
                APIOut.Error = 9;
                APIOut.StartAckNOK = true;
            }

            return false;
        }

        private bool OutputResponse(string message)
        {
            if (message.Contains(">"))
            {
                string[] SplitMessage = message.Split(" ");

                if (SplitMessage.Length == 2)
                {
                    APIOut.Data = int.Parse(message.Replace(">", ""));
                    APIOut.StartAckOK = true;
                }
                else if (SplitMessage.Length == 3)
                {
                    APIOut.Data = int.Parse(SplitMessage[2]);
                    APIOut.StartAckOK = true;
                }
            }
            else
            {
                APIOut.StartAckNOK = true;
            }

            return false;
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

        private bool PositionResponse(string message)
        {
            APIOut.Position = message.Split('>')[1];
            APIOut.Done = true;
            return false;
        }

        private void DecodeStatus(string status)
        {
            BitArray BitArray = Reverse(ConvertHexToBitArray(status));

            APIOut.UnableToMove = BitArray.Get(0);
            APIOut.CommandError = BitArray.Get(1);
            APIOut.VacuumSensor = BitArray.Get(2);
            APIOut.VacuumSwitch = BitArray.Get(3);
            APIOut.MotionError = BitArray.Get(4);
            APIOut.SoftwareLimit = BitArray.Get(5);
            APIOut.NotHomed = BitArray.Get(6);
            APIOut.MacroRunning = BitArray.Get(7);
            APIOut.InMotion = BitArray.Get(8);
            APIOut.ServoOff = BitArray.Get(10);
            APIOut.InTeachMode = BitArray.Get(11);
            APIOut.InSearchMode = BitArray.Get(12);
            APIOut.FileError = BitArray.Get(13);
            APIOut.InTeachScanMode = BitArray.Get(14);
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

        private static byte[] DecodeMapping(string mapping)
        {
            byte[] ByteArray = new byte[25];

            for (int ix = 0; ix < mapping.Length; ix++)
            {
                ByteArray[ix] = byte.Parse(mapping[ix].ToString());
            }

            return ByteArray;
        }

        private static string IntToAxis(int axis)
        {
            return axis switch
            {
                1 => "T",
                2 => "R",
                3 => "Z",
                _ => "",
            };
        }

        private async Task<bool> SendSON(bool status)
        {
            Logger?.LogDebug($"{Configuration.Name} TCP {Configuration.TCPEndpoint} - Trigger Servo Command - Status {status}");

            return status ? await SendMessage("SON") : await SendMessage("SOF");
        }

        private async Task<bool> SendINF(int mode)
        {
            Logger?.LogDebug($"{Configuration.Name} TCP {Configuration.TCPEndpoint} - Trigger Info Mode Command - Mode {mode}");

            return await SendMessage($"INF {mode}");
        }

        private async Task<bool> SendVON(bool vacuum)
        {
            Logger?.LogDebug($"{Configuration.Name} TCP {Configuration.TCPEndpoint} - Trigger Vacuum Command - Status {vacuum}");

            return vacuum ? await SendMessage("VON") : await SendMessage("VOF");
        }

        private async Task<bool> SendOUT(int output)
        {
            Logger?.LogDebug($"{Configuration.Name} TCP {Configuration.TCPEndpoint} - Trigger Output Command - Output {output}");

            return await SendMessage($"OUT {output}");
        }

        private async Task<bool> SendOUT(int output, bool status)
        {
            Logger?.LogDebug($"{Configuration.Name} TCP {Configuration.TCPEndpoint} - Trigger Output Command - Output {output} - Status {status}");

            return await SendMessage($"OUT {output} {Convert.ToInt32(status)}");
        }

        private async Task<bool> SendCSW(int speed)
        {
            Logger?.LogDebug($"{Configuration.Name} TCP {Configuration.TCPEndpoint} - Trigger Speed Command - Speed {speed}");

            return await SendMessage($"CSW {speed}");
        }

        private async Task<bool> SendHOM()
        {
            Logger?.LogDebug($"{Configuration.Name} TCP {Configuration.TCPEndpoint} - Trigger Home Command");

            return await SendMessage("HOM");
        }

        private async Task<bool> SendSCN(string station)
        {
            Logger?.LogDebug($"{Configuration.Name} TCP {Configuration.TCPEndpoint} - Trigger Scan Command - Station {station}");

            return await SendMessage($"SCN {station} 0");
        }

        private async Task<bool> SendMAP()
        {
            Logger?.LogDebug($"{Configuration.Name} TCP {Configuration.TCPEndpoint} - Trigger Mapping Command");

            return await SendMessage("MAP");
        }

        private async Task<bool> SendGET(string station, int slot)
        {
            Logger?.LogDebug($"{Configuration.Name} TCP {Configuration.TCPEndpoint} - Trigger Pick Command - Station {station} - Slot {slot}");

            return await SendMessage($"GET {station} {slot}");
        }

        private async Task<bool> SendPUT(string station, int slot)
        {
            Logger?.LogDebug($"{Configuration.Name} TCP {Configuration.TCPEndpoint} - Trigger Place Command - Station {station} - Slot {slot}");

            return await SendMessage($"PUT {station} {slot}");
        }

        private async Task<bool> SendSTP()
        {
            Logger?.LogDebug($"{Configuration.Name} TCP {Configuration.TCPEndpoint} - Trigger Stop Command");

            return await SendMessage($"STP", true);
        }

        private async Task<bool> SendMTS(string station)
        {
            Logger?.LogDebug($"{Configuration.Name} TCP {Configuration.TCPEndpoint} - Trigger Move Command - Station {station}");

            return await SendMessage($"MTS {station}");
        }

        private async Task<bool> SendMTH()
        {
            Logger?.LogDebug($"{Configuration.Name} TCP {Configuration.TCPEndpoint} - Trigger Move to Home Command");

            return await SendMessage($"MTH");
        }

        private async Task<bool> SendSTA()
        {
            Logger?.LogDebug($"{Configuration.Name} TCP {Configuration.TCPEndpoint} - Trigger Status Command");

            return await SendMessage($"STA");
        }

        private async Task<bool> SendINP(int input)
        {
            Logger?.LogDebug($"{Configuration.Name} TCP {Configuration.TCPEndpoint} - Trigger Input Command - Input {input}");

            return await SendMessage($"INP {input}");
        }

        private async Task<bool> SendMVR(int axis, int amount)
        {
            string Axis = IntToAxis(axis);

            Logger?.LogDebug($"{Configuration.Name} TCP {Configuration.TCPEndpoint} - Trigger Relative Move Command - Axis {Axis} - Amount {amount}");

            return await SendMessage($"MVR {Axis} {amount}");
        }

        private async Task<bool> SendMVA(int axis, int amount)
        {
            string Axis = IntToAxis(axis);

            Logger?.LogDebug($"{Configuration.Name} TCP {Configuration.TCPEndpoint} - Trigger Relative Move Command - Axis {Axis} - Amount {amount}");

            return await SendMessage($"MVA {Axis} {amount}");
        }

        private async Task<bool> SendCPO()
        {
            Logger?.LogDebug($"{Configuration.Name} TCP {Configuration.TCPEndpoint} - Trigger Fetch Current Position");

            return await SendMessage($"CPO");
        }

        private async Task<bool> SendSPO(string station, int axis, int value)
        {
            string Axis = IntToAxis(axis);

            Logger?.LogDebug($"{Configuration.Name} TCP {Configuration.TCPEndpoint} - Trigger Station Axis Set - Station {station} - Axis {Axis} - Value {value}");

            return await SendMessage($"SPO {station} {Axis} {value}");
        }

        private async Task<bool> SendTCH(string station)
        {
            Logger?.LogDebug($"{Configuration.Name} TCP {Configuration.TCPEndpoint} - Trigger Station Teach Mode - Station {station}");

            return await SendMessage($"TCH {station}");
        }

        private async Task<bool> SendEOT()
        {
            Logger?.LogDebug($"{Configuration.Name} TCP {Configuration.TCPEndpoint} - Trigger Station End of Teach");

            return await SendMessage($"EOT");
        }

        private async Task<bool> SendMessage(string message, bool force = false)
        {
            if (TCPClient.Connected)
            {
                if (!Busy || force)
                {
                    try
                    {
                        await TCPClient.WriteLineAsync(message);
                        LastTxMessage = message;
                        Logger?.LogTrace($"Robot TCP {Configuration.TCPEndpoint} Tx {LastTxMessage}");
                        return true;
                    }
                    catch
                    {
                        Logger?.LogError($"TCP {Configuration.TCPEndpoint} - Unable to Send Command {message}");
                        APIOut.Error = 3;
                    }
                }
                else
                {
                    Logger?.LogWarning($"Robot TCP {Configuration.TCPEndpoint} - Robot Busy Unable to Send Command {message}");
                    APIOut.Error = 2;
                }
            }
            else
            {
                Logger?.LogWarning($"Robot TCP {Configuration.TCPEndpoint} - Robot Unable to Send Commad - Client Not Connected");
                APIOut.Error = 1;
            }

            return false;
        }
    }
}