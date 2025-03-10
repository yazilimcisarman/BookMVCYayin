using BookMVCYayin.Context;
using BookMVCYayin.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookMVCYayin.Controllers
{
    public class RentedBooksController : Controller
    {
        private readonly BookDbContext _context;

        public RentedBooksController(BookDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var rentedBooks = _context.RentedBooks.ToList();
            var user = _context.Users.ToList();
            var books = _context.Books.ToList();
            return View(rentedBooks);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(RentedBook model)
        {
            model.StartDate = DateTime.Now;
            _context.RentedBooks.Add(model);

            var book = _context.Books.Find(model.BookId);
            book.Stock--;

            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult UpdateEndDate(int rentedBookId)
        {
            var rentedBook = _context.RentedBooks.Find(rentedBookId);
            rentedBook.EndDate = DateTime.Now;

            _context.RentedBooks.Update(rentedBook);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int rentedBookId)
        {
            var rentedBook = _context.RentedBooks.Find(rentedBookId);
            _context.RentedBooks.Remove(rentedBook);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
