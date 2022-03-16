using System.Text.Json;
using System.Text.Json.Serialization;

namespace JR.P262605.API.Laser.OPK
{
    public class Message
    {
        [JsonPropertyName("ABORT_COMPLETE")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public AbortComplete AbortComplete { get; set; }

        [JsonPropertyName("ERROR")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Error Error { get; set; }

        [JsonPropertyName("MEASURE_ACK")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public MeasureAck MeasureAck { get; set; }

        [JsonPropertyName("MEASURE_COMPLETE")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public MeasureComplete MeasureComplete { get; set; }

        [JsonPropertyName("PROCESS_ACK")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public ProcessAck ProcessAck { get; set; }

        [JsonPropertyName("PROCESS_COMPLETE")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public ProcessComplete ProcessComplete { get; set; }

        [JsonPropertyName("RECIPE_SET")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public RecipeSet RecipeSet { get; set; }

        [JsonPropertyName("STATUS_RESPONSE")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public StatusResponse StatusResponse { get; set; }

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