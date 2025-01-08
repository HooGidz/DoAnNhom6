using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using DoAnNhom6.Models;

namespace Harmic.Controllers
{
    public class ContactController : Controller
    {
        private readonly DoAnNhom6Context _context;
        public ContactController(DoAnNhom6Context context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost("/contact/SendContact")]
        public async Task<IActionResult> SendContact([Bind("Name,Phone,Email,Message")] TblContact contact)
        {
            if (ModelState.IsValid)
            {
                contact.IsRead = 0;
                contact.CreatedDate = DateTime.Now;
                contact.CreatedBy = contact.Name;

                _context.Add(contact);
                await _context.SaveChangesAsync();
                TempData["StatusMessage"] = "Gửi liên hệ thành công!";
                return RedirectToAction("Index"); // Điều hướng về trang Index
            }
            TempData["StatusMessage"] = "Đã có lỗi xảy ra. Vui lòng kiểm tra lại thông tin.";
            return RedirectToAction("Index");
        }


    }
}