using Workstation.ServiceModel.Ua;

namespace JR.P262605.HMI.UI.TypeLibrary
{
    [DataTypeId("ns=4;s=LaserAPIOut")]
    [BinaryEncodingId("nsu=urn:BeckhoffAutomation:Ua:PLC1;s=<StructuredDataType>:LaserAPIOut__DefaultBinary")]
    public class LaserAPIOut : IEncodable
    {
        public int HeartbeatEcho { get; set; } = 0;
        public bool Connected { get; set; } = false;
        public bool MeasureAck { get; set; } = false;
        public bool MeasureDone { get; set; } = false;
        public string MeasureError { get; set; } = string.Empty;
        public double MeasureValue { get; set; } = 0.0;
        public bool MarkIDSetDone { get; set; } = false;
        public bool RecipeSetDone { get; set; } = false;
        public bool ProcessStartAck { get; set; } = false;
        public bool ProcessAbortDone { get; set; } = false;
        public bool ProcessDone { get; set; } = false;
        public string ProcessError { get; set; } = string.Empty;
        public bool Heartbeat { get; set; } = false;
        public string Error { get; set; } = string.Empty;
        public string SelectedRecipe { get; set; } = string.Empty;
        public string MarkID { get; set; } = string.Empty;
        public double LaserPEC { get; set; } = 0.0;
        public double LaserDiodeCurrent { get; set; } = 0.0;
        public double LaserDiodeVoltage { get; set; } = 0.0;
        public double LaserDiodeTemp1 { get; set; } = 0.0;
        public double LaserDiodeTemp2 { get; set; } = 0.0;
        public double LaserDiodeTemp3 { get; set; } = 0.0;
        public double LaserSHGTemp { get; set; } = 0.0;
        public double LaserTHGTemp { get; set; } = 0.0;
        public double BeamExpanderMag { get; set; } = 0.0;
        public double AttenuatorPower { get; set; } = 0.0;
        public double ScannerPosX { get; set; } = 0.0;
        public double ScannerPosY { get; set; } = 0.0;
        public int ScannerPRF { get; set; } = 0;
        public double ScannerMarkSpeed { get; set; } = 0.0;
        public double ScannerJumpSpeed { get; set; } = 0.0;
        public double ScannerMarkDelay { get; set; } = 0.0;
        public double ScannerJumpDelay { get; set; } = 0.0;
        public double ScannerPolyDelay { get; set; } = 0.0;
        public double ScannerLaserOnDelay { get; set; } = 0.0;
        public double ScannerLaserOffDelay { get; set; } = 0.0;
        public double LaserInlinePowerRaw { get; set; } = 0.0;
        public double LaserInlinePower { get; set; } = 0.0;
        public double LaserWorkpiecePower { get; set; } = 0.0;
        public bool PowerStabActive { get; set; } = false;
        public bool BeamShaperActive { get; set; } = false;
        public int ModuleStatus { get; set; } = 0;
        public string ModuleStatusMessage { get; set; } = string.Empty;
        public bool ModuleReadyToProcess { get; set; } = false;
        public bool PLCFaulted { get; set; } = false;
        public bool PLCInitalized { get; set; } = false;
        public string PLCStatusMessage { get; set; } = string.Empty;
        public bool ScannerFaulted { get; set; } = false;
        public bool ScannerInitialized { get; set; } = false;
        public string ScannerStatusMessage { get; set; } = string.Empty;
        public bool WeldmarkFaulted { get; set; } = false;
        public bool WeldmarkInitialized { get; set; } = false;
        public string WeldmarkStatusMessage { get; set; } = string.Empty;
        public bool LaserFaulted { get; set; } = false;
        public bool LaserInitialized { get; set; } = false;
        public string LaserStatusMessage { get; set; } = string.Empty;
        public bool AxisControlFaulted { get; set; } = false;
        public bool AxisControlInitialized { get; set; } = false;
        public string AxisControlStatusMessage { get; set; } = string.Empty;
        public bool PowerAttenuatorFaulted { get; set; } = false;
        public bool PowerAttenuatorInitialized { get; set; } = false;
        public string PowerAttenuatorStatusMessage { get; set; } = string.Empty;
        public bool BeamExpanderFaulted { get; set; } = false;
        public bool BeamExpanderInitialized { get; set; } = false;
        public string BeamExpanderStatusMessage { get; set; } = string.Empty;
        public bool InlinePowerMeterFaulted { get; set; } = false;
        public bool InlinePowerMeterInitialized { get; set; } = false;
        public string InlinePowerMeterStatusMessage { get; set; } = string.Empty;
        public bool ProcessPowerMeterFaulted { get; set; } = false;
        public bool ProcessPowerMeterInitialized { get; set; } = false;
        public string ProcessPowerMeterStatusMessage { get; set; } = string.Empty;
        public bool MarkIDSetAck { get; set; } = false;
        public bool RecipeSetAck { get; set; } = false;
        public bool ProcessAbortAck { get; set; } = false;

