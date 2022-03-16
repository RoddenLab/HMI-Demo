using Workstation.ServiceModel.Ua;

namespace JR.P262605.HMI.UI.TypeLibrary
{
    [DataTypeId("ns=4;s=ExternalCassetteData")]
    [BinaryEncodingId("nsu=urn:BeckhoffAutomation:Ua:PLC1;s=<StructuredDataType>:ExternalCassetteData__DefaultBinary")]
    public class ExternalCassetteData : IEncodable
    {
        public ExternalCassetteData()
        {

        }

        public ExternalCassetteData(Data.CassetteModel cassetteData)
        {
            RFID = cassetteData.RFID;
            WaferSize = cassetteData.WaferSize;
            WaferNotch = cassetteData.WaferNotch;
            Thickness = cassetteData.Thicknesses;
            CarrierID = cassetteData.CarrierIDs;
            ScribeID = cassetteData.ScribeIDs;
        }

        public string RFID { get; set; } = string.Empty;
        public int WaferSize { get; set; } = 0;
        public int WaferNotch { get; set; } = 0;
        public double[] Thickness { get; set; } = new double[25];
        public string[] CarrierID { get; set; } = new string[25];
        public string[] ScribeID { get; set; } = new string[25];

        public void Encode(IEncoder encoder)
        {
            encoder.WriteString(nameof(RFID), RFID);
            encoder.WriteInt32(nameof(WaferSize), WaferSize);
            encoder.WriteInt32(nameof(WaferNotch), WaferNotch);
            encoder.WriteDoubleArray(nameof(Thickness), Thickness);
            encoder.WriteStringArray(nameof(CarrierID), CarrierID);
            encoder.WriteStringArray(nameof(ScribeID), ScribeID);
        }

        public void Decode(IDecoder decoder)
        {
            RFID = decoder.ReadString(nameof(RFID));
            WaferSize = decoder.ReadInt32(nameof(WaferSize));
            WaferNotch = decoder.ReadInt32(nameof(WaferNotch));
            Thickness = decoder.ReadDoubleArray(nameof(Thickness));
            CarrierID = decoder.ReadStringArray(nameof(CarrierID));
            ScribeID = decoder.ReadStringArray(nameof(ScribeID));
        }
    }
}
