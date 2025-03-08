using BeastStoreMvc.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace BeastStoreMvc.Controllers
{
    public class ProductMasterController : Controller
    {
        private readonly TodoContext context;

        public ProductMasterController(TodoContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            var products = (from p in context.ProductMaster
                            join c in context.CategoryMaster on p.CategoryId equals c.CategoryId
                            select new
                            {
                                Id = p.ProductId,
                                Name = p.ProductName ?? "Unknown",
                                CatId = p.CategoryId,
                                Price = p.Price ?? 0, // Handling NULL Price
                                Description = p.Description ?? "No Description", // Handling NULL Description
                                CatName = c.CategoryName ?? "No Category"
                            }).ToList()
                      .Select(x => new ProductMaster()
                      {
                          ProductId = x.Id,
                          ProductName = x.Name,
                          CategoryId = x.CatId,
                          Price = x.Price,
                          Description = x.Description,
                          CategoryName = x.CatName
                      });

            return View(products.ToList());
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Categories = new SelectList(context.CategoryMaster, "CategoryId", "CategoryName");
            return View(new ProductMaster());
        }

        [HttpPost]
        public IActionResult Create(ProductMaster model)
        {
            if (ModelState.IsValid)
            {
                context.ProductMaster.Add(model);
                context.SaveChanges();
                TempData["Success"] = "Product added successfully!";
                return RedirectToAction("Index");
            }

            TempData["Error"] = "Failed to add product. Please check the fields.";
            ViewBag.Categories = new SelectList(context.CategoryMaster, "CategoryId", "CategoryName");
            return View(model);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var product = context.ProductMaster.Find(id);
            if (product == null)
            {
                TempData["Error"] = "Product not found!";
                return RedirectToAction("Index");
            }

            ViewBag.Categories = new SelectList(context.CategoryMaster, "CategoryId", "CategoryName");
            return View(product);
        }

        [HttpPost]
        public IActionResult Edit(ProductMaster model)
        {
            if (ModelState.IsValid)
            {
                var existingProduct = context.ProductMaster.Find(model.ProductId);
                if (existingProduct != null)
                {
                    context.Entry(existingProduct).CurrentValues.SetValues(model);
                    context.SaveChanges();
                    TempData["Success"] = "Product updated successfully!";
                    return RedirectToAction("Index");
                }
                TempData["Error"] = "Product not found!";
            }

            ViewBag.Categories = new SelectList(context.CategoryMaster, "CategoryId", "CategoryName");
            return View(model);
        }

        public IActionResult Delete(int id)
        {
            var product = context.ProductMaster.Find(id);
            if (product != null)
            {
                context.ProductMaster.Remove(product);
                context.SaveChanges();
                TempData["Success"] = "Product deleted successfully!";
            }
            else
            {
                TempData["Error"] = "Product not found!";
            }
            return RedirectToAction("Index");
        }
    }
}
