using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class MovieController : Controller
    {
        // GET: Movie

        private MyDBContext mdb = null;


        public MovieController()
        {
            mdb = new MyDBContext();
        }

        protected override void Dispose(bool Disposing)
        {
            mdb.Dispose();
        }
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SaveMovie(MovieNew mgr)
        {
            if(mgr==null)
            {
                return HttpNotFound();
            }

            MovieNew mdo = mdb.MovieNew.SingleOrDefault(mx => mx.Id == mgr.Id);
            mdo.Name = mgr.Name;
            mdo.Dateadded = mgr.Dateadded;
            mdo.Releasedate = mgr.Releasedate;
            mdo.GenreId = mgr.GenreId;

            mdb.SaveChanges();

            return RedirectToAction("Index", "Home");

          
        }
    }


}