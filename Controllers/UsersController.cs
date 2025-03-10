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
        public IActionResult GetUsers()
        {
            var users = _context.Users.ToList();
            return Json(new {status=true,data=users});
        }
        public IActionResult Update(int userId)
        {
            var user = _context.Users.Find(userId);
            return View(user);
        }
        [HttpPost]
        public IActionResult Update(User model)
        {
            var vUser = _context.Users.Find(model.Id);
            vUser.Name = model.Name;
            vUser.Surname = model.Surname;
            vUser.Email = model.Email;
            vUser.Phone = model.Phone;
            _context.Users.Update(vUser);
            _context.SaveChanges();
            return RedirectToAction("Index");

        }

    }
}
