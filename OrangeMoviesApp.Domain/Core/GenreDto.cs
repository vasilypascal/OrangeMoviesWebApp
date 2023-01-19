using System.Text.Json.Serialization;

namespace OrangeMoviesApp.Domain.Core
{
    public class GenreDto
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }
    }
}
