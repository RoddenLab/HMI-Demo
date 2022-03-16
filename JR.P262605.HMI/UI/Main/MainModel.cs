using Workstation.ServiceModel.Ua;

namespace JR.P262605.HMI.UI.Main
{
    [Subscription(endpointUrl: "PLC", publishingInterval: 150)]
    public partial class MainModel : SubscriptionBase
    {
        public MainModel() : base()
        {
        }

        public void SetCassetteData(string cassette, Data.CassetteModel cassetteData)
        {
            if (cassette == "A")
            {
                hiCassetteAData = new(cassetteData);
            }
            else if (cassette == "B")
            {
                hiCassetteBData = new(cassetteData);
            }
        }

        [MonitoredItem("ns=4;s=Stn10_10_Main.hiSelectedCassette")]
        public string SelectedCassette
        {
            get => _SelectedCassette;
            set => SetProperty(ref _SelectedCassette, value);
        }

        private string _SelectedCassette;

        [MonitoredItem("ns=4;s=Stn10_10_Main.hiSelectedSlot")]
        public int SelectedSlot
        {
            get => _SelectedSlot;
            set => SetProperty(ref _SelectedSlot, value);
        }

        private int _SelectedSlot;

        [MonitoredItem("ns=4;s=Stn10_10_Main.hoSelectedWafer")]
        public TypeLibrary.Wafer SelectedWafer
        {
            get => _SelectedWafer;
            set => SetProperty(ref _SelectedWafer, value);
        }
        private TypeLibrary.Wafer _SelectedWafer = new();


        [MonitoredItem("ns=4;s=Stn10_10_Main.hoCassetteAStatuses")]
        public int[] CassetteAStatuses
        {
            get => _CassetteAStatuses;
            set => SetProperty(ref _CassetteAStatuses, value);
        }

        private int[] _CassetteAStatuses = new int[25];

        [MonitoredItem("ns=4;s=Stn10_10_Main.hoCassetteBStatuses")]
        public int[] CassetteBStatuses
        {
            get => _CassetteBStatuses;
            set => SetProperty(ref _CassetteBStatuses, value);
        }

        private int[] _CassetteBStatuses = new int[25];

        [MonitoredItem(nodeId: "ns=4;s=Stn10_10_Main.hoCassetteAID")]
        public string hoCassetteAID
        {
            get => _hoCassetteAID;
            set => SetProperty(ref _hoCassetteAID, value);
        }
        private string _hoCassetteAID = string.Empty;


        [MonitoredItem(nodeId: "ns=4;s=Stn10_10_Main.hoCassetteBID")]
        public string hoCassetteBID
        {
            get => _hoCassetteBID;
            set => SetProperty(ref _hoCassetteBID, value);
        }
        private string _hoCassetteBID = string.Empty;

        [MonitoredItem(nodeId: "ns=4;s=Stn10_10_Main.hiCassetteAData")]
        public TypeLibrary.ExternalCassetteData hiCassetteAData
        {
            get => _hiCassetteAData;
            set => SetProperty(ref _hiCassetteAData, value);
        }
        private TypeLibrary.ExternalCassetteData _hiCassetteAData = new();


        [MonitoredItem(nodeId: "ns=4;s=Stn10_10_Main.hiCassetteBData")]
        public TypeLibrary.ExternalCassetteData hiCassetteBData
        {
            get => _hiCassetteBData;
            set => SetProperty(ref _hiCassetteBData, value);
        }
        private TypeLibrary.ExternalCassetteData _hiCassetteBData = new();

        [MonitoredItem(nodeId: "ns=4;s=Stn10_10_Main.hiCassetteAPlaced")]
        public bool hiCassetteAPlaced
        {
            get => _hiCassetteAPlaced;
            set => SetProperty(ref _hiCassetteAPlaced, value);
        }

        private bool _hiCassetteAPlaced;

        [MonitoredItem(nodeId: "ns=4;s=Stn10_10_Main.hiCassetteBPlaced")]
        public bool hiCassetteBPlaced
        {
            get => _hiCassetteBPlaced;
            set => SetProperty(ref _hiCassetteBPlaced, value);
        }

        private bool _hiCassetteBPlaced;

