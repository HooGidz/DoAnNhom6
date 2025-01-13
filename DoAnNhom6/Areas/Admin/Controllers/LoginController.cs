using Microsoft.AspNetCore.Mvc;
using DoAnNhom6.Models;

namespace DoAnNhom6.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class LoginController : Controller
    {
        private readonly DoAnNhom6Context _context;
        public LoginController(DoAnNhom6Context context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(TblUser user)
        {
            if (user == null)
            {
                return NotFound();
            }
            string pw = DoAnNhom6.Utilities.Function.MD5Password(user.Password);
            var check = _context.TblUsers.Where(m => (m.Email == user.Email) && (m.Password == pw)).FirstOrDefault();
            if (check == null)
            {
                DoAnNhom6.Utilities.Function._Message = "INvalid Username or Password!";
                return RedirectToAction("Index", "Login");
            }
            DoAnNhom6.Utilities.Function._Message = string.Empty;
            DoAnNhom6.Utilities.Function._UserId = check.UserId;
            DoAnNhom6.Utilities.Function._Username = string.IsNullOrEmpty(check.Username) ? string.Empty : check.Username;
            DoAnNhom6.Utilities.Function._Email = string.IsNullOrEmpty(check.Email) ? string.Empty : check.Email;
            return RedirectToAction("Index", "Home", new { area = "Admin" });
        }
    }
}
