using Workstation.ServiceModel.Ua;

namespace JR.P262605.HMI.UI.Operator.Aligner
{
    [Subscription(endpointUrl: "PLC", publishingInterval: 250)]
    public class AlignerControlModel : SubscriptionBase
    {
        [MonitoredItem(nodeId: "ns=4;s=Stn10_12_Aligner.hiResetAPI")]
        public bool hiResetAPI
        {
            get => _hiResetAPI;
            set => SetProperty(ref _hiResetAPI, value);
        }

        private bool _hiResetAPI;

        [MonitoredItem(nodeId: "ns=4;s=Stn10_12_Aligner.hiRemoveWafer")]
        public bool hiWaferRemoved
        {
            get => _hiWaferRemoved;
            set => SetProperty(ref _hiWaferRemoved, value);
        }

        private bool _hiWaferRemoved;

        [MonitoredItem(nodeId: "ns=4;s=Stn10_12_Aligner.hiAlignWafer")]
        public bool hiAlignWafer
        {
            get => _hiAlignWafer;
            set => SetProperty(ref _hiAlignWafer, value);
        }

        private bool _hiAlignWafer;

        [MonitoredItem(nodeId: "ns=4;s=Stn10_12_Aligner.hiPollStatus")]
        public bool hiPollStatus
        {
            get => _hiPollStatus;
            set => SetProperty(ref _hiPollStatus, value);
        }

        private bool _hiPollStatus;

        [MonitoredItem(nodeId: "ns=4;s=Stn10_12_Aligner.hiServoOn")]
        public bool hiServoOn
        {
            get => _hiServoOn;
            set => SetProperty(ref _hiServoOn, value);
        }

        private bool _hiServoOn;

        [MonitoredItem(nodeId: "ns=4;s=Stn10_12_Aligner.hiHome")]
        public bool hiHome
        {
            get => _hiHome;
            set => SetProperty(ref _hiHome, value);
        }

        private bool _hiHome;

        [MonitoredItem(nodeId: "ns=4;s=Stn10_12_Aligner.hoManualMode")]
        public bool hoManualMode
        {
            get => _hoManualMode;
            set => SetProperty(ref _hoManualMode, value);
        }
        private bool _hoManualMode;

        [MonitoredItem(nodeId: "ns=4;s=Stn10_12_Aligner.hoWaferPresent")]
        public bool hoWaferPresent
        {
            get => _hoWaferPresent;
            set => SetProperty(ref _hoWaferPresent, value);
        }

        private bool _hoWaferPresent;

        [MonitoredItem(nodeId: "ns=4;s=Stn10_12_Aligner.hoWafer")]
        public TypeLibrary.Wafer Wafer
        {
            get => _Wafer;
            set => SetProperty(ref _Wafer, value);
        }
        private TypeLibrary.Wafer _Wafer = new();

        [MonitoredItem(nodeId: "ns=4;s=Stn10_12_Aligner.APIOut")]
        public TypeLibrary.AlignerAPIOut APIOut
        {
            get => _APIOut;
            set => SetProperty(ref _APIOut, value);
        }
        private TypeLibrary.AlignerAPIOut _APIOut = new();

        [MonitoredItem(nodeId: "ns=4;s=Stn10_12_Aligner.hoAlignerBusy")]
        public bool hoAlignerBusy
        {
            get => _hoAlignerBusy;
            set => SetProperty(ref _hoAlignerBusy, value);
        }
        private bool _hoAlignerBusy = false;
    }
}