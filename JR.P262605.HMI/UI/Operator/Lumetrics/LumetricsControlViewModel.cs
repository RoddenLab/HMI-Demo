using JR.WPF;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Windows.Input;

namespace JR.P262605.HMI.UI.Operator.Lumetrics
{
    public class LumetricsControlViewModel
    {
        private readonly ILogger Logger;
        private readonly IAppConfiguration Configuration;
        public LumetricsControlModel Model { get; set; } = new();

        public LumetricsControlViewModel(ILogger logger, IAppConfiguration configuration)
        {
            Logger = logger;
            Configuration = configuration;

            LumetricsMeasurementCommand = new AsyncCommand(OnLumetricsMeasurementCommand);
        }

        public ICommand LumetricsMeasurementCommand { get; private set; }

        private async Task OnLumetricsMeasurementCommand()
        {
            Logger?.LogInformation("User Pressed LumetricsMeasurement Command");

            Model.hiReadLumetricsMeasurement = true;
            await Task.Delay(Configuration.ButtonDelay);
            Model.hiReadLumetricsMeasurement = false;
        }
    }
}
