using System.ComponentModel.DataAnnotations;

namespace JR.P262605.API
{
    public class APIConfiguration
    {
        [Required]
        public Aligner.AlignerConfiguration AlignerConfiguration { get; set; }

        [Required]
        public Robot.RobotConfiguration RobotConfiguration { get; set; }

        [Required]
        public GEM.GEMConfiguration GEMConfiguration { get; set; }

        [Required]
        public Laser.LaserConfiguration LaserConfiguration { get; set; }

        [Required]
        public Lumetrics.LumetricsConfiguration LumetricsConfiguration { get; set; }

        [Required]
        public Vision.VisionConfiguration TopVisionConfiguration { get; set; }

        [Required]
        public Vision.VisionConfiguration BottomVisionConfiguration { get; set; }
    }
}
