using Workstation.ServiceModel.Ua;

namespace JR.P262605.HMI.UI.Operator.PLC
{
    [Subscription(endpointUrl: "PLC", publishingInterval: 250)]
    public partial class PLCControlModel : SubscriptionBase
    {
        [MonitoredItem(nodeId: "ns=4;s=Stn10_00_ModeControl.iLaserSafety1Status")]
        public bool iLaserSafety1Status
        {
            get => _iLaserSafety1Status;
            set => SetProperty(ref _iLaserSafety1Status, value);
        }
        private bool _iLaserSafety1Status = false;

        [MonitoredItem(nodeId: "ns=4;s=Stn10_00_ModeControl.iLaserSafety2Status")]
        public bool iLaserSafety2Status
        {
            get => _iLaserSafety2Status;
            set => SetProperty(ref _iLaserSafety2Status, value);
        }
        private bool _iLaserSafety2Status = false;

        [MonitoredItem(nodeId: "ns=4;s=Stn10_13_Laser.iProcessAbort")]
        public bool iProcessAbort
        {
            get { return _iProcessAbort; }
            set { SetProperty(ref _iProcessAbort, value); }
        }
        private bool _iProcessAbort = false;

        [MonitoredItem(nodeId: "ns=4;s=Stn10_10_Main.iCassetteAPresent")]
        public bool iCassetteAPresent
        {
            get => _iCassetteAPresent;
            set => SetProperty(ref _iCassetteAPresent, value);
        }
        private bool _iCassetteAPresent = false;

        [MonitoredItem(nodeId: "ns=4;s=Stn10_10_Main.iCassetteBPresent")]
        public bool iCassetteBPresent
        {
            get => _iCassetteBPresent;
            set => SetProperty(ref _iCassetteBPresent, value);
        }
        private bool _iCassetteBPresent = false;

        [MonitoredItem(nodeId: "ns=4;s=Stn10_10_Main.iDoorFrontLeftOpen")]
        public bool iDoorFrontLeftOpen
        {
            get => _iDoorFrontLeftOpen;
            set => SetProperty(ref _iDoorFrontLeftOpen, value);
        }
        private bool _iDoorFrontLeftOpen = false;

        [MonitoredItem(nodeId: "ns=4;s=Stn10_10_Main.iDoorFrontRightOpen")]
        public bool iDoorFrontRightOpen
        {
            get => _iDoorFrontRightOpen;
            set => SetProperty(ref _iDoorFrontRightOpen, value);
        }
        private bool _iDoorFrontRightOpen = false;

        [MonitoredItem(nodeId: "ns=4;s=Stn10_10_Main.iDoorSideLeftOpen")]
        public bool iDoorSideLeftOpen
        {
            get => _iDoorSideLeftOpen;
            set => SetProperty(ref _iDoorSideLeftOpen, value);
        }
        private bool _iDoorSideLeftOpen = false;

        [MonitoredItem(nodeId: "ns=4;s=Stn10_10_Main.iDoorSideRightOpen")]
        public bool iDoorSideRightOpen
        {
            get => _iDoorSideRightOpen;
            set => SetProperty(ref _iDoorSideRightOpen, value);
        }
        private bool _iDoorSideRightOpen = false;

        [MonitoredItem(nodeId: "ns=4;s=Stn10_10_Main.iDoorTopOpen")]
        public bool iDoorTopOpen
        {
            get => _iDoorTopOpen;
            set => SetProperty(ref _iDoorTopOpen, value);
        }
        private bool _iDoorTopOpen = false;

        [MonitoredItem(nodeId: "ns=4;s=Stn10_10_Main.iLoadAreaCylExtd")]
        public bool iLoadAreaCylExtd
        {
            get => _iLoadAreaCylExtd;
            set => SetProperty(ref _iLoadAreaCylExtd, value);
        }
        private bool _iLoadAreaCylExtd = false;

        [MonitoredItem(nodeId: "ns=4;s=Stn10_10_Main.iLoadAreaCylRetd")]
        public bool iLoadAreaCylRetd
        {
            get => _iLoadAreaCylRetd;
            set => SetProperty(ref _iLoadAreaCylRetd, value);
        }
        private bool _iLoadAreaCylRetd = false;

        [MonitoredItem(nodeId: "ns=4;s=Stn10_10_Main.iLoadDoorOpen")]
        public bool iLoadDoorOpen
        {
            get => _iLoadDoorOpen;
            set => SetProperty(ref _iLoadDoorOpen, value);
        }
        private bool _iLoadDoorOpen = false;

        [MonitoredItem(nodeId: "ns=4;s=Stn10_16_SMIFPodLt.iLeftLoadPlusReady")]
        public bool iLeftLoadPlusReady
        {
            get => _iLeftLoadPlusReady;
            set => SetProperty(ref _iLeftLoadPlusReady, value);
        }
        private bool _iLeftLoadPlusReady = false;

