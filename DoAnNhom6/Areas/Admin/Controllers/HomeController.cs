using Microsoft.AspNetCore.Mvc;
using DoAnNhom6.Utilities;

namespace DoAnNhom6.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        [Area ("Admin")]
        public IActionResult Index()
        {
            if (!DoAnNhom6.Utilities.Function.IsLogin())
            {
                return RedirectToAction("Index", "Login", new { area = "Admin" });
            }
            return View();
        }
    }
}
