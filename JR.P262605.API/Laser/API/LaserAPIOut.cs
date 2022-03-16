using JR.ADS;

namespace JR.P262605.API.Laser.API
{
    public class LaserAPIOut : AdsTag
    {
        public LaserAPIOut(string name) : base(name)
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

        public string Error
        {
            get => _Error;
            set => SetProperty(ref _Error, value);
        }
        private string _Error;

        public bool MeasureAck
        {
            get => _MeasureAck;
            set => SetProperty(ref _MeasureAck, value);
        }

        private bool _MeasureAck;

        public bool MeasureDone
        {
            get => _MeasureDone;
            set => SetProperty(ref _MeasureDone, value);
        }

        private bool _MeasureDone;

        public string MeasureError
        {
            get => _MeasureError;
            set => SetProperty(ref _MeasureError, value);
        }

        private string _MeasureError;

        public double MeasureValue
        {
            get => _MeasureValue;
            set => SetProperty(ref _MeasureValue, value);
        }

        private double _MeasureValue;

        public bool MarkIDSetDone
        {
            get => _MarkIDSetDone;
            set => SetProperty(ref _MarkIDSetDone, value);
        }
        private bool _MarkIDSetDone;

        public string MarkID
        {
            get => _MarkID;
            set => SetProperty(ref _MarkID, value);
        }
        private string _MarkID;

        public bool RecipeSetDone
        {
            get => _RecipeSetDone;
            set => SetProperty(ref _RecipeSetDone, value);
        }

        private bool _RecipeSetDone;

        public bool ProcessStartAck
        {
            get => _ProcessStartAck;
            set => SetProperty(ref _ProcessStartAck, value);
        }

        private bool _ProcessStartAck;

        public bool ProcessAbortDone
        {
            get => _ProcessAbortDone;
            set => SetProperty(ref _ProcessAbortDone, value);
        }

        private bool _ProcessAbortDone;

        public bool ProcessDone
        {
            get => _ProcessDone;
            set => SetProperty(ref _ProcessDone, value);
        }

        private bool _ProcessDone;

        public string ProcessError
        {
            get => _ProcessError;
            set => SetProperty(ref _ProcessError, value);
        }

        private string _ProcessError;

        public bool Heartbeat
        {
            get => _Heartbeat;
            set => SetProperty(ref _Heartbeat, value);
        }
        private bool _Heartbeat;

        public double LaserPEC
        {
            get => _LaserPEC;
            set => SetProperty(ref _LaserPEC, value);
        }

        private double _LaserPEC;

        public double LaserDiodeCurrent
        {
            get => _LaserDiodeCurrent;
            set => SetProperty(ref _LaserDiodeCurrent, value);
        }

        private double _LaserDiodeCurrent;

        public double LaserDiodeVoltage
        {
            get => _LaserDiodeVoltage;
            set => SetProperty(ref _LaserDiodeVoltage, value);
        }

        private double _LaserDiodeVoltage;

        public double LaserDiodeTemp1
        {
            get => _LaserDiodeTemp1;
            set => SetProperty(ref _LaserDiodeTemp1, value);
        }

        private double _LaserDiodeTemp1;

        public double LaserDiodeTemp2
        {
            get => _LaserDiodeTemp2;
            set => SetProperty(ref _LaserDiodeTemp2, value);
        }

        private double _LaserDiodeTemp2;

        public double LaserDiodeTemp3
        {
            get => _LaserDiodeTemp3;
            set => SetProperty(ref _LaserDiodeTemp3, value);
        }

        private double _LaserDiodeTemp3;

        public double LaserSHGTemp
        {
            get => _LaserSHGTemp;
            set => SetProperty(ref _LaserSHGTemp, value);
        }

        private double _LaserSHGTemp;

        public double LaserTHGTemp
        {
            get => _LaserTHGTemp;
            set => SetProperty(ref _LaserTHGTemp, value);
        }

        private double _LaserTHGTemp;

        public double BeamExpanderMag
        {
            get => _BeamExpanderMag;
            set => SetProperty(ref _BeamExpanderMag, value);
        }

        private double _BeamExpanderMag;

        public double AttenuatorPower
        {
            get => _AttenuatorPower;
            set => SetProperty(ref _AttenuatorPower, value);
        }

        private double _AttenuatorPower;

        public double ScannerPosX
        {
            get => _ScannerPosX;
            set => SetProperty(ref _ScannerPosX, value);
        }

        private double _ScannerPosX;

