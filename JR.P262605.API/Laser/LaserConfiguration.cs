namespace JR.P262605.API.Laser
{
    public class LaserConfiguration
    {
        public string Name { get; set; }
        public bool Enabled { get; set; }
        public string TCPEndpoint { get; set; }
        public string ADSEndpoint { get; set; }
    }
}