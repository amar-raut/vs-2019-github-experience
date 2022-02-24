using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using System.Data.Entity;

namespace Vidly.Controllers
{
    public class HomeController : Controller
    {
        private MyDBContext mdb = null;
 
        public ActionResult Index()
        {
            return View();
        }

        public HomeController()
        {
            mdb = new MyDBContext();
        }

        protected override void Dispose(bool Disposing)
        {
            mdb.Dispose();
        }

        public ActionResult New()
        {
            var Membershiptype = mdb.MembershipType.ToList();

           var ViewModel = new NewCustomerViewModelcs();
            ViewModel.MembershipTypes = Membershiptype;
            return View("Customer_Form", ViewModel);
    }

        public ActionResult Movies_info()
        {
            ViewBag.Message = "Your application description page.";

            List<MovieNew> MoviesList1 = mdb.MovieNew.Include(md => md.Genre).ToList();

            MoviesViewModel mvm = new MoviesViewModel(MoviesList1);


            ViewBag.Model1 = mvm;
            return View();
        }

        public ActionResult Customer_info()
        {
            ViewBag.Message = "Your contact page.";

            List<Customer> CustomersList1 = mdb.Customers.Include(c => c.MemberShipType).ToList();

            MoviesViewModel mvm = new MoviesViewModel(CustomersList1);

            ViewBag.Model1 = mvm;

            return View();
        }

        public ActionResult Customer_Data(int idx)
        {

            List<Customer> CustomersList1 = mdb.Customers.Include(cs => cs.MemberShipType).ToList();

            MoviesViewModel mvm = new MoviesViewModel(CustomersList1);

            Customer c = mvm.CustomersList.Find(x => x.Id == idx);

            return View(c);
        }

        public ActionResult Movies_Data(int idx)
        {


            List<MovieNew> MoviesList1 = mdb.MovieNew.Include(md => md.Genre).ToList();

            MoviesViewModel mvm = new MoviesViewModel(MoviesList1);

            MovieNew m = mvm.MoviesList.Find(x => x.Id == idx);

            return View(m);
        }

        [HttpPost]
        public ActionResult Create(Customer viewModel)
        {
            mdb.Customers.Add(viewModel);
            mdb.SaveChanges();
            return RedirectToAction("Index","Home");
        }


        public ActionResult Edit(int id)
        {
            Customer c = mdb.Customers.SingleOrDefault(cx=>cx.Id==id);

            if (c==null)
            {
                return HttpNotFound();
            }

            var ViewModel = new NewCustomerViewModelcs();

            ViewModel.Customer = c;
            ViewModel.MembershipTypes = mdb.MembershipType.ToList();

            return View("Customer_Form", ViewModel);
        }

        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
        {

            if(!ModelState.IsValid)
            {
                var cvm = new NewCustomerViewModelcs
                {
                    Customer = customer,
                    MembershipTypes = mdb.MembershipType.ToList()
                };

            return View("Customer_Form", cvm);

            }

            if (customer.Id == 0)
            {
                mdb.Customers.Add(customer);
                mdb.SaveChanges();
            }

            else
            {
                var udo = mdb.Customers.SingleOrDefault(c => c.Id == customer.Id);

                udo.Name = customer.Name;
                udo.Birthdate = customer.Birthdate;
                udo.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
                udo.MembershipTypeId = customer.MembershipTypeId;
            }

            mdb.SaveChanges();
           
            return RedirectToAction("Index", "Home");
        }

        
        public ActionResult AddMovie()
        {

            return View();
        }

    
        public ActionResult EditMovie(int id)
        {


            MovieNew m = mdb.MovieNew.SingleOrDefault(mx => mx.Id == id);

            if (m == null)
            {
                return HttpNotFound();
            }

            var mgv = new NewMoviesViewModel();

            mgv.Id = m.Id;
            mgv.Name = m.Name;
            mgv.Releasedate = m.Releasedate;
            mgv.Dateadded = m.Dateadded;
            mgv.GenreId = m.GenreId;
            mgv.GenreList = mdb.GenreNew.ToList();

            return View(mgv);

        }

        

        //[HttpPost]
        //public ActionResult SaveMovie(Movies viewModel)
        //{
        //    Response.Write("Name = " + viewModel.Name );
        //    Response.Write("<br/>");
        //    Response.Write("Id = " + viewModel.Id );
        //    Response.Write("<br/>");
        //    Response.Write("Dateaddedd = " + viewModel.Dateadded);
        //    Response.Write("<br/>");
        //    Response.Write("Releasedate = " + viewModel.Releasedate);
        //    Response.Write("<br/>");
        //    Response.Write("Noofstock = " + viewModel.Noofstock);

        //    //formCollection.GenreId = 2;

        //    //Movies mdo = new Movies();
        //    //mdo.Name = mvs.Name;
        //    //mdo.Dateadded = mvs.Dateadded;
        //    //mdo.Releasedate = mvs.Releasedate;
        //    //mdo.GenreId = mvs.GenreId;

        //    //mdb.Movies.Add(mdo);
        //    //mdb.SaveChanges();

        //    //if (mgr.Movies.Id == 0)
        //    //{
        //    //    //mdb.Movies.Add(mgr);
        //    //    //mdb.SaveChanges();

        //    //}
        //    //else
        //    //{
        //    //    //Movies mdo = mdb.Movies.SingleOrDefault(mx => mx.Id == mgr.Id);
        //    //    //mdo.Name = mgr.Name;
        //    //    //mdo.Dateadded = mgr.Dateadded;
        //    //    //mdo.Releasedate = mgr.Releasedate;
        //    //    //mdo.Genre = mgr.Genre;

        //    //}



        //    //return RedirectToAction("Index", "Home");

        //    return View("SaveMovie");
        //}
    }


}