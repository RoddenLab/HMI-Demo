using JR.WPF;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;

namespace JR.P262605.HMI.UI.Operator.SMIF
{
    public class SMIFControlViewModel : BindableBase
    {
        public ISMIFModel Model { get; set; }
        private readonly string ComponentName;
        private readonly ILogger Logger;
        private readonly IAppConfiguration Configuration;

        public SMIFControlViewModel(ILogger logger, IAppConfiguration configuration)
        {
            Logger = logger;
            Configuration = configuration;
        }

        public SMIFControlViewModel(ILogger logger, IAppConfiguration configuration, Position position)
        {
            Logger = logger;
            Configuration = configuration;

            if (position == Position.Left)
            {
                ComponentName = "Left Loader";
                Model = new SMIFLeftModel();
            }
            else
            {
                ComponentName = "Right Loader";
                Model = new SMIFRightModel();
            }

            LoaderEnableCommand = new AsyncCommand((obj) => OnLoaderEnableCommand(obj));
            PlaceCassetteCommand = new AsyncCommand(OnPlaceCassetteCommand);
            InitializeInterfaceCommand = new AsyncCommand(OnInitializeInterfaceCommand);
            SoftwareResetCommand = new AsyncCommand(OnSoftwareResetCommand);
            ClearErrorCommand = new AsyncCommand(OnClearErrorCommand);
            FetchStatusCommand = new AsyncCommand(OnFetchStatusCommand);
            OpenPodCommand = new AsyncCommand(OnOpenPodCommand);
            ClosePodCommand = new AsyncCommand(OnClosePodCommand);
            LoadCassetteCommand = new AsyncCommand(OnLoadCassetteCommand);
            UnloadCassetteCommand = new AsyncCommand(OnUnloadCassetteCommand);
            SelectDataCommand = new Command(OnSelectDataCommand);
            SetE84LocalCommand = new AsyncCommand(OnSetE84LocalCommand);
            SetE84RemoteCommand = new AsyncCommand(OnSetE84RemoteCommand);
            SetE84RecoveryCommand = new AsyncCommand(OnSetE84RecoveryCommand);
            ClearPortCommand = new AsyncCommand(OnClearPortCommand);
            ClearDoorRequestCommand = new AsyncCommand(OnClearDoorRequestCommand);
        }

        public enum Position
        {
            Left,
            Right
        }

        public ICommand SelectDataCommand { get; private set; }

        private void OnSelectDataCommand()
        {
            Logger?.LogInformation($"User Pressed Select Data Command.");

            OpenFileDialog OpenFileDialog = new();
            OpenFileDialog.Filter = "Cassette Data Files (*.data)|*.data|All Files(*.*)|*.*";
            if (OpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                Model.hiCassetteFile = OpenFileDialog.FileName;
            }
        }

        public ICommand LoaderEnableCommand { get; private set; }

        private async Task OnLoaderEnableCommand(object value)
        {
            bool Enable = (bool)value;

            if (Enable)
            {
                Logger?.LogInformation($"{ComponentName} - User Pressed Loader Enable Command.");

                Model.hiLoaderEnable = true;
                await Task.Delay(Configuration.ButtonDelay);
                Model.hiLoaderEnable = false;
            }
            else
            {
                Logger?.LogInformation($"{ComponentName} - User Pressed Loader Disable Command.");

                Model.hiLoaderDisable = true;
                await Task.Delay(Configuration.ButtonDelay);
                Model.hiLoaderDisable = false;
            }
        }

        public ICommand PlaceCassetteCommand { get; private set; }

        private async Task OnPlaceCassetteCommand()
        {
            Logger?.LogInformation($"{ComponentName} - User Pressed Place Cassette Command");

            try
            {
                Data.CassetteModel CassetteData = JsonSerializer.Deserialize<Data.CassetteModel>(File.ReadAllText(Model.hiCassetteFile));

                if (CassetteData is not null)
                {
                    Model.SetData(CassetteData);
                    await Task.Delay(500);
                    Model.hiCassettePlaced = true;
                    await Task.Delay(Configuration.ButtonDelay); ;
                    Model.hiCassettePlaced = false;
                }
            }
            catch (Exception Exception)
            {
                Logger?.LogError($"{ComponentName} - Error Placing Cassette - Exception {Exception}");
            }
        }

