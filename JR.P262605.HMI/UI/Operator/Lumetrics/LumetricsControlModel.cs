using Workstation.ServiceModel.Ua;

namespace JR.P262605.HMI.UI.Operator.Lumetrics
{
    [Subscription(endpointUrl: "PLC", publishingInterval: 150)]
    public class LumetricsControlModel : SubscriptionBase
    {
        [MonitoredItem(nodeId: "ns=4;s=Stn10_18_Lumetrics.hiReadLumetricsMeasurement")]
        public bool hiReadLumetricsMeasurement
        {
            get => _hiReadLumetricsMeasurement;
            set => SetProperty(ref _hiReadLumetricsMeasurement, value);
        }

        private bool _hiReadLumetricsMeasurement;


        [MonitoredItem(nodeId: "ns=4;s=Stn10_18_Lumetrics.hoLumetricsMeasurement")]
        public string hoLumetricsMeasurement
        {
            get => _hoLumetricsMeasurement;
            set => SetProperty(ref _hoLumetricsMeasurement, value);
        }

        private string _hoLumetricsMeasurement;


        [MonitoredItem(nodeId: "ns=4;s=Stn10_18_Lumetrics.hoConnected")]
        public bool hoConnected
        {
            get => _hoConnected;
            set => SetProperty(ref _hoConnected, value);
        }

        private bool _hoConnected;

        [MonitoredItem(nodeId: "ns=4;s=Stn10_18_Lumetrics.hoDone")]
        public bool hoDone
        {
            get => _hoDone;
            set => SetProperty(ref _hoDone, value);
        }

        private bool _hoDone;

        [MonitoredItem(nodeId: "ns=4;s=Stn10_18_Lumetrics.hoError")]
        public int hoError
        {
            get => _hoError;
            set => SetProperty(ref _hoError, value);
        }

        private int _hoError;

        [MonitoredItem(nodeId: "ns=4;s=Stn10_18_Lumetrics.hoHeartbeatEcho")]
        public int hoHeartbeatEcho
        {
            get => _hoHeartbeatEcho;
            set => SetProperty(ref _hoHeartbeatEcho, value);
        }

        private int _hoHeartbeatEcho;
    }
}
