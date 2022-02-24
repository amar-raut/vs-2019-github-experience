using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;
using System.Data.Entity;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {

        public NewMyDBContext _context;

        public MoviesController()
        {
            _context = new NewMyDBContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();

        }
        //List<Movies> movieslist = new List<Movies>
        //    {
        //        new Movies {Id=1 , Name = "Shrek1"},
        //        new Movies {Id=2 , Name = "Shrek2"},
        //        new Movies {Id=3 , Name = "Shrek3"}
        //    };
        // GET: Movies
        public ActionResult Index()
        {

            var moviesviewmodel = new MoviesViewModel()
            {
                Movielist = _context.Movies.Include(x => x.Genre).ToList()

            };

            return View(moviesviewmodel);
        }

        public ActionResult MovieDetails(int id)
        {


            var movie = new Movies();

            foreach (var mv in _context.Movies.Include(x => x.Genre).ToList())
            {
                if (mv.Id == id)
                {
                    movie = mv;
                }
            }

            return View(movie);
        }


        public ActionResult Random()
        {
            var Movies = new Movies() 
            { Name = "Shrek!" };
          

            var customers = new List<Customers>
            { 
                new Customers { Name = "Customer 1"},
              new Customers { Name = "Customer 2"}

            };



            var RandomMovieViewModel = new RandomMovieViewModel()
            {
                movies = Movies,
                customers = customers
            };

            return View(RandomMovieViewModel);
        }



        public ActionResult Edit(int movieId)
        {
            return Content("ID="+ movieId);
        }

        [Route("movies/released/{year}/{month:regex(\\d{2}):range(1,12)}")]

        public ActionResult ByReleasedate(int? year, int? month)
        {
            return Content("Year=" + year + " Month=" + month);
        }

     
    }
}