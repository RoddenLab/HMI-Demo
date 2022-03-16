using JR.ADS;

namespace JR.P262605.API.Lumetrics.API
{
    public class LumetricsAPIOut : AdsTag
    {
        public LumetricsAPIOut(string name) : base(name)
        {
        }

        public int HeartbeatEcho
        {
            get { return _HeartbeatEcho; }
            set { SetProperty(ref _HeartbeatEcho, value); }
        }

        private int _HeartbeatEcho;

        public bool Connected
        {
            get { return _Connected; }
            set { SetProperty(ref _Connected, value); }
        }

        private bool _Connected;

        public bool Done
        {
            get { return _Done; }
            set { SetProperty(ref _Done, value); }
        }

        private bool _Done;

        public int Error
        {
            get { return _Error; }
            set { SetProperty(ref _Error, value); }
        }

        private int _Error;

        public string Measurement
        {
            get { return _Measurement; }
            set { SetProperty(ref _Measurement, value); }
        }

        private string _Measurement;

        public string MaterialThickness
        {
            get { return _MaterialThickness; }
            set { SetProperty(ref _MaterialThickness, value); }
        }

        private string _MaterialThickness;

        public string RefractiveIndex
        {
            get { return _RefractiveIndex; }
            set { SetProperty(ref _RefractiveIndex, value); }
        }

        private string _RefractiveIndex;

        public void ResetHandshake()
        {
            Done = false;
            Error = 0;
        }
    }
}