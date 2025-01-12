using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DoAnNhom6.Areas.Admin.Model;
using DoAnNhom6.Models;
using DoAnNhom6.Utilities;

namespace DoAnNhom6.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RegisterController : Controller
    {
        private readonly DoAnNhom6Context _context;
        public RegisterController(DoAnNhom6Context context)
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
            var check = _context.TblUsers.Where(m => m.Email == user.Email).FirstOrDefault();
            if (check != null)
            {
                DoAnNhom6.Utilities.Function._MessageEmail = "Email đã đăng kí tài khoản!";
                return RedirectToAction("Index", "Register");
            }
            DoAnNhom6.Utilities.Function._MessageEmail = string.Empty;
            user.Password = DoAnNhom6.Utilities.Function.MD5Password(user.Password);
            _context.TblUsers.Add(user);
            _context.SaveChanges();

            return RedirectToAction("Index" , "Login");
        }
    }
}
