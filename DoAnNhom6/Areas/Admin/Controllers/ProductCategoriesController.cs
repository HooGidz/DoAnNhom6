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
    public class ProductCategoriesController : Controller
    {
        private readonly DoAnNhom6Context _context;

        public ProductCategoriesController(DoAnNhom6Context context)
        {
            _context = context;
        }

        // GET: Admin/ProductCategories
        public async Task<IActionResult> Index()
        {
            return View(await _context.TblProductCategories.ToListAsync());
        }

        // GET: Admin/ProductCategories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblProductCategory = await _context.TblProductCategories
                .FirstOrDefaultAsync(m => m.CategoryId == id);
            if (tblProductCategory == null)
            {
                return NotFound();
            }

            return View(tblProductCategory);
        }

        // GET: Admin/ProductCategories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/ProductCategories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CategoryId,Name,Alias,Description,IsActive")] TblProductCategory tblProductCategory)
        {
            if (ModelState.IsValid)
            {
                tblProductCategory.Alias = DoAnNhom6.Utilities.Function.TitleSlugGenerationAlias(tblProductCategory.Alias);
                _context.Add(tblProductCategory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tblProductCategory);
        }

        // GET: Admin/ProductCategories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblProductCategory = await _context.TblProductCategories.FindAsync(id);
            if (tblProductCategory == null)
            {
                return NotFound();
            }
            return View(tblProductCategory);
        }

        // POST: Admin/ProductCategories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CategoryId,Name,Alias,Description,IsActive")] TblProductCategory tblProductCategory)
        {
            if (id != tblProductCategory.CategoryId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblProductCategory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblProductCategoryExists(tblProductCategory.CategoryId))
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
            return View(tblProductCategory);
        }

        // GET: Admin/ProductCategories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblProductCategory = await _context.TblProductCategories
                .FirstOrDefaultAsync(m => m.CategoryId == id);
            if (tblProductCategory == null)
            {
                return NotFound();
            }

            return View(tblProductCategory);
        }

        // POST: Admin/ProductCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblProductCategory = await _context.TblProductCategories.FindAsync(id);
            if (tblProductCategory != null)
            {
                _context.TblProductCategories.Remove(tblProductCategory);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblProductCategoryExists(int id)
        {
            return _context.TblProductCategories.Any(e => e.CategoryId == id);
        }
    }
}
