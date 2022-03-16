using System.Text.Json.Serialization;

namespace JR.P262605.API.Laser.OPK
{
    public class ProcessComplete
    {
        [JsonPropertyName("ERROR")]
        public string Error { get; set; }
    }
}