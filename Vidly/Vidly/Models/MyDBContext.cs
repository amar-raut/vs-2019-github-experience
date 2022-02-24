using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class MyDBContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; } // My domain models
        
        public DbSet<MembershipType> MembershipType { get; set; }

        //public DbSet<GenreType> Genre { get; set; }

        //public DbSet<Movies> Movies { get; set; }// My domain models


        public DbSet<GenreType> GenreNew { get; set; }

        public DbSet<MovieNew> MovieNew { get; set; }// My domain models

    }
}