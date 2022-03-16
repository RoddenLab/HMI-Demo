using Workstation.ServiceModel.Ua;

namespace JR.P262605.HMI.UI.TypeLibrary
{
    [DataTypeId("ns=4;s=stSMIFStatus")]
    [BinaryEncodingId("nsu=urn:BeckhoffAutomation:Ua:PLC1;s=<StructuredDataType>:stSMIFStatus__DefaultBinary")]
    public class stSMIFStatus : IEncodable
    {
        public int ControlMode { get; set; } = 0;
        public int PlusMode { get; set; } = 0;
        public int SerialOverride { get; set; } = 0;
        public bool PodPresent { get; set; } = false;
        public bool PodLatched { get; set; } = false;
        public bool PodUnlocked { get; set; } = false;
        public bool PodLocked { get; set; } = false;
        public bool PodElevatorUp { get; set; } = false;
        public bool PodElevatorDown { get; set; } = false;
        public bool GripperClosed { get; set; } = false;
        public bool GripperOpen { get; set; } = false;
        public bool ArmCosine { get; set; } = false;
        public bool ArmSine { get; set; } = false;
        public bool ArmHome { get; set; } = false;
        public bool RailHome { get; set; } = false;
        public bool TiltDown { get; set; } = false;
        public bool TiltUp { get; set; } = false;
        public bool ArmOverload { get; set; } = false;
        public bool ArmUp { get; set; } = false;
        public bool CassetteInPlace { get; set; } = false;
        public bool MapSensor { get; set; } = false;
        public bool WaferProtrusion { get; set; } = false;
        public int GripperStatus { get; set; } = 0;
        public int ErrorCode { get; set; } = 0;
        public string ErrorText { get; set; } = string.Empty;

        public void Encode(IEncoder encoder)
        {
            encoder.WriteInt32(nameof(ControlMode), ControlMode);
            encoder.WriteInt32(nameof(PlusMode), PlusMode);
            encoder.WriteInt32(nameof(SerialOverride), SerialOverride);
            encoder.WriteBoolean(nameof(PodPresent), PodPresent);
            encoder.WriteBoolean(nameof(PodLatched), PodLatched);
            encoder.WriteBoolean(nameof(PodUnlocked), PodUnlocked);
            encoder.WriteBoolean(nameof(PodLocked), PodLocked);
            encoder.WriteBoolean(nameof(PodElevatorUp), PodElevatorUp);
            encoder.WriteBoolean(nameof(PodElevatorDown), PodElevatorDown);
            encoder.WriteBoolean(nameof(GripperClosed), GripperClosed);
            encoder.WriteBoolean(nameof(GripperOpen), GripperOpen);
            encoder.WriteBoolean(nameof(ArmCosine), ArmCosine);
            encoder.WriteBoolean(nameof(ArmSine), ArmSine);
            encoder.WriteBoolean(nameof(ArmHome), ArmHome);
            encoder.WriteBoolean(nameof(RailHome), RailHome);
            encoder.WriteBoolean(nameof(TiltDown), TiltDown);
            encoder.WriteBoolean(nameof(TiltUp), TiltUp);
            encoder.WriteBoolean(nameof(ArmOverload), ArmOverload);
            encoder.WriteBoolean(nameof(ArmUp), ArmUp);
            encoder.WriteBoolean(nameof(CassetteInPlace), CassetteInPlace);
            encoder.WriteBoolean(nameof(MapSensor), MapSensor);
            encoder.WriteBoolean(nameof(WaferProtrusion), WaferProtrusion);
            encoder.WriteInt32(nameof(GripperStatus), GripperStatus);
            encoder.WriteInt32(nameof(ErrorCode), ErrorCode);
            encoder.WriteString(nameof(ErrorText), ErrorText);
        }

        public void Decode(IDecoder decoder)
        {
            ControlMode = decoder.ReadInt32(nameof(ControlMode));
            PlusMode = decoder.ReadInt32(nameof(PlusMode));
            SerialOverride = decoder.ReadInt32(nameof(SerialOverride));
            PodPresent = decoder.ReadBoolean(nameof(PodPresent));
            PodLatched = decoder.ReadBoolean(nameof(PodLatched));
            PodUnlocked = decoder.ReadBoolean(nameof(PodUnlocked));
            PodLocked = decoder.ReadBoolean(nameof(PodLocked));
            PodElevatorUp = decoder.ReadBoolean(nameof(PodElevatorUp));
            PodElevatorDown = decoder.ReadBoolean(nameof(PodElevatorDown));
            GripperClosed = decoder.ReadBoolean(nameof(GripperClosed));
            GripperOpen = decoder.ReadBoolean(nameof(GripperOpen));
            ArmCosine = decoder.ReadBoolean(nameof(ArmCosine));
            ArmSine = decoder.ReadBoolean(nameof(ArmSine));
            ArmHome = decoder.ReadBoolean(nameof(ArmHome));
            RailHome = decoder.ReadBoolean(nameof(RailHome));
            TiltDown = decoder.ReadBoolean(nameof(TiltDown));
            TiltUp = decoder.ReadBoolean(nameof(TiltUp));
            ArmOverload = decoder.ReadBoolean(nameof(ArmOverload));
            ArmUp = decoder.ReadBoolean(nameof(ArmUp));
            CassetteInPlace = decoder.ReadBoolean(nameof(CassetteInPlace));
            MapSensor = decoder.ReadBoolean(nameof(MapSensor));
            WaferProtrusion = decoder.ReadBoolean(nameof(WaferProtrusion));
            GripperStatus = decoder.ReadInt32(nameof(GripperStatus));
            ErrorCode = decoder.ReadInt32(nameof(ErrorCode));
            ErrorText = decoder.ReadString(nameof(ErrorText));
        }
    }
}
