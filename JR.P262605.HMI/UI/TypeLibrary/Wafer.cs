using Workstation.ServiceModel.Ua;

namespace JR.P262605.HMI.UI.TypeLibrary
{
    [DataTypeId("ns=4;s=Wafer")]
    [BinaryEncodingId("nsu=urn:BeckhoffAutomation:Ua:PLC1;s=<StructuredDataType>:Wafer__DefaultBinary")]
    public class Wafer : IEncodable
    {
        public Wafer()
        {
        }

        public int Status { get; set; }
        public int CurrentStation { get; set; }
        public int CurrentSlot { get; set; }
        public int HomeStation { get; set; }
        public int HomeSlot { get; set; }
        public int HomeNest { get; set; }
        public int ProcessStep { get; set; }
        public string CarrierID { get; set; } = string.Empty;
        public string ScribeID { get; set; } = string.Empty;
        public double Thickness { get; set; }
        public int Notch { get; set; }
        public int Size { get; set; }
        public string BottomOCRCode { get; set; } = string.Empty;
        public string TopOCRCode { get; set; } = string.Empty;
        public double PowerBefore { get; set; }
        public double PowerAfter { get; set; }

        public void Decode(IDecoder decoder)
        {
            Status = decoder.ReadInt32(nameof(Status));
            CurrentStation = decoder.ReadInt32(nameof(CurrentStation));
            CurrentSlot = decoder.ReadInt32(nameof(CurrentSlot));
            HomeStation = decoder.ReadInt32(nameof(HomeStation));
            HomeSlot = decoder.ReadInt32(nameof(HomeSlot));
            HomeNest = decoder.ReadInt32(nameof(HomeNest));
            ProcessStep = decoder.ReadInt32(nameof(ProcessStep));
            CarrierID = decoder.ReadString(nameof(CarrierID));
            ScribeID = decoder.ReadString(nameof(ScribeID));
            Thickness = decoder.ReadDouble(nameof(Thickness));
            Notch = decoder.ReadInt32(nameof(Notch));
            Size = decoder.ReadInt32(nameof(Size));
            BottomOCRCode = decoder.ReadString(nameof(BottomOCRCode));
            TopOCRCode = decoder.ReadString(nameof(TopOCRCode));
            PowerBefore = decoder.ReadDouble(nameof(PowerBefore));
            PowerAfter = decoder.ReadDouble(nameof(PowerAfter));
        }

        public void Encode(IEncoder encoder)
        {
            encoder.WriteInt32(nameof(Status), Status);
            encoder.WriteInt32(nameof(CurrentStation), CurrentStation);
            encoder.WriteInt32(nameof(CurrentSlot), CurrentSlot);
            encoder.WriteInt32(nameof(HomeStation), HomeStation);
            encoder.WriteInt32(nameof(HomeSlot), HomeSlot);
            encoder.WriteInt32(nameof(HomeNest), HomeNest);
            encoder.WriteInt32(nameof(ProcessStep), ProcessStep);
            encoder.WriteString(nameof(CarrierID), CarrierID);
            encoder.WriteString(nameof(ScribeID), ScribeID);
            encoder.WriteDouble(nameof(Thickness), Thickness);
            encoder.WriteInt32(nameof(Notch), Notch);
            encoder.WriteInt32(nameof(Size), Size);
            encoder.WriteString(nameof(BottomOCRCode), BottomOCRCode);
            encoder.WriteString(nameof(TopOCRCode), TopOCRCode);
            encoder.WriteDouble(nameof(PowerBefore), PowerBefore);
            encoder.WriteDouble(nameof(PowerAfter), PowerAfter);
        }
    }
}