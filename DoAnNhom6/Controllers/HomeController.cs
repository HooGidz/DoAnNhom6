using DoAnNhom6.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace DoAnNhom6.Controllers
{
	public class HomeController : Controller
	{
		private readonly DoAnNhom6Context _context;
		private readonly ILogger<HomeController> _logger;

<<<<<<< HEAD
		public HomeController(DoAnNhom6Context context, ILogger<HomeController> logger)
=======
        public HomeController(ILogger<HomeController> logger)
>>>>>>> dba0d90f3e66eb184d996336070966e8702da3c3
		{
			_context = context;
			_logger = logger;
		}

        public IActionResult Index()
		{
			ViewBag.productCategories = _context.TblProductCategories.ToList();
			ViewBag.productNew = _context.TblProducts.Where(m=>m.IsNew).ToList();
            var products = _context.TblProducts.ToList();

            //return View(products); // Truy?n danh s�ch s?n ph?m v�o Model

            return View();
            
        }

		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
    }
}
