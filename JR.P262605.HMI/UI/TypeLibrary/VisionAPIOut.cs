using Workstation.ServiceModel.Ua;

namespace JR.P262605.HMI.UI.TypeLibrary
{
    [DataTypeId("ns=4;s=VisionAPIOut")]
    [BinaryEncodingId("nsu=urn:BeckhoffAutomation:Ua:PLC1;s=<StructuredDataType>:VisionAPIOut__DefaultBinary")]
    public class VisionAPIOut : IEncodable
    {
        public int HeartbeatEcho { get; set; } = 0;
        public bool Connected { get; set; } = false;
        public bool Done { get; set; } = false;
        public int Error { get; set; } = 0;
        public string OCRCode { get; set; } = string.Empty;

        public void Encode(IEncoder encoder)
        {
            encoder.WriteInt32(nameof(HeartbeatEcho), HeartbeatEcho);
            encoder.WriteBoolean(nameof(Connected), Connected);
            encoder.WriteBoolean(nameof(Done), Done);
            encoder.WriteInt32(nameof(Error), Error);
            encoder.WriteString(nameof(OCRCode), OCRCode);
        }

        public void Decode(IDecoder decoder)
        {
            HeartbeatEcho = decoder.ReadInt32(nameof(HeartbeatEcho));
            Connected = decoder.ReadBoolean(nameof(Connected));
            Done = decoder.ReadBoolean(nameof(Done));
            Error = decoder.ReadInt32(nameof(Error));
            OCRCode = decoder.ReadString(nameof(OCRCode));
        }
    }
}