        [MonitoredItem(nodeId: "ns=4;s=Stn10_10_Main.hoManualMode")]
        public bool hoManualMode
        {
            get => _hoManualMode;
            set => SetProperty(ref _hoManualMode, value);
        }

        private bool _hoManualMode;

        [MonitoredItem(nodeId: "ns=4;s=Stn10_10_Main.hiCassetteADataFile")]
        public string hiCassetteADataFile
        {
            get => _hiCassetteADataFile;
            set => SetProperty(ref _hiCassetteADataFile, value);
        }

        private string _hiCassetteADataFile;

        [MonitoredItem(nodeId: "ns=4;s=Stn10_10_Main.hiCassetteBDataFile")]
        public string hiCassetteBDataFile
        {
            get => _hiCassetteBDataFile;
            set => SetProperty(ref _hiCassetteBDataFile, value);
        }

        private string _hiCassetteBDataFile;

        [MonitoredItem(nodeId: "ns=4;s=Stn10_10_Main.hiCassetteARecipeFile")]
        public string hiCassetteARecipeFile
        {
            get => _hiCassetteARecipeFile;
            set => SetProperty(ref _hiCassetteARecipeFile, value);
        }
        private string _hiCassetteARecipeFile = string.Empty;

        [MonitoredItem(nodeId: "ns=4;s=Stn10_10_Main.hiCassetteBRecipeFile")]
        public string hiCassetteBRecipeFile
        {
            get => _hiCassetteBRecipeFile;
            set => SetProperty(ref _hiCassetteBRecipeFile, value);
        }
        private string _hiCassetteBRecipeFile = string.Empty;


        [MonitoredItem(nodeId: "ns=4;s=Stn10_10_Main.hoCassetteAFile")]
        public string hoCassetteAFile
        {
            get => _hoCassetteAFile;
            set => SetProperty(ref _hoCassetteAFile, value);
        }

        private string _hoCassetteAFile;

        [MonitoredItem(nodeId: "ns=4;s=Stn10_10_Main.hoCassetteBFile")]
        public string hoCassetteBFile
        {
            get => _hoCassetteBFile;
            set => SetProperty(ref _hoCassetteBFile, value);
        }

        private string _hoCassetteBFile;

        [MonitoredItem(nodeId: "ns=4;s=Stn10_10_Main.hoCassetteAReady")]
        public bool hoCassetteAReady
        {
            get => _hoCassetteAReady;
            set => SetProperty(ref _hoCassetteAReady, value);
        }

        private bool _hoCassetteAReady;

        [MonitoredItem(nodeId: "ns=4;s=Stn10_10_Main.hoCassetteBReady")]
        public bool hoCassetteBReady
        {
            get => _hoCassetteBReady;
            set => SetProperty(ref _hoCassetteBReady, value);
        }

        private bool _hoCassetteBReady;

        [MonitoredItem(nodeId: "ns=4;s=Stn10_10_Main.hoCassetteACompleteAlert")]
        public bool hoCassetteACompleteAlert
        {
            get => _hoCassetteACompleteAlert;
            set => SetProperty(ref _hoCassetteACompleteAlert, value);
        }

        private bool _hoCassetteACompleteAlert;

        [MonitoredItem(nodeId: "ns=4;s=Stn10_10_Main.hoCassetteBCompleteAlert")]
        public bool hoCassetteBCompleteAlert
        {
            get => _hoCassetteBCompleteAlert;
            set => SetProperty(ref _hoCassetteBCompleteAlert, value);
        }

        private bool _hoCassetteBCompleteAlert;

        [MonitoredItem(nodeId: "ns=4;s=Stn10_11_Robot.APIOut.Connected")]
        public bool RobotConnected
        {
            get => _RobotConnected;
            set => SetProperty(ref _RobotConnected, value);
        }

        private bool _RobotConnected;

        [MonitoredItem(nodeId: "ns=4;s=Stn10_12_Aligner.APIOut.Connected")]
        public bool AlignerConnected
        {
            get => _AlignerConnected;
            set => SetProperty(ref _AlignerConnected, value);
        }

        private bool _AlignerConnected;

        [MonitoredItem(nodeId: "ns=4;s=Stn10_13_Laser.APIOut.Connected")]
        public bool LaserReady
        {
            get => _LaserReady;
            set => SetProperty(ref _LaserReady, value);
        }

        private bool _LaserReady;

