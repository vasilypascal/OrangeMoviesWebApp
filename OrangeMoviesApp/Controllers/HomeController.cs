using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OrangeMoviesApp.Domain.Core;
using OrangeMoviesApp.Models;
using OrangeMoviesApp.Persistence;
using OrangeMoviesApp.Web.Services;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace OrangeMoviesApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IOrangeMoviesApiService _orangeMoviesApiService;
        private readonly IMoviesRepository _moviesRepository;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, IOrangeMoviesApiService orangeMoviesApiService, IMoviesRepository moviesRepostitory)
        {
            _logger = logger;
            _orangeMoviesApiService = orangeMoviesApiService;
            _moviesRepository = moviesRepostitory;
        }

        public async Task<IActionResult> Index(int pageId = 1, bool sortByRating = false, int groupByGenreId = 0)
        {
            // TO DO: Add VieModels + proper Mapping + validation
            List<MovieDto> movies = await _orangeMoviesApiService.GetMostPopularMovies(pageId);
            var genres = await _moviesRepository.GetAllGenres();

            foreach (var movie in movies)
            {
                List<Genre> currentMovieGenres = genres.Where(x => movie.GenresIds.Contains(x.GenreId)).ToList();
                List<GenreDto> currentMovieGenresDto = new List<GenreDto>();
                foreach (var currentMovieGenre in currentMovieGenres)
                {
                    currentMovieGenresDto.Add(new GenreDto { Id = currentMovieGenre.GenreId, Name = currentMovieGenre.Name });
                }

                movie.Genres = currentMovieGenresDto;
            }

            if (sortByRating)
            {
                movies = movies.OrderByDescending(x => x.VoteAverage).ToList();
            }

            if (groupByGenreId > 0)
            {
                movies = movies.Where(x => x.GenresIds.Contains(groupByGenreId)).ToList();
            }

            return View(movies);
        }

        [HttpGet]
        public async Task<IActionResult> FavouriteMovies()
        {
            List<Movie> favouriteMovies = await _moviesRepository.GetFavouriteMovies();

            return View(favouriteMovies);
        }

        public async Task<IActionResult> Create(int id)
        {
            var movie = await _orangeMoviesApiService.GetMovieDetails(id);

            var existingMovie = await _moviesRepository.GetMovieWithGenres(id);

            if (existingMovie is null)
            {
                List<MovieGenre> currentMovieGenres = new List<MovieGenre>();

                foreach (var genre in movie.Genres)
                {
                    MovieGenre currentMovieGenre = new MovieGenre
                    {
                        MovieId = movie.Id,
                        GenreId = genre.Id,
                    };

                    currentMovieGenres.Add(currentMovieGenre);
                }

                Movie favouriteMovieToAdd = new Movie
                {
                    MovieId = movie.Id,
                    Title = movie.Title,
                    VoteAverage = movie.VoteAverage,
                    ReleaseDate = movie.ReleaseDate,
                    Overview = movie.Overview,
                    PosterPath = movie.PosterPath,
                    MovieGenres = currentMovieGenres
                };

                await _moviesRepository.AddMovieToFavourites(favouriteMovieToAdd);
            }
            
            return RedirectToAction("FavouriteMovies");
        }

        public async Task<IActionResult> Delete(int id)
        {
            await _moviesRepository.RemoveMovieFromFavourites(id);

            return RedirectToAction("FavouriteMovies");
        }

        public async Task<IActionResult> MovieDetails(int id)
        {
            var movie = await _orangeMoviesApiService.GetMovieDetails(id);

            return View(movie);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
