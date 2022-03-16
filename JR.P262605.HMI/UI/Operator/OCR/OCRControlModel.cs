using Workstation.ServiceModel.Ua;

namespace JR.P262605.HMI.UI.Operator.OCR
{
    [Subscription(endpointUrl: "PLC", publishingInterval: 250)]
    public class OCRControlModel : SubscriptionBase
    {
        [MonitoredItem(nodeId: "ns=4;s=Stn10_15_TopCamera.hiReadOCR")]
        public bool hiReadTopOCR
        {
            get => _hiReadTopOCR;
            set => SetProperty(ref _hiReadTopOCR, value);
        }

        private bool _hiReadTopOCR;

        [MonitoredItem(nodeId: "ns=4;s=Stn10_15_TopCamera.hoOCRString")]
        public string hoTopOCRString
        {
            get => _hoTopOCRString;
            set => SetProperty(ref _hoTopOCRString, value);
        }

        private string _hoTopOCRString;

        [MonitoredItem(nodeId: "ns=4;s=Stn10_14_BottomCamera.hiReadOCR")]
        public bool hiReadBottomOCR
        {
            get => _hiReadBottomOCR;
            set => SetProperty(ref _hiReadBottomOCR, value);
        }

        private bool _hiReadBottomOCR;

        [MonitoredItem(nodeId: "ns=4;s=Stn10_14_BottomCamera.hoOCRString")]
        public string hoBottomOCRString
        {
            get => _hoBottomOCRString;
            set => SetProperty(ref _hoBottomOCRString, value);
        }

        private string _hoBottomOCRString;

        [MonitoredItem(nodeId: "ns=4;s=Stn10_15_TopCamera.APIOut")]
        public TypeLibrary.VisionAPIOut TopAPIOut
        {
            get => _TopAPIOut;
            set => SetProperty(ref _TopAPIOut, value);
        }
        private TypeLibrary.VisionAPIOut _TopAPIOut = new();

        [MonitoredItem(nodeId: "ns=4;s=Stn10_14_BottomCamera.APIOut")]
        public TypeLibrary.VisionAPIOut BottomAPIOut
        {
            get => _BottomAPIOut;
            set => SetProperty(ref _BottomAPIOut, value);
        }
        private TypeLibrary.VisionAPIOut _BottomAPIOut = new();

        [MonitoredItem(nodeId: "ns=4;s=Stn10_15_TopCamera.hoOCRBusy")]
        public bool hoTopOCRBusy
        {
            get => _hoTopOCRBusy;
            set => SetProperty(ref _hoTopOCRBusy, value);
        }
        private bool _hoTopOCRBusy = false;


        [MonitoredItem(nodeId: "ns=4;s=Stn10_14_BottomCamera.hoOCRBusy")]
        public bool hoBottomOCRBusy
        {
            get => _hoBottomOCRBusy;
            set => SetProperty(ref _hoBottomOCRBusy, value);
        }
        private bool _hoBottomOCRBusy = false;
    }
}