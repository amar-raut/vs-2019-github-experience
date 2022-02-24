using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyApp.Models;
using MyApp.Db.DBOperations;

namespace MVCAppWithDb.Controllers
{
    public class HomeController : Controller
    {
        EmployeeRepository repository = null;
        public HomeController()
        {

            repository = new EmployeeRepository();

        }
        // GET: Home
        public ActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Create(EmployeeModel model)
        {

            if (ModelState.IsValid)
            {
                int id = repository.AddEmployee(model);

                if (id > 0)
                {
                    ModelState.Clear();
                    ViewBag.Issuccess = "Data Added";
                }
            }

            return View();
        }

        public ActionResult GetAllRecords()
        {
            var result = repository.GetAllEmployee();
            return View(result);

        }

        public ActionResult Details(int id)
        {
            var result = repository.GetEmployee(id);
            return View(result);


        }


        public ActionResult Edit(int id)
        {
            var result = repository.GetEmployee(id);
            return View(result);

        }

        [HttpPost]
        public ActionResult Edit(EmployeeModel model)

        {
            if (ModelState.IsValid)
            {
                var result = repository.EditEmployee(model);

                return RedirectToAction("GetAllRecords");
            }

            return View();

        }

        public ActionResult Delete(int id)

        {
            
                var result = repository.DeleteEmployee(id);
                return RedirectToAction("GetAllRecords");
      
        }
    }
}