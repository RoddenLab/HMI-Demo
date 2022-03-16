using JR.ADS;

namespace JR.P262605.API.Aligner.API
{
    public class AlignerAPIOut : AdsTag
    {
        public AlignerAPIOut(string name) : base(name)
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

        public bool ChuckVacuumSensor
        {
            get => _ChuckVacuumSensor;
            set => SetProperty(ref _ChuckVacuumSensor, value);
        }

        private bool _ChuckVacuumSensor;

        public bool ChuckVacuumSwitch
        {
            get => _ChuckVacuumSwitch;
            set => SetProperty(ref _ChuckVacuumSwitch, value);
        }

        private bool _ChuckVacuumSwitch;

        public bool MotionError
        {
            get => _MotionError;
            set => SetProperty(ref _MotionError, value);
        }

        private bool _MotionError;

        public bool MotionLimitsViolation
        {
            get => _MotionLimitsViolation;
            set => SetProperty(ref _MotionLimitsViolation, value);
        }

        private bool _MotionLimitsViolation;

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

        public bool MotionInProgress
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

        public bool FileError
        {
            get => _FileError;
            set => SetProperty(ref _FileError, value);
        }

        private bool _FileError;

        public bool PinsVacuumSwitch
        {
            get => _PinsVacuumSwitch;
            set => SetProperty(ref _PinsVacuumSwitch, value);
        }

        private bool _PinsVacuumSwitch;

        public void ResetHandshake()
        {
            StartAckOK = false;
            StartAckNOK = false;
            Done = false;
            Error = 0;
        }
    }
}