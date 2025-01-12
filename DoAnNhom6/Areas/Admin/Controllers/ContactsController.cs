using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DoAnNhom6.Models;

namespace DoAnNhom6.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ContactsController : Controller
    {
        private readonly DoAnNhom6Context _context;

        public ContactsController(DoAnNhom6Context context)
        {
            _context = context;
        }

        // GET: Admin/Contacts
        public async Task<IActionResult> Index()
        {
            if (!DoAnNhom6.Utilities.Function.IsLogin())  // Kiểm tra xem người dùng đã đăng nhập chưa
                return RedirectToAction("Login", "Home");
            return View(await _context.TblContacts.ToListAsync());
        }

        // GET: Admin/Contacts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblContact = await _context.TblContacts
                .FirstOrDefaultAsync(m => m.ContactId == id);
            if (tblContact == null)
            {
                return NotFound();
            }

            return View(tblContact);
        }

        // GET: Admin/Contacts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Contacts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ContactId,Name,Phone,Email,Message,IsRead,CreatedDate,CreatedBy,ModifiedDate,ModifiedBy")] TblContact tblContact)
        {
            if (ModelState.IsValid)
            {
                tblContact.Name = DoAnNhom6.Utilities.Function.TitleSlugGenerationAlias(tblContact.Name);
                _context.Add(tblContact);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tblContact);
        }

        // GET: Admin/Contacts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblContact = await _context.TblContacts.FindAsync(id);
            if (tblContact == null)
            {
                return NotFound();
            }
            return View(tblContact);
        }

        // POST: Admin/Contacts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ContactId,Name,Phone,Email,Message,IsRead,CreatedDate,CreatedBy,ModifiedDate,ModifiedBy")] TblContact tblContact)
        {
            if (id != tblContact.ContactId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblContact);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblContactExists(tblContact.ContactId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(tblContact);
        }

        // GET: Admin/Contacts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblContact = await _context.TblContacts
                .FirstOrDefaultAsync(m => m.ContactId == id);
            if (tblContact == null)
            {
                return NotFound();
            }

            return View(tblContact);
        }

        // POST: Admin/Contacts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblContact = await _context.TblContacts.FindAsync(id);
            if (tblContact != null)
            {
                _context.TblContacts.Remove(tblContact);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblContactExists(int id)
        {
            return _context.TblContacts.Any(e => e.ContactId == id);
        }
    }
}
