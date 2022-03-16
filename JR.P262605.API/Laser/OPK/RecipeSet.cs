using System.Text.Json.Serialization;

namespace JR.P262605.API.Laser.OPK
{
    public class RecipeSet
    {
        [JsonPropertyName("RECIPE_PATH")]
        public string RecipePath { get; set; }
    }
}
