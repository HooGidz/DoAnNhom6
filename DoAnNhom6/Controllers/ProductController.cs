using Microsoft.AspNetCore.Mvc;

namespace DoAnNhom6.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