        public void Encode(IEncoder encoder)
        {
            encoder.WriteInt32(nameof(HeartbeatEcho), HeartbeatEcho);
            encoder.WriteBoolean(nameof(Connected), Connected);

            encoder.WriteBoolean(nameof(MeasureAck), MeasureAck);
            encoder.WriteBoolean(nameof(MeasureDone), MeasureDone);
            encoder.WriteString(nameof(MeasureError), MeasureError);

            encoder.WriteBoolean(nameof(MarkIDSetAck), MarkIDSetAck);
            encoder.WriteBoolean(nameof(MarkIDSetDone), MarkIDSetDone);

            encoder.WriteBoolean(nameof(RecipeSetAck), RecipeSetAck);
            encoder.WriteBoolean(nameof(RecipeSetDone), RecipeSetDone);

            encoder.WriteBoolean(nameof(ProcessStartAck), ProcessStartAck);
            encoder.WriteBoolean(nameof(ProcessDone), ProcessDone);
            encoder.WriteBoolean(nameof(ProcessAbortAck), ProcessAbortAck);
            encoder.WriteBoolean(nameof(ProcessAbortDone), ProcessAbortDone);
            encoder.WriteString(nameof(ProcessError), ProcessError);

            encoder.WriteBoolean(nameof(Heartbeat), Heartbeat);
            encoder.WriteString(nameof(Error), Error);
            encoder.WriteString(nameof(SelectedRecipe), SelectedRecipe);
            encoder.WriteString(nameof(MarkID), MarkID);
            encoder.WriteDouble(nameof(MeasureValue), MeasureValue);
            encoder.WriteDouble(nameof(BeamExpanderMag), BeamExpanderMag);
            encoder.WriteDouble(nameof(AttenuatorPower), AttenuatorPower);
            encoder.WriteBoolean(nameof(PowerStabActive), PowerStabActive);
            encoder.WriteBoolean(nameof(BeamShaperActive), BeamShaperActive);

            encoder.WriteDouble(nameof(LaserPEC), LaserPEC);
            encoder.WriteDouble(nameof(LaserDiodeCurrent), LaserDiodeCurrent);
            encoder.WriteDouble(nameof(LaserDiodeVoltage), LaserDiodeVoltage);
            encoder.WriteDouble(nameof(LaserDiodeTemp1), LaserDiodeTemp1);
            encoder.WriteDouble(nameof(LaserDiodeTemp2), LaserDiodeTemp2);
            encoder.WriteDouble(nameof(LaserDiodeTemp3), LaserDiodeTemp3);
            encoder.WriteDouble(nameof(LaserSHGTemp), LaserSHGTemp);
            encoder.WriteDouble(nameof(LaserTHGTemp), LaserTHGTemp);
            encoder.WriteDouble(nameof(LaserInlinePowerRaw), LaserInlinePowerRaw);
            encoder.WriteDouble(nameof(LaserInlinePower), LaserInlinePower);
            encoder.WriteDouble(nameof(LaserWorkpiecePower), LaserWorkpiecePower);

            encoder.WriteDouble(nameof(ScannerPosX), ScannerPosX);
            encoder.WriteDouble(nameof(ScannerPosY), ScannerPosY);
            encoder.WriteInt32(nameof(ScannerPRF), ScannerPRF);
            encoder.WriteDouble(nameof(ScannerMarkSpeed), ScannerMarkSpeed);
            encoder.WriteDouble(nameof(ScannerJumpSpeed), ScannerJumpSpeed);
            encoder.WriteDouble(nameof(ScannerMarkDelay), ScannerMarkDelay);
            encoder.WriteDouble(nameof(ScannerJumpDelay), ScannerJumpDelay);
            encoder.WriteDouble(nameof(ScannerPolyDelay), ScannerPolyDelay);
            encoder.WriteDouble(nameof(ScannerLaserOnDelay), ScannerLaserOnDelay);
            encoder.WriteDouble(nameof(ScannerLaserOffDelay), ScannerLaserOffDelay);

            encoder.WriteInt32(nameof(ModuleStatus), ModuleStatus);
            encoder.WriteString(nameof(ModuleStatusMessage), ModuleStatusMessage);
            encoder.WriteBoolean(nameof(ModuleReadyToProcess), ModuleReadyToProcess);

            encoder.WriteBoolean(nameof(PLCFaulted), PLCFaulted);
            encoder.WriteBoolean(nameof(PLCInitalized), PLCInitalized);
            encoder.WriteString(nameof(PLCStatusMessage), PLCStatusMessage);

            encoder.WriteBoolean(nameof(ScannerFaulted), ScannerFaulted);
            encoder.WriteBoolean(nameof(ScannerInitialized), ScannerInitialized);
            encoder.WriteString(nameof(ScannerStatusMessage), ScannerStatusMessage);

            encoder.WriteBoolean(nameof(WeldmarkFaulted), WeldmarkFaulted);
            encoder.WriteBoolean(nameof(WeldmarkInitialized), WeldmarkInitialized);
            encoder.WriteString(nameof(WeldmarkStatusMessage), WeldmarkStatusMessage);

            encoder.WriteBoolean(nameof(LaserFaulted), LaserFaulted);
            encoder.WriteBoolean(nameof(LaserInitialized), LaserInitialized);
            encoder.WriteString(nameof(LaserStatusMessage), LaserStatusMessage);

            encoder.WriteBoolean(nameof(AxisControlFaulted), AxisControlFaulted);
            encoder.WriteBoolean(nameof(AxisControlInitialized), AxisControlInitialized);
            encoder.WriteString(nameof(AxisControlStatusMessage), AxisControlStatusMessage);

            encoder.WriteBoolean(nameof(PowerAttenuatorFaulted), PowerAttenuatorFaulted);
            encoder.WriteBoolean(nameof(PowerAttenuatorInitialized), PowerAttenuatorInitialized);
            encoder.WriteString(nameof(PowerAttenuatorStatusMessage), PowerAttenuatorStatusMessage);

            encoder.WriteBoolean(nameof(BeamExpanderFaulted), BeamExpanderFaulted);
            encoder.WriteBoolean(nameof(BeamExpanderInitialized), BeamExpanderInitialized);
            encoder.WriteString(nameof(BeamExpanderStatusMessage), BeamExpanderStatusMessage);

            encoder.WriteBoolean(nameof(InlinePowerMeterFaulted), InlinePowerMeterFaulted);
            encoder.WriteBoolean(nameof(InlinePowerMeterInitialized), InlinePowerMeterInitialized);
            encoder.WriteString(nameof(InlinePowerMeterStatusMessage), InlinePowerMeterStatusMessage);

            encoder.WriteBoolean(nameof(ProcessPowerMeterFaulted), ProcessPowerMeterFaulted);
            encoder.WriteBoolean(nameof(ProcessPowerMeterInitialized), ProcessPowerMeterInitialized);
            encoder.WriteString(nameof(ProcessPowerMeterStatusMessage), ProcessPowerMeterStatusMessage);
        }

