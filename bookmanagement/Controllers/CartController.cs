using bookmanagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace bookmanagement.Controllers
{
   
    public class CartController : Controller
    {
       BookManagementDbContext db = new BookManagementDbContext();
        // GET: Cart
        public ActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "User")]
        public ActionResult AddToCart(int id)
        {
            if (Session["cart"] == null)
            {
                List<Items_InCart> cart = new List<Items_InCart>();
                Items_InCart items_InCart = new Items_InCart();
                items_InCart.Product = db.Books.Find(id);
                items_InCart.Quantity = 1;
                cart.Add(items_InCart);
                Session["cart"] = cart;
            }
            else
            {
                List<Items_InCart> cart = (List<Items_InCart>)Session["cart"];
                int index = IsInCart(id);

                if (index != -1)
                {
                    cart[index].Quantity++;
                }
                else
                {
                    cart.Add(new Items_InCart() { Product = db.Books.Find(id), Quantity = 1 });

                }

                Session["cart"] = cart;


            }
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "User")]
        public ActionResult RemoveFromCart(int ProductID)
        {
            List<Items_InCart> cart = (List<Items_InCart>)Session["cart"];
            int index = IsInCart(ProductID);
            cart.RemoveAt(index);
            Session["cart"] = cart;
            return RedirectToAction("Index");

        }

        [Authorize(Roles = "User")]
        public int IsInCart(int ProductID)
        {
            List<Items_InCart> cart = (List<Items_InCart>)Session["cart"];
            for (int i = 0; i < cart.Count; i++)
            {
                if (cart[i].Product.BookId == ProductID)
                {
                    return i;
                }
            }

            return -1;
        }
    }
}