        public double ScannerPosY
        {
            get => _ScannerPosY;
            set => SetProperty(ref _ScannerPosY, value);
        }

        private double _ScannerPosY;

        public int ScannerPRF
        {
            get => _ScannerPRF;
            set => SetProperty(ref _ScannerPRF, value);
        }

        private int _ScannerPRF;

        public double ScannerMarkSpeed
        {
            get => _ScannerMarkSpeed;
            set => SetProperty(ref _ScannerMarkSpeed, value);
        }

        private double _ScannerMarkSpeed;

        public double ScannerJumpSpeed
        {
            get => _ScannerJumpSpeed;
            set => SetProperty(ref _ScannerJumpSpeed, value);
        }

        private double _ScannerJumpSpeed;

        public double ScannerMarkDelay
        {
            get => _ScannerMarkDelay;
            set => SetProperty(ref _ScannerMarkDelay, value);
        }

        private double _ScannerMarkDelay;

        public double ScannerJumpDelay
        {
            get => _ScannerJumpDelay;
            set => SetProperty(ref _ScannerJumpDelay, value);
        }

        private double _ScannerJumpDelay;

        public double ScannerPolyDelay
        {
            get => _ScannerPolyDelay;
            set => SetProperty(ref _ScannerPolyDelay, value);
        }

        private double _ScannerPolyDelay;

        public double ScannerLaserOnDelay
        {
            get => _ScannerLaserOnDelay;
            set => SetProperty(ref _ScannerLaserOnDelay, value);
        }

        private double _ScannerLaserOnDelay;

        public double ScannerLaserOffDelay
        {
            get => _ScannerLaserOffDelay;
            set => SetProperty(ref _ScannerLaserOffDelay, value);
        }

        private double _ScannerLaserOffDelay;

        public double LaserInlinePowerRaw
        {
            get => _LaserInlinePowerRaw;
            set => SetProperty(ref _LaserInlinePowerRaw, value);
        }

        private double _LaserInlinePowerRaw;

        public double LaserInlinePower
        {
            get => _LaserInlinePower;
            set => SetProperty(ref _LaserInlinePower, value);
        }

        private double _LaserInlinePower;

        public double LaserWorkpiecePower
        {
            get => _LaserWorkpiecePower;
            set => SetProperty(ref _LaserWorkpiecePower, value);
        }

        private double _LaserWorkpiecePower;

        public string SelectedRecipe
        {
            get => _SelectedRecipe;
            set => SetProperty(ref _SelectedRecipe, value);
        }

        private string _SelectedRecipe;

        public bool PowerStabActive
        {
            get => _PowerStabActive;
            set => SetProperty(ref _PowerStabActive, value);
        }

        private bool _PowerStabActive;

        public bool BeamShaperActive
        {
            get => _BeamShaperActive;
            set => SetProperty(ref _BeamShaperActive, value);
        }

        private bool _BeamShaperActive;

        public int ModuleStatus
        {
            get => _ModuleStatus;
            set => SetProperty(ref _ModuleStatus, value);
        }

        private int _ModuleStatus;

        public string ModuleStatusMessage
        {
            get => _ModuleStatusMessage;
            set => SetProperty(ref _ModuleStatusMessage, value);
        }

        private string _ModuleStatusMessage;

        public bool ModuleReadyToProcess
        {
            get => _ModuleReadyToProcess;
            set => SetProperty(ref _ModuleReadyToProcess, value);
        }

        private bool _ModuleReadyToProcess;

        public bool PLCFaulted
        {
            get => _PLCFaulted;
            set => SetProperty(ref _PLCFaulted, value);
        }

        private bool _PLCFaulted;

        public bool PLCInitalized
        {
            get => _PLCInitalized;
            set => SetProperty(ref _PLCInitalized, value);
        }

        private bool _PLCInitalized;

        public string PLCStatusMessage
        {
            get => _PLCStatusMessage;
            set => SetProperty(ref _PLCStatusMessage, value);
        }

        private string _PLCStatusMessage;

        public bool ScannerFaulted
        {
            get => _ScannerFaulted;
            set => SetProperty(ref _ScannerFaulted, value);
        }

        private bool _ScannerFaulted;

        public bool ScannerInitialized
        {
            get => _ScannerInitalized;
            set => SetProperty(ref _ScannerInitalized, value);
        }

        private bool _ScannerInitalized;

        public string ScannerStatusMessage
        {
            get => _ScannerStatusMessage;
            set => SetProperty(ref _ScannerStatusMessage, value);
        }

        private string _ScannerStatusMessage;

