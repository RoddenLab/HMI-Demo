using JR.WPF;
using Microsoft.Extensions.Logging;
using System.Windows.Controls;
using System.Windows.Input;

namespace JR.P262605.HMI.UI.Operator
{
    public class OperatorViewModel : BindableBase
    {
        public readonly IAppConfiguration Configuration;
        private readonly ILogger Logger;
        public PLC.PLCControlView PLCControlView { get; set; }
        public PLC.PLCControlViewModel PLCControlViewModel { get; set; }
        public Robot.RobotControlView RobotControlView { get; set; }
        public Robot.RobotControlViewModel RobotControlViewModel { get; set; }
        public Aligner.AlignerControlView AlignerControlView { get; set; }
        public Aligner.AlignerControlViewModel AlignerControlViewModel { get; set; }
        public Laser.LaserControlView LaserControlView { get; set; }
        public Laser.LaserControlViewModel LaserControlViewModel { get; set; }
        public Lumetrics.LumetricsView LumetricsControlView { get; set; }
        public Lumetrics.LumetricsControlViewModel LumetricsControlViewModel { get; set; }
        public OCR.OCRControlView OCRControlView { get; set; }
        public OCR.OCRControlViewModel OCRControlViewModel { get; set; }
        public SMIF.SMIFControlView SMIFControlView { get; set; }
        public SMIF.SMIFControlViewModel SMIFRightViewModel { get; set; }
        public SMIF.SMIFControlViewModel SMIFLeftViewModel { get; set; }

        public OperatorViewModel(ILogger logger, IAppConfiguration configuration)
        {
            // Set Logger
            Logger = logger;

            // Get Configuration
            Configuration = configuration;

            LumetricsScreenEnabled = Configuration.LumetricsEnabled;
            LaserScreenEnabled = Configuration.LaserEnabled;


            PLCControlViewModel = new();
            PLCControlView = new()
            {
                DataContext = PLCControlViewModel
            };

            RobotControlViewModel = new(logger, configuration);
            RobotControlView = new()
            {
                DataContext = RobotControlViewModel
            };

            AlignerControlViewModel = new(logger, configuration);
            AlignerControlView = new()
            {
                DataContext = AlignerControlViewModel
            };

            if (Configuration.LaserEnabled)
            {
                LaserControlViewModel = new(logger, configuration);
                LaserControlView = new()
                {
                    DataContext = LaserControlViewModel
                };
            }

            if (Configuration.LumetricsEnabled)
            {
                LumetricsControlViewModel = new(logger, configuration);
                LumetricsControlView = new()
                {
                    DataContext = LumetricsControlViewModel
                };
            }

            OCRControlViewModel = new(logger, configuration);
            OCRControlView = new()
            {
                DataContext = OCRControlViewModel
            };

            SMIFRightViewModel = new(logger, configuration, SMIF.SMIFControlViewModel.Position.Right);
            SMIFLeftViewModel = new(logger, configuration, SMIF.SMIFControlViewModel.Position.Left);
            SMIFControlView = new()
            {
                DataContext = SMIFRightViewModel
            };

            ActiveScreen = PLCControlView;

            SelectScreenCommand = new Command((screen) => SelectScreen(screen));
        }

        public UserControl ActiveScreen
        {
            get => _ActiveScreen;
            set => SetProperty(ref _ActiveScreen, value);
        }

        private UserControl _ActiveScreen;

        public ICommand SelectScreenCommand { get; private set; }

        private void SelectScreen(object screen)
        {
            PLCScreenActive = false;
            RobotScreenActive = false;
            AlignerScreenActive = false;
            LaserScreenActive = false;
            LumetricsScreenActive = false;
            OCRScreenActive = false;
            SMIFRightScreenActive = false;
            SMIFLeftScreenActive = false;

            string Screen = (string)screen;

            switch (Screen)
            {
                case "PLC":
                    ActiveScreen = PLCControlView;
                    PLCScreenActive = true;
                    break;

                case "Robot":
                    ActiveScreen = RobotControlView;
                    RobotScreenActive = true;
                    break;

                case "Aligner":
                    ActiveScreen = AlignerControlView;
                    AlignerScreenActive = true;
                    break;

                case "Laser":
                    ActiveScreen = LaserControlView;
                    LaserScreenActive = true;
                    break;

                case "Lumetrics":
                    ActiveScreen = LumetricsControlView;
                    LumetricsScreenActive = true;
                    break;

                case "OCR":
                    ActiveScreen = OCRControlView;
                    OCRScreenActive = true;
                    break;

                case "SMIFRight":
                    SMIFControlView.DataContext = SMIFRightViewModel;
                    ActiveScreen = SMIFControlView;
                    SMIFRightScreenActive = true;
                    break;

                case "SMIFLeft":
                    SMIFControlView.DataContext = SMIFLeftViewModel;
                    ActiveScreen = SMIFControlView;
                    SMIFLeftScreenActive = true;
                    break;
            }
        }

        public bool LaserScreenEnabled { get; set; }
        public bool LumetricsScreenEnabled { get; set; }

        public bool PLCScreenActive
        {
            get => _PLCScreenActive;
            set => SetProperty(ref _PLCScreenActive, value);
        }

        private bool _PLCScreenActive = true;

        public bool RobotScreenActive
        {
            get => _RobotScreenActive;
            set => SetProperty(ref _RobotScreenActive, value);
        }

        private bool _RobotScreenActive;

        public bool AlignerScreenActive
        {
            get => _AlignerScreenActive;
            set => SetProperty(ref _AlignerScreenActive, value);
        }

        private bool _AlignerScreenActive;

        public bool LaserScreenActive
        {
            get => _LaserScreenActive;
            set => SetProperty(ref _LaserScreenActive, value);
        }

        private bool _LaserScreenActive;

        public bool LumetricsScreenActive
        {
            get { return _LumetricsScreenActive; }
            set { SetProperty(ref _LumetricsScreenActive, value); }
        }
        private bool _LumetricsScreenActive;

        public bool OCRScreenActive
        {
            get => _OCRScreenActive;
            set => SetProperty(ref _OCRScreenActive, value);
        }

        private bool _OCRScreenActive;

        public bool SMIFRightScreenActive
        {
            get => _SMIFRightScreenActive;
            set => SetProperty(ref _SMIFRightScreenActive, value);
        }
        private bool _SMIFRightScreenActive;

        public bool SMIFLeftScreenActive
        {
            get => _SMIFLeftScreenActive;
            set => SetProperty(ref _SMIFLeftScreenActive, value);
        }
        private bool _SMIFLeftScreenActive;
    }
}