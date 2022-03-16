using JR.ADS;

namespace JR.P262605.API.Aligner.API
{
    public class AlignerAPIIn : AdsTag
    {
        public AlignerAPIIn(string name) : base(name)
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

        public int Command
        {
            get => _Command;
            set => SetProperty(ref _Command, value);
        }

        private int _Command;

        public int Data1
        {
            get => _Data1;
            set => SetProperty(ref _Data1, value);
        }

        private int _Data1;

        public int Data2
        {
            get => _Data2;
            set => SetProperty(ref _Data2, value);
        }

        private int _Data2;

        public int Data3
        {
            get => _Data3;
            set => SetProperty(ref _Data3, value);
        }

        private int _Data3;

        public int Data4
        {
            get => _Data4;
            set => SetProperty(ref _Data4, value);
        }

        private int _Data4;
    }
}