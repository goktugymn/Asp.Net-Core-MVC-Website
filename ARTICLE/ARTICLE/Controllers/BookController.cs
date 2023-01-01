using ARTICLE.Models;
using ARTICLE.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using X.PagedList;

namespace ARTICLE.Controllers
{
    public class BookController : Controller
    {
        
        BookRepository bookRepository = new BookRepository();
        Context c = new Context();
        public IActionResult Index(int page=1)
        {
            return View(bookRepository.TList("Category").ToPagedList(page,20));
        }
        [HttpGet]
        public IActionResult AddBook()
        {
            List<SelectListItem> values = (from x in c.Categories.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CategoryName,
                                               Value = x.CategoryID.ToString(),
                                           }).ToList();
            ViewBag.v1 = values;
            return View();
        }
        [HttpPost]
        public IActionResult AddBook(Book p)
        {
            bookRepository.TAdd(p);
            return RedirectToAction("Index");
        }
        public IActionResult DeleteBook(int id)
        {
            bookRepository.TDelete(new Book { BookID = id}); 
            return RedirectToAction("Index");
        }
        public IActionResult BookGet(int id)
        {
            var x = bookRepository.TGet(id);
            List<SelectListItem> values = (from y in c.Categories.ToList()
                                           select new SelectListItem
                                           {
                                               Text = y.CategoryName,
                                               Value = y.CategoryID.ToString(),
                                           }).ToList();
            ViewBag.v1 = values;
            
            Book b = new Book()
            {
                BookID = x.BookID,
                CategoryID = x.CategoryID,
                BookName = x.BookName,
                Price = x.Price,
                Stock = x.Stock,
                DecriptionofBook = x.DecriptionofBook,
                ImageURL = x.ImageURL
            };
            return View(b);
        }
        [HttpPost]
        public IActionResult BookUpdate(Book p)
        {
            var x = bookRepository.TGet(p.BookID);
            x.BookName = p.BookName;
            x.Stock = p.Stock;
            x.Price = p.Price;
            x.ImageURL = p.ImageURL;
            x.DecriptionofBook = p.DecriptionofBook;
            x.CategoryID = p.CategoryID;
            bookRepository.TUpdate(x);
            return RedirectToAction("Index");
        }
    }
}
