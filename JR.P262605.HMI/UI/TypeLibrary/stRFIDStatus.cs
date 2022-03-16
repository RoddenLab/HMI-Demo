using Workstation.ServiceModel.Ua;

namespace JR.P262605.HMI.UI.TypeLibrary
{
    [DataTypeId("ns=4;s=stRFIDStatus")]
    [BinaryEncodingId("nsu=urn:BeckhoffAutomation:Ua:PLC1;s=<StructuredDataType>:stRFIDStatus__DefaultBinary")]
    public class stRFIDStatus : IEncodable
    {
        public bool ControlMode { get; set; } = false;
        public bool TagPresent { get; set; } = false;
        public bool DoubleCheckMode { get; set; } = false;
        public bool LCDModuleStatus { get; set; } = false;
        public int ErrorCode { get; set; } = 0;
        public string ErrorText { get; set; } = string.Empty;

        public void Encode(IEncoder encoder)
        {
            encoder.WriteBoolean(nameof(ControlMode), ControlMode);
            encoder.WriteBoolean(nameof(TagPresent), TagPresent);
            encoder.WriteBoolean(nameof(DoubleCheckMode), DoubleCheckMode);
            encoder.WriteBoolean(nameof(LCDModuleStatus), LCDModuleStatus);
            encoder.WriteInt32(nameof(ErrorCode), ErrorCode);
            encoder.WriteString(nameof(ErrorText), ErrorText);
        }

        public void Decode(IDecoder decoder)
        {
            ControlMode = decoder.ReadBoolean(nameof(ControlMode));
            TagPresent = decoder.ReadBoolean(nameof(TagPresent));
            DoubleCheckMode = decoder.ReadBoolean(nameof(DoubleCheckMode));
            LCDModuleStatus = decoder.ReadBoolean(nameof(LCDModuleStatus));
            ErrorCode = decoder.ReadInt32(nameof(ErrorCode));
            ErrorText = decoder.ReadString(nameof(ErrorText));
        }
    }
}
