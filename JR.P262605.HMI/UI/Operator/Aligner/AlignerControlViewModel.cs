using JR.WPF;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Windows.Input;

namespace JR.P262605.HMI.UI.Operator.Aligner
{
    public class AlignerControlViewModel : BindableBase
    {
        private readonly ILogger Logger;
        private readonly IAppConfiguration Configuration;
        public AlignerControlModel Model { get; set; } = new();

        public AlignerControlViewModel(ILogger logger, IAppConfiguration configuration)
        {
            Logger = logger;
            Configuration = configuration;

            ResetAPICommand = new AsyncCommand(OnResetAPICommand);
            RemoveWaferCommand = new AsyncCommand(OnRemoveWaferCommand);
            AlignWaferCommand = new AsyncCommand(OnAlignWaferCommand);
            PollStatusCommand = new AsyncCommand(OnPollStatusCommand);
            ServoOnCommand = new AsyncCommand(OnServoOnCommand);
            HomeCommand = new AsyncCommand(OnHomeCommand);
            BypassAlignerOnCommand = new AsyncCommand(OnBypassAlignerOnCommand);
            BypassAlignerOffCommand = new AsyncCommand(OnBypassAlignerOffCommand);
        }

        public ICommand ResetAPICommand { get; private set; }

        private async Task OnResetAPICommand()
        {
            Logger?.LogInformation("User Pressed Aligner Reset API Command.");

            Model.hiResetAPI = true;
            await Task.Delay(Configuration.ButtonDelay); ;
            Model.hiResetAPI = false;
        }

        public ICommand RemoveWaferCommand { get; private set; }

        private async Task OnRemoveWaferCommand()
        {
            Logger?.LogInformation("User Pressed Aligner Remove Wafer Command.");

            Model.hiWaferRemoved = true;
            await Task.Delay(Configuration.ButtonDelay);
            Model.hiWaferRemoved = false;
        }

        public ICommand AlignWaferCommand { get; private set; }

        private async Task OnAlignWaferCommand()
        {
            Logger?.LogInformation("User Pressed Align Wafer Command.");

            Model.hiAlignWafer = true;
            await Task.Delay(Configuration.ButtonDelay); ;
            Model.hiAlignWafer = false;
        }

        public ICommand PollStatusCommand { get; private set; }

        private async Task OnPollStatusCommand()
        {
            Logger?.LogInformation("User Pressed Aligner Poll Status Command.");

            Model.hiPollStatus = true;
            await Task.Delay(Configuration.ButtonDelay); ;
            Model.hiPollStatus = false;
        }

        public ICommand ServoOnCommand { get; private set; }

        private async Task OnServoOnCommand()
        {
            Logger?.LogInformation("User Pressed Aligner Servo On Command.");

            Model.hiServoOn = true;
            await Task.Delay(Configuration.ButtonDelay); ;
            Model.hiServoOn = false;
        }

        public ICommand HomeCommand { get; private set; }

        private async Task OnHomeCommand()
        {
            Logger?.LogInformation("User Pressed Aligner Home Command.");

            Model.hiHome = true;
            await Task.Delay(Configuration.ButtonDelay); ;
            Model.hiHome = false;
        }

        public ICommand BypassAlignerOnCommand { get; private set; }

        private async Task OnBypassAlignerOnCommand()
        {
            Logger?.LogInformation("User Pressed Bypass Aligner On Command.");

            //Model.hiBypassAlignerOn = true;
            await Task.Delay(Configuration.ButtonDelay); ;
            //Model.hiBypassAlignerOn = false;
        }

        public ICommand BypassAlignerOffCommand { get; private set; }

        private async Task OnBypassAlignerOffCommand()
        {
            Logger?.LogInformation("User Pressed Bypass Aligner Off Command.");

            //Model.hiBypassAlignerOff = true;
            await Task.Delay(Configuration.ButtonDelay); ;
            //Model.hiBypassAlignerOff = false;
        }
    }
}