        public void Decode(IDecoder decoder)
        {
            HeartbeatEcho = decoder.ReadInt32(nameof(HeartbeatEcho));
            Connected = decoder.ReadBoolean(nameof(Connected));


            MeasureAck = decoder.ReadBoolean(nameof(MeasureAck));
            MeasureDone = decoder.ReadBoolean(nameof(MeasureDone));
            MeasureError = decoder.ReadString(nameof(MeasureError));

            MarkIDSetAck = decoder.ReadBoolean(nameof(MarkIDSetAck));
            MarkIDSetDone = decoder.ReadBoolean(nameof(MarkIDSetDone));

            RecipeSetAck = decoder.ReadBoolean(nameof(RecipeSetAck));
            RecipeSetDone = decoder.ReadBoolean(nameof(RecipeSetDone));

            ProcessStartAck = decoder.ReadBoolean(nameof(ProcessStartAck));
            ProcessDone = decoder.ReadBoolean(nameof(ProcessDone));
            ProcessAbortAck = decoder.ReadBoolean(nameof(ProcessAbortAck));
            ProcessAbortDone = decoder.ReadBoolean(nameof(ProcessAbortDone));
            ProcessError = decoder.ReadString(nameof(ProcessError));

            Heartbeat = decoder.ReadBoolean(nameof(Heartbeat));
            Error = decoder.ReadString(nameof(Error));
            SelectedRecipe = decoder.ReadString(nameof(SelectedRecipe));
            MarkID = decoder.ReadString(nameof(MarkID));
            MeasureValue = decoder.ReadDouble(nameof(MeasureValue));
            BeamExpanderMag = decoder.ReadDouble(nameof(BeamExpanderMag));
            AttenuatorPower = decoder.ReadDouble(nameof(AttenuatorPower));
            PowerStabActive = decoder.ReadBoolean(nameof(PowerStabActive));
            BeamShaperActive = decoder.ReadBoolean(nameof(BeamShaperActive));


            LaserPEC = decoder.ReadDouble(nameof(LaserPEC));
            LaserDiodeCurrent = decoder.ReadDouble(nameof(LaserDiodeCurrent));
            LaserDiodeVoltage = decoder.ReadDouble(nameof(LaserDiodeVoltage));
            LaserDiodeTemp1 = decoder.ReadDouble(nameof(LaserDiodeTemp1));
            LaserDiodeTemp2 = decoder.ReadDouble(nameof(LaserDiodeTemp2));
            LaserDiodeTemp3 = decoder.ReadDouble(nameof(LaserDiodeTemp3));
            LaserSHGTemp = decoder.ReadDouble(nameof(LaserSHGTemp));
            LaserTHGTemp = decoder.ReadDouble(nameof(LaserTHGTemp));
            LaserInlinePowerRaw = decoder.ReadDouble(nameof(LaserInlinePowerRaw));
            LaserInlinePower = decoder.ReadDouble(nameof(LaserInlinePower));
            LaserWorkpiecePower = decoder.ReadDouble(nameof(LaserWorkpiecePower));


            ScannerPosX = decoder.ReadDouble(nameof(ScannerPosX));
            ScannerPosY = decoder.ReadDouble(nameof(ScannerPosY));
            ScannerPRF = decoder.ReadInt32(nameof(ScannerPRF));
            ScannerMarkSpeed = decoder.ReadDouble(nameof(ScannerMarkSpeed));
            ScannerJumpSpeed = decoder.ReadDouble(nameof(ScannerJumpSpeed));
            ScannerMarkDelay = decoder.ReadDouble(nameof(ScannerMarkDelay));
            ScannerJumpDelay = decoder.ReadDouble(nameof(ScannerJumpDelay));
            ScannerPolyDelay = decoder.ReadDouble(nameof(ScannerPolyDelay));
            ScannerLaserOnDelay = decoder.ReadDouble(nameof(ScannerLaserOnDelay));
            ScannerLaserOffDelay = decoder.ReadDouble(nameof(ScannerLaserOffDelay));

            ModuleStatus = decoder.ReadInt32(nameof(ModuleStatus));
            ModuleStatusMessage = decoder.ReadString(nameof(ModuleStatusMessage));
            ModuleReadyToProcess = decoder.ReadBoolean(nameof(ModuleReadyToProcess));

            PLCFaulted = decoder.ReadBoolean(nameof(PLCFaulted));
            PLCInitalized = decoder.ReadBoolean(nameof(PLCInitalized));
            PLCStatusMessage = decoder.ReadString(nameof(PLCStatusMessage));

            ScannerFaulted = decoder.ReadBoolean(nameof(ScannerFaulted));
            ScannerInitialized = decoder.ReadBoolean(nameof(ScannerInitialized));
            ScannerStatusMessage = decoder.ReadString(nameof(ScannerStatusMessage));

            WeldmarkFaulted = decoder.ReadBoolean(nameof(WeldmarkFaulted));
            WeldmarkInitialized = decoder.ReadBoolean(nameof(WeldmarkInitialized));
            WeldmarkStatusMessage = decoder.ReadString(nameof(WeldmarkStatusMessage));

            LaserFaulted = decoder.ReadBoolean(nameof(LaserFaulted));
            LaserInitialized = decoder.ReadBoolean(nameof(LaserInitialized));
            LaserStatusMessage = decoder.ReadString(nameof(LaserStatusMessage));

            AxisControlFaulted = decoder.ReadBoolean(nameof(AxisControlFaulted));
            AxisControlInitialized = decoder.ReadBoolean(nameof(AxisControlInitialized));
            AxisControlStatusMessage = decoder.ReadString(nameof(AxisControlStatusMessage));

            PowerAttenuatorFaulted = decoder.ReadBoolean(nameof(PowerAttenuatorFaulted));
            PowerAttenuatorInitialized = decoder.ReadBoolean(nameof(PowerAttenuatorInitialized));
            PowerAttenuatorStatusMessage = decoder.ReadString(nameof(PowerAttenuatorStatusMessage));

            BeamExpanderFaulted = decoder.ReadBoolean(nameof(BeamExpanderFaulted));
            BeamExpanderInitialized = decoder.ReadBoolean(nameof(BeamExpanderInitialized));
            BeamExpanderStatusMessage = decoder.ReadString(nameof(BeamExpanderStatusMessage));

            InlinePowerMeterFaulted = decoder.ReadBoolean(nameof(InlinePowerMeterFaulted));
            InlinePowerMeterInitialized = decoder.ReadBoolean(nameof(InlinePowerMeterInitialized));
            InlinePowerMeterStatusMessage = decoder.ReadString(nameof(InlinePowerMeterStatusMessage));

            ProcessPowerMeterFaulted = decoder.ReadBoolean(nameof(ProcessPowerMeterFaulted));
            ProcessPowerMeterInitialized = decoder.ReadBoolean(nameof(ProcessPowerMeterInitialized));
            ProcessPowerMeterStatusMessage = decoder.ReadString(nameof(ProcessPowerMeterStatusMessage));
        }
    }
}
