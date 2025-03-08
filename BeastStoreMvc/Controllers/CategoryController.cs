using Microsoft.AspNetCore.Mvc;
using System.Linq;
using BeastStoreMvc.Models;

namespace BeastStoreMvc.Controllers
{
    public class CategoryMasterController : Controller
    {
        private readonly TodoContext _context;

        public CategoryMasterController(TodoContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var categories = _context.CategoryMaster.ToList();
            return View(categories);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CategoryMaster model)
        {
            if (!ModelState.IsValid)
            {
                TempData["Error"] = "Empty fields cannot be submitted.";
                return View(model);
            }

            _context.CategoryMaster.Add(model);
            _context.SaveChanges();
            TempData["Success"] = "Record saved successfully!";
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                TempData["Error"] = "Invalid category ID.";
                return RedirectToAction("Index");
            }

            var category = _context.CategoryMaster.Find(id);
            if (category == null)
            {
                TempData["Error"] = "Category not found!";
                return RedirectToAction("Index");
            }

            _context.CategoryMaster.Remove(category);
            _context.SaveChanges();
            TempData["Success"] = "Record deleted successfully!";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                TempData["Error"] = "Invalid category ID.";
                return RedirectToAction("Index");
            }

            var category = _context.CategoryMaster.Find(id);
            if (category == null)
            {
                TempData["Error"] = "Category not found!";
                return RedirectToAction("Index");
            }

            return View(category);
        }

        [HttpPost]
        public IActionResult Edit(CategoryMaster model)
        {
            if (!ModelState.IsValid)
            {
                TempData["Error"] = "Record update failed. Please check the fields.";
                return View(model);
            }

            var category = _context.CategoryMaster.Find(model.CategoryId);
            if (category == null)
            {
                TempData["Error"] = "Category not found!";
                return RedirectToAction("Index");
            }

            category.CategoryName = model.CategoryName;
            category.Description = model.Description;
            _context.SaveChanges();

            TempData["Success"] = "Record updated successfully!";
            return RedirectToAction("Index");
        }
    }
}
