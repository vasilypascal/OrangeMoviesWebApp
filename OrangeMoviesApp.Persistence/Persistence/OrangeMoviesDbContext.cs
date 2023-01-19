using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using OrangeMoviesApp.Domain.Core;
using System.IO;

namespace OrangeMoviesApp.Persistence.Persistence
{
    public class OrangeMoviesDbContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<MovieGenre> MovieGenres { get; set; }

        public OrangeMoviesDbContext(DbContextOptions<OrangeMoviesDbContext> options)
        : base(options)
        {
        }

        public OrangeMoviesDbContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

                IConfigurationRoot configuration = builder.Build();
                optionsBuilder.UseSqlServer(configuration.GetConnectionString("Default"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //MovieGenre Many to Many Configuration:
            modelBuilder.Entity<MovieGenre>()
                .HasKey(mg => new { mg.MovieId, mg.GenreId });

            modelBuilder.Entity<MovieGenre>()
                .HasOne(mg => mg.Movie)
                .WithMany(m => m.MovieGenres)
                .HasForeignKey(mg => mg.MovieId);

            modelBuilder.Entity<MovieGenre>()
                .HasOne(mg => mg.Genre)
                .WithMany(g => g.MovieGenres)
                .HasForeignKey(mg => mg.GenreId);

            modelBuilder.Entity<Genre>().HasData(
                new Genre { GenreId = 28, Name = "Action"},
                new Genre { GenreId = 12, Name = "Adventure" },
                new Genre { GenreId = 16, Name = "Animation" },
                new Genre { GenreId = 35, Name = "Comedy" },
                new Genre { GenreId = 80, Name = "Crime" },
                new Genre { GenreId = 99, Name = "Documentary" },
                new Genre { GenreId = 18, Name = "Drama" },
                new Genre { GenreId = 10751, Name = "Family" },
                new Genre { GenreId = 14, Name = "Fantasy" },
                new Genre { GenreId = 36, Name = "History" },
                new Genre { GenreId = 27, Name = "Horror" },
                new Genre { GenreId = 10402, Name = "Music" },
                new Genre { GenreId = 9648, Name = "Mystery" },
                new Genre { GenreId = 10749, Name = "Romance" },
                new Genre { GenreId = 878, Name = "Science Fiction" },
                new Genre { GenreId = 10770, Name = "TV Movie" },
                new Genre { GenreId = 53, Name = "Thriller" },
                new Genre { GenreId = 10752, Name = "War" },
                new Genre { GenreId = 37, Name = "Western" }
            );
        }
    }
}
