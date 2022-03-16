using JR.WPF;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace JR.P262605.HMI.UI.Navigation
{
    public class NavigationBarViewModel : BindableBase
    {
        public NavigationBarModel Model { get; set; }

        private Main.MainView MainView { get; set; }
        private Main.MainViewModel MainViewModel { get; set; }
        private Operator.OperatorView OperatorView { get; set; }
        private Operator.OperatorViewModel OperatorViewModel { get; set; }
        private readonly ILogger Logger;
        private readonly IAppConfiguration Configuration;

        public UserControl ActiveScreen
        {
            get => _ActiveScreen;
            set => SetProperty(ref _ActiveScreen, value);
        }

        private UserControl _ActiveScreen;

        public bool MainScreenActive
        {
            get => _MainScreenActive;
            set => SetProperty(ref _MainScreenActive, value);
        }
        private bool _MainScreenActive;

        public bool OperatorScreenActive
        {
            get => _OperatorScreenActive;
            set => SetProperty(ref _OperatorScreenActive, value);
        }
        private bool _OperatorScreenActive;

        public NavigationBarViewModel(ILogger logger, IAppConfiguration configuration)
        {
            // Set Logger
            Logger = logger;

            // Get Configuration
            Configuration = configuration;

            Model = new(logger);

            MainViewModel = new(logger, configuration);
            MainView = new()
            {
                DataContext = MainViewModel
            };

            OperatorViewModel = new(logger, configuration);
            OperatorView = new()
            {
                DataContext = OperatorViewModel
            };

            ActiveScreen = MainView;
            MainScreenActive = true;

            CommandUpdatePage = new Command((obj) => OnCommandUpdatePage(obj));
            CommandFaultAcknowledge = new AsyncCommand(OnCommandFaultAcknlowledge);
            CommandStationReset = new AsyncCommand(OnCommandStationReset);
            CommandCycleStart = new AsyncCommand(OnCommandCycleStart);
            CommandCycleStop = new AsyncCommand(OnCommandCycleStop);
            CommandCycleManual = new AsyncCommand(OnCommandCycleManual);
            CommandFaultReset = new AsyncCommand(OnCommandFaultReset);
            CommandExit = new Command(OnExitPress);
            CassetteDataEditorCommand = new Command(OnCassetteDataEditorCommand);
            RecipeEditorCommand = new Command(OnRecipeEditorCommand);
        }

        public ICommand CommandUpdatePage { get; private set; }

        private void OnCommandUpdatePage(object obj)
        {
            string Button = (string)obj;

            Logger?.LogInformation($"User pressed {Button} Screen Button.");

            MainScreenActive = OperatorScreenActive = false;

            switch (Button)
            {
                case "Main":
                    ActiveScreen = MainView;
                    MainScreenActive = true;
                    break;

                case "Operator":
                    ActiveScreen = OperatorView;
                    OperatorScreenActive = true;
                    break;
            }
        }

        public ICommand CommandFaultAcknowledge { get; private set; }

        private async Task OnCommandFaultAcknlowledge()
        {
            Logger?.LogInformation("User pressed Fault Acknowledge.");

            Model.FaultAcknowledge = true;
            await Task.Delay(Configuration.ButtonDelay); ;
            Model.FaultAcknowledge = false;
        }

        public ICommand CommandStationReset { get; private set; }

        private async Task OnCommandStationReset()
        {
            Logger?.LogInformation("User pressed Station Initialization.");

            Model.StationReset = true;
            await Task.Delay(Configuration.ButtonDelay); ;
            Model.StationReset = false;
        }

        public ICommand CommandCycleStart { get; private set; }

        private async Task OnCommandCycleStart()
        {
            Logger?.LogInformation("User pressed Cycle Start.");

            Model.CycleStartRequest = true;
            await Task.Delay(Configuration.ButtonDelay); ;
            Model.CycleStartRequest = false;
        }

        public ICommand CommandCycleStop { get; private set; }

        private async Task OnCommandCycleStop()
        {
            Logger?.LogInformation("User pressed Cycle Stop.");

            Model.CycleStopRequest = true;
            await Task.Delay(Configuration.ButtonDelay); ;
            Model.CycleStopRequest = false;
        }

        public ICommand CommandCycleManual { get; private set; }

        private async Task OnCommandCycleManual()
        {
            Logger?.LogInformation("User pressed Cycle Manual.");

            Model.ManualModeRequest = true;
            await Task.Delay(Configuration.ButtonDelay); ;
            Model.ManualModeRequest = false;
        }

        public ICommand CommandFaultReset { get; private set; }

        private async Task OnCommandFaultReset()
        {
            Logger?.LogInformation("User pressed Fault Reset.");

            Model.FaultResetCommand = true;
            await Task.Delay(Configuration.ButtonDelay); ;
            Model.FaultResetCommand = false;
        }

        public ICommand CommandExit { get; private set; }

        private void OnExitPress()
        {
            Logger?.LogInformation($"User Pressed Exit Button");

            MessageBoxResult MessageBoxResult = MessageBox.Show("Are you sure?", "Exit", MessageBoxButton.YesNo);
            if (MessageBoxResult == MessageBoxResult.Yes)
            {
                Application.Current.Shutdown();
            }
        }

        public ICommand CassetteDataEditorCommand { get; private set; }
        private void OnCassetteDataEditorCommand()
        {
            Logger?.LogInformation($"User Started Cassette Data Editor");

            Data.CassetteViewModel CassetteViewModel = new();
            Data.CassetteView CassetteView = new()
            {
                DataContext = CassetteViewModel
            };
            CassetteView.ShowDialog();
        }

        public ICommand RecipeEditorCommand { get; private set; }
        private void OnRecipeEditorCommand()
        {
            Logger?.LogInformation($"User Started Recipe Editor");

            Recipe.RecipeViewModel RecipeViewModel = new();
            Recipe.RecipeView RecipeView = new()
            {
                DataContext = RecipeViewModel
            };
            RecipeView.ShowDialog();
        }
    }
}