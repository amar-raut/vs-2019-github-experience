using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Please enter Customer Name")]
        public string Name { get; set; }

        [Display(Name= "Date of Birth")]
        [Min18yearsValidation]
        public DateTime? Birthdate { get; set; }
        public Customer(int x, string y)
        {
            Id = x;
            Name = y;
        }

        public Customer()
        {
        }

        public bool IsSubscribedToNewsletter { get; set; }
        public MembershipType MemberShipType { get; set; }
        public byte MembershipTypeId { get; set; }

    }   
 

    
}