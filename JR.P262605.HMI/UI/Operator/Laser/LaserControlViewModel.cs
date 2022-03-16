using JR.WPF;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;

namespace JR.P262605.HMI.UI.Operator.Laser
{
    public class LaserControlViewModel
    {
        private readonly ILogger Logger;
        private readonly IAppConfiguration Configuration;
        public LaserControlModel Model { get; set; } = new();

        public LaserControlViewModel(ILogger logger, IAppConfiguration configuration)
        {
            Logger = logger;
            Configuration = configuration;

            MeasurePowerCommand = new AsyncCommand(OnMeasurePowerCommand);
            SelectRecipeCommand = new AsyncCommand(OnSelectRecipeCommand);
            SetWaferRecipeCommand = new AsyncCommand(OnSetWaferRecipeCommand);
            SetMarkIDCommand = new AsyncCommand(OnSetMarkIDCommand);
            SetWaferMarkIDCommand = new AsyncCommand(OnSetWaferMarkIDCommand);
            StartRecipeCommand = new AsyncCommand(OnStartRecipeCommand);
            AbortCommand = new AsyncCommand(OnAbortCommand);
        }

        public ICommand MeasurePowerCommand { get; private set; }

        private async Task OnMeasurePowerCommand()
        {
            Logger?.LogInformation("User Pressed Measure Power Command");

            Model.hiMeasureStart = true;
            await Task.Delay(Configuration.ButtonDelay); ;
            Model.hiMeasureStart = false;
        }

        public ICommand SetWaferRecipeCommand { get; private set; }

        private async Task OnSetWaferRecipeCommand()
        {
            Logger?.LogInformation("User Pressed Set Wafer Recipe Command");

            Model.hiWaferRecipeSet = true;
            await Task.Delay(Configuration.ButtonDelay); ;
            Model.hiWaferRecipeSet = false;
        }

        public ICommand SetMarkIDCommand { get; private set; }

        private async Task OnSetMarkIDCommand()
        {
            Logger?.LogInformation("User Pressed Set Mark ID Command");

            Model.hiMarkIDSet = true;
            await Task.Delay(Configuration.ButtonDelay); ;
            Model.hiMarkIDSet = false;
        }

        public ICommand SelectRecipeCommand { get; private set; }

        private async Task OnSelectRecipeCommand()
        {
            Logger?.LogInformation("User Pressed Select Recipe Command");

            OpenFileDialog OpenFileDialog = new()
            {
                Filter = "Weldmark Files (*.wmj3)|*.wmj3|All Files (*.*)|*.*"
            };

            if (OpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (!string.IsNullOrWhiteSpace(OpenFileDialog.FileName))
                {
                    Model.hiSelectedRecipe = OpenFileDialog.FileName.Replace("C:", $"\\\\{Environment.MachineName}");
                    await Task.Delay(Configuration.ButtonDelay); ;
                    Model.hiRecipeSet = true;
                    await Task.Delay(Configuration.ButtonDelay); ;
                    Model.hiRecipeSet = false;
                }
            }
        }

        public ICommand SetWaferMarkIDCommand { get; private set; }
        private async Task OnSetWaferMarkIDCommand()
        {
            Logger?.LogInformation("User Pressed Set Wafer Mark ID Command");

            Model.hiWaferMarkIDSet = true;
            await Task.Delay(Configuration.ButtonDelay); ;
            Model.hiWaferMarkIDSet = false;
        }

        public ICommand StartRecipeCommand { get; private set; }
        private async Task OnStartRecipeCommand()
        {
            Logger?.LogInformation("User Pressed Start Recipe Command");

            Model.hiRecipeStart = true;
            await Task.Delay(Configuration.ButtonDelay); ;
            Model.hiRecipeStart = false;
        }


        public ICommand AbortCommand { get; private set; }
        private async Task OnAbortCommand()
        {
            Logger?.LogInformation("User Pressed Abort Recipe Command");

            Model.hiAbort = true;
            await Task.Delay(Configuration.ButtonDelay); ;
            Model.hiAbort = false;
        }
    }
}