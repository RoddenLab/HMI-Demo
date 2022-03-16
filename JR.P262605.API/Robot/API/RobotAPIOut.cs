using JR.ADS;

namespace JR.P262605.API.Robot
{
    public class RobotAPIOut : AdsTag
    {
        public RobotAPIOut(string name) : base(name)
        {

        }

        public int HeartbeatEcho
        {
            get => _HeartbeatEcho;
            set => SetProperty(ref _HeartbeatEcho, value);
        }

        private int _HeartbeatEcho;

        public bool Connected
        {
            get => _Connected;
            set => SetProperty(ref _Connected, value);
        }

        private bool _Connected;

        public bool StartAckOK
        {
            get => _StartAckOK;
            set => SetProperty(ref _StartAckOK, value);
        }

        private bool _StartAckOK;

        public bool StartAckNOK
        {
            get => _StartAckNOK;
            set => SetProperty(ref _StartAckNOK, value);
        }

        private bool _StartAckNOK;

        public bool Done
        {
            get => _Done;
            set => SetProperty(ref _Done, value);
        }

        private bool _Done;

        public int Error
        {
            get => _Error;
            set => SetProperty(ref _Error, value);
        }

        private int _Error;

        public int Data
        {
            get => _Data;
            set => SetProperty(ref _Data, value);
        }

        private int _Data;

        public byte[] Mapping
        {
            get => _Mapping;
            set => SetProperty(ref _Mapping, value);
        }
        private byte[] _Mapping;

        public bool UnableToMove
        {
            get => _UnableToMove;
            set => SetProperty(ref _UnableToMove, value);
        }
        private bool _UnableToMove;


        public bool CommandError
        {
            get => _CommandError;
            set => SetProperty(ref _CommandError, value);
        }
        private bool _CommandError;

        public bool VacuumSensor
        {
            get => _VacuumSensor;
            set => SetProperty(ref _VacuumSensor, value);
        }

        private bool _VacuumSensor;


        public bool MotionError
        {
            get => _MotionError;
            set => SetProperty(ref _MotionError, value);
        }
        private bool _MotionError;


        public bool SoftwareLimit
        {
            get => _SoftwareLimitError;
            set => SetProperty(ref _SoftwareLimitError, value);
        }
        private bool _SoftwareLimitError;

        public bool NotHomed
        {
            get => _NotHomed;
            set => SetProperty(ref _NotHomed, value);
        }
        private bool _NotHomed;

        public bool MacroRunning
        {
            get => _MacroRunning;
            set => SetProperty(ref _MacroRunning, value);
        }
        private bool _MacroRunning;

        public bool InMotion
        {
            get => _MotionInProgress;
            set => SetProperty(ref _MotionInProgress, value);
        }
        private bool _MotionInProgress;

        public bool ServoOff
        {
            get => _ServoOff;
            set => SetProperty(ref _ServoOff, value);
        }
        private bool _ServoOff;

        public bool InTeachMode
        {
            get => _InTeachMode;
            set => SetProperty(ref _InTeachMode, value);
        }
        private bool _InTeachMode;

        public bool InSearchMode
        {
            get => _InSearchMode;
            set => SetProperty(ref _InSearchMode, value);
        }
        private bool _InSearchMode;

        public bool FileError
        {
            get => _FileError;
            set => SetProperty(ref _FileError, value);
        }
        private bool _FileError;

        public bool InTeachScanMode
        {
            get => _InTeachScanMode;
            set => SetProperty(ref _InTeachScanMode, value);
        }
        private bool _InTeachScanMode;

        public bool VacuumSwitch
        {
            get => _VacuumSwitch;
            set => SetProperty(ref _VacuumSwitch, value);
        }

        private bool _VacuumSwitch;

        public string Position
        {
            get => _Position;
            set => SetProperty(ref _Position, value);
        }
        private string _Position = string.Empty;


        public void ResetHandshake()
        {
            StartAckOK = false;
            StartAckNOK = false;
            Done = false;
            Error = 0;
            Data = 0;
        }
    }
}