using Workstation.ServiceModel.Ua;

namespace JR.P262605.HMI.UI.TypeLibrary
{
    [DataTypeId("ns=4;s=AlignerAPIOut")]
    [BinaryEncodingId("nsu=urn:BeckhoffAutomation:Ua:PLC1;s=<StructuredDataType>:AlignerAPIOut__DefaultBinary")]
    public class AlignerAPIOut : IEncodable
    {
        public int HeartbeatEcho { get; set; }
        public bool Connected { get; set; }
        public bool StartAckOK { get; set; }
        public bool StartAckNOK { get; set; }
        public bool Done { get; set; }
        public int Error { get; set; }
        public bool UnableToMove { get; set; }
        public bool CommandError { get; set; }
        public bool ChuckVacuumSensor { get; set; }
        public bool ChuckVacuumSwitch { get; set; }
        public bool MotionError { get; set; }
        public bool MotionLimitsViolation { get; set; }
        public bool NotHomed { get; set; }
        public bool MacroRunning { get; set; }
        public bool MotionInProgress { get; set; }
        public bool ServoOff { get; set; }
        public bool FileError { get; set; }
        public bool PinsVacuumSwitch { get; set; }

        public void Encode(IEncoder encoder)
        {
            encoder.WriteInt32(nameof(HeartbeatEcho), HeartbeatEcho);
            encoder.WriteBoolean(nameof(Connected), Connected);
            encoder.WriteBoolean(nameof(StartAckOK), StartAckOK);
            encoder.WriteBoolean(nameof(StartAckNOK), StartAckNOK);
            encoder.WriteBoolean(nameof(Done), Done);
            encoder.WriteInt32(nameof(Error), Error);
            encoder.WriteBoolean(nameof(UnableToMove), UnableToMove);
            encoder.WriteBoolean(nameof(CommandError), CommandError);
            encoder.WriteBoolean(nameof(ChuckVacuumSensor), ChuckVacuumSensor);
            encoder.WriteBoolean(nameof(ChuckVacuumSwitch), ChuckVacuumSwitch);
            encoder.WriteBoolean(nameof(MotionError), MotionError);
            encoder.WriteBoolean(nameof(MotionLimitsViolation), MotionLimitsViolation);
            encoder.WriteBoolean(nameof(NotHomed), NotHomed);
            encoder.WriteBoolean(nameof(MacroRunning), MacroRunning);
            encoder.WriteBoolean(nameof(MotionInProgress), MotionInProgress);
            encoder.WriteBoolean(nameof(ServoOff), ServoOff);
            encoder.WriteBoolean(nameof(FileError), FileError);
            encoder.WriteBoolean(nameof(PinsVacuumSwitch), PinsVacuumSwitch);
        }

        public void Decode(IDecoder decoder)
        {
            HeartbeatEcho = decoder.ReadInt32(nameof(HeartbeatEcho));
            Connected = decoder.ReadBoolean(nameof(Connected));
            StartAckOK = decoder.ReadBoolean(nameof(StartAckOK));
            StartAckNOK = decoder.ReadBoolean(nameof(StartAckNOK));
            Done = decoder.ReadBoolean(nameof(Done));
            Error = decoder.ReadInt32(nameof(Error));
            UnableToMove = decoder.ReadBoolean(nameof(UnableToMove));
            CommandError = decoder.ReadBoolean(nameof(CommandError));
            ChuckVacuumSensor = decoder.ReadBoolean(nameof(ChuckVacuumSensor));
            ChuckVacuumSwitch = decoder.ReadBoolean(nameof(ChuckVacuumSwitch));
            MotionError = decoder.ReadBoolean(nameof(MotionError));
            MotionLimitsViolation = decoder.ReadBoolean(nameof(MotionLimitsViolation));
            NotHomed = decoder.ReadBoolean(nameof(NotHomed));
            MacroRunning = decoder.ReadBoolean(nameof(MacroRunning));
            MotionInProgress = decoder.ReadBoolean(nameof(MotionInProgress));
            ServoOff = decoder.ReadBoolean(nameof(ServoOff));
            FileError = decoder.ReadBoolean(nameof(FileError));
            PinsVacuumSwitch = decoder.ReadBoolean(nameof(PinsVacuumSwitch));
        }
    }
}
