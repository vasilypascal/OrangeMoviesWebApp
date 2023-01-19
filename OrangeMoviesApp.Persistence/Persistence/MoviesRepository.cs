using Microsoft.Extensions.Logging;
using OrangeMoviesApp.Domain.Core;
using OrangeMoviesApp.Persistence.Persistence;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace OrangeMoviesApp.Persistence
{
    public class MoviesRepository : IMoviesRepository
    {
        private readonly OrangeMoviesDbContext _dbContext;
        private readonly ILogger<MoviesRepository> _logger;

        public MoviesRepository(OrangeMoviesDbContext dbContext, ILogger<MoviesRepository> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public async Task<List<Movie>> GetFavouriteMovies()
        {
            try
            {
                return await _dbContext.Movies.Include(x => x.MovieGenres).ThenInclude(x => x.Genre).ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error occured while retrieving the list of favourite movies", ex);

                throw ex;
            }
        }

        public async Task<Movie> GetMovieWithGenres(int movieId)
        {
            try
            {
                return await _dbContext.Movies.Include(x => x.MovieGenres).ThenInclude(x => x.Genre).FirstOrDefaultAsync(x => x.MovieId == movieId);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error occured while retrieving the list of favourite movies", ex);

                throw ex;
            }
        }

        public async Task<Movie> AddMovieToFavourites(Movie movie)
        {
            try
            {
                _dbContext.Movies.Add(movie);
                await _dbContext.SaveChangesAsync();

                return movie;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error occured while adding movie with [MovieId] = {movie.MovieId} to favourites", ex);

                throw ex;
            }
        }

        public async Task RemoveMovieFromFavourites(int movieId)
        {
            try
            {
                var movieToDelete = await _dbContext.Movies.FindAsync(movieId);
                _dbContext.Movies.Remove(movieToDelete);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error occured while removing movie with [MovieId] = {movieId} from favourites", ex);

                throw ex;
            }
        }

        public async Task<List<Genre>> GetAllGenres()
        {
            try
            {
                return await _dbContext.Genres.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error occured while retrieving the list of movie genres", ex);

                throw ex;
            }
        }
    }
}
