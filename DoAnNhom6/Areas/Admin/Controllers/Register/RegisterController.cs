using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace DoAnNhom6.Controllers.Register
{
    [Area("Admin")]
    public class RegisterController : Controller
    {
        private readonly DbContext _context;
        public RegisterController(DbContext context)
        {
            _context = context;

        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(User user)
        {
            if (user == null)
            {
                return View();
            }
            var check = _context.User.Where(m => m.Email == user.Email).FirsOrDefault();
            if (check != null)
            {
                Functions._MassageEmail = "Duplicate Email!";
                return RedirectToAction("Index", "Register");
            }
        }
    }
