using System.Text.Json.Serialization;

namespace JR.P262605.API.Laser.OPK
{
    public class MarkIDSet
    {
        [JsonPropertyName("ID")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string ID { get; set; }
    }
}
