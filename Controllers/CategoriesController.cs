using BookMVCYayin.Context;
using BookMVCYayin.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookMVCYayin.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly BookDbContext _context;

        public CategoriesController(BookDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var categories = _context.Categories.ToList();
            return View(categories);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category model)
        {
            _context.Categories.Add(model);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult GetUstKategori()
        {
            var ustCategories = _context.Categories.Where(x => x.UstKategori == 0).ToList();
            return Json(new { status = true,data=ustCategories});
        }

        public IActionResult GetAltKategori(int categoryId)
        {
            var altKategori = _context.Categories.Where(x => x.UstKategori == categoryId).ToList();
            return Json(new {status = true, data=altKategori});
        }

    }
}
