using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using BeastStoreMvc.Models;

namespace BeastStoreMvc.Controllers
{
    public class ProductListController : Controller
    {
        private readonly TodoContext _context;

        public ProductListController(TodoContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(GetProducts(1));
        }

        [HttpPost]
        public IActionResult Index(int currentPageIndex)
        {
            return View(GetProducts(currentPageIndex));
        }

        private ProductListsModel GetProducts(int currentPage)
        {
            int maxRows = 10;

            var productList = new ProductListsModel
            {
                ProductData = _context.ProductMaster
                    .Join(_context.CategoryMaster,
                          prod => prod.CategoryId,
                          cat => cat.CategoryId,
                          (prod, cat) => new Products
                          {
                              ProductId = prod.ProductId,
                              ProductName = prod.ProductName ?? "Unknown",
                              CategoryId = cat.CategoryId,
                              CategoryName = cat.CategoryName ?? "No Category"
                          })
                    .OrderBy(prod => prod.ProductId)
                    .Skip((currentPage - 1) * maxRows)
                    .Take(maxRows)
                    .ToList(),

                PageCount = (int)Math.Ceiling((double)_context.ProductMaster.Count() / maxRows),
                CurrentPageIndex = currentPage
            };

            return productList;
        }
    }
}
