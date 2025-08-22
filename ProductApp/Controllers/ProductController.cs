using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProductApp.Models; // Make sure this matches your namespace
using System.Collections.Generic;
using System;
using System.Linq;

namespace ProductApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly ILogger<ProductController> _logger;

        public ProductController(ILogger<ProductController> logger)
        {
            _logger = logger;
        }

        // GET: /Product or /Product/Index
        [HttpGet]
        public IActionResult Index()
        {
            var products = GetProducts();

            _logger.LogInformation("Displayed full product list.");

            return View(products);
        }

        // POST: /Product/Index
        [HttpPost]
        public IActionResult Index(string searchTerm)
        {
            var products = GetProducts();

            if (!string.IsNullOrEmpty(searchTerm))
            {
                products = products
                    .Where(p => p.Name.Contains(searchTerm, StringComparison.OrdinalIgnoreCase))
                    .ToList();

                _logger.LogInformation("Search performed for term: {SearchTerm}", searchTerm);
            }
            else
            {
                _logger.LogInformation("Search performed with no term.");
            }

            return View(products);
        }

        // Private helper method to get sample data
        private List<Product> GetProducts()
        {
            return new List<Product>
            {
                new Product { Id = 1, Name = "Laptop", Price = 999.99M },
                new Product { Id = 2, Name = "Headphones", Price = 199.99M },
                new Product { Id = 3, Name = "Keyboard", Price = 49.99M },
                new Product { Id = 4, Name = "Mouse", Price = 25.99M },
                new Product { Id = 5, Name = "Monitor", Price = 199.99M }
            };
        }
    }
}