using JR.WPF;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace JR.P262605.HMI.UI.Operator.Robot
{
    public class RobotControlViewModel : BindableBase
    {
        private readonly ILogger Logger;
        private readonly IAppConfiguration Configuration;

        public RobotControlModel Model { get; set; } = new();

        public RobotControlViewModel(ILogger logger, IAppConfiguration configuration)
        {
            // Set Logger
            Logger = logger;

            // Get Configuration
            Configuration = configuration;

            StopCommand = new AsyncCommand(OnStopCommand);
            ResetAPICommand = new AsyncCommand(OnResetAPICommand);
            RemoveWaferCommand = new AsyncCommand(OnRemoveWaferCommand);
            StatusCommand = new AsyncCommand(OnStatusCommand);
            ServoOnCommand = new AsyncCommand(OnServoOnCommand);
            ServoOffCommand = new AsyncCommand(OnServoOffCommand);
            VacuumOnCommand = new AsyncCommand(OnVacuumOnCommand);
            VacuumOffCommand = new AsyncCommand(OnVacuumOffCommand);
            SetSpeedCommand = new AsyncCommand(OnSetSpeedCommand);
            MoveRelativeCommand = new AsyncCommand(OnMoveRelativeCommand);
            MoveAbsoluteCommand = new AsyncCommand(OnMoveAbsoluteCommand);
            MoveToStationCommand = new AsyncCommand(OnMoveToStationCommand);
            MoveToHomeCommand = new AsyncCommand(OnMoveToHomeCommand);
            PickFromAlignerCommand = new AsyncCommand(OnPickFromAlignerCommand);
            PlaceToAlignerCommand = new AsyncCommand(OnPlaceToAlignerCommand);
            PickFromCassetteACommand = new AsyncCommand(OnPickFromCassetteACommand);
            PlaceToCassetteACommand = new AsyncCommand(OnPlaceToCassetteACommand);
            ScanCassetteACommand = new AsyncCommand(OnScanCassetteACommand);
            PickFromCassetteBCommand = new AsyncCommand(OnPickFromCassetteBCommand);
            PlaceToCassetteBCommand = new AsyncCommand(OnPlaceToCassetteBCommand);
            ScanCassetteBCommand = new AsyncCommand(OnScanCassetteBCommand);
            AlignWaferCommand = new AsyncCommand(OnAlignWaferCommand);
            HomeRobotCommand = new AsyncCommand(OnHomeRobotCommand);
            FetchPositionCommand = new AsyncCommand(OnFetchPositionCommand);
            UpdateSpeedCommand = new AsyncCommand(OnUpdateSpeedCommand);
            SetZStepRatio = new AsyncCommand(OnSetZStepRatio);
            SetReferenceWaferCommand = new AsyncCommand(OnSetReferenceWaferCommand);
        }

        public void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            Process[] pname = Process.GetProcessesByName("osk.exe");
            if (pname.Length == 0)
            {
                _ = Process.Start("osk.exe");
            }
        }

        public ICommand StopCommand { get; private set; }

        private async Task OnStopCommand()
        {
            Logger?.LogInformation("User Pressed Stop Command");

            Model.hiStop = true;
            await Task.Delay(Configuration.ButtonDelay);
            Model.hiStop = false;
        }

        public ICommand ResetAPICommand { get; private set; }

        private async Task OnResetAPICommand()
        {
            Logger?.LogInformation("User Pressed API Reset Command.");

            Model.hiResetAPI = true;
            await Task.Delay(Configuration.ButtonDelay); ;
            Model.hiResetAPI = false;
        }

        public ICommand RemoveWaferCommand { get; private set; }

        private async Task OnRemoveWaferCommand()
        {
            Logger?.LogInformation("User Pressed Remove Wafer Command.");

            Model.hiWaferRemoved = true;
            await Task.Delay(Configuration.ButtonDelay); ;
            Model.hiWaferRemoved = false;
        }

        public ICommand StatusCommand { get; private set; }

        private async Task OnStatusCommand()
        {
            Logger?.LogInformation("User Pressed Poll Status Command.");

            Model.hiPollStatus = true;
            await Task.Delay(Configuration.ButtonDelay); ;
            Model.hiPollStatus = false;
        }

        public ICommand ServoOnCommand { get; private set; }

        private async Task OnServoOnCommand()
        {
            Logger?.LogInformation("User Pressed Servo On Command.");

            Model.hiServoOn = true;
            await Task.Delay(Configuration.ButtonDelay); ;
            Model.hiServoOn = false;
        }

        public ICommand ServoOffCommand { get; private set; }

        private async Task OnServoOffCommand()
        {
            Logger?.LogInformation("User Pressed Servo On Command.");

            Model.hiServoOff = true;
            await Task.Delay(Configuration.ButtonDelay); ;
            Model.hiServoOff = false;
        }

        public ICommand HomeRobotCommand { get; private set; }

        private async Task OnHomeRobotCommand()
        {
            Logger?.LogInformation("User Pressed Home Robot Command.");

            Model.hiHomeRobot = true;
            await Task.Delay(Configuration.ButtonDelay); ;
            Model.hiHomeRobot = false;
        }

        public ICommand VacuumOnCommand { get; private set; }

        private async Task OnVacuumOnCommand()
        {
            Logger?.LogInformation("User Pressed Vacuum On Command.");

            Model.hiVacuumOn = true;
            await Task.Delay(Configuration.ButtonDelay); ;
            Model.hiVacuumOn = false;
        }

        public ICommand VacuumOffCommand { get; private set; }

        private async Task OnVacuumOffCommand()
        {
            Logger?.LogInformation("User Pressed Vacuum Off Command.");

            Model.hiVacuumOff = true;
            await Task.Delay(Configuration.ButtonDelay); ;
            Model.hiVacuumOff = false;
        }

        public ICommand MoveToHomeCommand { get; private set; }

        private async Task OnMoveToHomeCommand()
        {
            Logger?.LogInformation("User Pressed Move To Home Command.");

            Model.hiMoveToHome = true;
            await Task.Delay(Configuration.ButtonDelay); ;
            Model.hiMoveToHome = false;
        }

        public ICommand MoveToStationCommand { get; private set; }

        private async Task OnMoveToStationCommand()
        {
            Logger?.LogInformation("User Pressed Move to Station Command.");

            Model.hiMoveToStation = true;
            await Task.Delay(Configuration.ButtonDelay);
            Model.hiMoveToStation = false;
        }

        public ICommand MoveRelativeCommand { get; private set; }
        private async Task OnMoveRelativeCommand()
        {
            Logger?.LogInformation("User Pressed Move Relative Command.");

            Model.hiMoveRelative = true;
            await Task.Delay(Configuration.ButtonDelay);
            Model.hiMoveRelative = false;
        }

        public ICommand MoveAbsoluteCommand { get; private set; }
        private async Task OnMoveAbsoluteCommand()
        {
            Logger?.LogInformation("User Pressed Move Absolute Command.");

            Model.hiMoveAbsolute = true;
            await Task.Delay(Configuration.ButtonDelay);
            Model.hiMoveAbsolute = false;
        }

        public ICommand FetchPositionCommand { get; private set; }
        private async Task OnFetchPositionCommand()
        {
            Logger?.LogInformation("User Pressed Fetch Position Command.");

            Model.hiFetchPosition = true;
            await Task.Delay(Configuration.ButtonDelay);
            Model.hiFetchPosition = false;
        }

        public ICommand PickFromAlignerCommand { get; private set; }

        private async Task OnPickFromAlignerCommand()
        {
            Logger?.LogInformation("User Pressed Pick From Aligner Command.");

            Model.hiPickFromAligner = true;
            await Task.Delay(Configuration.ButtonDelay); ;
            Model.hiPickFromAligner = false;
        }

        public ICommand PlaceToAlignerCommand { get; private set; }

        private async Task OnPlaceToAlignerCommand()
        {
            Logger?.LogInformation("User Pressed Place To Aligner Command.");

            Model.hiPlaceToAligner = true;
            await Task.Delay(Configuration.ButtonDelay); ;
            Model.hiPlaceToAligner = false;
        }

        public ICommand PickFromCassetteACommand { get; private set; }

        private async Task OnPickFromCassetteACommand()
        {
            Logger?.LogInformation("User Pressed Pick From Cassette A Command.");

            Model.hiPickFromCassetteA = true;
            await Task.Delay(Configuration.ButtonDelay); ;
            Model.hiPickFromCassetteA = false;
        }

        public ICommand PlaceToCassetteACommand { get; private set; }

        private async Task OnPlaceToCassetteACommand()
        {
            Logger?.LogInformation("User Pressed Place To Cassette A Command.");

            Model.hiPlaceToCassetteA = true;
            await Task.Delay(Configuration.ButtonDelay); ;
            Model.hiPlaceToCassetteA = false;
        }

        public ICommand ScanCassetteACommand { get; private set; }

        private async Task OnScanCassetteACommand()
        {
            Logger?.LogInformation("User Pressed Scan Cassette A Command.");

            Model.hiScanCassetteA = true;
            await Task.Delay(Configuration.ButtonDelay); ;
            Model.hiScanCassetteA = false;
        }

        public ICommand PickFromCassetteBCommand { get; private set; }

        private async Task OnPickFromCassetteBCommand()
        {
            Logger?.LogInformation("User Pressed Pick From Cassette B Command.");

            Model.hiPickFromCassetteB = true;
            await Task.Delay(Configuration.ButtonDelay); ;
            Model.hiPickFromCassetteB = false;
        }

        public ICommand PlaceToCassetteBCommand { get; private set; }

        private async Task OnPlaceToCassetteBCommand()
        {
            Logger?.LogInformation("User Pressed Place To Cassette B Command.");

            Model.hiPlaceToCassetteB = true;
            await Task.Delay(Configuration.ButtonDelay); ;
            Model.hiPlaceToCassetteB = false;
        }

        public ICommand ScanCassetteBCommand { get; private set; }

        private async Task OnScanCassetteBCommand()
        {
            Logger?.LogInformation("User Pressed Scan Cassette B Command.");

            Model.hiScanCassetteB = true;
            await Task.Delay(Configuration.ButtonDelay); ;
            Model.hiScanCassetteB = false;
        }

        public ICommand SetSpeedCommand { get; private set; }

        private async Task OnSetSpeedCommand()
        {
            Logger?.LogInformation("User Pressed Set Speed Command.");

            Model.hiSetSpeed = true;
            await Task.Delay(Configuration.ButtonDelay); ;
            Model.hiSetSpeed = false;
        }

        public ICommand UpdateSpeedCommand { get; private set; }

        private async Task OnUpdateSpeedCommand()
        {
            Logger?.LogInformation("User Pressed Update Speed Command.");

            Model.hiUpdateSpeed = true;
            await Task.Delay(Configuration.ButtonDelay); ;
            Model.hiUpdateSpeed = false;
        }

        public ICommand SetReferenceWaferCommand { get; private set; }

        private async Task OnSetReferenceWaferCommand()
        {
            Logger?.LogInformation("User Pressed Set Reference Wafer Command.");

            Model.hiSetReferenceWafer = true;
            await Task.Delay(Configuration.ButtonDelay); ;
            Model.hiSetReferenceWafer = false;
        }

        public ICommand SetZStepRatio { get; private set; }

        private async Task OnSetZStepRatio()
        {
            Logger?.LogInformation("User Pressed Set Z-Step Ratio Command.");

            Model.hiSetZStepRatio = true;
            await Task.Delay(Configuration.ButtonDelay); ;
            Model.hiSetZStepRatio = false;
        }

        public ICommand AlignWaferCommand { get; private set; }

        private async Task OnAlignWaferCommand()
        {
            Logger?.LogInformation("User Pressed Align Wafer Command");

            Model.hiAlignWafer = true;
            await Task.Delay(Configuration.ButtonDelay); ;
            Model.hiAlignWafer = false;
        }
    }
}