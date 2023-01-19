using OrangeMoviesApp.Domain.Core;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OrangeMoviesApp.Web.Services
{
    public interface IOrangeMoviesApiService
    {
        Task<List<MovieDto>> GetMostPopularMovies(int pageId);
        Task<MovieDto> GetMovieDetails(int movieId);
    }
}
