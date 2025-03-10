using BookMVCYayin.Context;
using BookMVCYayin.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookMVCYayin.Controllers
{
    public class BooksController : Controller
    {
        private readonly BookDbContext _context;

        public BooksController(BookDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var books = _context.Books.ToList();
            var category = _context.Categories.ToList();    
            return View(books);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Book model )
        {
            _context.Books.Add(model);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult GetBooks()
        {
            var books = _context.Books.Where(x => x.Stock > 0).ToList();
            return Json(new {status = true, data=books});
        }
        public IActionResult Update(int bookId)
        {
            var book = _context.Books.Find(bookId);
            book.Kategori = _context.Categories.Where(x => x.Id == book.KategoriId).FirstOrDefault();
            //book.Kategori.UstKategori
            var bookcategory = book.Kategori.UstKategori;
            var category = _context.Categories.Where(x => x.Id == bookcategory).FirstOrDefault();
            ViewBag.Kategori = category.Id;
            //ViewBag.AltKategori = book.KategoriId;
            return View(book);
        }
        [HttpPost]
        public IActionResult Update(Book model)
        {
            var vBook = _context.Books.Find(model.Id);
            vBook.Title= model.Title;
            vBook.Author= model.Author;
            vBook.Stock = model.Stock;
            vBook.KategoriId = model.KategoriId;

            _context.Books.Update(vBook);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
