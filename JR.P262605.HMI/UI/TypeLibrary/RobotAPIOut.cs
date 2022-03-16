using Workstation.ServiceModel.Ua;

namespace JR.P262605.HMI.UI.TypeLibrary
{
    [DataTypeId("ns=4;s=RobotAPIOut")]
    [BinaryEncodingId("nsu=urn:BeckhoffAutomation:Ua:PLC1;s=<StructuredDataType>:RobotAPIOut__DefaultBinary")]
    public class RobotAPIOut : IEncodable
    {
        public int HeartbeatEcho { get; set; }
        public bool Connected { get; set; }
        public bool StartAckOK { get; set; }
        public bool StartAckNOK { get; set; }
        public bool Done { get; set; }
        public int Error { get; set; }
        public int Data { get; set; }
        public byte[] Mapping { get; set; } = new byte[25];
        public bool UnableToMove { get; set; }
        public bool CommandError { get; set; }
        public bool VacuumSensor { get; set; }
        public bool VacuumSwitch { get; set; }
        public bool MotionError { get; set; }
        public bool SoftwareLimit { get; set; }
        public bool NotHomed { get; set; }
        public bool MacroRunning { get; set; }
        public bool InMotion { get; set; }
        public bool ServoOff { get; set; }
        public bool InTeachMode { get; set; }
        public bool InSearchMode { get; set; }
        public bool FileError { get; set; }
        public bool InTeachScanMode { get; set; }
        public string Position { get; set; } = string.Empty;

        public void Encode(IEncoder encoder)
        {
            encoder.WriteInt32(nameof(HeartbeatEcho), HeartbeatEcho);
            encoder.WriteBoolean(nameof(Connected), Connected);
            encoder.WriteBoolean(nameof(StartAckOK), StartAckOK);
            encoder.WriteBoolean(nameof(StartAckNOK), StartAckNOK);
            encoder.WriteBoolean(nameof(Done), Done);
            encoder.WriteInt32(nameof(Error), Error);
            encoder.WriteInt32(nameof(Data), Data);
            encoder.WriteByteArray(nameof(Mapping), Mapping);
            encoder.WriteBoolean(nameof(UnableToMove), UnableToMove);
            encoder.WriteBoolean(nameof(CommandError), CommandError);
            encoder.WriteBoolean(nameof(VacuumSensor), VacuumSensor);
            encoder.WriteBoolean(nameof(VacuumSwitch), VacuumSwitch);
            encoder.WriteBoolean(nameof(MotionError), MotionError);
            encoder.WriteBoolean(nameof(SoftwareLimit), SoftwareLimit);
            encoder.WriteBoolean(nameof(NotHomed), NotHomed);
            encoder.WriteBoolean(nameof(MacroRunning), MacroRunning);
            encoder.WriteBoolean(nameof(InMotion), InMotion);
            encoder.WriteBoolean(nameof(ServoOff), ServoOff);
            encoder.WriteBoolean(nameof(InTeachMode), InTeachMode);
            encoder.WriteBoolean(nameof(InSearchMode), InSearchMode);
            encoder.WriteBoolean(nameof(FileError), FileError);
            encoder.WriteBoolean(nameof(InTeachScanMode), InTeachScanMode);
            encoder.WriteString(nameof(Position), Position);
        }

        public void Decode(IDecoder decoder)
        {
            HeartbeatEcho = decoder.ReadInt32(nameof(HeartbeatEcho));
            Connected = decoder.ReadBoolean(nameof(Connected));
            StartAckOK = decoder.ReadBoolean(nameof(StartAckOK));
            StartAckNOK = decoder.ReadBoolean(nameof(StartAckNOK));
            Done = decoder.ReadBoolean(nameof(Done));
            Error = decoder.ReadInt32(nameof(Error));
            Data = decoder.ReadInt32(nameof(Data));
            Mapping = decoder.ReadByteArray(nameof(Mapping));
            UnableToMove = decoder.ReadBoolean(nameof(UnableToMove));
            CommandError = decoder.ReadBoolean(nameof(CommandError));
            VacuumSensor = decoder.ReadBoolean(nameof(VacuumSensor));
            VacuumSwitch = decoder.ReadBoolean(nameof(VacuumSwitch));
            MotionError = decoder.ReadBoolean(nameof(MotionError));
            SoftwareLimit = decoder.ReadBoolean(nameof(SoftwareLimit));
            NotHomed = decoder.ReadBoolean(nameof(NotHomed));
            MacroRunning = decoder.ReadBoolean(nameof(MacroRunning));
            InMotion = decoder.ReadBoolean(nameof(InMotion));
            ServoOff = decoder.ReadBoolean(nameof(ServoOff));
            InTeachMode = decoder.ReadBoolean(nameof(InTeachMode));
            InSearchMode = decoder.ReadBoolean(nameof(InSearchMode));
            FileError = decoder.ReadBoolean(nameof(FileError));
            InTeachScanMode = decoder.ReadBoolean(nameof(InTeachScanMode));
            Position = decoder.ReadString(nameof(Position));
        }
    }
}
