using OrangeMoviesApp.Domain.Core;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OrangeMoviesApp.Persistence
{
    public interface IMoviesRepository
    {
        Task<List<Movie>> GetFavouriteMovies();

        Task<Movie> GetMovieWithGenres(int movieId);

        Task<Movie> AddMovieToFavourites(Movie movie);

        Task RemoveMovieFromFavourites(int movieId);

        Task<List<Genre>> GetAllGenres();
    }
}
