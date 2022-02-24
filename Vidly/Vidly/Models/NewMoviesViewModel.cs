using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class NewMoviesViewModel
    {
        public IEnumerable<GenreType> GenreList { get; set; }

        [Required]
        public int Id { get; set; }
        public string Name { get; set; }

        [Required]
        [Column(TypeName = "datetime2")]
        public DateTime? Releasedate { get; set; }
        [Required]
        [Column(TypeName = "datetime2")]
        public DateTime? Dateadded { get; set; }
        public int Noofstock { get; set; }
        [Required]
        public int GenreId { get; set; }
    }
}