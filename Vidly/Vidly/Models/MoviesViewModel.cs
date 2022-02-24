using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class MoviesViewModel
    {

        public List<Customer> CustomersList;
        public List<MovieNew> MoviesList;
        public MoviesViewModel(List<Customer> cl)
        {

            CustomersList = cl;

        }

        public MoviesViewModel(List<MovieNew> ml)
        {

            MoviesList = ml;

        }

        //public List<Customer> CustomersList = new List<Customer>()
        //{
        //    new Customer(1,"Abhishek"),
        //    new Customer(2,"Prathmesh")
        //};



        //public List<Movies> MoviesList = new List<Movies>()
        //{
        //    new Movies(1,"SHREK"),
        //   new Movies(2,"HTTYD")
        //};
    }
}