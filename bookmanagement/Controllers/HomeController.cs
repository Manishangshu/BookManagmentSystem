using bookmanagement.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace bookmanagement.Controllers
{

    public class HomeController : Controller
    {
        private BookManagementDbContext db = new BookManagementDbContext();
        // GET: Book
       
        public ActionResult Index()
        {
            var books = db.Books.Include(b => b.Author).Include(b => b.Genre).ToList();

            return View(books);
        }

        [Authorize(Roles = "User")]
        public ActionResult Home()
        {

            var books = db.Books.Include(b => b.Author).Include(b => b.Genre).ToList();

            return View(books);
            
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}