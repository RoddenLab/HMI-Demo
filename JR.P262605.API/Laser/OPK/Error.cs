using System.Text.Json.Serialization;

namespace JR.P262605.API.Laser.OPK
{
    public class Error
    {
        [JsonPropertyName("MESSAGE")]
        public string Message;
    }
}