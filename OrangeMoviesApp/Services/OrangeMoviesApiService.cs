using OrangeMoviesApp.Domain.Core;
using OrangeMoviesApp.Web.Services;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace OrangeMoviesApp.Web
{
    public class OrangeMoviesApiService : IOrangeMoviesApiService
    {
        private readonly HttpClient client;
        private readonly string apiKey = "dad8a59d86a2793dda93aa485f7339c1";

        public OrangeMoviesApiService(IHttpClientFactory clientFactory)
        {
            client = clientFactory.CreateClient("OrangeMoviesApi");
        }

        public async Task<List<MovieDto>> GetMostPopularMovies(int pageId)
        {
            var url = string.Format("/3/movie/popular?api_key={0}&page={1}", this.apiKey, pageId);
            var result = new ApiContent();
            var response = await client.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var stringResponse = await response.Content.ReadAsStringAsync();

                result = JsonSerializer.Deserialize<ApiContent>(stringResponse);

                foreach (var movie in result.Movies)
                {
                    var moviePosterLink = $"https://image.tmdb.org/t/p/w300/{movie.PosterPath}";
                    movie.PosterPath = moviePosterLink;
                }
            }
            else
            {
                throw new HttpRequestException(response.ReasonPhrase);
            }

            return result.Movies;
        }

        public async Task<MovieDto> GetMovieDetails(int movieId)
        {
            var url = string.Format("/3/movie/{0}?api_key={1}", movieId, this.apiKey);
            var movieResult = new MovieDto();
            var response = await client.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var stringResponse = await response.Content.ReadAsStringAsync();

                movieResult = JsonSerializer.Deserialize<MovieDto>(stringResponse);


                var moviePosterLink = $"https://image.tmdb.org/t/p/w300/{movieResult.PosterPath}";
                movieResult.PosterPath = moviePosterLink;
            }
            else
            {
                throw new HttpRequestException(response.ReasonPhrase);
            }

            return movieResult;
        }

        public async Task<MovieDto> GetMovieGenres(int movieId)
        {
            var url = string.Format("/3/movie/{0}?api_key={1}", movieId, this.apiKey);
            var movieResult = new MovieDto();
            var response = await client.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var stringResponse = await response.Content.ReadAsStringAsync();

                movieResult = JsonSerializer.Deserialize<MovieDto>(stringResponse);


                var moviePosterLink = $"https://image.tmdb.org/t/p/w300/{movieResult.PosterPath}";
                movieResult.PosterPath = moviePosterLink;
            }
            else
            {
                throw new HttpRequestException(response.ReasonPhrase);
            }

            return movieResult;
        }
    }
}
