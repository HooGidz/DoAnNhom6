using DoAnNhom6.Models;
using Microsoft.AspNetCore.Mvc;

namespace DoAnNhom6.Controllers
{
    public class ContactController : Controller
    {
        private readonly DoAnNhom6Context _context;
        public ContactController(DoAnNhom6Context Context)
        {
            _context = Context;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(string name, string email, string phone, string message)
        {
            try
            {
                TblContact contact = new TblContact();
                contact.Name = name;
                contact.Phone = phone;
                contact.Email = email;                
                contact.Message = message;
                _context.TblContacts.Add(contact);
                _context.SaveChanges();
                return Json(new { startus = true });
            }
            catch
            {
                return Json(new { startus = false });
            }
        }
    }
}
