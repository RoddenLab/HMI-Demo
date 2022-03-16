using JR.ADS;

namespace JR.P262605.API.Robot
{
    public class RobotAPIIn : AdsTag
    {
        public RobotAPIIn(string name) : base(name)
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

        public string Station
        {
            get => _Station;
            set => SetProperty(ref _Station, value);
        }

        private string _Station = "";

        public int Slot
        {
            get => _Slot;
            set => SetProperty(ref _Slot, value);
        }

        private int _Slot;

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

        public bool Stop
        {
            get => _Stop;
            set => SetProperty(ref _Stop, value);
        }
        private bool _Stop;
    }
}