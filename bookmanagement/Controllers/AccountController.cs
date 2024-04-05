using bookmanagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.UI.WebControls;

namespace bookmanagement.Controllers
{
    
        public class AccountController : Controller
        {
            BookManagementDbContext db = new BookManagementDbContext();
            // GET: Login
            public ActionResult Index()
            {
                return View();
            }

            public ActionResult SignUp()
            {
                return View();
            }

            [ValidateAntiForgeryToken]
            [HttpPost]
            public ActionResult SignUp([Bind(Include = "Role,FirstName,LastName,UserName,Email,Password,ConfirmPassword, Phone_number")] User user)
            {

                if (ModelState.IsValid)
                {
                    db.Users.Add(user);
                    var a = db.SaveChanges();

                    return RedirectToAction("SignIn", "Account");
                }
                return View();
            }

            public ActionResult SignIn()
            {
                return View();
            }

            [HttpPost]
            public ActionResult SignIn(User user)
            {
                var usr = db.Users.Where(m => m.Email == user.Email && m.Password == user.Password).FirstOrDefault();

                if (usr != null)
                {
                    FormsAuthentication.SetAuthCookie(user.Email, false);
                    Session["fname"] = usr.FirstName;
                    Session["userid"] = usr.UserId;
                    Session.Add("Role", usr.Role);

                    if (usr.Role == "Admin")
                    {
                        return RedirectToAction("Welcome_Admin", "Book");
                    }
                    
                    if (usr.Role == "User")
                    {
                        return RedirectToAction("Home", "Home");
                    }


                    TempData["alert"] = "<script>alert('Login Successfull')</script>";
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.alert = "<script>alert('Login Failed')</script>";
                   
                }
                return View();
            }

            public ActionResult SignOut(User user)
            {
                FormsAuthentication.SignOut();
                Session["fname"] = null;
                return RedirectToAction("Signin");
            }

        }
       
    }

