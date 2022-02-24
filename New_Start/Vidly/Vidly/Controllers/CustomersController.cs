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
    public class CustomersController : Controller
    {

        public NewMyDBContext _context;

        public CustomersController()
        {
            _context = new NewMyDBContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();

        }

        //List<Customers> clist = new List<Customers>()
        //    {
        //        new Customers { Id =1 , Name = "Amar"},
        //        new Customers { Id =2 , Name = "Ajay"},
        //        new Customers { Id =3 , Name = "Jay"}
        //    };

        // GET: Customers
        public ActionResult Index()
        {
            CustomersViewModel customersViewModel = new CustomersViewModel()
            {
                Customerslist = _context.Customers.Include(c=>c.MembershipType).ToList()
            };

            return View(customersViewModel);
        }

        public ActionResult Customerdetails(int id)
        {
            var customer = new Customers();

            foreach (var cm in _context.Customers.Include(c => c.MembershipType).ToList())
            {
                if (cm.Id == id)
                {
                    customer = cm;
                }
            }
            return View(customer);

        }
    }
}