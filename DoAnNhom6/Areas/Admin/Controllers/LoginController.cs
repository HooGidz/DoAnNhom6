using DoAnNhom6.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
            string pw = Functions.SHA256Password(user.Password);
            var check = _context.TblUser.Where(m => (m.Email == user.Email) && (m.Password == pw).FirsOrDefault());
            if (check == null)
            {
                Functions._Message = "INvalid Username or Password!";
                return RedirectToAction("Index", "Login");
            }
            Functions._Message = string.Empty;
            Functions._UserId = check.UserId;
            Functions._Username = string.IsNullOrEmpty(check.Username) ? string.Empty : check.Username;
            Functions._Email = string.IsNullOrEmpty(check.Email) ? string.Empty : check.Email;
            return RedirectToAction("Index", "Home");
        }
    }
}
