using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FileUploadControl;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebWindowsProject.Data;
using WebWindowsProject.Models;

namespace WebWindowsProject.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private ApplicationDbContext _context;
        private UploadInterface _upload;

        public AdminController(ApplicationDbContext context, UploadInterface upload)
        {
            _upload = upload;
            _context = context;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(IList<IFormFile> files, ProductViewModel pmodel, ProductItem product)
        {
            product.Name = pmodel.Name;
            product.Description = pmodel.Description;
            product.IsPurchased = pmodel.IsPurchased;
            product.Price = pmodel.Price;
            product.TypeName = pmodel.TypeName;
            foreach (var item in files)
            {
                product.Image = "~/uploads/" + item.FileName.Trim();
            }
            _upload.uploadfilemultiple(files);
            _context.Products.Add(product);
            _context.SaveChanges();
            TempData["Success"] = "Saved Your Product";
            return RedirectToAction("Create", "Admin");
        }
        [HttpGet]
        public IActionResult CheckProducts()
        {
            var getProducts = _context.Products.ToList();

            //var getOrderTable = _context.OrderTables.ToList().OrderByDescending(a => a.DatetoPresent);
            return View(getProducts);
        }

        [HttpPost]
        public IActionResult CheckProducts(ProductViewModel model, ProductItem product)
        {
            product.Name = model.Name;
            product.Description = model.Description;
            product.IsPurchased = model.IsPurchased;
            product.Price = model.Price;
            product.TypeName = model.TypeName;
            _context.Products.Add(product);
            _context.SaveChanges();
            return  RedirectToAction("CheckProducts", "Admin");
        }

        [HttpGet]
        public IActionResult getUsersDetails()
        {
            var getUserTable = _context.Users.ToList();
            return View(getUserTable);
        }

       
    }
}