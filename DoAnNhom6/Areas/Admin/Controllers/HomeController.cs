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
        public IActionResult Logout()
        {
            DoAnNhom6.Utilities.Function._UserId = 0;
            DoAnNhom6.Utilities.Function._Username = string. Empty;
            DoAnNhom6.Utilities.Function._Email = string. Empty;
            DoAnNhom6.Utilities.Function._Message = string. Empty;
            DoAnNhom6.Utilities.Function._MessageEmail = string. Empty;
            return RedirectToAction("Index","Login");
        }
    }
}
