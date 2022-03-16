namespace JR.P262605.HMI
{
    public class AppConfiguration : IAppConfiguration
    {
        public int ButtonDelay { get; set; }
        public string OPCEndPoint { get; set; }
        public bool LaserEnabled { get; set; }
        public bool LumetricsEnabled { get; set; }
        public bool TopOCREnabled { get; set; }
    }

    public interface IAppConfiguration
    {
        public int ButtonDelay { get; set; }
        public string OPCEndPoint { get; set; }
        public bool LaserEnabled { get; set; }
        public bool LumetricsEnabled { get; set; }
        public bool TopOCREnabled { get; set; }
    }
}
