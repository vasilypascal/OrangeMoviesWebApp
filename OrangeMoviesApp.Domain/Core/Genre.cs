using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrangeMoviesApp.Domain.Core
{
    public class Genre
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int GenreId { get; set; }

        public string Name { get; set; }
        public virtual ICollection<MovieGenre> MovieGenres { get; set; }
    }
}
