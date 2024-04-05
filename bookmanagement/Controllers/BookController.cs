using bookmanagement.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using bookmanagement.Models;
using System.IO;
using System.Data.Entity.Migrations;

namespace bookmanagement.Controllers
{
    
    public class BookController : Controller
    {
        private BookManagementDbContext db = new BookManagementDbContext();
        // GET: Book
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            var books = db.Books.Include(b=>b.Author  ).Include(b=>b.Genre).ToList();

            return View(books);
        }
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Book books)
        {
            if (ModelState.IsValid)
            {

                //var auth = db.Author.Where(m => m.id == books.AuthorId).Count();
                //if (auth > 0)
                //{
                //    books.AuthorId = 0;
                //}
                Author existingAuthor = db.Author.FirstOrDefault(a=>a.AuthorName==books.Author.AuthorName);
                Genre existingGenre = db.Genres.FirstOrDefault(a => a.GenreName == books.Genre.GenreName);
                
               
                if (existingAuthor == null && existingGenre == null)
                {
                    db.Books.Add(books);
                    db.SaveChanges();
                    return RedirectToAction("Index");

                }
                if (existingGenre != null)
                {
                    books.GenreId = existingGenre.GenreId;
                }
                else
                {
                    var newGenre = new Genre { GenreName = books.Genre.GenreName };
                    db.Genres.Add(newGenre);
                    db.SaveChanges();
                    books.GenreId = newGenre.GenreId;
                }
                if (existingAuthor != null)
                {
                    books.AuthorId = existingAuthor.id;
                }
                else
                {
                    Author newAuthor = new Author{AuthorName=books.Author.AuthorName};
                    db.Author.Add(newAuthor);
                    db.SaveChanges();
                    books.AuthorId=newAuthor.id;
                }
                Book newBook = new Book
                {
                    BookName = books.BookName,
                    AuthorId = books.AuthorId,
                    GenreId = books.GenreId,
                    PublicationDate = books.PublicationDate,
                    ISBN = books.ISBN,
                    Price = books.Price,
                };
                db.Books.Add(newBook);
                db.SaveChanges();

               
                return RedirectToAction("Index");
            }
            return View(books);
        }

        //Update
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int id)
        {
            var books = db.Books.Include(a => a.Author).Include(g => g.Genre).FirstOrDefault(m => m.BookId == id);

            if (books == null)
            {
                return HttpNotFound();
            }
            return View(books);
        }

        [HttpPost]
        public ActionResult Edit(Book books)
        {
            if (ModelState.IsValid)
            {
                db.Books.AddOrUpdate(books);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(books);
        }
        //[HttpPost]
        //public ActionResult Edit(Book books)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        // Check if the AuthorId exists in the Authors table
        //        var authorExists = db.Author.Any(a => a.id == books.AuthorId);

        //        if (!authorExists)
        //        {
        //            ModelState.AddModelError("", "The specified author does not exist.");
        //            return View(books);
        //        }

        //        db.Entry(books).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(books);
        //}



        //Delete
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int id)
        {
            var books = db.Books.Find(id);

            if (books == null)
            {
                return HttpNotFound();
            }

            return View(books);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var books = db.Books.Find(id);

            if (books == null)
            {
                return HttpNotFound();
            }
          //  db.Books.Remove(books.AuthorId);
            db.Books.Remove(books);
           
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Admin")]
        [ActionName("Welcome_Admin")]
        public ActionResult baseview()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        public ActionResult CustomerDetails()
        {
            var user = db.Users.ToList();

            return View(user);
        }

       



    }
}