        public ICommand InitializeInterfaceCommand { get; private set; }
        private async Task OnInitializeInterfaceCommand()
        {
            Logger?.LogInformation($"{ComponentName} - User Pressed Initialize Interface Command.");

            Model.hiInitialize = true;
            await Task.Delay(Configuration.ButtonDelay);
            Model.hiInitialize = false;
        }

        public ICommand SoftwareResetCommand { get; private set; }
        private async Task OnSoftwareResetCommand()
        {
            Logger?.LogInformation($"{ComponentName} - User Pressed Software Reset Command.");

            Model.hiSoftwareReset = true;
            await Task.Delay(Configuration.ButtonDelay);
            Model.hiSoftwareReset = false;
        }

        public ICommand ClearErrorCommand { get; private set; }
        private async Task OnClearErrorCommand()
        {
            Logger?.LogInformation($"{ComponentName} - User Pressed Clear Error Command.");

            Model.hiStatusClear = true;
            await Task.Delay(Configuration.ButtonDelay);
            Model.hiStatusClear = false;
        }


        public ICommand FetchStatusCommand { get; private set; }
        private async Task OnFetchStatusCommand()
        {
            Logger?.LogInformation($"{ComponentName} - User Pressed Fetch Status Command.");

            Model.hiFetchStatus = true;
            await Task.Delay(Configuration.ButtonDelay);
            Model.hiFetchStatus = false;
        }

        public ICommand OpenPodCommand { get; private set; }
        private async Task OnOpenPodCommand()
        {
            Logger?.LogInformation($"{ComponentName} - User Pressed Open Pod Command.");

            Model.hiOpenPod = true;
            await Task.Delay(Configuration.ButtonDelay);
            Model.hiOpenPod = false;
        }

        public ICommand ClosePodCommand { get; private set; }
        private async Task OnClosePodCommand()
        {
            Logger?.LogInformation($"{ComponentName} - User Pressed Close Pod Command.");

            Model.hiClosePod = true;
            await Task.Delay(Configuration.ButtonDelay);
            Model.hiClosePod = false;
        }

        public ICommand LoadCassetteCommand { get; private set; }
        private async Task OnLoadCassetteCommand()
        {
            Logger?.LogInformation($"{ComponentName} - User Pressed Load Cassette Command.");

            Model.hiLoad = true;
            await Task.Delay(Configuration.ButtonDelay);
            Model.hiLoad = false;
        }

        public ICommand UnloadCassetteCommand { get; private set; }
        private async Task OnUnloadCassetteCommand()
        {
            Logger?.LogInformation($"{ComponentName} - User Pressed Unload Cassette Command.");

            Model.hiUnload = true;
            await Task.Delay(Configuration.ButtonDelay);
            Model.hiUnload = false;
        }

        public ICommand SetE84LocalCommand { get; private set; }
        private async Task OnSetE84LocalCommand()
        {
            Logger?.LogInformation($"{ComponentName} - User Pressed E84 Access Local Command.");

            Model.hiAccessLocal = true;
            await Task.Delay(Configuration.ButtonDelay);
            Model.hiAccessLocal = false;
        }

        public ICommand SetE84RemoteCommand { get; private set; }
        private async Task OnSetE84RemoteCommand()
        {
            Logger?.LogInformation($"{ComponentName} - User Pressed E84 Access Remote Command.");

            Model.hiAccessRemote = true;
            await Task.Delay(Configuration.ButtonDelay);
            Model.hiAccessRemote = false;
        }

        public ICommand SetE84RecoveryCommand { get; private set; }
        private async Task OnSetE84RecoveryCommand()
        {
            Logger?.LogInformation($"{ComponentName} - User Pressed E84 Recovery Command.");

            Model.hiE84Recovery = true;
            await Task.Delay(Configuration.ButtonDelay);
            Model.hiE84Recovery = false;
        }

        public ICommand ClearPortCommand { get; private set; }
        private async Task OnClearPortCommand()
        {
            Logger?.LogInformation($"{ComponentName} - User Pressed Clear Port Command");

            Model.hiClearPort = true;
            await Task.Delay(Configuration.ButtonDelay);
            Model.hiClearPort = false;
        }

        public ICommand ClearDoorRequestCommand { get; private set; }
        private async Task OnClearDoorRequestCommand()
        {
            Logger?.LogInformation($"{ComponentName} - User Pressed Clear Door Request Command");

            Model.hiClearDoorRequest = true;
            await Task.Delay(Configuration.ButtonDelay);
            Model.hiClearDoorRequest = false;
        }
    }
}
