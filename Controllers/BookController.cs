using Lab2_3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab2_3.Controllers
{
    public class BookController : Controller
    {
        // GET: Book
        public string HelloTeacher(string university)
        {
            return "Hello Thầy Hùng - University: " + university;
        }

        public ActionResult ListBook()
        {
            var books = new List<string>();
            books.Add("HTML5 & CSS3 The Complete Manual - Author Name Book 1");
            books.Add("HTML 5 & CSS3  Responsive web Design CookBook - Author Name Book 2");
            books.Add("Professional ASP.Net MVC5 - Author Name Book 2");
            ViewBag.Books = books;
            return View();
        }

        public ActionResult ListBookModel()
        {
            var books = new List<Book>();
            books.Add(new Book(1, "Book 1", "Nguyễn Du", "/Content/Images/book1.jpg"));
            books.Add(new Book(2, "Book 2", "Kim Lân", "/Content/Images/book2.jpg"));
            books.Add(new Book(3, "Book 3", "Nguyễn Trãi", "/Content/Images/book3.jpg"));
            return View(books);
            return View();
        }

        public ActionResult EditBook(int id)
        {
            var books = new List<Book>();
            books.Add(new Book(1, "Book 1", "Nguyễn Du", "/Content/Images/book1.jpg"));
            books.Add(new Book(2, "Book 2", "Kim Lân", "/Content/Images/book2.jpg"));
            books.Add(new Book(3, "Book 3", "Nguyễn Trãi", "/Content/Images/book3.jpg"));
            Book book = new Book();
            foreach (Book b in books)
            {
                if (b.Id == id)
                {
                    book = b;
                    break;
                }
            }
            return View(book);
        }

        [HttpPost, ActionName("EditBook")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, string Title, string Author, string Image_cover)
        {
            var books = new List<Book>();
            books.Add(new Book(1, "Book 1", "Nguyễn Du", "/Content/Images/book1.jpg"));
            books.Add(new Book(2, "Book 2", "Kim Lân", "/Content/Images/book2.jpg"));
            books.Add(new Book(3, "Book 3", "Nguyễn Trãi", "/Content/Images/book3.jpg"));
            foreach (Book b in books)
            {
                if (b.Id == id)
                {
                    b.Title = Title;
                    b.Author = Author;
                    b.Image_cover = Image_cover;
                }
            }
            return View("ListBookModel", books);
        }
        public ActionResult CreateBook()
        {
            return View();
        }

        [HttpPost, ActionName("CreateBook")]
        [ValidateAntiForgeryToken]
        public ActionResult Contact([Bind(Include = "Id, Title, Author, ImageCover")] Book book)
        {
            var books = new List<Book>();
            books.Add(new Book(1, "Book 1", "Nguyễn Du", "/Content/Images/book1.jpg"));
            books.Add(new Book(2, "Book 2", "Kim Lân", "/Content/Images/book2.jpg"));
            books.Add(new Book(3, "Book 3", "Nguyễn Trãi", "/Content/Images/book3.jpg"));
            try
            {
                if (ModelState.IsValid)
                {
                    books.Add(book);
                }
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Error Save Data");
            }
            return View("ListBookModel", books);
        }

        public ActionResult DeleteBook(int id)
        {
            var books = new List<Book>();
            Book book = new Book();
            foreach (Book b in books)
            {
                if (b.Id == id)
                {
                    book = b;
                    break;
                }
            }
            return View(book);
        }

        [HttpPost, ActionName("DeleteBook")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, string Title, string Author, string ImageCover)
        {
            var books = new List<Book>();
            books.Add(new Book(1, "Book 1", "Nguyễn Du", "/Content/Images/book1.jpg"));
            books.Add(new Book(2, "Book 2", "Kim Lân", "/Content/Images/book2.jpg"));
            books.Add(new Book(3, "Book 3", "Nguyễn Trãi", "/Content/Images/book3.jpg"));
            foreach (Book b in books)
            {
                if (b.Id == id)
                {
                    b.Title = Title;
                    b.Author = Author;
                    b.Image_cover = ImageCover;
                    books.Remove(b);
                    break;
                }
            }
            return View("ListBookModel", books);
        }

    }
}