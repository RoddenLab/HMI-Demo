using Microsoft.Extensions.Logging;
using Workstation.ServiceModel.Ua;

namespace JR.P262605.HMI.UI.Navigation
{
    [Subscription(endpointUrl: "PLC", publishingInterval: 150)]
    public class NavigationBarModel : SubscriptionBase
    {
        private readonly ILogger Logger;

        public NavigationBarModel(ILogger logger) : base()
        {
            Logger = logger;
        }

        [MonitoredItem(nodeId: "ns=4;s=Stn10_00_ModeControl.hoStationStateMessage")]
        public string StationStateMessage
        {
            get => _StationStateMessage;
            set => SetProperty(ref _StationStateMessage, value);
        }

        private string _StationStateMessage;

        [MonitoredItem(nodeId: "ns=4;s=Stn10_00_ModeControl.hoOperatorMessage")]
        public string OperatorMessage
        {
            get => _OperatorMessage;
            set
            {
                SetProperty(ref _OperatorMessage, value);
                if (!string.IsNullOrWhiteSpace(_OperatorMessage))
                {
                    Logger?.LogError($"PLC Fault Occured! - {_OperatorMessage}");
                }
            }
        }

        private string _OperatorMessage;

        [MonitoredItem(nodeId: "ns=4;s=Stn10_00_ModeControl.hiFaultAck")]
        public bool FaultAcknowledge
        {
            get => _FaultAcknowledge;
            set => SetProperty(ref _FaultAcknowledge, value);
        }

        private bool _FaultAcknowledge;

        [MonitoredItem(nodeId: "ns=4;s=Stn10_00_ModeControl.hiStationReset")]
        public bool StationReset
        {
            get => _StationReset;
            set => SetProperty(ref _StationReset, value);
        }

        private bool _StationReset;

        [MonitoredItem(nodeId: "ns=4;s=Stn10_00_ModeControl.hiCycleStart")]
        public bool CycleStartRequest
        {
            get => _CycleStartRequest;
            set => SetProperty(ref _CycleStartRequest, value);
        }

        private bool _CycleStartRequest;

        [MonitoredItem(nodeId: "ns=4;s=Stn10_00_ModeControl.hoOKToStart")]
        public bool OKToStart
        {
            get => _OKToStart;
            set => SetProperty(ref _OKToStart, value);
        }

        private bool _OKToStart;

        [MonitoredItem(nodeId: "ns=4;s=Stn10_00_ModeControl.hiCycleStop")]
        public bool CycleStopRequest
        {
            get => _CycleStopRequest;
            set => SetProperty(ref _CycleStopRequest, value);
        }

        private bool _CycleStopRequest;

        [MonitoredItem(nodeId: "ns=4;s=Stn10_00_ModeControl.hoOKToStop")]
        public bool OKToStop
        {
            get => _OKToStop;
            set => SetProperty(ref _OKToStop, value);
        }

        private bool _OKToStop;

        [MonitoredItem(nodeId: "ns=4;s=Stn10_00_ModeControl.hoOKToReset")]
        public bool OKToReset
        {
            get => _OKToReset;
            set => SetProperty(ref _OKToReset, value);
        }

        private bool _OKToReset;


        [MonitoredItem(nodeId: "ns=4;s=Stn10_00_ModeControl.hiManualMode")]
        public bool ManualModeRequest
        {
            get => _ManualModeRequest;
            set => SetProperty(ref _ManualModeRequest, value);
        }

        private bool _ManualModeRequest;

        [MonitoredItem(nodeId: "ns=4;s=Stn10_00_ModeControl.Station.OKForManual")]
        public bool OKForManual
        {
            get => _OKForManual;
            set => SetProperty(ref _OKForManual, value);
        }

        private bool _OKForManual;

        [MonitoredItem(nodeId: "ns=4;s=Stn10_00_ModeControl.hiFaultReset")]
        public bool FaultResetCommand
        {
            get => _FaultResetCommand;
            set => SetProperty(ref _FaultResetCommand, value);
        }

        private bool _FaultResetCommand;

        [MonitoredItem(nodeId: "ns=4;s=Stn10_10_Main.hiStageLightOn")]
        public bool StageLightCommand
        {
            get => _StageLightCommand;
            set => SetProperty(ref _StageLightCommand, value);
        }

        private bool _StageLightCommand;

        [MonitoredItem(nodeId: "ns=4;s=Stn10_10_Main.hiLockDoorRequest")]
        public bool hiLockDoorRequest
        {
            get => _hiLockDoorRequest;
            set => SetProperty(ref _hiLockDoorRequest, value);
        }

        private bool _hiLockDoorRequest;

        [MonitoredItem(nodeId: "ns=4;s=Stn10_10_Main.hiCloseLoadDoor")]
        public bool hiCloseLoadDoor
        {
            get => _hiCloseLoadDoor;
            set => SetProperty(ref _hiCloseLoadDoor, value);
        }

        private bool _hiCloseLoadDoor;

        [MonitoredItem(nodeId: "ns=4;s=Stn10_10_Main.oLoadDoorLock")]
        public bool oLoadDoorLock
        {
            get => _oLoadDoorLock;
            set => SetProperty(ref _oLoadDoorLock, value);
        }

        private bool _oLoadDoorLock;

        [MonitoredItem(nodeId: "ns=4;s=Stn10_10_Main.oStageLightCommand")]
        public bool oStageLightCommand
        {
            get => _oStageLightCommand;
            set => SetProperty(ref _oStageLightCommand, value);
        }

        private bool _oStageLightCommand;


        [MonitoredItem(nodeId: "ns=4;s=Stn10_10_Main.oGuardDoorLock")]
        public bool oGuardDoorLock
        {
            get => _oGuardDoorLock;
            set => SetProperty(ref _oGuardDoorLock, value);
        }

        private bool _oGuardDoorLock;

        [MonitoredItem(nodeId: "ns=4;s=Stn10_20_GEM.hoGEMState")]
        public string GEMState
        {
            get => _GEMState;
            set => SetProperty(ref _GEMState, value);
        }
        private string _GEMState = string.Empty;

        [MonitoredItem(nodeId: "ns=4;s=Stn10_20_GEM.hoRemoteMode")]
        public bool RemoteMode
        {
            get => _RemoteMode;
            set => SetProperty(ref _RemoteMode, value);
        }
        private bool _RemoteMode;

        [MonitoredItem(nodeId: "ns=4;s=Stn10_20_GEM.hoRemoteMode")]
        public bool NotRemoteMode
        {
            get => !_NotRemoteMode;
            set => SetProperty(ref _NotRemoteMode, value);
        }
        private bool _NotRemoteMode = false;

        [MonitoredItem(nodeId: "ns=4;s=Stn10_00_ModeControl.hoFaultAlert")]
        public bool FaultAlert
        {
            get => _FaultAlert;
            set => SetProperty(ref _FaultAlert, value);
        }
        private bool _FaultAlert = false;

        [MonitoredItem(nodeId: "ns=4;s=Stn10_00_ModeControl.hoShowStart")]
        public bool ShowStart
        {
            get => _ShowStart;
            set => SetProperty(ref _ShowStart, value);
        }
        private bool _ShowStart;

        [MonitoredItem(nodeId: "ns=4;s=Stn10_00_ModeControl.hoShowStop")]
        public bool ShowStop
        {
            get => _ShowStop;
            set => SetProperty(ref _ShowStop, value);
        }
        private bool _ShowStop;
    }
}