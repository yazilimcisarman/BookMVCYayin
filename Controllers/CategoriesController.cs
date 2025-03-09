﻿using BookMVCYayin.Context;
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
    }
}
