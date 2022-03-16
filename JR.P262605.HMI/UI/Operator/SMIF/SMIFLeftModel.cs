using Workstation.ServiceModel.Ua;

namespace JR.P262605.HMI.UI.Operator.SMIF
{
    [Subscription(endpointUrl: "PLC", publishingInterval: 250)]
    public class SMIFLeftModel : SubscriptionBase, ISMIFModel
    {
        [MonitoredItem(nodeId: "ns=4;s=Stn10_16_SMIFPodLt.hiInitialize")]
        public bool hiStatusClear
        {
            get => _hiStatusClear;
            set => SetProperty(ref _hiStatusClear, value);
        }
        private bool _hiStatusClear;

        [MonitoredItem(nodeId: "ns=4;s=Stn10_16_SMIFPodLt.hiInitialize")]
        public bool hiInitialize
        {
            get => _hiInitialize;
            set => SetProperty(ref _hiInitialize, value);
        }
        private bool _hiInitialize = false;

        [MonitoredItem(nodeId: "ns=4;s=Stn10_16_SMIFPodLt.hiSoftwareReset")]
        public bool hiSoftwareReset
        {
            get => _hiSoftwareReset;
            set => SetProperty(ref _hiSoftwareReset, value);
        }
        private bool _hiSoftwareReset = false;

        [MonitoredItem(nodeId: "ns=4;s=Stn10_16_SMIFPodLt.hiGetStatus")]
        public bool hiFetchStatus
        {
            get => _hiFetchStatus;
            set => SetProperty(ref _hiFetchStatus, value);
        }
        private bool _hiFetchStatus = false;

        [MonitoredItem(nodeId: "ns=4;s=Stn10_16_SMIFPodLt.hiOpenPod")]
        public bool hiOpenPod
        {
            get => _hiOpenPod;
            set => SetProperty(ref _hiOpenPod, value);
        }
        private bool _hiOpenPod = false;

        [MonitoredItem(nodeId: "ns=4;s=Stn10_16_SMIFPodLt.hiClosePod")]
        public bool hiClosePod
        {
            get => _hiClosePod;
            set => SetProperty(ref _hiClosePod, value);
        }
        private bool _hiClosePod = false;

        [MonitoredItem(nodeId: "ns=4;s=Stn10_16_SMIFPodLt.hiLoad")]
        public bool hiLoad
        {
            get => _hiLoad;
            set => SetProperty(ref _hiLoad, value);
        }
        private bool _hiLoad = false;

        [MonitoredItem(nodeId: "ns=4;s=Stn10_16_SMIFPodLt.hiUnload")]
        public bool hiUnload
        {
            get => _hiUnload;
            set => SetProperty(ref _hiUnload, value);
        }
        private bool _hiUnload = false;

        [MonitoredItem(nodeId: "ns=4;s=Stn10_16_SMIFPodLt.hiCassettePlaced")]
        public bool hiCassettePlaced
        {
            get => _hiCassettePlaced;
            set => SetProperty(ref _hiCassettePlaced, value);
        }
        private bool _hiCassettePlaced = false;

        [MonitoredItem(nodeId: "ns=4;s=Stn10_16_SMIFPodLt.hiCassetteFile")]
        public string hiCassetteFile
        {
            get => _hiCassetteFile;
            set => SetProperty(ref _hiCassetteFile, value);
        }
        private string _hiCassetteFile = string.Empty;

        [MonitoredItem(nodeId: "ns=4;s=Stn10_16_SMIFPodLt.hiLoaderEnable")]
        public bool hiLoaderEnable
        {
            get => _hiLoaderEnable;
            set => SetProperty(ref _hiLoaderEnable, value);
        }
        private bool _hiLoaderEnable = false;

        [MonitoredItem(nodeId: "ns=4;s=Stn10_16_SMIFPodLt.hiLoaderDisable")]
        public bool hiLoaderDisable
        {
            get => _hiLoaderDisable;
            set => SetProperty(ref _hiLoaderDisable, value);
        }
        private bool _hiLoaderDisable = false;


        [MonitoredItem(nodeId: "ns=4;s=Stn10_16_SMIFPodLt.hiCassetteData.RFID")]
        public string CassetteRFID
        {
            get => _CassetteARFID;
            set => SetProperty(ref _CassetteARFID, value);
        }

        private string _CassetteARFID = string.Empty;

        [MonitoredItem(nodeId: "ns=4;s=Stn10_16_SMIFPodLt.hiCassetteData.WaferSize")]
        public int CassetteWaferSize
        {
            get => _CassetteAWaferSize;
            set => SetProperty(ref _CassetteAWaferSize, value);
        }

        private int _CassetteAWaferSize = 0;

        [MonitoredItem(nodeId: "ns=4;s=Stn10_16_SMIFPodLt.hiCassetteData.WaferNotch")]
        public int CassetteWaferNotch
        {
            get => _CassetteAWaferNotch;
            set => SetProperty(ref _CassetteAWaferNotch, value);
        }

        private int _CassetteAWaferNotch = 0;

        [MonitoredItem(nodeId: "ns=4;s=Stn10_16_SMIFPodLt.hiCassetteData.Thickness")]
        public double[] CassetteThickness
        {
            get => _CassetteAThickness;
            set => SetProperty(ref _CassetteAThickness, value);
        }

        private double[] _CassetteAThickness = new double[25];

