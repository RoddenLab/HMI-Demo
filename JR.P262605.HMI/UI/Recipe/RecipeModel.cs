using JR.WPF;

namespace JR.P262605.HMI.UI.Recipe
{
    public class RecipeModel : BindableBase
    {
        public bool RepeatCassette
        {
            get => _RepeatCassette;
            set => SetProperty(ref _RepeatCassette, value);
        }
        private bool _RepeatCassette;

        public bool ScanCassette
        {
            get => _ScanCassette;
            set => SetProperty(ref _ScanCassette, value);
        }
        private bool _ScanCassette;

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
        private bool _AlignWafers;

        public bool GoToAligner
        {
            get => _GoToAligner;
            set => SetProperty(ref _GoToAligner, value);
        }
        private bool _GoToAligner;

        public bool GoToBottomOCR
        {
            get => _GoToBottomOCR; set => SetProperty(ref _GoToBottomOCR, value);
        }
        private bool _GoToBottomOCR;
        public bool GoToLaser { get => _GoToLaser; set => SetProperty(ref _GoToLaser, value); }
        private bool _GoToLaser;
        public bool GoToLumetrics { get => _GoToLumetrics; set => SetProperty(ref _GoToLumetrics, value); }
        private bool _GoToLumetrics;
        public bool GoToTopOCR { get => _GoToTopOCR; set => SetProperty(ref _GoToTopOCR, value); }
        private bool _GoToTopOCR;
        public bool LazyOCRSearch { get => _LazyOCRSearch; set => SetProperty(ref _LazyOCRSearch, value); }
        private bool _LazyOCRSearch;
        public bool AnnealWafer { get => _AnnealWafer; set => SetProperty(ref _AnnealWafer, value); }
        private bool _AnnealWafer;
        public bool MeasureAfter { get => _MeasureAfter; set => SetProperty(ref _MeasureAfter, value); }
        private bool _MeasureAfter;
        public bool MeasureBefore { get => _MeasureBefore; set => SetProperty(ref _MeasureBefore, value); }
        private bool _MeasureBefore;
        public double MinimumPower { get => _MinimumPower; set => SetProperty(ref _MinimumPower, value); }
        private double _MinimumPower;
        public double MaximumPower { get => _MaximumPower; set => SetProperty(ref _MaximumPower, value); }
        private double _MaximumPower;
        public bool StopOnPowerOOR { get => _StopOnPowerOOR; set => SetProperty(ref _StopOnPowerOOR, value); }
        private bool _StopOnPowerOOR;
        public bool ReadBottomOCR { get => _ReadBottomOCR; set => SetProperty(ref _ReadBottomOCR, value); }
        private bool _ReadBottomOCR;
        public bool StopOnBottomReadFail { get => _StopOnBottomReadFail; set => SetProperty(ref _StopOnBottomReadFail, value); }
        private bool _StopOnBottomReadFail;
        public bool ReadTopOCR { get => _ReadTopOCR; set => SetProperty(ref _ReadTopOCR, value); }
        private bool _ReadTopOCR;
        public bool StopOnTopReadFail { get => _StopOnTopReadFail; set => SetProperty(ref _StopOnTopReadFail, value); }
        private bool _StopOnTopReadFail;
        public bool StopOnWaferMapMismatch
        {
            get { return _StopOnWaferMapMismatch; }
            set { SetProperty(ref _StopOnWaferMapMismatch, value); }
        }
        private bool _StopOnWaferMapMismatch; 

        public string RecipePath { get => _RecipePath; set => SetProperty(ref _RecipePath, value); }
        private string _RecipePath = string.Empty;

        public void SetData(RecipeModel other)
        {
            RepeatCassette = other.RepeatCassette;
            ScanCassette = other.ScanCassette;
            LaserJob = other.LaserJob;
            AlignWafers = other.AlignWafers;
            GoToAligner = other.GoToAligner;
            GoToBottomOCR = other.GoToBottomOCR;
            GoToLaser = other.GoToLaser;
            GoToLumetrics = other.GoToLumetrics;
            GoToTopOCR = other.GoToTopOCR;
            LazyOCRSearch = other.LazyOCRSearch;
            AnnealWafer = other.AnnealWafer;
            MeasureAfter = other.MeasureAfter;
            MeasureBefore = other.MeasureBefore;
            MinimumPower = other.MinimumPower;
            MaximumPower = other.MaximumPower;
            StopOnPowerOOR = other.StopOnPowerOOR;
            ReadBottomOCR = other.ReadBottomOCR;
            StopOnBottomReadFail = other.StopOnBottomReadFail;
            ReadTopOCR = other.ReadTopOCR;
            StopOnTopReadFail = other.StopOnTopReadFail;
            StopOnWaferMapMismatch = other.StopOnWaferMapMismatch;
            RecipePath = other.RecipePath;
        }
    }
}
