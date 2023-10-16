using System.Text.Json.Serialization;

namespace BrightAkademie.Shared.Models
{
    public class CityType
    {
        [JsonPropertyName("il")]
        public string Il { get; set; }

        [JsonPropertyName("plaka")]
        public int Plaka { get; set; }

        [JsonPropertyName("ilceleri")]
        public List<string> Ilceleri { get; set; }

    }
}