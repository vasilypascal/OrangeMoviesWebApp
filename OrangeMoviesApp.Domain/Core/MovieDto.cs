using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace OrangeMoviesApp.Domain.Core
{
    public class MovieDto
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("original_title")]
        public string Title { get; set; }

        [JsonPropertyName("overview")]
        public string Overview { get; set; }

        [JsonPropertyName("release_date")]
        public string ReleaseDate { get; set; }

        [JsonPropertyName("vote_average")]
        public float VoteAverage { get; set; }

        [JsonPropertyName("poster_path")]
        public string PosterPath { get; set; }

        [JsonPropertyName("genre_ids")]
        public List<int> GenresIds { get; set; }

        [JsonPropertyName("genres")]
        public List<GenreDto> Genres { get; set; }
    }
}
