using JR.ADS;

namespace JR.P262605.API.Vision.API
{
    public class VisionAPIIn : AdsTag
    {
        public VisionAPIIn(string name) : base(name)
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
