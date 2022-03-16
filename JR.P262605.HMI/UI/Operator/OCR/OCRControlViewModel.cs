using JR.WPF;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Windows.Input;

namespace JR.P262605.HMI.UI.Operator.OCR
{
    public class OCRControlViewModel
    {
        private readonly ILogger Logger;
        private readonly IAppConfiguration Configuration;
        public OCRControlModel Model { get; set; } = new();
        public bool TopCameraEnabled { get; set; }

        public OCRControlViewModel(ILogger logger, IAppConfiguration configuration)
        {
            Logger = logger;
            Configuration = configuration;
            TopCameraEnabled = Configuration.TopOCREnabled;

            TopCameraScanCommand = new AsyncCommand(OnTopCameraScanCommand);
            BottomCameraScanCommand = new AsyncCommand(OnBottomCameraScanCommand);
        }

        public ICommand TopCameraScanCommand { get; private set; }

        private async Task OnTopCameraScanCommand()
        {
            Logger?.LogInformation("User Pressed Top Camera Scan Command");

            Model.hiReadTopOCR = true;
            await Task.Delay(Configuration.ButtonDelay);
            Model.hiReadTopOCR = false;
        }

        public ICommand BottomCameraScanCommand { get; private set; }

        private async Task OnBottomCameraScanCommand()
        {
            Logger?.LogInformation("User Pressed Bottom Camera Scan Command");

            Model.hiReadBottomOCR = true;
            await Task.Delay(Configuration.ButtonDelay);
            Model.hiReadBottomOCR = false;
        }
    }
}