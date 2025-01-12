using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using DoAnNhom6.Areas.Admin.Models;
using DoAnNhom6.Models;
using DoAnNhom6.Utilities;

namespace DoAnNhom6.Areas.Admin.Controllers
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
        public IActionResult Index(TblUser user)
        {
            if (user == null)
            {
                return View();
            }
            var check = _context.TblUser.FirstOrDefault(m => m.Email == user.Email);
            if (check != null)
            {
                Functions._MessageEmail = "Duplicate Email!";
                return RedirectToAction("Index", "Register");
            }
            Functions._MessageEmail = string.Empty;
            user.Password = Functions.SHA256Hash(user.Password); 
            _context.TblUser.Add(user);
            _context.SaveChanges(); 

            return RedirectToAction("Success", "Register"); 
        }
    }
}

