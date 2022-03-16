using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace JR.P262605.API.Laser
{
    public class LaserModel
    {
        private readonly CancellationTokenSource CancellationTokenSource = new();
        private readonly List<ADS.AdsItem> ADSItems;
        private readonly ILogger Logger;
        private readonly LaserConfiguration Configuration;
        private TCP.Client TCPClient { get; set; } = new();
        private ADS.Client ADSClient { get; set; }
        public API.LaserAPIOut APIOut { get; set; } = new(nameof(APIOut));
        public API.LaserAPIIn APIIn { get; set; } = new(nameof(APIIn));
        public bool ADSConnected { get; private set; }

        public LaserModel(ILogger logger, IConfiguration configuration)
        {
            // Set Logger
            Logger = logger;

            // Get Configuration
            Configuration = configuration.GetSection("LaserConfiguration").Get<LaserConfiguration>();

            ADSClient = new(Logger);

            ADSItems = new()
            {
                new(nameof(APIOut.HeartbeatEcho), "Stn10_13_Laser.APIOut.HeartbeatEcho", ADS.AdsConnectionType.WriteOnly, APIOut),
                new(nameof(APIOut.Connected), "Stn10_13_Laser.APIOut.Connected", ADS.AdsConnectionType.WriteOnly, APIOut),
                new(nameof(APIOut.MeasureAck), "Stn10_13_Laser.APIOut.MeasureAck", ADS.AdsConnectionType.WriteOnly, APIOut),
                new(nameof(APIOut.MeasureDone), "Stn10_13_Laser.APIOut.MeasureDone", ADS.AdsConnectionType.WriteOnly, APIOut),
                new(nameof(APIOut.MeasureError), "Stn10_13_Laser.APIOut.MeasureError", ADS.AdsConnectionType.WriteOnly, APIOut),
                new(nameof(APIOut.MeasureValue), "Stn10_13_Laser.APIOut.MeasureValue", ADS.AdsConnectionType.WriteOnly, APIOut),
                new(nameof(APIOut.MarkID), "Stn10_13_Laser.APIOut.MarkID", ADS.AdsConnectionType.WriteOnly, APIOut),
                new(nameof(APIOut.MarkIDSetDone), "Stn10_13_Laser.APIOut.MarkIDSetDone", ADS.AdsConnectionType.WriteOnly, APIOut),
                new(nameof(APIOut.RecipeSetDone), "Stn10_13_Laser.APIOut.RecipeSetDone", ADS.AdsConnectionType.WriteOnly, APIOut),
                new(nameof(APIOut.ProcessStartAck), "Stn10_13_Laser.APIOut.ProcessStartAck", ADS.AdsConnectionType.WriteOnly, APIOut),
                new(nameof(APIOut.ProcessAbortDone), "Stn10_13_Laser.APIOut.ProcessAbortDone", ADS.AdsConnectionType.WriteOnly, APIOut),
                new(nameof(APIOut.ProcessDone), "Stn10_13_Laser.APIOut.ProcessDone", ADS.AdsConnectionType.WriteOnly, APIOut),
                new(nameof(APIOut.ProcessError), "Stn10_13_Laser.APIOut.ProcessError", ADS.AdsConnectionType.WriteOnly, APIOut),
                new(nameof(APIOut.Heartbeat), "Stn10_13_Laser.APIOut.Heartbeat", ADS.AdsConnectionType.WriteOnly, APIOut),
                new(nameof(APIOut.Error), "Stn10_13_Laser.APIOut.Error", ADS.AdsConnectionType.WriteOnly, APIOut),
                new(nameof(APIOut.BeamExpanderMag), "Stn10_13_Laser.APIOut.BeamExpanderMag", ADS.AdsConnectionType.WriteOnly, APIOut),
                new(nameof(APIOut.AttenuatorPower), "Stn10_13_Laser.APIOut.AttenuatorPower", ADS.AdsConnectionType.WriteOnly, APIOut),
                new(nameof(APIOut.SelectedRecipe), "Stn10_13_Laser.APIOut.SelectedRecipe", ADS.AdsConnectionType.WriteOnly, APIOut),
                new(nameof(APIOut.PowerStabActive), "Stn10_13_Laser.APIOut.PowerStabActive", ADS.AdsConnectionType.WriteOnly, APIOut),
                new(nameof(APIOut.BeamShaperActive), "Stn10_13_Laser.APIOut.BeamShaperActive", ADS.AdsConnectionType.WriteOnly, APIOut),
                new(nameof(APIOut.LaserPEC), "Stn10_13_Laser.APIOut.LaserPEC", ADS.AdsConnectionType.WriteOnly, APIOut),
                new(nameof(APIOut.LaserDiodeCurrent), "Stn10_13_Laser.APIOut.LaserDiodeCurrent", ADS.AdsConnectionType.WriteOnly, APIOut),
                new(nameof(APIOut.LaserDiodeVoltage), "Stn10_13_Laser.APIOut.LaserDiodeVoltage", ADS.AdsConnectionType.WriteOnly, APIOut),
                new(nameof(APIOut.LaserDiodeTemp1), "Stn10_13_Laser.APIOut.LaserDiodeTemp1", ADS.AdsConnectionType.WriteOnly, APIOut),
                new(nameof(APIOut.LaserDiodeTemp2), "Stn10_13_Laser.APIOut.LaserDiodeTemp2", ADS.AdsConnectionType.WriteOnly, APIOut),
                new(nameof(APIOut.LaserDiodeTemp3), "Stn10_13_Laser.APIOut.LaserDiodeTemp3", ADS.AdsConnectionType.WriteOnly, APIOut),
                new(nameof(APIOut.LaserSHGTemp), "Stn10_13_Laser.APIOut.LaserSHGTemp", ADS.AdsConnectionType.WriteOnly, APIOut),
                new(nameof(APIOut.LaserTHGTemp), "Stn10_13_Laser.APIOut.LaserTHGTemp", ADS.AdsConnectionType.WriteOnly, APIOut),
                new(nameof(APIOut.LaserInlinePowerRaw), "Stn10_13_Laser.APIOut.LaserInlinePowerRaw", ADS.AdsConnectionType.WriteOnly, APIOut),
                new(nameof(APIOut.LaserInlinePower), "Stn10_13_Laser.APIOut.LaserInlinePower", ADS.AdsConnectionType.WriteOnly, APIOut),
                new(nameof(APIOut.LaserWorkpiecePower), "Stn10_13_Laser.APIOut.LaserWorkpiecePower", ADS.AdsConnectionType.WriteOnly, APIOut),
                new(nameof(APIOut.ScannerPosX), "Stn10_13_Laser.APIOut.ScannerPosX", ADS.AdsConnectionType.WriteOnly, APIOut),
                new(nameof(APIOut.ScannerPosY), "Stn10_13_Laser.APIOut.ScannerPosY", ADS.AdsConnectionType.WriteOnly, APIOut),
                new(nameof(APIOut.ScannerPRF), "Stn10_13_Laser.APIOut.ScannerPRF", ADS.AdsConnectionType.WriteOnly, APIOut),
                new(nameof(APIOut.ScannerMarkSpeed), "Stn10_13_Laser.APIOut.ScannerMarkSpeed", ADS.AdsConnectionType.WriteOnly, APIOut),
                new(nameof(APIOut.ScannerJumpSpeed), "Stn10_13_Laser.APIOut.ScannerJumpSpeed", ADS.AdsConnectionType.WriteOnly, APIOut),
                new(nameof(APIOut.ScannerMarkDelay), "Stn10_13_Laser.APIOut.ScannerMarkDelay", ADS.AdsConnectionType.WriteOnly, APIOut),
                new(nameof(APIOut.ScannerJumpDelay), "Stn10_13_Laser.APIOut.ScannerJumpDelay", ADS.AdsConnectionType.WriteOnly, APIOut),
                new(nameof(APIOut.ScannerPolyDelay), "Stn10_13_Laser.APIOut.ScannerPolyDelay", ADS.AdsConnectionType.WriteOnly, APIOut),
                new(nameof(APIOut.ScannerLaserOnDelay), "Stn10_13_Laser.APIOut.ScannerLaserOnDelay", ADS.AdsConnectionType.WriteOnly, APIOut),
                new(nameof(APIOut.ScannerLaserOffDelay), "Stn10_13_Laser.APIOut.ScannerLaserOffDelay", ADS.AdsConnectionType.WriteOnly, APIOut),
                new(nameof(APIOut.ModuleStatus), "Stn10_13_Laser.APIOut.ModuleStatus", ADS.AdsConnectionType.WriteOnly, APIOut),
                new(nameof(APIOut.ModuleStatusMessage), "Stn10_13_Laser.APIOut.ModuleStatusMessage", ADS.AdsConnectionType.WriteOnly, APIOut),
                new(nameof(APIOut.ModuleReadyToProcess), "Stn10_13_Laser.APIOut.ModuleReadyToProcess", ADS.AdsConnectionType.WriteOnly, APIOut),
                new(nameof(APIOut.PLCFaulted), "Stn10_13_Laser.APIOut.PLCFaulted", ADS.AdsConnectionType.WriteOnly, APIOut),
                new(nameof(APIOut.PLCInitalized), "Stn10_13_Laser.APIOut.PLCInitalized", ADS.AdsConnectionType.WriteOnly, APIOut),
                new(nameof(APIOut.PLCStatusMessage), "Stn10_13_Laser.APIOut.PLCStatusMessage", ADS.AdsConnectionType.WriteOnly, APIOut),
                new(nameof(APIOut.ScannerFaulted), "Stn10_13_Laser.APIOut.ScannerFaulted", ADS.AdsConnectionType.WriteOnly, APIOut),
                new(nameof(APIOut.ScannerInitialized), "Stn10_13_Laser.APIOut.ScannerInitialized", ADS.AdsConnectionType.WriteOnly, APIOut),
                new(nameof(APIOut.ScannerStatusMessage), "Stn10_13_Laser.APIOut.ScannerStatusMessage", ADS.AdsConnectionType.WriteOnly, APIOut),
                new(nameof(APIOut.WeldmarkFaulted), "Stn10_13_Laser.APIOut.WeldmarkFaulted", ADS.AdsConnectionType.WriteOnly, APIOut),
                new(nameof(APIOut.WeldmarkInitialized), "Stn10_13_Laser.APIOut.WeldmarkInitialized", ADS.AdsConnectionType.WriteOnly, APIOut),
                new(nameof(APIOut.WeldmarkStatusMessage), "Stn10_13_Laser.APIOut.WeldmarkStatusMessage", ADS.AdsConnectionType.WriteOnly, APIOut),
                new(nameof(APIOut.LaserFaulted), "Stn10_13_Laser.APIOut.LaserFaulted", ADS.AdsConnectionType.WriteOnly, APIOut),
                new(nameof(APIOut.LaserInitialized), "Stn10_13_Laser.APIOut.LaserInitialized", ADS.AdsConnectionType.WriteOnly, APIOut),
                new(nameof(APIOut.LaserStatusMessage), "Stn10_13_Laser.APIOut.LaserStatusMessage", ADS.AdsConnectionType.WriteOnly, APIOut),
                new(nameof(APIOut.AxisControlFaulted), "Stn10_13_Laser.APIOut.AxisControlFaulted", ADS.AdsConnectionType.WriteOnly, APIOut),
                new(nameof(APIOut.AxisControlInitialized), "Stn10_13_Laser.APIOut.AxisControlInitialized", ADS.AdsConnectionType.WriteOnly, APIOut),
                new(nameof(APIOut.AxisControlStatusMessage), "Stn10_13_Laser.APIOut.AxisControlStatusMessage", ADS.AdsConnectionType.WriteOnly, APIOut),
                new(nameof(APIOut.PowerAttenuatorFaulted), "Stn10_13_Laser.APIOut.PowerAttenuatorFaulted", ADS.AdsConnectionType.WriteOnly, APIOut),
                new(nameof(APIOut.PowerAttenuatorInitialized), "Stn10_13_Laser.APIOut.PowerAttenuatorInitialized", ADS.AdsConnectionType.WriteOnly, APIOut),
                new(nameof(APIOut.PowerAttenuatorStatusMessage), "Stn10_13_Laser.APIOut.PowerAttenuatorStatusMessage", ADS.AdsConnectionType.WriteOnly, APIOut),
                new(nameof(APIOut.BeamExpanderFaulted), "Stn10_13_Laser.APIOut.BeamExpanderFaulted", ADS.AdsConnectionType.WriteOnly, APIOut),
                new(nameof(APIOut.BeamExpanderInitialized), "Stn10_13_Laser.APIOut.BeamExpanderInitialized", ADS.AdsConnectionType.WriteOnly, APIOut),
                new(nameof(APIOut.BeamExpanderStatusMessage), "Stn10_13_Laser.APIOut.BeamExpanderStatusMessage", ADS.AdsConnectionType.WriteOnly, APIOut),
                new(nameof(APIOut.InlinePowerMeterFaulted), "Stn10_13_Laser.APIOut.InlinePowerMeterFaulted", ADS.AdsConnectionType.WriteOnly, APIOut),
                new(nameof(APIOut.InlinePowerMeterInitialized), "Stn10_13_Laser.APIOut.InlinePowerMeterInitialized", ADS.AdsConnectionType.WriteOnly, APIOut),
                new(nameof(APIOut.InlinePowerMeterStatusMessage), "Stn10_13_Laser.APIOut.InlinePowerMeterStatusMessage", ADS.AdsConnectionType.WriteOnly, APIOut),
                new(nameof(APIOut.ProcessPowerMeterFaulted), "Stn10_13_Laser.APIOut.ProcessPowerMeterFaulted", ADS.AdsConnectionType.WriteOnly, APIOut),
                new(nameof(APIOut.ProcessPowerMeterInitialized), "Stn10_13_Laser.APIOut.ProcessPowerMeterInitialized", ADS.AdsConnectionType.WriteOnly, APIOut),
                new(nameof(APIOut.ProcessPowerMeterStatusMessage), "Stn10_13_Laser.APIOut.ProcessPowerMeterStatusMessage", ADS.AdsConnectionType.WriteOnly, APIOut),

                new(nameof(APIIn.Heartbeat), "Stn10_13_Laser.APIIn.Heartbeat", ADS.AdsConnectionType.ReadOnly, APIIn),
                new(nameof(APIIn.MeasureAttenuator), "Stn10_13_Laser.APIIn.MeasureAttenuator", ADS.AdsConnectionType.ReadOnly, APIIn),
                new(nameof(APIIn.MeasurePEC), "Stn10_13_Laser.APIIn.MeasurePEC", ADS.AdsConnectionType.ReadOnly, APIIn),
                new(nameof(APIIn.MeasurePRF), "Stn10_13_Laser.APIIn.MeasurePRF", ADS.AdsConnectionType.ReadOnly, APIIn),
                new(nameof(APIIn.MeasureTarget), "Stn10_13_Laser.APIIn.MeasureTarget", ADS.AdsConnectionType.ReadOnly, APIIn),
                new(nameof(APIIn.MeasureStart), "Stn10_13_Laser.APIIn.MeasureStart", ADS.AdsConnectionType.ReadOnly, APIIn),
                new(nameof(APIIn.ProcessAbort), "Stn10_13_Laser.APIIn.ProcessAbort", ADS.AdsConnectionType.ReadOnly, APIIn),
                new(nameof(APIIn.ProcessStart), "Stn10_13_Laser.APIIn.ProcessStart", ADS.AdsConnectionType.ReadOnly, APIIn),
                new(nameof(APIIn.MarkID), "Stn10_13_Laser.APIIn.MarkID", ADS.AdsConnectionType.ReadOnly, APIIn),
                new(nameof(APIIn.MarkIDSet), "Stn10_13_Laser.APIIn.MarkIDSet", ADS.AdsConnectionType.ReadOnly, APIIn),
                new(nameof(APIIn.RecipePath), "Stn10_13_Laser.APIIn.RecipePath", ADS.AdsConnectionType.ReadOnly, APIIn),
                new(nameof(APIIn.RecipeSet), "Stn10_13_Laser.APIIn.RecipeSet", ADS.AdsConnectionType.ReadOnly, APIIn)
            };

            if (Configuration.Enabled)
            {
                StartADSClientMonitor();
                StartTCPClientMonitor();
                StartTCPHeartbeat();
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
                    if (e.PropertyName != nameof(APIOut.HeartbeatEcho))
                    {
                        Logger?.LogTrace($"{Configuration.Name} PLC Write - {AdsTag.Name}.{e.PropertyName} = {e.Value}");
                    }

                    ADSClient.Write($"{AdsTag.Name}.{e.PropertyName}", e.Value);
                }
                catch (Exception Exception)
                {
                    Logger?.LogError($"{Configuration.Name} ADS - Unable to write to symbol {e.PropertyName} = {e.Value} - Error {Exception.Message}");
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

                    if (!APIIn.ProcessStart)
                    {
                        APIOut.ProcessStartAck = false;
                        APIOut.ProcessError = "";
                        APIOut.ProcessDone = false;
                    }

                    if (!APIIn.ProcessAbort)
                    {
                        APIOut.ProcessAbortDone = false;
                    }

                    if (!APIIn.MarkIDSet)
                    {
                        APIOut.MarkID = " ";
                        APIOut.MarkIDSetDone = false;
                    }

                    if (!APIIn.RecipeSet)
                    {
                        APIOut.RecipeSetDone = false;
                    }

                    if (!APIIn.MeasureStart)
                    {
                        APIOut.MeasureAck = false;
                        APIOut.MeasureDone = false;
                        APIOut.MeasureError = "";
                        APIOut.MeasureValue = 0.0;
                    }
                }

                // Start Process Trigger
                if (e.PropertyName == nameof(APIIn.ProcessStart))
                {
                    if (APIIn.ProcessStart)
                    {
                        Logger?.LogDebug($"{Configuration.Name} TCP {Configuration.TCPEndpoint} - Trigger Process Start");

                        SendStartProcess();
                    }
                    else
                    {
                        APIOut.ProcessStartAck = false;
                        APIOut.ProcessError = "";
                        APIOut.ProcessDone = false;
                    }
                }

                // Abort Process Trigger
                if (e.PropertyName == nameof(APIIn.ProcessAbort))
                {
                    if (APIIn.ProcessAbort)
                    {
                        Logger?.LogDebug($"{Configuration.Name} TCP {Configuration.TCPEndpoint} - Trigger Process Abort");

                        SendAbortProcess();
                    }
                    else
                    {
                        APIOut.ProcessAbortDone = false;
                    }
                }

                // Set Mark ID Trigger
                if (e.PropertyName == nameof(APIIn.MarkIDSet))
                {
                    if (APIIn.MarkIDSet)
                    {
                        _ = ADSClient.Read($"{APIIn.Name}.{nameof(APIIn.MarkID)}");

                        Logger?.LogDebug($"{Configuration.Name} TCP {Configuration.TCPEndpoint} - Trigger Mark ID Set - Scribe ID {APIIn.MarkID}");

                        SendScribeID(APIIn.MarkID);
                    }
                    else
                    {
                        APIOut.MarkIDSetDone = false;
                        APIOut.MarkID = " ";
                    }
                }

                // Set Recipe Trigger
                if (e.PropertyName == nameof(APIIn.RecipeSet))
                {
                    if (APIIn.RecipeSet)
                    {
                        _ = ADSClient.Read($"{APIIn.Name}.{nameof(APIIn.RecipePath)}");

                        Logger?.LogDebug($"{Configuration.Name} TCP {Configuration.TCPEndpoint} - Trigger Recipe Set - Recipe Path {APIIn.RecipePath}");

                        SendSetRecipe(APIIn.RecipePath);
                    }
                    else
                    {
                        APIOut.RecipeSetDone = false;
                    }
                }

                // Measure Power Trigger
                if (e.PropertyName == nameof(APIIn.MeasureStart))
                {
                    if (APIIn.MeasureStart)
                    {
                        _ = ADSClient.Read($"{APIIn.Name}.{nameof(APIIn.MeasurePEC)}");
                        _ = ADSClient.Read($"{APIIn.Name}.{nameof(APIIn.MeasurePRF)}");
                        _ = ADSClient.Read($"{APIIn.Name}.{nameof(APIIn.MeasureAttenuator)}");
                        _ = ADSClient.Read($"{APIIn.Name}.{nameof(APIIn.MeasureTarget)}");

                        Logger?.LogDebug($"{Configuration.Name} TCP {Configuration.TCPEndpoint} - Trigger Measure Start - PEC {APIIn.MeasurePEC} - PRF {APIIn.MeasurePRF} - ATT {APIIn.MeasureAttenuator} - Target {APIIn.MeasureTarget}");

                        if (APIIn.MeasurePEC > 0 || APIIn.MeasurePRF > 0 || APIIn.MeasureAttenuator > 0)
                        {
                            SendMeasureStart(APIIn.MeasurePEC, APIIn.MeasurePRF, APIIn.MeasureAttenuator, APIIn.MeasureTarget);
                        }
                        else
                        {
                            SendMeasureStart();
                        }
                    }
                    else
                    {
                        APIOut.MeasureAck = false;
                        APIOut.MeasureDone = false;
                        APIOut.MeasureError = "";
                        APIOut.MeasureValue = 0.0;
                    }
                }
            }
        }

        private void TCPClient_DelimiterDataReceived(object sender, TCP.Message e)
        {
            string MessageString = e.MessageString.Replace("\u0003", "");
            Logger?.LogTrace($"{Configuration.Name} TCP {Configuration.TCPEndpoint} Rx {MessageString}");
            OPK.Message Message = OPK.Message.Deserialize(MessageString);

            if (Message.AbortComplete is not null)
            {
                Logger?.LogDebug($"{Configuration.Name} TCP {Configuration.TCPEndpoint} - Abort Complete");

                APIOut.ProcessAbortDone = true;
            }

            if (Message.Error is not null)
            {
                Logger?.LogDebug($"{Configuration.Name} TCP {Configuration.TCPEndpoint} - Error {Message.Error.Message}");

                APIOut.Error = Message.Error.Message;
            }

            if (Message.MeasureAck is not null)
            {
                Logger?.LogDebug($"{Configuration.Name} TCP {Configuration.TCPEndpoint} - Measure Acknowledge");

                APIOut.MeasureAck = true;
            }

            if (Message.MeasureComplete is not null)
            {
                Logger?.LogDebug($"{Configuration.Name} TCP {Configuration.TCPEndpoint} - Measure Complete - Power {Message.MeasureComplete.Power} - Error {Message.MeasureComplete.Error}");

                APIOut.MeasureError = Message.MeasureComplete.Error;
                APIOut.MeasureValue = Message.MeasureComplete.Power;
                APIOut.MeasureDone = true;
            }

            if (Message.ProcessAck is not null)
            {
                Logger?.LogDebug($"{Configuration.Name} TCP {Configuration.TCPEndpoint} - Process Acknowledge");

                APIOut.ProcessStartAck = true;
            }

            if (Message.ProcessComplete is not null)
            {
                Logger?.LogDebug($"{Configuration.Name} TCP {Configuration.TCPEndpoint} - Process Complete - Error {Message.ProcessComplete.Error}");

                APIOut.ProcessError = Message.ProcessComplete.Error;
                APIOut.ProcessDone = true;
            }

            if (Message.MarkIDSet is not null)
            {
                Logger?.LogDebug($"{Configuration.Name} TCP {Configuration.TCPEndpoint} - Mark ID Set - Sribe ID {Message.MarkIDSet.ID}");

                APIOut.MarkID = Message.MarkIDSet.ID;
                APIOut.MarkIDSetDone = true;
            }

            if (Message.RecipeSet is not null)
            {
                Logger?.LogDebug($"{Configuration.Name} TCP {Configuration.TCPEndpoint} - Recipe Set Response - Recipe Path {Message.RecipeSet.RecipePath}");

                APIOut.SelectedRecipe = Message.RecipeSet.RecipePath;
                APIOut.RecipeSetDone = true;
            }

            if (Message.StatusResponse is not null)
            {
                Logger?.LogDebug($"{Configuration.Name} TCP {Configuration.TCPEndpoint} - Status Response");

                Task.Run(() =>
                {
                    APIOut.AttenuatorPower = Message.StatusResponse.AttenuatorPower ?? 0;
                    APIOut.AxisControlFaulted = Message.StatusResponse.AxisControlFaulted;
                    APIOut.AxisControlInitialized = Message.StatusResponse.AxisControlInitialized;
                    APIOut.AxisControlStatusMessage = Message.StatusResponse.AxisControlStatusMessage;
                    APIOut.BeamExpanderFaulted = Message.StatusResponse.BeamExpanderFaulted;
                    APIOut.BeamExpanderInitialized = Message.StatusResponse.BeamExpanderInitialized;
                    APIOut.BeamExpanderMag = Message.StatusResponse.BeamExpanderMag ?? 0;
                    APIOut.BeamExpanderStatusMessage = Message.StatusResponse.BeamExpanderStatusMessage;
                    APIOut.BeamShaperActive = Message.StatusResponse.BeamShaperActive ?? false;
                    APIOut.Heartbeat = Message.StatusResponse.Heartbeat;
                    APIOut.InlinePowerMeterFaulted = Message.StatusResponse.InlinePowerMeterFaulted;
                    APIOut.InlinePowerMeterInitialized = Message.StatusResponse.InlinePowerMeterInitialized;
                    APIOut.InlinePowerMeterStatusMessage = Message.StatusResponse.InlinePowerMeterStatusMessage;
                    APIOut.LaserDiodeCurrent = Message.StatusResponse.LaserDiodeCurrent ?? 0;
                    APIOut.LaserDiodeTemp1 = Message.StatusResponse.LaserDiodeTemp1 ?? 0;
                    APIOut.LaserDiodeTemp2 = Message.StatusResponse.LaserDiodeTemp2 ?? 0;
                    APIOut.LaserDiodeTemp3 = Message.StatusResponse.LaserDiodeTemp3 ?? 0;
                    APIOut.LaserDiodeVoltage = Message.StatusResponse.LaserDiodeVoltage ?? 0;
                    APIOut.LaserFaulted = Message.StatusResponse.LaserFaulted;
                    APIOut.LaserInitialized = Message.StatusResponse.LaserInitialized;
                    APIOut.LaserStatusMessage = Message.StatusResponse.LaserStatusMessage;
                    APIOut.LaserInlinePower = Message.StatusResponse.LaserInlinePower ?? 0;
                    APIOut.LaserInlinePowerRaw = Message.StatusResponse.LaserInlinePowerRaw ?? 0;
                    APIOut.LaserPEC = Message.StatusResponse.LaserPEC ?? 0;

                    APIOut.LaserSHGTemp = Message.StatusResponse.LaserSHGTemp ?? 0;
                    APIOut.LaserTHGTemp = Message.StatusResponse.LaserTHGTemp ?? 0;
                    APIOut.LaserWorkpiecePower = Message.StatusResponse.LaserWorkpiecePower ?? 0;
                    APIOut.ModuleReadyToProcess = Message.StatusResponse.ModuleReadyToProcess;
                    APIOut.ModuleStatus = Message.StatusResponse.ModuleStatus;
                    APIOut.ModuleStatusMessage = Message.StatusResponse.ModuleStatusMessage;

                    APIOut.PLCFaulted = Message.StatusResponse.PLCFaulted;
                    APIOut.PLCInitalized = Message.StatusResponse.PLCInitialized;
                    APIOut.PLCStatusMessage = Message.StatusResponse.PLCStatusMessage;
                    APIOut.PowerAttenuatorFaulted = Message.StatusResponse.PowerAttenuatorFaulted;
                    APIOut.PowerAttenuatorInitialized = Message.StatusResponse.PowerAttenuatorInitialized;
                    APIOut.PowerAttenuatorStatusMessage = Message.StatusResponse.PowerAttenuatorStatusMessage;
                    APIOut.PowerStabActive = Message.StatusResponse.PowerStabActive;
                    APIOut.ProcessPowerMeterFaulted = Message.StatusResponse.ProcessPowerMeterFaulted;
                    APIOut.ProcessPowerMeterInitialized = Message.StatusResponse.ProcessPowerMeterInitialized;
                    APIOut.ProcessPowerMeterStatusMessage = Message.StatusResponse.ProcessPowerMeterStatusMessage;
                    APIOut.ScannerFaulted = Message.StatusResponse.ScannerFaulted;
                    APIOut.ScannerInitialized = Message.StatusResponse.ScannerInitialized;
                    APIOut.ScannerStatusMessage = Message.StatusResponse.ScannerStatusMessage;
                    APIOut.ScannerJumpDelay = Message.StatusResponse.ScannerJumpDelay ?? 0;
                    APIOut.ScannerJumpSpeed = Message.StatusResponse.ScannerJumpSpeed ?? 0;
                    APIOut.ScannerLaserOffDelay = Message.StatusResponse.ScannerLaserOffDelay ?? 0;
                    APIOut.ScannerLaserOnDelay = Message.StatusResponse.ScannerLaserOnDelay ?? 0;
                    APIOut.ScannerMarkDelay = Message.StatusResponse.ScannerMarkDelay ?? 0;
                    APIOut.ScannerMarkSpeed = Message.StatusResponse.ScannerMarkSpeed ?? 0;
                    APIOut.ScannerPolyDelay = Message.StatusResponse.ScannerPolyDelay ?? 0;
                    APIOut.ScannerPosX = Message.StatusResponse.ScannerPosX ?? 0;
                    APIOut.ScannerPosY = Message.StatusResponse.ScannerPosY ?? 0;
                    APIOut.ScannerPRF = Message.StatusResponse.ScannerPRF ?? 0;
                    APIOut.SelectedRecipe = Message.StatusResponse.SelectedRecipe;
                    APIOut.WeldmarkFaulted = Message.StatusResponse.WeldmarkFaulted;
                    APIOut.WeldmarkInitialized = Message.StatusResponse.WeldmarkInitialized;
                    APIOut.WeldmarkStatusMessage = Message.StatusResponse.WelmarkStatusMessage;
                });
            }
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
                            TCPClient.Delimiter = (byte)'\u0003';
                            TCPClient.DelimiterDataReceived += TCPClient_DelimiterDataReceived;

                            try
                            {
                                Logger?.LogInformation($"{Configuration.Name} TCP {Configuration.TCPEndpoint} - Attempting to Connect TCP Client...");
                                TCPClient.Connect(Address[0], int.Parse(Address[1]));

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

        private void StartTCPHeartbeat()
        {
            bool Heartbeat = false;

            _ = Task.Run(async () =>
            {
                while (true)
                {
                    Heartbeat = !Heartbeat;

                    try
                    {
                        if (TCPClient.Connected && ADSConnected)
                        {
                            SendStatusRequest(Heartbeat);
                        }
                    }
                    catch (Exception Exception)
                    {
                        Logger?.LogError($"{Configuration.Name} TCP {Configuration.TCPEndpoint} - Unable to Send Status Request - {Exception.Message}");
                    }

                    await Task.Delay(500);
                }
            }, CancellationTokenSource.Token);
        }

        public void SendStatusRequest(bool heartbeat)
        {
            JRA.Message Message = new()
            {
                StatusRequest = new()
                {
                    Heartbeat = heartbeat
                }
            };

            SendMessage(JRA.Message.Serialize(Message));
        }

        public void SendSetRecipe(string recipePath)
        {
            JRA.Message Message = new()
            {
                SetRecipe = new()
                {
                    RecipePath = recipePath
                }
            };

            SendMessage(JRA.Message.Serialize(Message));
        }

        public void SendStartProcess()
        {
            JRA.Message Message = new()
            {
                StartProcess = new()
            };

            SendMessage(JRA.Message.Serialize(Message));
        }

        public void SendAbortProcess()
        {
            JRA.Message Message = new()
            {
                AbortProcess = new()
            };

            SendMessage(JRA.Message.Serialize(Message));
        }

        public void SendMeasureStart(double pec, int prf, double attenuator, double target)
        {
            JRA.Message Message = new()
            {
                MeasureStart = new()
                {
                    PEC = pec,
                    PRF = prf,
                    Attenuator = attenuator,
                    Target = target
                }
            };

            SendMessage(JRA.Message.Serialize(Message));
        }

        public void SendMeasureStart()
        {
            JRA.Message Message = new()
            {
                MeasureStart = new()
            };

            SendMessage(JRA.Message.Serialize(Message));
        }

        public void SendScribeID(string id)
        {
            JRA.Message Message = new()
            {
                MarkIDSet = new()
                {
                    ID = id
                }
            };

            SendMessage(JRA.Message.Serialize(Message));
        }

        private void SendMessage(string message)
        {
            try
            {
                TCPClient.WriteLine(message);
                Logger?.LogTrace($"{Configuration.Name} TCP {Configuration.TCPEndpoint} Tx {message}");

            }
            catch (Exception Exception)
            {
                Logger?.LogError($"Laser - {Exception.Message}");
            }
        }
    }
}