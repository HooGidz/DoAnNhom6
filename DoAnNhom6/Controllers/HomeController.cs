using DoAnNhom6.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace DoAnNhom6.Controllers
{
	public class HomeController : Controller
	{
		
		private readonly ILogger<HomeController> _logger;


        public HomeController(ILogger<HomeController> logger)
        {
            Console.WriteLine("Remote changes"); // Thay ??i t? remote
            
            _logger = logger;
        }
        public IActionResult Index()
		{

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
