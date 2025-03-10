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

        public IActionResult Index(int? userId)
        {
            if(userId != null && userId !=0)
            {
                var userRendtedBooks = _context.RentedBooks.Where(x => x.UserId == userId).ToList();
                var user = _context.Users.ToList();
                var books = _context.Books.ToList();
                return View(userRendtedBooks);
            }
            else
            {
                var rentedBooks = _context.RentedBooks.ToList();
                var user = _context.Users.ToList();
                var books = _context.Books.ToList();
                return View(rentedBooks);
            }
            
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(RentedBook model)
        {
            if (model.UserId != 0 && model.BookId != 0)
            {
                model.StartDate = DateTime.Now;
                _context.RentedBooks.Add(model);

                var book = _context.Books.Find(model.BookId);
                book.Stock--;

                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
            
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
        public IActionResult GetCountByRentedBooks()
        {
            var rendtedBooks = _context.RentedBooks.Where(x => x.EndDate == null).Count();

            return Json(new {status = true, data=rendtedBooks});
        }
    }
}
