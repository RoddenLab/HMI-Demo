using System.Text.Json.Serialization;

namespace JR.P262605.API.Laser.OPK
{
#nullable enable
    public class StatusResponse
    {
        [JsonPropertyName("HEARTBEAT")]
        public bool Heartbeat { get; set; }

        [JsonPropertyName("LASER_PEC")]
        public double? LaserPEC { get; set; }

        [JsonPropertyName("LASER_DIODE_CURRENT")]
        public double? LaserDiodeCurrent { get; set; }

        [JsonPropertyName("LASER_DIODE_VOLTAGE")]
        public double? LaserDiodeVoltage { get; set; }

        [JsonPropertyName("LASER_DIODE_TEMP_1")]
        public double? LaserDiodeTemp1 { get; set; }

        [JsonPropertyName("LASER_DIODE_TEMP_2")]
        public double? LaserDiodeTemp2 { get; set; }

        [JsonPropertyName("LASER_DIODE_TEMP_3")]
        public double? LaserDiodeTemp3 { get; set; }

        [JsonPropertyName("LASER_SHG_TEMP")]
        public double? LaserSHGTemp { get; set; }

        [JsonPropertyName("LASER_THG_TEMP")]
        public double? LaserTHGTemp { get; set; }

        [JsonPropertyName("BEAM_EXPANDER_MAG")]
        public double? BeamExpanderMag { get; set; }

        [JsonPropertyName("ATTENUATOR_POWER")]
        public double? AttenuatorPower { get; set; }

        [JsonPropertyName("SCANNER_POS_X")]
        public double? ScannerPosX { get; set; }

        [JsonPropertyName("SCANNER_POS_Y")]
        public double? ScannerPosY { get; set; }

        [JsonPropertyName("SCANNER_PRF")]
        public int? ScannerPRF { get; set; }

        [JsonPropertyName("SCANNER_MARK_SPEED")]
        public double? ScannerMarkSpeed { get; set; }

        [JsonPropertyName("SCANNER_JUMP_SPEED")]
        public double? ScannerJumpSpeed { get; set; }

        [JsonPropertyName("SCANNER_MARK_DELAY")]
        public double? ScannerMarkDelay { get; set; }

        [JsonPropertyName("SCANNER_JUMP_DELAY")]
        public double? ScannerJumpDelay { get; set; }

        [JsonPropertyName("SCANNER_POLY_DELAY")]
        public double? ScannerPolyDelay { get; set; }

        [JsonPropertyName("SCANNER_LASER_ON_DELAY")]
        public double? ScannerLaserOnDelay { get; set; }

        [JsonPropertyName("SCANNER_LASER_OFF_DELAY")]
        public double? ScannerLaserOffDelay { get; set; }

        [JsonPropertyName("LASER_INLINE_POWER_RAW")]
        public double? LaserInlinePowerRaw { get; set; }

        [JsonPropertyName("LASER_INLINE_POWER")]
        public double? LaserInlinePower { get; set; }

        [JsonPropertyName("LASER_WORKPIECE_POWER")]
        public double? LaserWorkpiecePower { get; set; }

        [JsonPropertyName("SELECTED_RECIPE")]
        public string? SelectedRecipe { get; set; }

        [JsonPropertyName("POWER_STAB_ACTIVE")]
        public bool PowerStabActive { get; set; }

        [JsonPropertyName("BEAM_SHAPER_ACTIVE")]
        public bool? BeamShaperActive { get; set; }

        [JsonPropertyName("MODULE_STATUS")]
        public int ModuleStatus { get; set; }

        [JsonPropertyName("MODULE_STATUS_MESSAGE")]
        public string? ModuleStatusMessage { get; set; }

        [JsonPropertyName("MODULE_READY_TO_PROCESS")]
        public bool ModuleReadyToProcess { get; set; }

        [JsonPropertyName("PLC_FAULTED")]
        public bool PLCFaulted { get; set; }

        [JsonPropertyName("PLC_INITIALISED")]
        public bool PLCInitialized { get; set; }

        [JsonPropertyName("PLC_STATUS_MESSAGE")]
        public string? PLCStatusMessage { get; set; }

        [JsonPropertyName("SCANNER_FAULTED")]
        public bool ScannerFaulted { get; set; }

        [JsonPropertyName("SCANNER_INITIALISED")]
        public bool ScannerInitialized { get; set; }

        [JsonPropertyName("SCANNER_STATUS_MESSAGE")]
        public string? ScannerStatusMessage { get; set; } // 50

        [JsonPropertyName("WELDMARK_FAULTED")]
        public bool WeldmarkFaulted { get; set; }

        [JsonPropertyName("WELDMARK_INITIALISED")]
        public bool WeldmarkInitialized { get; set; }

        [JsonPropertyName("WELDMARK_STATUS_MESSAGE")]
        public string? WelmarkStatusMessage { get; set; } // 50

        [JsonPropertyName("LASER_FAULTED")]
        public bool LaserFaulted { get; set; }

        [JsonPropertyName("LASER_INITIALISED")]
        public bool LaserInitialized { get; set; }

        [JsonPropertyName("LASER_STATUS_MESSAGE")]
        public string? LaserStatusMessage { get; set; } // 50

        [JsonPropertyName("AXIS_CONTROL_FAULTED")]
        public bool AxisControlFaulted { get; set; }

        [JsonPropertyName("AXIS_CONTROL_INITIALISED")]
        public bool AxisControlInitialized { get; set; }

        [JsonPropertyName("AXIS_CONTROL_STATUS_MESSAGE")]
        public string? AxisControlStatusMessage { get; set; }

        [JsonPropertyName("POWER_ATTENUATOR_FAULTED")]
        public bool PowerAttenuatorFaulted { get; set; }

        [JsonPropertyName("POWER_ATTENUATOR_INITIALISED")]
        public bool PowerAttenuatorInitialized { get; set; }

        [JsonPropertyName("POWER_ATTENUATOR_STATUS_MESSAGE")]
        public string? PowerAttenuatorStatusMessage { get; set; } // 50

        [JsonPropertyName("BEAM_EXPANDER_FAULTED")]
        public bool BeamExpanderFaulted { get; set; }

        [JsonPropertyName("BEAM_EXPANDER_INITIALISED")]
        public bool BeamExpanderInitialized { get; set; }

        [JsonPropertyName("BEAM_EXPANDER_STATUS_MESSAGE")]
        public string? BeamExpanderStatusMessage { get; set; } // 50

        [JsonPropertyName("INLINE_POWER_METER_FAULTED")]
        public bool InlinePowerMeterFaulted { get; set; }

        [JsonPropertyName("INLINE_POWER_METER_INITIALISED")]
        public bool InlinePowerMeterInitialized { get; set; }

        [JsonPropertyName("INLINE_POWER_METER_STATUS_MESSAGE")]
        public string? InlinePowerMeterStatusMessage { get; set; } // 50

        [JsonPropertyName("PROCESS_POWER_METER_FAULTED")]
        public bool ProcessPowerMeterFaulted { get; set; }

        [JsonPropertyName("PROCESS_POWER_METER_INITIALISED")]
        public bool ProcessPowerMeterInitialized { get; set; }

        [JsonPropertyName("PROCESS_POWER_METER_STATUS_MESSAGE")]
        public string? ProcessPowerMeterStatusMessage { get; set; } // 50
    }
}