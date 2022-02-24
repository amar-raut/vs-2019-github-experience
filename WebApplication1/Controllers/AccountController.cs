using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using System.Web.Security;

namespace WebApplication1.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Models.Membership model)
        {

            using (var context = new OfficeEntities())
            {
                bool isvalid = context.Users.Any(x => x.UserName == model.Username && x.Password == x.Password);

                if (isvalid)
                {
                    FormsAuthentication.SetAuthCookie(model.Username, false);
                    return RedirectToAction("Index", "Employees");
                }

                ModelState.AddModelError("", "Invalid Username OR Password");
                return View();
            }

           
        }

        public ActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignUp(Users model)
        {
            using (var context = new OfficeEntities())
            {
                context.Users.Add(model);
                context.SaveChanges();
            }
                return RedirectToAction("login");
        }


        public ActionResult Logout()
        {

            FormsAuthentication.SignOut();
            return RedirectToAction("login");
        }
    }
}