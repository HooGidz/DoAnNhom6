using Microsoft.AspNetCore.Mvc;

namespace DoAnNhom6.Areas.Admin.Controllers
{
    public class FileManagerController: Controller
    {

        [Area("Admin")]
        [Route("/Admin/file-manager")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
