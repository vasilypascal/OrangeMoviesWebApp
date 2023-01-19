using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrangeMoviesApp.Domain.Core
{
    public class Movie
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MovieId { get; set; }

        public string Title { get; set; }

        public string Overview { get; set; }

        public string ReleaseDate { get; set; }

        public float VoteAverage { get; set; }

        public string PosterPath { get; set; }

        public virtual ICollection<MovieGenre> MovieGenres { get; set; }
    }
}
