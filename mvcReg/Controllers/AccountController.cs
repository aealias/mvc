using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mvcReg.Models;

namespace mvcReg.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                return View(db.userAccounts.ToList());
            }
        }
        public ActionResult Register()   //blank registrtion form //get method
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(Reg account, HttpPostedFileBase file) //post method
        {
            if (ModelState.IsValid)
            {
                using (DatabaseContext db = new DatabaseContext())
                {
                    var fileName = new Random().Next().ToString() + Path.GetExtension(file.FileName);
                    var path = Path.Combine(Server.MapPath("/images/"), fileName);
                    account.Image = fileName;
                    db.reg.Add(account);
                    db.SaveChanges();

                }
                ModelState.Clear();
                ViewBag.Message = account.FirstName + "" + account.LastName + " successfully registered";
            }
            return View();
        }
        //login

        public ActionResult Login() //get method
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(UserAccount user)

        {
            using (DatabaseContext db = new DatabaseContext())
            {
                var usr = db.userAccounts.Single(u => u.Email == user.Email && u.Password == user.Password);
                if (usr != null)
                {
                    Session["Id"] = usr.Id.ToString();
                    Session["UserName"] = usr.Email.ToString();
                    return RedirectToAction("LoggedIn");

                }
                else
                {
                    ModelState.AddModelError("", "Username or Password is wrong");
                }
                return View();

            }
        }
        public ActionResult LoggedIn()
        {
            if (Session["Id"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }

        }
    }
}

