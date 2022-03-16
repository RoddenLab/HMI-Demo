using JR.P262605.HMI.UI.TypeLibrary;

namespace JR.P262605.HMI.UI.Operator.SMIF
{
    public interface ISMIFModel
    {
        string[] CassetteCarrierIDs { get; set; }
        string CassetteRFID { get; set; }
        string[] CassetteScribeIDs { get; set; }
        double[] CassetteThickness { get; set; }
        int CassetteWaferNotch { get; set; }
        int CassetteWaferSize { get; set; }
        string hiCassetteFile { get; set; }
        bool hiCassettePlaced { get; set; }
        bool hiClosePod { get; set; }
        bool hiFetchStatus { get; set; }
        bool hiInitialize { get; set; }
        bool hiLoad { get; set; }
        bool hiLoaderDisable { get; set; }
        bool hiLoaderEnable { get; set; }
        bool hiOpenPod { get; set; }
        bool hiSoftwareReset { get; set; }
        bool hiStatusClear { get; set; }
        bool hiUnload { get; set; }
        bool hoCassetteCompleteAlert { get; set; }
        string hoCassetteFile { get; set; }
        bool hoCassetteReadyForPlace { get; set; }
        bool hoManualMode { get; set; }
        bool INSTALLED { get; set; }
        stSMIFStatus Status { get; set; }
        stRFIDStatus RFIDStatus { get; set; }
        string hoRFID { get; set; }
        bool hiAccessLocal { get; set; }
        bool hiAccessRemote { get; set; }
        bool hiE84Recovery { get; set; }
        bool hoLoaderBusy { get; set; }
        bool hiClearPort { get; set; }
        bool hoDoorRequest { get; set; }
        bool hiClearDoorRequest { get; set; }
        public void SetData(Data.CassetteModel model)
        {
            CassetteCarrierIDs = model.CarrierIDs;
            CassetteRFID = model.RFID;
            CassetteScribeIDs = model.ScribeIDs;
            CassetteThickness = model.Thicknesses;
            CassetteWaferNotch = model.WaferNotch;
            CassetteWaferSize = model.WaferSize;
        }
    }
}