        [MonitoredItem(nodeId: "ns=4;s=Stn10_15_TopCamera.APIOut.Connected")]
        public bool TopCameraConnected
        {
            get => _TopCameraConnected;
            set => SetProperty(ref _TopCameraConnected, value);
        }

        private bool _TopCameraConnected;

        [MonitoredItem(nodeId: "ns=4;s=Stn10_14_BottomCamera.APIOut.Connected")]
        public bool BottomCameraConnected
        {
            get => _BottomCameraConnected;
            set => SetProperty(ref _BottomCameraConnected, value);
        }

        private bool _BottomCameraConnected;

        [MonitoredItem(nodeId: "ns=4;s=Stn10_17_SMIFPodRt.iRightLoadPlusReady")]
        public bool RightLoaderReady
        {
            get { return _RightLoaderReady; }
            set { SetProperty(ref _RightLoaderReady, value); }
        }
        private bool _RightLoaderReady;

        [MonitoredItem(nodeId: "ns=4;s=Stn10_16_SMIFPodLt.iLeftLoadPlusReady")]
        public bool LeftLoaderReady
        {
            get { return _LeftLoaderReady; }
            set { SetProperty (ref _LeftLoaderReady, value); }
        }
        private bool _LeftLoaderReady;

        public void SetRecipe(string cassette, Recipe.RecipeModel recipe)
        {
            switch (cassette)
            {
                case "A":
                    hiCassetteARecipe = new(recipe);
                    break;
                case "B":
                    hiCassetteBRecipe = new(recipe);
                    break;
                default:
                    return;
            }
        }

        [MonitoredItem(nodeId: "ns=4;s=Stn10_10_Main.hiCassetteARecipe")]
        public TypeLibrary.stRecipe hiCassetteARecipe
        {
            get => _hiCassetteARecipe;
            set => SetProperty(ref _hiCassetteARecipe, value);
        }
        private TypeLibrary.stRecipe _hiCassetteARecipe = new();

        [MonitoredItem(nodeId: "ns=4;s=Stn10_10_Main.hiSetCassetteARecipe")]
        public bool hiSetCassetteARecipe
        {
            get => _hiSetCassetteARecipe;
            set => SetProperty(ref _hiSetCassetteARecipe, value);
        }
        private bool _hiSetCassetteARecipe;

        [MonitoredItem(nodeId: "ns=4;s=Stn10_10_Main.hoCassetteARecipe")]
        public string hoCassetteARecipe
        {
            get => _hoCassetteARecipe;
            set => SetProperty(ref _hoCassetteARecipe, value);
        }
        private string _hoCassetteARecipe = string.Empty;

        [MonitoredItem(nodeId: "ns=4;s=Stn10_10_Main.hiCassetteBRecipe")]
        public TypeLibrary.stRecipe hiCassetteBRecipe
        {
            get => _hiCassetteBRecipe;
            set => SetProperty(ref _hiCassetteBRecipe, value);
        }
        private TypeLibrary.stRecipe _hiCassetteBRecipe = new();

        [MonitoredItem(nodeId: "ns=4;s=Stn10_10_Main.hiSetCassetteBRecipe")]
        public bool hiSetCassetteBRecipe
        {
            get => _hiSetCassetteBRecipe;
            set => SetProperty(ref _hiSetCassetteBRecipe, value);
        }
        private bool _hiSetCassetteBRecipe;

        [MonitoredItem(nodeId: "ns=4;s=Stn10_10_Main.hoCassetteBRecipe")]
        public string hoCassetteBRecipe
        {
            get => _hoCassetteBRecipe;
            set => SetProperty(ref _hoCassetteBRecipe, value);
        }
        private string _hoCassetteBRecipe = string.Empty;

        [MonitoredItem(nodeId: "ns=4;s=Stn10_20_GEM.hoRemoteMode")]
        public bool NotRemoteMode
        {
            get => !_NotRemoteMode;
            set => SetProperty(ref _NotRemoteMode, value);
        }
        private bool _NotRemoteMode;

        [MonitoredItem(nodeId: "ns=4;s=Stn10_10_Main.hoRecipeALaserJob")]
        public string hoRecipeALaserJob
        {
            get => _hoRecipeAALaserJob;
            set => SetProperty(ref _hoRecipeAALaserJob, value);
        }
        private string _hoRecipeAALaserJob = string.Empty;


