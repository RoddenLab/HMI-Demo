using System.Text.Json;
using System.Text.Json.Serialization;

namespace JR.P262605.API.Laser.JRA
{
    public class Message
    {
        [JsonPropertyName("ABORT")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Abort AbortProcess { get; set; }

        [JsonPropertyName("MEASURE_START")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public MeasureStart MeasureStart { get; set; }

        [JsonPropertyName("SET_RECIPE")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public SetRecipe SetRecipe { get; set; }

        [JsonPropertyName("START_PROCESS")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public StartProcess StartProcess { get; set; }

        [JsonPropertyName("REQUEST_STATUS")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public StatusRequest StatusRequest { get; set; }

        [JsonPropertyName("MARK_ID_SET")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public MarkIDSet MarkIDSet { get; set; }

        private static JsonSerializerOptions Options { get; set; } = new()
        {
            IncludeFields = true,
            PropertyNameCaseInsensitive = true,
            WriteIndented = true
        };

        public static string Serialize(Message message)
        {
            return JsonSerializer.Serialize(message, Options);
        }

        public static Message Deserialize(string message)
        {
            return (Message)JsonSerializer.Deserialize(message, typeof(Message), Options);
        }
    }
}