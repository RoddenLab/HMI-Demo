using System.ComponentModel.DataAnnotations;

namespace JR.P262605.API.Lumetrics
{
    public class LumetricsConfiguration
    {
        [Required]
        public string TCPEndpoint { get; set; }
        [Required]
        public string ADSEndpoint { get; set; }
        [Required]
        public bool Enabled { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
