using Workstation.ServiceModel.Ua;

namespace JR.P262605.HMI.UI.Operator.Robot
{
    [Subscription(endpointUrl: "PLC", publishingInterval: 250)]
    public partial class RobotControlModel : SubscriptionBase
    {
        public RobotControlModel() : base()
        {
        }

        [MonitoredItem(nodeId: "ns=4;s=Stn10_11_Robot.hiWaferRemoved")]
        public bool hiWaferRemoved
        {
            get => _hiWaferRemoved;
            set => SetProperty(ref _hiWaferRemoved, value);
        }

        private bool _hiWaferRemoved;

        [MonitoredItem(nodeId: "ns=4;s=Stn10_11_Robot.hiResetAPI")]
        public bool hiResetAPI
        {
            get => _hiResetAPI;
            set => SetProperty(ref _hiResetAPI, value);
        }

        private bool _hiResetAPI;

        [MonitoredItem(nodeId: "ns=4;s=Stn10_11_Robot.hiServoOn")]
        public bool hiServoOn
        {
            get => _hiServoOn;
            set => SetProperty(ref _hiServoOn, value);
        }

        private bool _hiServoOn;

        [MonitoredItem(nodeId: "ns=4;s=Stn10_11_Robot.hiServoOff")]
        public bool hiServoOff
        {
            get => _hiServoOff;
            set => SetProperty(ref _hiServoOff, value);
        }
        private bool _hiServoOff;

        [MonitoredItem(nodeId: "ns=4;s=Stn10_11_Robot.hiPollStatus")]
        public bool hiPollStatus
        {
            get => _hiPollStatus;
            set => SetProperty(ref _hiPollStatus, value);
        }

        private bool _hiPollStatus;

        [MonitoredItem(nodeId: "ns=4;s=Stn10_11_Robot.hiHomeRobot")]
        public bool hiHomeRobot
        {
            get => _hiHomeRobot;
            set => SetProperty(ref _hiHomeRobot, value);
        }

        private bool _hiHomeRobot;

        [MonitoredItem(nodeId: "ns=4;s=Stn10_11_Robot.hiVacuumOn")]
        public bool hiVacuumOn
        {
            get => _hiVacuumOn;
            set => SetProperty(ref _hiVacuumOn, value);
        }

        private bool _hiVacuumOn;

        [MonitoredItem(nodeId: "ns=4;s=Stn10_11_Robot.hiVacuumOff")]
        public bool hiVacuumOff
        {
            get => _hiVacuumOff;
            set => SetProperty(ref _hiVacuumOff, value);
        }

        private bool _hiVacuumOff;

        [MonitoredItem(nodeId: "ns=4;s=Stn10_11_Robot.hiStop")]
        public bool hiStop
        {
            get => _hiStop;
            set => SetProperty(ref _hiStop, value);
        }
        private bool _hiStop = false;

        [MonitoredItem(nodeId: "ns=4;s=Stn10_11_Robot.hiMoveToHome")]
        public bool hiMoveToHome
        {
            get => _hiMoveToHome;
            set => SetProperty(ref _hiMoveToHome, value);
        }

        private bool _hiMoveToHome;

        [MonitoredItem(nodeId: "ns=4;s=Stn10_11_Robot.hiPickFromAligner")]
        public bool hiPickFromAligner
        {
            get => _hiPickFromAligner;
            set => SetProperty(ref _hiPickFromAligner, value);
        }

        private bool _hiPickFromAligner;

        [MonitoredItem(nodeId: "ns=4;s=Stn10_11_Robot.hiPlaceToAligner")]
        public bool hiPlaceToAligner
        {
            get => _hiPlaceToAligner;
            set => SetProperty(ref _hiPlaceToAligner, value);
        }

        private bool _hiPlaceToAligner;

        [MonitoredItem(nodeId: "ns=4;s=Stn10_11_Robot.hiPickFromCassetteA")]
        public bool hiPickFromCassetteA
        {
            get => _hiPickFromCassetteA;
            set => SetProperty(ref _hiPickFromCassetteA, value);
        }

