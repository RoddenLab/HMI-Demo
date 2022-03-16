using JR.P262605.API;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Serilog;
using System;
using System.IO;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using Workstation.ServiceModel.Ua;

[assembly: TypeLibrary()]
namespace JR.P262605.HMI
{
    public partial class App : Application
    {
        private UaApplication UaApplication;
        private UI.Navigation.NavigationBarView NavigationBarView;
        private UI.Navigation.NavigationBarViewModel NavigationBarViewModel;
        private readonly CancellationTokenSource CancellationTokenSource = new();
        private readonly string LogDirectory;
        private readonly IAppConfiguration Configuration; 
        private readonly Microsoft.Extensions.Logging.ILogger Logger;    

        public App()
        {
            // Create Logger
            LogDirectory = Path.Combine(new FileInfo(AppDomain.CurrentDomain.BaseDirectory).Directory.Parent.FullName, "Logs");

            Directory.CreateDirectory(LogDirectory);

            Logger = new Microsoft.Extensions.Logging.LoggerFactory()
                    .AddSerilog(new LoggerConfiguration()
                    .MinimumLevel.Verbose()
                    .WriteTo.File(Path.Combine(LogDirectory, "HMI-LOG-.txt"),
                        rollingInterval: RollingInterval.Day,
                        restrictedToMinimumLevel: Serilog.Events.LogEventLevel.Verbose)
                    .CreateLogger()).CreateLogger("HMI");

            Logger?.LogInformation($"Logger Initialized");

            // Load Configuration
            Logger?.LogInformation($"Initializing Application Configuration");

            Configuration = new ConfigurationBuilder().AddJsonFile("appConfig.json", true).Build().Get<AppConfiguration>();

            InitializeComponent();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            _ = APIHost.RunAsync(CancellationTokenSource.Token);
            Task.Delay(2500).Wait();

            InitializeOPCClient();
            Task.Delay(2500).Wait();

            NavigationBarViewModel = new(Logger, Configuration);
            NavigationBarView = new()
            {
                DataContext = NavigationBarViewModel
            };
            NavigationBarView.Show();

            base.OnStartup(e);
        }

        protected override void OnExit(ExitEventArgs e)
        {
            Logger?.LogInformation("Closing application.");
            CancellationTokenSource.Cancel();
            UaApplication?.Dispose();
            base.OnExit(e);
        }

        private void InitializeOPCClient()
        {
            Logger?.LogInformation("Building OPC UA Client.");

            try
            {
                EndpointDescription EndPointDescription = new()
                {
                    EndpointUrl = Configuration.OPCEndPoint
                };

                ILoggerFactory LoggerFactory = new LoggerFactory()
                    .AddSerilog(new LoggerConfiguration()
                    .MinimumLevel.Debug()
                    .WriteTo.File(Path.Combine(LogDirectory, "OPC-LOG-.txt"),
                        rollingInterval: RollingInterval.Day,
                        restrictedToMinimumLevel: Serilog.Events.LogEventLevel.Debug)
                    .CreateLogger());

                UaApplication = new UaApplicationBuilder()
                    .SetApplicationUri($"urn:{Dns.GetHostName()}:Annealer")
                    .SetDirectoryStore(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Annealer", "pki"))
                    .SetIdentity(new AnonymousIdentity())
                    .SetLoggerFactory(LoggerFactory)
                    .AddMappedEndpoint("PLC", EndPointDescription)
                    .Build();

                Logger?.LogInformation("Starting OPC UA Client.");

                UaApplication.Run();
            }
            catch (Exception)
            {
                _ = MessageBox.Show("Unable to run application. Please execute as Administrator.");
                Environment.Exit(1);
            }
        }
    }
}