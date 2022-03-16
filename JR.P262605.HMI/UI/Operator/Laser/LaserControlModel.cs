using Workstation.ServiceModel.Ua;

namespace JR.P262605.HMI.UI.Operator.Laser
{
    [Subscription(endpointUrl: "PLC", publishingInterval: 250)]
    public class LaserControlModel : SubscriptionBase
    {
        public LaserControlModel() : base()
        {
        }

        [MonitoredItem(nodeId: "ns=4;s=Stn10_13_Laser.hiMeasureProcess")]
        public bool hiMeasureProcess
        {
            get => _hiMeasureProcess;
            set => SetProperty(ref _hiMeasureProcess, value);
        }

        private bool _hiMeasureProcess;

        [MonitoredItem(nodeId: "ns=4;s=Stn10_13_Laser.hiMeasureStart")]
        public bool hiMeasureStart
        {
            get => _hiMeasureStart;
            set => SetProperty(ref _hiMeasureStart, value);
        }

        private bool _hiMeasureStart;

        [MonitoredItem(nodeId: "ns=4;s=Stn10_13_Laser.hiMeasurePEC")]
        public double hiMeasurePEC
        {
            get => _hiMeasurePEC;
            set => SetProperty(ref _hiMeasurePEC, value);
        }

        private double _hiMeasurePEC;

        [MonitoredItem(nodeId: "ns=4;s=Stn10_13_Laser.hiMeasurePRF")]
        public int hiMeasurePRF
        {
            get => _hiMeasurePRF;
            set => SetProperty(ref _hiMeasurePRF, value);
        }

        private int _hiMeasurePRF;

        [MonitoredItem(nodeId: "ns=4;s=Stn10_13_Laser.hiMeasureATT")]
        public double hiMeasureATT
        {
            get => _hiMeasureATT;
            set => SetProperty(ref _hiMeasureATT, value);
        }

        private double _hiMeasureATT;

        [MonitoredItem(nodeId: "ns=4;s=Stn10_13_Laser.hiMeasureTAR")]
        public double hiMeasureTAR
        {
            get => _hiMeasureTAR;
            set => SetProperty(ref _hiMeasureTAR, value);
        }

        private double _hiMeasureTAR;

        [MonitoredItem(nodeId: "ns=4;s=Stn10_13_Laser.hiMarkIDSet")]
        public bool hiMarkIDSet
        {
            get => _hiMarkIDSet;
            set => SetProperty(ref _hiMarkIDSet, value);
        }

        private bool _hiMarkIDSet;

        [MonitoredItem(nodeId: "ns=4;s=Stn10_13_Laser.hiMarkID")]
        public string hiMarkID
        {
            get => _hiMarkID;
            set => SetProperty(ref _hiMarkID, value);
        }

        private string _hiMarkID;

        [MonitoredItem(nodeId: "ns=4;s=Stn10_13_Laser.hiWaferMarkIDSet")]
        public bool hiWaferMarkIDSet
        {
            get => _hiWaferMarkIDSet;
            set => SetProperty(ref _hiWaferMarkIDSet, value);
        }

        private bool _hiWaferMarkIDSet;


        [MonitoredItem(nodeId: "ns=4;s=Stn10_13_Laser.hiRecipeSet")]
        public bool hiRecipeSet
        {
            get => _hiRecipeSet;
            set => SetProperty(ref _hiRecipeSet, value);
        }

        private bool _hiRecipeSet;

        [MonitoredItem(nodeId: "ns=4;s=Stn10_13_Laser.hiWaferRecipeSet")]
        public bool hiWaferRecipeSet
        {
            get => _hiWaferRecipeSet;
            set => SetProperty(ref _hiWaferRecipeSet, value);
        }

        private bool _hiWaferRecipeSet;

        [MonitoredItem(nodeId: "ns=4;s=Stn10_13_Laser.hiSelectedRecipe")]
        public string hiSelectedRecipe
        {
            get => _hiSelectedRecipe;
            set => SetProperty(ref _hiSelectedRecipe, value);
        }

        private string _hiSelectedRecipe;

        [MonitoredItem(nodeId: "ns=4;s=Stn10_13_Laser.hiRecipeStart")]
        public bool hiRecipeStart
        {
            get => _hiRecipeStart;
            set => SetProperty(ref _hiRecipeStart, value);
        }

        private bool _hiRecipeStart;

        [MonitoredItem(nodeId: "ns=4;s=Stn10_13_Laser.hiAbort")]
        public bool hiAbort
        {
            get => _hiAbort;
            set => SetProperty(ref _hiAbort, value);
        }

        private bool _hiAbort;

        [MonitoredItem(nodeId: "ns=4;s=Stn10_13_Laser.hoWaferRecipe")]
        public string hoWaferRecipe
        {
            get => _hoWaferRecipe;
            set => SetProperty(ref _hoWaferRecipe, value);
        }

        private string _hoWaferRecipe;

        [MonitoredItem(nodeId: "ns=4;s=Stn10_13_Laser.hoWaferMarkID")]
        public string hoWaferMarkID
        {
            get => _hoWaferMarkID;
            set => SetProperty(ref _hoWaferMarkID, value);
        }

        private string _hoWaferMarkID;

        [MonitoredItem(nodeId: "ns=4;s=Stn10_13_Laser.hoMarkID")]
        public string hoMarkID
        {
            get => _hoMarkID;
            set => SetProperty(ref _hoMarkID, value);
        }

        private string _hoMarkID;

        [MonitoredItem(nodeId: "ns=4;s=Stn10_13_Laser.hoManualMode")]
        public bool hoManualMode
        {
            get => _hoManualMode;
            set => SetProperty(ref _hoManualMode, value);
        }

        private bool _hoManualMode;

        [MonitoredItem(nodeId: "ns=4;s=Stn10_13_Laser.hoMeasurePower")]
        public double hoMeasurePower
        {
            get => _hoMeasurePower;
            set => SetProperty(ref _hoMeasurePower, value);
        }
        private double _hoMeasurePower;


        [MonitoredItem(nodeId: "ns=4;s=Stn10_13_Laser.hoLaserFireReady")]
        public bool hoLaserFireReady
        {
            get => _hoLaserFireReady;
            set => SetProperty(ref _hoLaserFireReady, value);
        }

        private bool _hoLaserFireReady;

        [MonitoredItem(nodeId: "ns=4;s=Stn10_13_Laser.APIOut")]
        public TypeLibrary.LaserAPIOut APIOut
        {
            get => _APIOut;
            set => SetProperty(ref _APIOut, value);
        }
        private TypeLibrary.LaserAPIOut _APIOut = new();

        [MonitoredItem(nodeId: "ns=4;s=Stn10_13_Laser.hoLaserBusy")]
        public bool hoLaserBusy
        {
            get => _hoLaserBusy;
            set => SetProperty(ref _hoLaserBusy, value);
        }
        private bool _hoLaserBusy = false;
    }
}