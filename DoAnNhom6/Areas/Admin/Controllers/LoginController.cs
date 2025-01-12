using DoAnNhom6.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DoAnNhom6.Models;

namespace DoAnNhom6.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class LoginController : Controller
    {
        private readonly DbContext _context;
        public LoginController(DbContext context)
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
            string pw = Function.SHA256Password(user.Password);
            var check = _context.TblUser.Where(m => (m.Email == user.Email) && (m.Password == pw).FirsOrDefault());
            if (check == null)
            {
                Function._Message = "INvalid Username or Password!";
                return RedirectToAction("Index", "Login");
            }
            Function._Message = string.Empty;
            Function._UserId = check.UserId;
            Function._Username = string.IsNullOrEmpty(check.Username) ? string.Empty : check.Username;
            Function._Email = string.IsNullOrEmpty(check.Email) ? string.Empty : check.Email;
            return RedirectToAction("Index", "Home");
        }
    }
}
