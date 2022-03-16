using JR.WPF;

namespace JR.P262605.HMI.UI.Data
{
    public class CassetteModel : BindableBase
    {
        public string RFID
        {
            get => _RFID;
            set => SetProperty(ref _RFID, value);
        }

        private string _RFID;

        public int WaferSize
        {
            get => _WaferSize;
            set => SetProperty(ref _WaferSize, value);
        }

        private int _WaferSize = 0;

        public int WaferNotch
        {
            get => _WaferNotch;
            set => SetProperty(ref _WaferNotch, value);
        }

        private int _WaferNotch = 0;

        public string[] CarrierIDs
        {
            get => _CarrierIDs;
            set => SetProperty(ref _CarrierIDs, value);
        }

        private string[] _CarrierIDs = new string[25];

        public string[] ScribeIDs
        {
            get => _ScribeIDs;
            set => SetProperty(ref _ScribeIDs, value);
        }

        private string[] _ScribeIDs = new string[25];

        public double[] Thicknesses
        {
            get => _Thicknesses;
            set => SetProperty(ref _Thicknesses, value);
        }
        
        private double[] _Thicknesses = new double[25];

        public void SetData(CassetteModel other)
        {
            RFID = other.RFID;
            WaferSize = other.WaferSize;
            WaferNotch = other.WaferNotch;
            CarrierIDs = other.CarrierIDs;
            ScribeIDs = other.ScribeIDs;
            Thicknesses = other.Thicknesses;
        }
    }
}