using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace JR.P262605.API.Laser.JRA
{
    public class StatusRequest
    {
        [JsonPropertyName("HEARTBEAT")]
        public bool Heartbeat { get; set; }
    }

    public class BoolJsonConverter : JsonConverter<bool>
    {
        public override bool Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            return Convert.ToBoolean(reader.GetString());
        }

        public override void Write(Utf8JsonWriter writer, bool value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString());
        }
    }
}