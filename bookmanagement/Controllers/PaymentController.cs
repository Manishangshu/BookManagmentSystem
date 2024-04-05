using bookmanagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace bookmanagement.Controllers
{
    

    [Authorize(Roles = "User")]
    public class PaymentController : Controller
    {
        BookManagementDbContext db = new BookManagementDbContext();
        // GET: Payment
        public ActionResult Index()
        {
         
            return View();
        }

       
    
        public ActionResult tq ()
        {
            return View(); 
        }
    }
}