        [MonitoredItem(nodeId: "ns=4;s=Stn10_16_SMIFPodLt.iLeftLoadPodInPlace")]
        public bool iLeftLoadPodInPlace
        {
            get => _iLeftLoadPodInPlace;
            set => SetProperty(ref _iLeftLoadPodInPlace, value);
        }
        private bool _iLeftLoadPodInPlace = false;

        [MonitoredItem(nodeId: "ns=4;s=Stn10_16_SMIFPodLt.iLeftLoadSpare")]
        public bool iLeftLoadSpare
        {
            get => _iLeftLoadSpare;
            set => SetProperty(ref _iLeftLoadSpare, value);
        }
        private bool _iLeftLoadSpare = false;

        [MonitoredItem(nodeId: "ns=4;s=Stn10_17_SMIFPodRt.iRightLoadPlusReady")]
        public bool iRightLoadPlusReady
        {
            get => _iRightLoadPlusReady;
            set => SetProperty(ref _iRightLoadPlusReady, value);
        }
        private bool _iRightLoadPlusReady = false;

        [MonitoredItem(nodeId: "ns=4;s=Stn10_17_SMIFPodRt.iRightLoadPodInPlace")]
        public bool iRightLoadPodInPlace
        {
            get => _iRightLoadPodInPlace;
            set => SetProperty(ref _iRightLoadPodInPlace, value);
        }
        private bool _iRightLoadPodInPlace = false;

        [MonitoredItem(nodeId: "ns=4;s=Stn10_17_SMIFPodRt.iRightLoadSpare")]
        public bool iRightLoadSpare
        {
            get => _iRightLoadSpare;
            set => SetProperty(ref _iRightLoadSpare, value);
        }
        private bool _iRightLoadSpare = false;

        [MonitoredItem(nodeId: "ns=4;s=Stn10_00_ModeControl.iEMORearStatus")]
        public bool iEMOButtonRight
        {
            get => _iEMOButtonRight;
            set => SetProperty(ref _iEMOButtonRight, value);
        }
        private bool _iEMOButtonRight = false;

        [MonitoredItem(nodeId: "ns=4;s=Stn10_00_ModeControl.iEMOOperatorStatus")]
        public bool iEMOButtonLeft
        {
            get => _iEMOButtonLeft;
            set => SetProperty(ref _iEMOButtonLeft, value);
        }
        private bool _iEMOButtonLeft = false;

        [MonitoredItem(nodeId: "ns=4;s=Stn10_00_ModeControl.iEMOMaintenanceStatus")]
        public bool iEMOButtonFront
        {
            get => _iEMOButtonFront;
            set => SetProperty(ref _iEMOButtonFront, value);
        }
        private bool _iEMOButtonFront = false;

        [MonitoredItem(nodeId: "ns=4;s=Stn10_00_ModeControl.iEMOElectricalStatus")]
        public bool iEMOButtonBack
        {
            get => _iEMOButtonBack;
            set => SetProperty(ref _iEMOButtonBack, value);
        }
        private bool _iEMOButtonBack = false;
    }

    public partial class PLCControlModel
    {
        [MonitoredItem(nodeId: "ns=4;s=Stn10_00_ModeControl.oSafetyResetButtonLight")]
        public bool oSafteyResetButtonLight
        {
            get => _oSafteyResetButtonLight;
            set => SetProperty(ref _oSafteyResetButtonLight, value);
        }
        private bool _oSafteyResetButtonLight = false;

        [MonitoredItem(nodeId: "ns=4;s=Stn10_10_Main.oGuardDoorLock")]
        public bool oGuardDoorLock
        {
            get => _oGuardDoorLock;
            set => SetProperty(ref _oGuardDoorLock, value);
        }
        private bool _oGuardDoorLock = false;

        [MonitoredItem(nodeId: "ns=4;s=Stn10_10_Main.oLoadDoorLock")]
        public bool oLoadDoorLock
        {
            get => _oLoadDoorLock;
            set => SetProperty(ref _oLoadDoorLock, value);
        }
        private bool _oLoadDoorLock = false;

        [MonitoredItem(nodeId: "ns=4;s=Stn10_10_Main.oLoadDoorClose")]
        public bool oLoadDoorClose
        {
            get => _oLoadDoorClose;
            set => SetProperty(ref _oLoadDoorClose, value);
        }
        private bool _oLoadDoorClose = false;

        [MonitoredItem(nodeId: "ns=4;s=Stn10_10_Main.oLoadDoorOpen")]
        public bool oLoadDoorOpen
        {
            get => _oLoadDoorOpen;
            set => SetProperty(ref _oLoadDoorOpen, value);
        }
        private bool _oLoadDoorOpen = false;

