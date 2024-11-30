using Microsoft.AspNetCore.Mvc;

namespace DoAnNhom6.Controllers
{
    public class MenuController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