        [MonitoredItem(nodeId: "ns=4;s=Stn10_16_SMIFPodLt.hiCassetteData.CarrierID")]
        public string[] CassetteCarrierIDs
        {
            get => _CassetteACarrierIDs;
            set => SetProperty(ref _CassetteACarrierIDs, value);
        }

        private string[] _CassetteACarrierIDs = new string[25];

        [MonitoredItem(nodeId: "ns=4;s=Stn10_16_SMIFPodLt.hiCassetteData.ScribeID")]
        public string[] CassetteScribeIDs
        {
            get => _CassetteAScribeIDs;
            set => SetProperty(ref _CassetteAScribeIDs, value);
        }

        private string[] _CassetteAScribeIDs = new string[25];

        [MonitoredItem(nodeId: "ns=4;s=Stn10_16_SMIFPodLt.hoStatus")]
        public TypeLibrary.stSMIFStatus Status
        {
            get => _Status;
            set => SetProperty(ref _Status, value);
        }
        private TypeLibrary.stSMIFStatus _Status = new();

        [MonitoredItem(nodeId: "ns=4;s=Stn10_16_SMIFPodLt.hoCassetteFile")]
        public string hoCassetteFile
        {
            get => _hoCassetteFile;
            set => SetProperty(ref _hoCassetteFile, value);
        }
        private string _hoCassetteFile = string.Empty;

        [MonitoredItem(nodeId: "ns=4;s=Stn10_16_SMIFPodLt.hoCassetteReadyForPlace")]
        public bool hoCassetteReadyForPlace
        {
            get => _hoCassetteReadyForPlace;
            set => SetProperty(ref _hoCassetteReadyForPlace, value);
        }
        private bool _hoCassetteReadyForPlace = false;

        [MonitoredItem(nodeId: "ns=4;s=Stn10_16_SMIFPodLt.hoManualMode")]
        public bool hoManualMode
        {
            get => _hoManualMode;
            set => SetProperty(ref _hoManualMode, value);
        }
        private bool _hoManualMode = false;

        [MonitoredItem(nodeId: "ns=4;s=Stn10_16_SMIFPodLt.hoCassetteCompleteAlert")]
        public bool hoCassetteCompleteAlert
        {
            get => _hoCassetteCompleteAlert;
            set => SetProperty(ref _hoCassetteCompleteAlert, value);
        }
        private bool _hoCassetteCompleteAlert = false;

        [MonitoredItem(nodeId: "ns=4;s=Stn10_16_SMIFPodLt.INSTALLED")]
        public bool INSTALLED
        {
            get => _INSTALLED;
            set => SetProperty(ref _INSTALLED, value);
        }
        private bool _INSTALLED = false;


        [MonitoredItem(nodeId: "ns=4;s=Stn10_16_SMIFPodLt.hoRFID")]
        public string hoRFID
        {
            get { return _hoRFID; }
            set { SetProperty(ref _hoRFID, value); }
        }
        private string _hoRFID = string.Empty;

        [MonitoredItem(nodeId: "ns=4;s=Stn10_16_SMIFPodLt.hoRFIDStatus")]
        public TypeLibrary.stRFIDStatus RFIDStatus
        {
            get { return _RFIDStatus; }
            set { SetProperty(ref _RFIDStatus, value); }
        }
        private TypeLibrary.stRFIDStatus _RFIDStatus = new();

        [MonitoredItem(nodeId: "ns=4;s=Stn10_16_SMIFPodLt.hiAccessLocal")]
        public bool hiAccessLocal
        {
            get { return _hiAccessLocal; }
            set { SetProperty(ref _hiAccessLocal, value); }
        }
        private bool _hiAccessLocal = false;

        [MonitoredItem(nodeId: "ns=4;s=Stn10_16_SMIFPodLt.hiAccessRemote")]
        public bool hiAccessRemote
        {
            get { return _hiAccessRemote; }
            set { SetProperty(ref _hiAccessRemote, value); }
        }
        private bool _hiAccessRemote = false;

        [MonitoredItem(nodeId: "ns=4;s=Stn10_16_SMIFPodLt.hiE84Recovery")]
        public bool hiE84Recovery
        {
            get { return _hiE84Recovery; }
            set { SetProperty(ref _hiE84Recovery, value); }
        }
        private bool _hiE84Recovery = false;

        [MonitoredItem(nodeId: "ns=4;s=Stn10_16_SMIFPodLt.hoLoaderBusy")]
        public bool hoLoaderBusy
        {
            get { return _hoLoaderBusy; }
            set { SetProperty(ref _hoLoaderBusy, value); }
        }
        private bool _hoLoaderBusy = false;

        [MonitoredItem(nodeId: "ns=4;s=Stn10_16_SMIFPodLt.hiClearPort")]
        public bool hiClearPort
        {
            get { return _hiClearPort; }
            set { SetProperty(ref _hiClearPort, value); }
        }
        private bool _hiClearPort = false;


        [MonitoredItem(nodeId: "ns=4;s=Stn10_16_SMIFPodLt.hoDoorRequest")]
        public bool hoDoorRequest
        {
            get { return _hoDoorRequest; }
            set { SetProperty(ref _hoDoorRequest, value); }
        }
        private bool _hoDoorRequest = false;

        [MonitoredItem(nodeId: "ns=4;s=Stn10_16_SMIFPodLt.hiClearDoorRequest")]
        public bool hiClearDoorRequest
        {
            get { return _hiClearDoorRequest; }
            set { SetProperty(ref _hiClearDoorRequest, value); }
        }
        private bool _hiClearDoorRequest = false;
    }
}
