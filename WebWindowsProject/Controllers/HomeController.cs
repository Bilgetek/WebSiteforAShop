using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebWindowsProject.Data;
using WebWindowsProject.Models;

namespace WebWindowsProject.Controllers
{
    public class HomeController : Controller
    {
        int count = 1;
        bool flag = true;
        private UserManager<ApplicationUser> _userManager;

        private ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            var getProducts = _context.Products.ToList();
            return View(getProducts);
        }

        [HttpGet]
        public IActionResult SatinAl(int id)
        {
            SatinAlViewModel vm = new SatinAlViewModel();
            var item = _context.Products.Where(a => a.productId == id).FirstOrDefault();
            vm.Amount = item.Amount;
            vm.description = item.Description;
            vm.price = item.Price;
            vm.product_name = item.Name;
            vm.type_name = item.TypeName;
            vm.product_id = item.productId;
            return View(vm);
        }

        [HttpPost]
        public IActionResult SatinAl(SatinAlViewModel satinmodel)
        {
            List<OrderTable> ordering = new List<OrderTable>();
            List<Order> orders = new List<Order>();
            string amount = satinmodel.Amount.ToString();
            int productid = satinmodel.product_id;

            string[] amountArray = amount.Split(',');
            count = amountArray.Length;
            if (Checkproduct(amount, productid) == false)
            {
                foreach (var item in amountArray)
                {
                    orders.Add(new Order { ProductId = satinmodel.product_id, Amount = satinmodel.Amount, UserId = _userManager.GetUserId(HttpContext.User) });
                }
                foreach (var item in orders)
                {
                    _context.Orders.Add(item);
                    _context.SaveChanges();
                }
                TempData["Success"] = "Product Sepette, Kontrol ediniz";
            }
            else
            {
                TempData["Message"] = "Sepete eklenemedi, ürün kalmamış olabilir";
            }
            return RedirectToAction("SatinAl");
        }

        private bool Checkproduct(string amount, int productid)
        {
            string _amount = amount;
            string[] amountTook = _amount.Split(',');
            var amountList = _context.OrderTables.Where(a => a.productDetailsId == productid).ToList();
            foreach (var item in amountList)
            {
                string alreadyTook = item.amount;
                foreach (var item1 in amountTook)
                {
                    if (item1==alreadyTook)
                    {
                        flag = false;
                        break;
                    }
                }
            }
            if (flag == false)
                return true;
            else
                return false;
        }

        [HttpGet]
        public IActionResult WishList(){
            var getOrders = _context.Orders.ToList();
            return View(getOrders);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            Order order = GetOrder(id);
            if (order != null)
            {
                _context.Orders.Remove(order);
                _context.SaveChanges();
            }
            var getOrders = _context.Orders.ToList();
            
            ViewData["Success"] = "Your order has been deleted.";
            return RedirectToAction("WishList");
        }

        private Order GetOrder(int id)
        {
            return _context.Orders.FirstOrDefault(o => o.ProductId == id);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }
        public IActionResult Gomlek(ProductItem item)
        {
            ViewData["Message"] = "Gomlekler";
            
            var products = (from i in _context.Products
                            where i.TypeName == "Gomlek"
                            select i);
            return View(products);
        }

        public IActionResult MontveKaban(ProductItem item)
        {
            ViewData["Message"] = "Mont ve Kabanlar";

            var products = (from i in _context.Products
                            where i.TypeName == "Montkaban"
                            select i);
            return View(products);
        }

        public IActionResult Ceket(ProductItem item)
        {
            ViewData["Message"] = "Ceketler";

            var products = (from i in _context.Products
                            where i.TypeName == "Ceket"
                            select i);
            return View(products);
        }
        public IActionResult Elbise(ProductItem item)
        {
            ViewData["Message"] = "Elbiseler";

            var products = (from i in _context.Products
                            where i.TypeName == "Elbise"
                            select i);
            return View(products);
        }

        public IActionResult Kazak(ProductItem item)
        {
            ViewData["Message"] = "Kazaklar";

            var products = (from i in _context.Products
                            where i.TypeName == "Kazak"
                            select i);
            return View(products);
        }
        public IActionResult Etek(ProductItem item)
        {
            ViewData["Message"] = "Etekler";

            var products = (from i in _context.Products
                            where i.TypeName == "Etek"
                            select i);
            return View(products);
        }
        public IActionResult PantolonveSort(ProductItem item)
        {
            ViewData["Message"] = "PantolonveSortlar";

            var products = (from i in _context.Products
                            where i.TypeName == "Pantolonşort"
                            select i);
            return View(products);
        }
        
        public IActionResult Gozluk(ProductItem item)
        {
            ViewData["Message"] = "Gozluk";

            var products = (from i in _context.Products
                            where i.TypeName == "Gozluk"
                            select i);
            return View(products);
        }
        public IActionResult Dekorasyon(ProductItem item)
        {
            ViewData["Message"] = "Dekorasyon";

            var products = (from i in _context.Products
                            where i.TypeName == "Dekorasyon"
                            select i);
            return View(products);
        }


        public IActionResult Sweat(ProductItem item)
        {
            ViewData["Message"] = "Sweatler";

            var products = (from i in _context.Products
                            where i.TypeName == "Sweat"
                            select i);
            return View(products);
        }

        public IActionResult Aksesuar()
        {
            ViewData["Message"] = "Aksesuarlar";
            var products = (from i in _context.Products
                            where i.TypeName == "Aksesuar"
                            select i);
            return View(products);


        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
       
    }
}
