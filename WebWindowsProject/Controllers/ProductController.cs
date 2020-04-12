using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebWindowsProject.Data;
using WebWindowsProject.Models;
using WebWindowsProject.Services;

namespace WebWindowsProject.Controllers
{
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _context;
        public ProductController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<ProductItem> productList = new List<ProductItem>();
            productList = (from products in _context.Products
                           select products).ToList();
            return View(productList);
        }

        
      

    }
}
