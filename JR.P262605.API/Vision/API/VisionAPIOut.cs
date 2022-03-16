using JR.ADS;

namespace JR.P262605.API.Vision.API
{
    public class VisionAPIOut : AdsTag
    {
        public VisionAPIOut(string name) : base(name)
        {
        }

        public int HeartbeatEcho
        {
            get => _HeartbeatEcho;
            set => SetProperty(ref _HeartbeatEcho, value);
        }

        private int _HeartbeatEcho;

        public bool Connected
        {
            get => _Connected;
            set => SetProperty(ref _Connected, value);
        }

        private bool _Connected;

        public bool Done
        {
            get => _Done;
            set => SetProperty(ref _Done, value);
        }

        private bool _Done;

        public int Error
        {
            get => _Error;
            set => SetProperty(ref _Error, value);
        }

        private int _Error;

        public string OCRCode
        {
            get => _OCRCode;
            set => SetProperty(ref _OCRCode, value);
        }

        private string _OCRCode;

        public void ResetHandshake()
        {
            Done = false;
            Error = 0;
        }
    }
}