        [MonitoredItem(nodeId: "ns=4;s=Stn10_10_Main.oDoorRelayReset")]
        public bool oDoorRelayReset
        {
            get => _oDoorRelayReset;
            set => SetProperty(ref _oDoorRelayReset, value);
        }
        private bool _oDoorRelayReset = false;

        [MonitoredItem(nodeId: "ns=4;s=Stn10_10_Main.oStageLightCommand")]
        public bool oStageLightCommand
        {
            get => _oStageLightCommand;
            set => SetProperty(ref _oStageLightCommand, value);
        }
        private bool _oStageLightCommand = false;

        [MonitoredItem(nodeId: "ns=4;s=Stn10_10_Main.oAirSolenoidCommand")]
        public bool oAirSolenoidCommand
        {
            get => _oAirSolenoidCommand;
            set => SetProperty(ref _oAirSolenoidCommand, value);
        }
        private bool _oAirSolenoidCommand = false;

        [MonitoredItem(nodeId: "ns=4;s=Stn10_10_Main.oStackLightGreen")]
        public bool oStackLightGreen
        {
            get => _oStackLightGreen;
            set => SetProperty(ref _oStackLightGreen, value);
        }
        private bool _oStackLightGreen = false;

        [MonitoredItem(nodeId: "ns=4;s=Stn10_10_Main.oStackLightYellow")]
        public bool oStackLightYellow
        {
            get => _oStackLightYellow;
            set => SetProperty(ref _oStackLightYellow, value);
        }
        private bool _oStackLightYellow = false;

        [MonitoredItem(nodeId: "ns=4;s=Stn10_10_Main.oStackLightRed")]
        public bool oStackLightRed
        {
            get => _oStackLightRed;
            set => SetProperty(ref _oStackLightRed, value);
        }
        private bool _oStackLightRed = false;

        [MonitoredItem(nodeId: "ns=4;s=Stn10_13_Laser.oNitrogenSolenoid")]
        public bool oNitrogenSolenoid
        {
            get => _oNitrogenSolenoid;
            set => SetProperty(ref _oNitrogenSolenoid, value);
        }
        private bool _oNitrogenSolenoid = false;

        [MonitoredItem(nodeId: "ns=4;s=Stn10_13_Laser.oMachineReady")]
        public bool oMachineReady
        {
            get => _oMachineReady;
            set => SetProperty(ref _oMachineReady, value);
        }
        private bool _oMachineReady = false;

        [MonitoredItem(nodeId: "ns=4;s=Stn10_16_SMIFPodLt.oLeftLoadToolReady")]
        public bool oLeftLoadToolReady
        {
            get => _oLeftLoadToolReady;
            set => SetProperty(ref _oLeftLoadToolReady, value);
        }
        private bool _oLeftLoadToolReady = false;

        [MonitoredItem(nodeId: "ns=4;s=Stn10_16_SMIFPodLt.oLeftLoadCassPIP")]
        public bool oLeftLoadCassPIP
        {
            get => _oLeftLoadCassPIP;
            set => SetProperty(ref _oLeftLoadCassPIP, value);
        }
        private bool _oLeftLoadCassPIP = false;

        [MonitoredItem(nodeId: "ns=4;s=Stn10_17_SMIFPodRt.oRightLoadToolReady")]
        public bool oRightLoadToolReady
        {
            get => _oRightLoadToolReady;
            set => SetProperty(ref _oRightLoadToolReady, value);
        }
        private bool _oRightLoadToolReady = false;

        [MonitoredItem(nodeId: "ns=4;s=Stn10_17_SMIFPodRt.oRightLoadCassPIP")]
        public bool oRightLoadCassPIP
        {
            get => _oRightLoadCassPIP;
            set => SetProperty(ref _oRightLoadCassPIP, value);
        }
        private bool _oRightLoadCassPIP = false;
    }

    public partial class PLCControlModel
    {
        [MonitoredItem(nodeId: "ns=4;s=Stn10_02_Inputs.iBannerConnected")]
        public bool iBannerConnected
        {
            get => _iBannerConnected;
            set => SetProperty(ref _iBannerConnected, value);
        }
        private bool _iBannerConnected = false;

        [MonitoredItem(nodeId: "ns=4;s=Stn10_02_Inputs.iSafetySystemLockout")]
        public bool iSafetySystemLockout
        {
            get => _iSafetySystemLockout;
            set => SetProperty(ref _iSafetySystemLockout, value);
        }
        private bool _iSafetySystemLockout = false;

        [MonitoredItem(nodeId: "ns=4;s=Stn10_02_Inputs.iSafetyInputFault")]
        public bool iSafetyInputFault
        {
            get => _iSafetyInputFault;
            set => SetProperty(ref _iSafetyInputFault, value);
        }
        private bool _iSafetyInputFault = false;

