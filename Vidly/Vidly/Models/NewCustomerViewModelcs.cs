using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class NewCustomerViewModelcs
    {
        public IEnumerable<MembershipType> MembershipTypes { get; set; }
        public Customer Customer { get; set; }

        public IEnumerable<GenreNew> GenreTypes { get; set; }
        public MovieNew moviesset { get; set; }

      
    }
}