        private bool _hiPickFromCassetteA;

        [MonitoredItem(nodeId: "ns=4;s=Stn10_11_Robot.hiPlaceToCassetteA")]
        public bool hiPlaceToCassetteA
        {
            get => _hiPlaceToCassetteA;
            set => SetProperty(ref _hiPlaceToCassetteA, value);
        }

        private bool _hiPlaceToCassetteA;

        [MonitoredItem(nodeId: "ns=4;s=Stn10_11_Robot.hiScanCassetteA")]
        public bool hiScanCassetteA
        {
            get => _hiScanCassetteA;
            set => SetProperty(ref _hiScanCassetteA, value);
        }

        private bool _hiScanCassetteA;

        [MonitoredItem(nodeId: "ns=4;s=Stn10_11_Robot.hiCassetteSlot")]
        public int hiCassetteSlot
        {
            get => _hiCassetteSlot;
            set => SetProperty(ref _hiCassetteSlot, value);
        }

        private int _hiCassetteSlot;

        [MonitoredItem(nodeId: "ns=4;s=Stn10_11_Robot.hiPickFromCassetteB")]
        public bool hiPickFromCassetteB
        {
            get => _hiPickFromCassetteB;
            set => SetProperty(ref _hiPickFromCassetteB, value);
        }

        private bool _hiPickFromCassetteB;

        [MonitoredItem(nodeId: "ns=4;s=Stn10_11_Robot.hiPlaceToCassetteB")]
        public bool hiPlaceToCassetteB
        {
            get => _hiPlaceToCassetteB;
            set => SetProperty(ref _hiPlaceToCassetteB, value);
        }

        private bool _hiPlaceToCassetteB;

        [MonitoredItem(nodeId: "ns=4;s=Stn10_11_Robot.hiScanCassetteB")]
        public bool hiScanCassetteB
        {
            get => _hiScanCassetteB;
            set => SetProperty(ref _hiScanCassetteB, value);
        }

        private bool _hiScanCassetteB;

        [MonitoredItem(nodeId: "ns=4;s=Stn10_11_Robot.hiSetSpeed")]
        public bool hiSetSpeed
        {
            get => _hiSetSpeed;
            set => SetProperty(ref _hiSetSpeed, value);
        }

        private bool _hiSetSpeed;

        [MonitoredItem(nodeId: "ns=4;s=Stn10_11_Robot.hiSpeedSetting")]
        public int hiSpeedSetting
        {
            get => _hiSpeedSetting;
            set => SetProperty(ref _hiSpeedSetting, value);
        }

        private int _hiSpeedSetting;

        [MonitoredItem(nodeId: "ns=4;s=Stn10_11_Robot.hiUpdateSpeed")]
        public bool hiUpdateSpeed
        {
            get => _hiUpdateSpeed;
            set => SetProperty(ref _hiUpdateSpeed, value);
        }

        private bool _hiUpdateSpeed;

        [MonitoredItem(nodeId: "ns=4;s=Stn10_11_Robot.hiSetReferenceWafer")]
        public bool hiSetReferenceWafer
        {
            get => _hiSetReferenceWafer;
            set => SetProperty(ref _hiSetReferenceWafer, value);
        }

        private bool _hiSetReferenceWafer;

        [MonitoredItem(nodeId: "ns=4;s=Stn10_11_Robot.hiReferenceWafer")]
        public float hiReferenceWafer
        {
            get => _hiReferenceWafer;
            set => SetProperty(ref _hiReferenceWafer, value);
        }

        private float _hiReferenceWafer;

        [MonitoredItem(nodeId: "ns=4;s=Stn10_11_Robot.hiSetZStepRatio")]
        public bool hiSetZStepRatio
        {
            get => _hiSetZStepRatio;
            set => SetProperty(ref _hiSetZStepRatio, value);
        }

        private bool _hiSetZStepRatio;

