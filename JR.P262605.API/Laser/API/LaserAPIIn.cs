using JR.ADS;

namespace JR.P262605.API.Laser.API
{
    public class LaserAPIIn : AdsTag
    {
        public LaserAPIIn(string name) : base(name)
        {
        }

        public int Heartbeat
        {
            get => _Heartbeat;
            set => SetProperty(ref _Heartbeat, value);
        }

        private int _Heartbeat;

        public bool ProcessStart
        {
            get => _ProcessStart;
            set => SetProperty(ref _ProcessStart, value);
        }

        private bool _ProcessStart;

        public bool ProcessAbort
        {
            get => _ProcessAbort;
            set => SetProperty(ref _ProcessAbort, value);
        }

        private bool _ProcessAbort;

        public bool MarkIDSet
        {
            get => _MarkIDSet;
            set => SetProperty(ref _MarkIDSet, value);
        }
        private bool _MarkIDSet;

        public string MarkID
        {
            get => _MarkID;
            set => SetProperty(ref _MarkID, value);
        }
        private string _MarkID;

        public bool RecipeSet
        {
            get => _RecipeSet;
            set => SetProperty(ref _RecipeSet, value);
        }

        private bool _RecipeSet;

        public string RecipePath
        {
            get => _RecipePath;
            set => SetProperty(ref _RecipePath, value);
        }

        private string _RecipePath;

        public bool MeasureStart
        {
            get => _MeasureStart;
            set => SetProperty(ref _MeasureStart, value);
        }

        private bool _MeasureStart;

        public double MeasurePEC
        {
            get => _MeasurePEC;
            set => SetProperty(ref _MeasurePEC, value);
        }

        private double _MeasurePEC;

        public int MeasurePRF
        {
            get => _MeasurePRF;
            set => SetProperty(ref _MeasurePRF, value);
        }

        private int _MeasurePRF;

        public double MeasureAttenuator
        {
            get => _MeasureAttenuator;
            set => SetProperty(ref _MeasureAttenuator, value);
        }

        private double _MeasureAttenuator;

        public double MeasureTarget
        {
            get => _MeasureTarget;
            set => SetProperty(ref _MeasureTarget, value);
        }

        private double _MeasureTarget;
    }
}