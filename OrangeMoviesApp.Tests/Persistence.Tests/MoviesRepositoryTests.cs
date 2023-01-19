using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using OrangeMoviesApp.Persistence;
using OrangeMoviesApp.Persistence.Persistence;
using OrangeMoviesApp.Tests.Persistence.TestData;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace OrangeMoviesApp.Tests
{
    public class MoviesRepositoryTests
    {
        [Fact]
        public async Task AddValidMovieToFavourites_DataIsSuccessfullySaved()
        {
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();

            try
            {
                var options = new DbContextOptionsBuilder<OrangeMoviesDbContext>()
                    .UseSqlite(connection)
                    .Options;

                using (var context = new OrangeMoviesDbContext(options))
                {
                    var testData = new MoviesRepositoryTestData();
                    var testFavouriteMovie = testData.testMovies.First();
                    var expectedMovieGenresCOunt = testFavouriteMovie.MovieGenres.Count();
                    int expectedMovieCount = 1;

                    context.Database.EnsureCreated();

                    var testLogger = new Mock<ILogger<MoviesRepository>>(MockBehavior.Strict);
                    var service = new MoviesRepository(context, testLogger.Object);
                    
                    await service.AddMovieToFavourites(testFavouriteMovie);

                    context.SaveChanges();

                    var movieGenresCountResult = context.MovieGenres.Count();
                    var moviesCountResult = context.Movies.Count();
                    var genresCountResult = context.Genres.Count();
                    var movieGenresResult = context.MovieGenres;
                    var movieResult = context.Movies.Single();

                    Assert.Equal(expectedMovieGenresCOunt, context.MovieGenres.Count());
                    Assert.Equal(expectedMovieCount, context.Movies.Count());
                }
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
