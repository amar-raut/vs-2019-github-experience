using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class MovieNew
    {
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
        public GenreType Genre { get; set; }
        [Required]
        public int GenreId { get; set; }

        public MovieNew()
        {


        }
    }
}