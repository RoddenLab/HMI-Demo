using System.ComponentModel.DataAnnotations;

namespace JR.P262605.API.Aligner
{
    public class AlignerConfiguration
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public bool Enabled { get; set; }

        [Required]
        public string TCPEndpoint { get; set; }

        [Required]
        public string ADSEndpoint { get; set; }
    }
}
