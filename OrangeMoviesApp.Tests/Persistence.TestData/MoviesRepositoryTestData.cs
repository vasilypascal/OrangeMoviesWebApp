using OrangeMoviesApp.Domain.Core;
using System.Collections.Generic;
using System.Linq;

namespace OrangeMoviesApp.Tests.Persistence.TestData
{
    public class MoviesRepositoryTestData
    {
        public readonly List<Movie> testMovies;

        public readonly List<Genre> testGenres;

        public readonly List<MovieGenre> testMovieGenres = new List<MovieGenre>();

        public MoviesRepositoryTestData()
        {
            this.testMovies = new List<Movie>
            {
                new Movie
                {
                    MovieId = 1,
                    Title = "Test Title 1",
                    Overview = "Test Overview 1",
                    VoteAverage = 7.1f,
                    PosterPath = "/Test Path 1",
                    ReleaseDate = "2023-01-01",
                },
                new Movie
                {
                    MovieId = 2,
                    Title = "Test Title 2",
                    Overview = "Test Overview 2",
                    VoteAverage = 7.2f,
                    PosterPath = "/Test Path 2",
                    ReleaseDate = "2023-01-02",
                },
                new Movie
                {
                    MovieId = 3,
                    Title = "Test Title 3",
                    Overview = "Test Overview 3",
                    VoteAverage = 7.3f,
                    PosterPath = "/Test Path 3",
                    ReleaseDate = "2023-01-03",
                },
                new Movie
                {
                    MovieId = 4,
                    Title = "Test Title 4",
                    Overview = "Test Overview 4",
                    VoteAverage = 7.4f,
                    PosterPath = "/Test Path 4",
                    ReleaseDate = "2023-01-04",
                }
            };


            this.testGenres = new List<Genre>
            {
                new Genre { GenreId = 101, Name = "Action"},
                new Genre { GenreId = 102, Name = "Adventure" },
                new Genre { GenreId = 103, Name = "Animation" },
                new Genre { GenreId = 104, Name = "Comedy" }
            };

            var testMovieGenre1 = new MovieGenre { Movie = this.testMovies.ElementAt(0), Genre = this.testGenres.ElementAt(0) };
            var testMovieGenre2 = new MovieGenre { Movie = this.testMovies.ElementAt(0), Genre = this.testGenres.ElementAt(3) };
            var testMovieGenre3 = new MovieGenre { Movie = this.testMovies.ElementAt(1), Genre = this.testGenres.ElementAt(0) };
            var testMovieGenre4 = new MovieGenre { Movie = this.testMovies.ElementAt(1), Genre = this.testGenres.ElementAt(1) };
            var testMovieGenre5 = new MovieGenre { Movie = this.testMovies.ElementAt(1), Genre = this.testGenres.ElementAt(3) };
            var testMovieGenre6 = new MovieGenre { Movie = this.testMovies.ElementAt(2), Genre = this.testGenres.ElementAt(1) };
            var testMovieGenre7 = new MovieGenre { Movie = this.testMovies.ElementAt(3), Genre = this.testGenres.ElementAt(2) };
            var testMovieGenre8 = new MovieGenre { Movie = this.testMovies.ElementAt(3), Genre = this.testGenres.ElementAt(3) };


            this.testMovieGenres.Add(testMovieGenre1);
            this.testMovieGenres.Add(testMovieGenre2);
            this.testMovieGenres.Add(testMovieGenre3);
            this.testMovieGenres.Add(testMovieGenre4);
            this.testMovieGenres.Add(testMovieGenre5);
            this.testMovieGenres.Add(testMovieGenre6);
            this.testMovieGenres.Add(testMovieGenre7);
            this.testMovieGenres.Add(testMovieGenre8);

            testMovies.ElementAt(0).MovieGenres = new List<MovieGenre> { testMovieGenre1, testMovieGenre2 };
            testMovies.ElementAt(1).MovieGenres = new List<MovieGenre> { testMovieGenre3, testMovieGenre4, testMovieGenre5 };
            testMovies.ElementAt(2).MovieGenres = new List<MovieGenre> { testMovieGenre6 };
            testMovies.ElementAt(3).MovieGenres = new List<MovieGenre> { testMovieGenre7, testMovieGenre8 };
        }
    }
}