        public bool WeldmarkFaulted
        {
            get => _WeldmarkFaulted;
            set => SetProperty(ref _WeldmarkFaulted, value);
        }

        private bool _WeldmarkFaulted;

        public bool WeldmarkInitialized
        {
            get => _WeldmarkInitialized;
            set => SetProperty(ref _WeldmarkInitialized, value);
        }

        private bool _WeldmarkInitialized;

        public string WeldmarkStatusMessage
        {
            get => _WeldmarkStatusMessage;
            set => SetProperty(ref _WeldmarkStatusMessage, value);
        }

        private string _WeldmarkStatusMessage;

        public bool LaserFaulted
        {
            get => _LaserFaulted;
            set => SetProperty(ref _LaserFaulted, value);
        }

        private bool _LaserFaulted;

        public bool LaserInitialized
        {
            get => _LaserInitialized;
            set => SetProperty(ref _LaserInitialized, value);
        }

        private bool _LaserInitialized;

        public string LaserStatusMessage
        {
            get => _LaserStatusMessage;
            set => SetProperty(ref _LaserStatusMessage, value);
        }

        private string _LaserStatusMessage;

        public bool AxisControlFaulted
        {
            get => _AxisControlFaulted;
            set => SetProperty(ref _AxisControlFaulted, value);
        }

        private bool _AxisControlFaulted;

        public bool AxisControlInitialized
        {
            get => _AxisControlInitialized;
            set => SetProperty(ref _AxisControlInitialized, value);
        }

        private bool _AxisControlInitialized;

        public string AxisControlStatusMessage
        {
            get => _AxisControlStatusMessage;
            set => SetProperty(ref _AxisControlStatusMessage, value);
        }

        private string _AxisControlStatusMessage;

        public bool PowerAttenuatorFaulted
        {
            get => _PowerAttenuatorFaulted;
            set => SetProperty(ref _PowerAttenuatorFaulted, value);
        }

        private bool _PowerAttenuatorFaulted;

        public bool PowerAttenuatorInitialized
        {
            get => _PowerAttenuatorInitialized;
            set => SetProperty(ref _PowerAttenuatorInitialized, value);
        }

        private bool _PowerAttenuatorInitialized;

        public string PowerAttenuatorStatusMessage
        {
            get => _PowerAttenutatorStatusMessage;
            set => SetProperty(ref _PowerAttenutatorStatusMessage, value);
        }

        private string _PowerAttenutatorStatusMessage;

        public bool BeamExpanderFaulted
        {
            get => _BeamExpanderFaulted;
            set => SetProperty(ref _BeamExpanderFaulted, value);
        }

        private bool _BeamExpanderFaulted;

        public bool BeamExpanderInitialized
        {
            get => _BeamExpanderInitialized;
            set => SetProperty(ref _BeamExpanderInitialized, value);
        }

        private bool _BeamExpanderInitialized;

        public string BeamExpanderStatusMessage
        {
            get => _BeamExpanderStatusMessage;
            set => SetProperty(ref _BeamExpanderStatusMessage, value);
        }

        private string _BeamExpanderStatusMessage;

        public bool InlinePowerMeterFaulted
        {
            get => _InlinePowerMeterFaulted;
            set => SetProperty(ref _InlinePowerMeterFaulted, value);
        }

        private bool _InlinePowerMeterFaulted;

        public bool InlinePowerMeterInitialized
        {
            get => _InlinePowerMeterInitialized;
            set => SetProperty(ref _InlinePowerMeterInitialized, value);
        }

        private bool _InlinePowerMeterInitialized;

        public string InlinePowerMeterStatusMessage
        {
            get => _InlinePowerMeterStatusMessage;
            set => SetProperty(ref _InlinePowerMeterStatusMessage, value);
        }

        private string _InlinePowerMeterStatusMessage;

        public bool ProcessPowerMeterFaulted
        {
            get => _ProcessPowerMeterFaulted;
            set => SetProperty(ref _ProcessPowerMeterFaulted, value);
        }

        private bool _ProcessPowerMeterFaulted;

        public bool ProcessPowerMeterInitialized
        {
            get => _ProcessPowerMeterInitialized;
            set => SetProperty(ref _ProcessPowerMeterInitialized, value);
        }

        private bool _ProcessPowerMeterInitialized;

        public string ProcessPowerMeterStatusMessage
        {
            get => _ProcessPowerMeterStatusMessage;
            set => SetProperty(ref _ProcessPowerMeterStatusMessage, value);
        }

        private string _ProcessPowerMeterStatusMessage;
    }
}