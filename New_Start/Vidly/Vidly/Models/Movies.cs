using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Movies
    {
        public int Id { get; set; }
        public String Name { get; set; }

        public int rating { get; set; }

        public Genre Genre { get; set; }

        public int GenreID { get; set; }

        public DateTime? ReleaseDate { get; set; }

        public DateTime? DateAdded { get; set; }

        public int Numberinstock { get; set; }
    }
}