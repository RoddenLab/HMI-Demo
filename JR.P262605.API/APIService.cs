using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace JR.P262605.API
{
    public class APIService : BackgroundService
    {
        private readonly Robot.RobotModel RobotModel;
        private readonly Aligner.AlignerModel AlignerModel;
        private readonly Vision.VisionModel TopCameraModel;
        private readonly Vision.VisionModel BottomCameraModel;
        private readonly Laser.LaserModel LaserModel;
        private readonly Lumetrics.LumetricsModel LumetricsModel;
        private readonly GEM.GEMModel GEMModel;
        private readonly ILogger Logger;

        public APIService(ILogger logger, IConfiguration configuration)
        {
            Logger = logger;
            RobotModel = new(logger, configuration);
            AlignerModel = new(logger, configuration);
            TopCameraModel = new(logger, configuration, Vision.VisionModel.Position.Top);
            BottomCameraModel = new(logger, configuration, Vision.VisionModel.Position.Bottom);
            LaserModel = new(logger, configuration);
            LumetricsModel = new(logger, configuration);
            GEMModel = new(logger, configuration);
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                Logger?.LogInformation("API Heartbeat");

                await Task.Delay(2500, stoppingToken);
            }
        }
    }
}