        [MonitoredItem(nodeId: "ns=4;s=Stn10_10_Main.hoRecipeBLaserJob")]
        public string hoRecipeBLaserJob
        {
            get => _hoRecipeBLaserJob;
            set => SetProperty(ref _hoRecipeBLaserJob, value);
        }
        private string _hoRecipeBLaserJob = string.Empty;
    }

    public partial class MainModel
    {
        [MonitoredItem("ns=4;s=Stn10_10_Main.iCassetteAPresent")]
        public bool CassetteAPresent
        {
            get => _CassetteAPresent;
            set => SetProperty(ref _CassetteAPresent, value);
        }

        private bool _CassetteAPresent;

        [MonitoredItem("ns=4;s=Stn10_10_Main.iCassetteBPresent")]
        public bool CassetteBPresent
        {
            get => _CassetteBPresent;
            set => SetProperty(ref _CassetteBPresent, value);
        }

        private bool _CassetteBPresent;

        [MonitoredItem(nodeId: "ns=4;s=Stn10_00_ModeControl.iEMOMaintenanceStatus")]
        public bool iEMOButtonFront
        {
            get => _iEMOButtonFront;
            set => SetProperty(ref _iEMOButtonFront, value);
        }

        private bool _iEMOButtonFront;

        [MonitoredItem(nodeId: "ns=4;s=Stn10_00_ModeControl.iEMORearStatus")]
        public bool iEMOButtonRight
        {
            get => _iEMOButtonRight;
            set => SetProperty(ref _iEMOButtonRight, value);
        }

        private bool _iEMOButtonRight;

        [MonitoredItem(nodeId: "ns=4;s=Stn10_00_ModeControl.iEMOOperatorStatus")]
        public bool iEMOButtonLeft
        {
            get => _iEMOButtonLeft;
            set => SetProperty(ref _iEMOButtonLeft, value);
        }

        private bool _iEMOButtonLeft;

        [MonitoredItem(nodeId: "ns=4;s=Stn10_00_ModeControl.iEMOElectricalStatus")]
        public bool iEMOButtonBack
        {
            get => _iEMOButtonBack;
            set => SetProperty(ref _iEMOButtonBack, value);
        }

        private bool _iEMOButtonBack;

        [MonitoredItem(nodeId: "ns=4;s=Stn10_10_Main.iDoorFrontLeftOpen")]
        public bool iDoorFrontLeftOpen
        {
            get => _iDoorFrontLeftOpen;
            set => SetProperty(ref _iDoorFrontLeftOpen, value);
        }

        private bool _iDoorFrontLeftOpen;

        [MonitoredItem(nodeId: "ns=4;s=Stn10_10_Main.iDoorFrontRightOpen")]
        public bool iDoorFrontRightOpen
        {
            get => _iDoorFrontRightOpen;
            set => SetProperty(ref _iDoorFrontRightOpen, value);
        }

        private bool _iDoorFrontRightOpen;

        [MonitoredItem(nodeId: "ns=4;s=Stn10_10_Main.iDoorSideLeftOpen")]
        public bool iDoorSideLeftOpen
        {
            get => _iDoorSideLeftOpen;
            set => SetProperty(ref _iDoorSideLeftOpen, value);
        }

        private bool _iDoorSideLeftOpen;

        [MonitoredItem(nodeId: "ns=4;s=Stn10_10_Main.iDoorSideRightOpen")]
        public bool iDoorSideRightOpen
        {
            get => _iDoorSideRightOpen;
            set => SetProperty(ref _iDoorSideRightOpen, value);
        }

        private bool _iDoorSideRightOpen;

        [MonitoredItem(nodeId: "ns=4;s=Stn10_10_Main.iLoadDoorOpen")]
        public bool iLoadDoorOpen
        {
            get => _iLoadDoorOpen;
            set => SetProperty(ref _iLoadDoorOpen, value);
        }
        private bool _iLoadDoorOpen;

        [MonitoredItem(nodeId: "ns=4;s=Stn10_10_Main.iDoorTopOpen")]
        public bool iDoorTopOpen
        {
            get => _iDoorTopOpen;
            set => SetProperty(ref _iDoorTopOpen, value);
        }

        private bool _iDoorTopOpen;
    }
}