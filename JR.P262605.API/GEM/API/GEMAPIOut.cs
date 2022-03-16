using JR.ADS;

namespace JR.P262605.API.GEM.API
{
    public class GEMAPIOut : AdsTag
    {
        public GEMAPIOut(string name) : base(name) { }

        public int HeartbeatEcho
        {
            get => _HeartbeatEcho;
            set => SetProperty(ref _HeartbeatEcho, value);
        }
        private int _HeartbeatEcho = 0;

        public bool Done
        {
            get => _Done;
            set => SetProperty(ref _Done, value);
        }
        private bool _Done = false;

        public bool Error
        {
            get => _Error;
            set => SetProperty(ref _Error, value);
        }
        private bool _Error = false;

        public string Nest
        {
            get => _Nest;
            set => SetProperty(ref _Nest, value);
        }
        private string _Nest = string.Empty;

        public bool RepeatCassette
        {
            get => _RepeatCassette;
            set => SetProperty(ref _RepeatCassette, value);
        }
        private bool _RepeatCassette = false;

        public bool ScanCassette
        {
            get => _ScanCassette;
            set => SetProperty(ref _ScanCassette, value);
        }
        private bool _ScanCassette = false;

        public string LaserJob
        {
            get => _LaserJob;
            set => SetProperty(ref _LaserJob, value);
        }
        private string _LaserJob = string.Empty;

        public bool AlignWafers
        {
            get => _AlignWafers;
            set => SetProperty(ref _AlignWafers, value);
        }
        private bool _AlignWafers = false;

        public bool GoToAligner
        {
            get => _GoToAligner;
            set => SetProperty(ref _GoToAligner, value);
        }
        private bool _GoToAligner = false;

        public bool GoToBottomOCR
        {
            get => _GoToBottomOCR;
            set => SetProperty(ref _GoToBottomOCR, value);
        }
        private bool _GoToBottomOCR = false;

        public bool GoToLaser
        {
            get => _GoToLaser;
            set => SetProperty(ref _GoToLaser, value);
        }
        private bool _GoToLaser = false;

        public bool GoToLumetrics
        {
            get => _GoToLumetrics;
            set => SetProperty(ref _GoToLumetrics, value);
        }
        private bool _GoToLumetrics = false;

        public bool GoToTopOCR
        {
            get => _GoToTopOCR;
            set => SetProperty(ref _GoToTopOCR, value);
        }
        private bool _GoToTopOCR = false;

        public bool LazyOCRSearch
        {
            get => _LazyOCRSearch;
            set => SetProperty(ref _LazyOCRSearch, value);
        }
        private bool _LazyOCRSearch = false;

        public bool AnnealWafer
        {
            get => _AnnealWafer;
            set => SetProperty(ref _AnnealWafer, value);
        }
        private bool _AnnealWafer = false;

        public bool MeasureAfter
        {
            get => _MeasureAfter;
            set => SetProperty(ref _MeasureAfter, value);
        }
        private bool _MeasureAfter = false;

        public bool MeasureBefore
        {
            get => _MeasureBefore;
            set => SetProperty(ref _MeasureBefore, value);
        }
        private bool _MeasureBefore = false;

        public double MinimumPower
        {
            get => _MinimumPower;
            set => SetProperty(ref _MinimumPower, value);
        }
        private double _MinimumPower = 0.0;

        public double MaximumPower
        {
            get => _MaximumPower;
            set => SetProperty(ref _MaximumPower, value);
        }
        private double _MaximumPower = 0.0;

        public bool StopOnPowerOOR
        {
            get => _StopOnPowerOOR;
            set => SetProperty(ref _StopOnPowerOOR, value);
        }
        private bool _StopOnPowerOOR = false;

        public bool ReadBottomOCR
        {
            get => _ReadBottomOCR;
            set => SetProperty(ref _ReadBottomOCR, value);
        }
        private bool _ReadBottomOCR = false;

        public bool StopOnBottomReadFail
        {
            get => _StopOnBottomReadFail;
            set => SetProperty(ref _StopOnBottomReadFail, value);
        }
        private bool _StopOnBottomReadFail = false;

        public bool ReadTopOCR
        {
            get => _ReadTopOCR;
            set => SetProperty(ref _ReadTopOCR, value);
        }
        private bool _ReadTopOCR = false;

        public bool StopOnTopReadFail
        {
            get => _StopOnTopReadFail;
            set => SetProperty(ref _StopOnTopReadFail, value);
        }
        private bool _StopOnTopReadFail = false;

        public bool StopOnWaferMapMismatch
        {
            get { return _StopOnWaferMapMismatch; }
            set { SetProperty(ref _StopOnWaferMapMismatch, value); }
        }
        private bool _StopOnWaferMapMismatch;

        public string RecipePath
        {
            get => _RecipePath;
            set => SetProperty(ref _RecipePath, value);
        }
        private string _RecipePath = string.Empty;

        public void ResetHandshake()
        {
            Done = false;
            Nest = string.Empty;
            Error = false;
            RepeatCassette = false;
            ScanCassette = false;
            LaserJob = string.Empty;
            AlignWafers = false;
            GoToAligner = false;
            GoToBottomOCR = false;
            GoToLaser = false;
            GoToLumetrics = false;
            GoToTopOCR = false;
            LazyOCRSearch = false;
            AnnealWafer = false;
            MeasureAfter = false;
            MeasureBefore = false;
            MinimumPower = 0.0;
            MaximumPower = 0.0;
            StopOnPowerOOR = false;
            ReadBottomOCR = false;
            StopOnBottomReadFail = false;
            ReadTopOCR = false;
            StopOnTopReadFail = false;
            StopOnWaferMapMismatch = false;
            RecipePath = string.Empty;
        }
    }
}
