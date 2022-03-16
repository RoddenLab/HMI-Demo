using System.Text.Json.Serialization;

namespace JR.P262605.API.Laser.OPK
{
    public class MeasureComplete
    {
        [JsonPropertyName("ERROR")]
        public string Error { get; set; }

        [JsonPropertyName("POWER")]
        public double Power { get; set; }
    }
}