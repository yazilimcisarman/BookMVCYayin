using BookMVCYayin.Context;
using BookMVCYayin.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookMVCYayin.Controllers
{
    public class UsersController : Controller
    {
        private readonly BookDbContext _context;

        public UsersController(BookDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var value = _context.Users.ToList();
            return View(value);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(User model)
        {
            _context.Users.Add(model);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
