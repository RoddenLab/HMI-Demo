using System.Text.Json.Serialization;

namespace JR.P262605.API.Laser.JRA
{
    public class SetRecipe
    {
        [JsonPropertyName("RECIPE_PATH")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string RecipePath { get; set; }
    }
}