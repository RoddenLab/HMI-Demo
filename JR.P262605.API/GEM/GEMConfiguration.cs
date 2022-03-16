using System.ComponentModel.DataAnnotations;

namespace JR.P262605.API.GEM
{
    public class GEMConfiguration
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public bool Enabled { get; set; }

        [Required]
        public string ADSEndPoint { get; set; } 
    }
}
