using JR.ADS;

namespace JR.P262605.API.GEM.API
{
    public class GEMAPIIn : AdsTag
    {
        public GEMAPIIn(string name) : base(name) { }


        public int Heartbeat
        {
            get => _Heartbeat;
            set => SetProperty(ref _Heartbeat, value);
        }
        private int _Heartbeat = 0;

        public bool Start
        {
            get => _Start;
            set => SetProperty(ref _Start, value);
        }
        private bool _Start = false;

        public string RecipePath
        {
            get => _RecipePath;
            set => SetProperty(ref _RecipePath, value);
        }
        private string _RecipePath = string.Empty;

        public string Nest
        {
            get => _Nest;
            set => SetProperty(ref _Nest, value);
        }
        private string _Nest = string.Empty;
    }
}
