using Microsoft.AspNetCore.Mvc;

namespace DoAnNhom6.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        [Area ("Admin")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
