using JR.ADS;

namespace JR.P262605.API.Lumetrics.API
{
    public class LumetricsAPIIn : AdsTag
    {
        public LumetricsAPIIn(string name) : base(name)
        {
        }

        public int Heartbeat
        {
            get => _Heartbeat;
            set => SetProperty(ref _Heartbeat, value);
        }
        private int _Heartbeat;

        public bool Start
        {
            get => _Start;
            set => SetProperty(ref _Start, value);
        }
        private bool _Start;
    }
}