        [MonitoredItem(nodeId: "ns=4;s=Stn10_11_Robot.hiZStepRatio")]
        public float hiZStepRatio
        {
            get => _hiZStepRatio;
            set => SetProperty(ref _hiZStepRatio, value);
        }

        private float _hiZStepRatio;

        [MonitoredItem(nodeId: "ns=4;s=Stn10_11_Robot.hiMoveRelative")]
        public bool hiMoveRelative
        {
            get => _hiMoveRelative;
            set => SetProperty(ref _hiMoveRelative, value);
        }
        private bool _hiMoveRelative = false;

        [MonitoredItem(nodeId: "ns=4;s=Stn10_11_Robot.hiMoveRelativeAmount")]
        public int hiMoveRelativeAmount
        {
            get => _hiMoveRelativeAmount;
            set => SetProperty(ref _hiMoveRelativeAmount, value);
        }
        private int _hiMoveRelativeAmount = 0;

        [MonitoredItem(nodeId: "ns=4;s=Stn10_11_Robot.hiMoveRelativeAxis")]
        public int hiMoveRelativeAxis
        {
            get => _hiMoveRelativeAxis;
            set => SetProperty(ref _hiMoveRelativeAxis, value);
        }
        private int _hiMoveRelativeAxis = 0;

        [MonitoredItem(nodeId: "ns=4;s=Stn10_11_Robot.hiMoveAbsolute")]
        public bool hiMoveAbsolute
        {
            get => _hiMoveAbsolute;
            set => SetProperty(ref _hiMoveAbsolute, value);
        }
        private bool _hiMoveAbsolute = false;

        [MonitoredItem(nodeId: "ns=4;s=Stn10_11_Robot.hiMoveAbsoluteAmount")]
        public int hiMoveAbsoluteAmount
        {
            get => _hiMoveAbsoluteAmount;
            set => SetProperty(ref _hiMoveAbsoluteAmount, value);
        }
        private int _hiMoveAbsoluteAmount = 0;

        [MonitoredItem(nodeId: "ns=4;s=Stn10_11_Robot.hiMoveAbsoluteAxis")]
        public int hiMoveAbsoluteAxis
        {
            get => _hiMoveAbsoluteAxis;
            set => SetProperty(ref _hiMoveAbsoluteAxis, value);
        }
        private int _hiMoveAbsoluteAxis = 0;

        [MonitoredItem(nodeId: "ns=4;s=Stn10_11_Robot.hiMoveToStation")]
        public bool hiMoveToStation
        {
            get => _hiMoveToStation;
            set => SetProperty(ref _hiMoveToStation, value);
        }
        private bool _hiMoveToStation = false;

        [MonitoredItem(nodeId: "ns=4;s=Stn10_11_Robot.hiSelectedStation")]
        public int hiSelectedStation
        {
            get => _hiSelectedStation;
            set => SetProperty(ref _hiSelectedStation, value);
        }
        private int _hiSelectedStation = 0;

        [MonitoredItem(nodeId: "ns=4;s=Stn10_11_Robot.hiFetchPosition")]
        public bool hiFetchPosition
        {
            get => _hiFetchPosition;
            set => SetProperty(ref _hiFetchPosition, value);
        }
        private bool _hiFetchPosition = false;

        [MonitoredItem(nodeId: "ns=4;s=Stn10_11_Robot.hoManualMode")]
        public bool hoManualMode
        {
            get => _hoManualMode;
            set => SetProperty(ref _hoManualMode, value);
        }

        private bool _hoManualMode;

        [MonitoredItem(nodeId: "ns=4;s=Stn10_11_Robot.hoMovementReady")]
        public bool hoMovementReady
        {
            get => _hoMovementReady;
            set => SetProperty(ref _hoMovementReady, value);
        }

        private bool _hoMovementReady;

        [MonitoredItem(nodeId: "ns=4;s=Stn10_11_Robot.hoStatusHeartbeat")]
        public bool hoStatusHeartbeat
        {
            get => _hoStatusHeartbeat;
            set => SetProperty(ref _hoStatusHeartbeat, value);
        }

