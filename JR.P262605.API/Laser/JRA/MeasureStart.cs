using System.Text.Json.Serialization;

namespace JR.P262605.API.Laser.JRA
{
    public class MeasureStart
    {
        [JsonPropertyName("PEC")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public double PEC { get; set; }

        [JsonPropertyName("PRF")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public int PRF { get; set; }

        [JsonPropertyName("ATTENUATOR")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public double Attenuator { get; set; }

        [JsonPropertyName("TARGET")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public double Target { get; set; }
    }
}