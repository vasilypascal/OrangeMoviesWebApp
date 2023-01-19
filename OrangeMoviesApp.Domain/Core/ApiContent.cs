using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace OrangeMoviesApp.Domain.Core
{
    public class ApiContent
    {
        [JsonPropertyName("results")]
        public List<MovieDto> Movies { get; set; }

    }
}