        private bool _hoStatusHeartbeat;

        [MonitoredItem(nodeId: "ns=4;s=Stn10_11_Robot.hoWaferPresent")]
        public bool hoWaferPresent
        {
            get => _hoWaferPresent;
            set => SetProperty(ref _hoWaferPresent, value);
        }

        private bool _hoWaferPresent;

        [MonitoredItem(nodeId: "ns=4;s=Stn10_11_Robot.hoWaferCarrierID")]
        public string hoWaferCarrierID
        {
            get => _hoWaferCarrierID;
            set => SetProperty(ref _hoWaferCarrierID, value);
        }

        private string _hoWaferCarrierID;

        [MonitoredItem(nodeId: "ns=4;s=Stn10_11_Robot.hoWaferThickness")]
        public float hoWaferThickness
        {
            get => _hoWaferThickness;
            set => SetProperty(ref _hoWaferThickness, value);
        }

        private float _hoWaferThickness;

        [MonitoredItem(nodeId: "ns=4;s=Stn10_11_Robot.hoWaferSize")]
        public int hoWaferSize
        {
            get => _hoWaferSize;
            set => SetProperty(ref _hoWaferSize, value);
        }

        private int _hoWaferSize;

        [MonitoredItem(nodeId: "ns=4;s=Stn10_11_Robot.APIOut")]
        public TypeLibrary.RobotAPIOut APIOut
        {
            get => _APIOut;
            set => SetProperty(ref _APIOut, value);
        }
        private TypeLibrary.RobotAPIOut _APIOut = new();

        [MonitoredItem(nodeId: "ns=4;s=Stn10_11_Robot.hoRefWaferThickness")]
        public float hoRefWaferThickness
        {
            get => _hoRefWaferThickness;
            set => SetProperty(ref _hoRefWaferThickness, value);
        }

        private float _hoRefWaferThickness;

        [MonitoredItem(nodeId: "ns=4;s=Stn10_11_Robot.hoZStepRatio")]
        public float hoZStepRatio
        {
            get => _hoZStepRatio;
            set => SetProperty(ref _hoZStepRatio, value);
        }

        private float _hoZStepRatio;

        [MonitoredItem(nodeId: "ns=4;s=Stn10_11_Robot.hoRobotSpeed")]
        public int hoRobotSpeed
        {
            get => _hoRobotSpeed;
            set => SetProperty(ref _hoRobotSpeed, value);
        }

        private int _hoRobotSpeed;

        [MonitoredItem(nodeId: "ns=4;s=Stn10_12_Aligner.hoWaferPresent")]
        public bool AlignerHasWafer
        {
            get => _AlignerHasWafer;
            set => SetProperty(ref _AlignerHasWafer, value);
        }

        private bool _AlignerHasWafer;

        [MonitoredItem(nodeId: "ns=4;s=Stn10_12_Aligner.hiAlignWafer")]
        public bool hiAlignWafer
        {
            get => _hiAlignWafer;
            set => SetProperty(ref _hiAlignWafer, value);
        }

        private bool _hiAlignWafer;

        [MonitoredItem(nodeId: "ns=4;s=Stn10_11_Robot.hoRobotBusy")]
        public bool hoRobotBusy
        {
            get => _hoRobotBusy;
            set => SetProperty(ref _hoRobotBusy, value);
        }
        private bool _hoRobotBusy = false;

        [MonitoredItem(nodeId: "ns=4;s=Stn10_11_Robot.hoCurrentPosition")]
        public string hoCurrentPosition
        {
            get => _hoCurrentPosition;
            set => SetProperty(ref _hoCurrentPosition, value);
        }
        private string _hoCurrentPosition = string.Empty;

        [MonitoredItem(nodeId: "ns=4;s=Stn10_11_Robot.hoHomeReady")]
        public bool hoHomeReady
        {
            get => _hoHomeReady;
            set => SetProperty(ref _hoHomeReady, value);
        }
        private bool _hoHomeReady = false;
    }
}