        [MonitoredItem(nodeId: "ns=4;s=Stn10_02_Inputs.iSafetyOutputFault")]
        public bool iSafetyOutputFault
        {
            get => _iSafetyOutputFault;
            set => SetProperty(ref _iSafetyOutputFault, value);
        }
        private bool _iSafetyOutputFault = false;

        [MonitoredItem(nodeId: "ns=4;s=Stn10_02_Inputs.iDoorRelayClosed")]
        public bool iDoorRelayClosed
        {
            get => _iDoorRelayClosed;
            set => SetProperty(ref _iDoorRelayClosed, value);
        }
        private bool _iDoorRelayClosed = false;

        [MonitoredItem(nodeId: "ns=4;s=Stn10_02_Inputs.iEMORelayClosed")]
        public bool iEMORelayClosed
        {
            get => _iEMORelayClosed;
            set => SetProperty(ref _iEMORelayClosed, value);
        }
        private bool _iEMORelayClosed = false;

        [MonitoredItem(nodeId: "ns=4;s=Stn10_02_Inputs.iEMOCircuitClosed")]
        public bool iEMOCircuitClosed
        {
            get => _iEMOCircuitClosed;
            set => SetProperty(ref _iEMOCircuitClosed, value);
        }
        private bool _iEMOCircuitClosed = false;

        [MonitoredItem(nodeId: "ns=4;s=Stn10_02_Inputs.iDoorCircuitClosed")]
        public bool iDoorCircuitClosed
        {
            get => _iDoorCircuitClosed;
            set => SetProperty(ref _iDoorCircuitClosed, value);
        }
        private bool _iDoorCircuitClosed = false;

        [MonitoredItem(nodeId: "ns=4;s=Stn10_02_Inputs.iDoorRelayOpen")]
        public bool iDoorRelayOpen
        {
            get => _iDoorRelayOpen;
            set => SetProperty(ref _iDoorRelayOpen, value);
        }
        private bool _iDoorRelayOpen = false;

        [MonitoredItem(nodeId: "ns=4;s=Stn10_02_Inputs.iRoomBypassActive")]
        public bool iRoomBypassActive
        {
            get => _iRoomBypassActive;
            set => SetProperty(ref _iRoomBypassActive, value);
        }
        private bool _iRoomBypassActive = false;

        [MonitoredItem(nodeId: "ns=4;s=Stn10_02_Inputs.iEMORelayOpen")]
        public bool iEMORelayOpen
        {
            get => _iEMORelayOpen;
            set => SetProperty(ref _iEMORelayOpen, value);
        }
        private bool _iEMORelayOpen = false;

        [MonitoredItem(nodeId: "ns=4;s=Stn10_02_Inputs.iRoomRelayOpen")]
        public bool iRoomRelayOpen
        {
            get => _iRoomRelayOpen;
            set => SetProperty(ref _iRoomRelayOpen, value);
        }
        private bool _iRoomRelayOpen = false;

        [MonitoredItem(nodeId: "ns=4;s=Stn10_02_Inputs.iRoomInterlockActive")]
        public bool iRoomInterlockActive
        {
            get => _iRoomInterlockActive;
            set => SetProperty(ref _iRoomInterlockActive, value);
        }
        private bool _iRoomInterlockActive = false;

        [MonitoredItem(nodeId: "ns=4;s=Stn10_02_Inputs.iEMOResetNeeded")]
        public bool iEMOResetNeeded
        {
            get => _iEMOResetNeeded;
            set => SetProperty(ref _iEMOResetNeeded, value);
        }
        private bool _iEMOResetNeeded = false;

        [MonitoredItem(nodeId: "ns=4;s=Stn10_02_Inputs.iDoorResetNeeded")]
        public bool iDoorResetNeeded
        {
            get => _iDoorResetNeeded;
            set => SetProperty(ref _iDoorResetNeeded, value);
        }
        private bool _iDoorResetNeeded = false;

        [MonitoredItem(nodeId: "ns=4;s=Stn10_02_Inputs.iLoadDoorClosed")]
        public  bool iLoadDoorClosed
        {
            get { return _iLoadDoorClosed; }
            set { SetProperty(ref _iLoadDoorClosed, value);}
        }
        private bool _iLoadDoorClosed = false;

        [MonitoredItem(nodeId: "ns=4;s=Stn10_02_Inputs.iFrontDoorClosed")]
        public bool iFrontDoorClosed
        {
            get { return _iFrontDoorClosed; }
            set { SetProperty(ref _iFrontDoorClosed, value); }               
        }
        private bool _iFrontDoorClosed = false;
    }
}