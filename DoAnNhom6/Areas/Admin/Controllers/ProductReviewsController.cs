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
    public class ProductReviewsController : Controller
    {
        private readonly DoAnNhom6Context _context;

        public ProductReviewsController(DoAnNhom6Context context)
        {
            _context = context;
        }

        // GET: Admin/ProductReviews
        public async Task<IActionResult> Index()
        {
            var doAnNhom6Context = _context.TblProductReviews.Include(t => t.Product).Include(t => t.User);
            return View(await doAnNhom6Context.ToListAsync());
        }

        // GET: Admin/ProductReviews/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblProductReview = await _context.TblProductReviews
                .Include(t => t.Product)
                .Include(t => t.User)
                .FirstOrDefaultAsync(m => m.ProductReviewId == id);
            if (tblProductReview == null)
            {
                return NotFound();
            }

            return View(tblProductReview);
        }

        // GET: Admin/ProductReviews/Create
        public IActionResult Create()
        {
            ViewData["ProductId"] = new SelectList(_context.TblProducts, "ProductId", "ProductId");
            ViewData["UserId"] = new SelectList(_context.TblUsers, "UserId", "UserId");
            return View();
        }

        // POST: Admin/ProductReviews/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductReviewId,ProductId,UserId,CreatedDate,Detail,Star,IsActive")] TblProductReview tblProductReview)
        {
            if (ModelState.IsValid)
            {
                tblProductReview.Detail= DoAnNhom6.Utilities.Function.TitleSlugGenerationAlias(tblProductReview.Detail);
                _context.Add(tblProductReview);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProductId"] = new SelectList(_context.TblProducts, "ProductId", "ProductId", tblProductReview.ProductId);
            ViewData["UserId"] = new SelectList(_context.TblUsers, "UserId", "UserId", tblProductReview.UserId);
            return View(tblProductReview);
        }

        // GET: Admin/ProductReviews/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblProductReview = await _context.TblProductReviews.FindAsync(id);
            if (tblProductReview == null)
            {
                return NotFound();
            }
            ViewData["ProductId"] = new SelectList(_context.TblProducts, "ProductId", "ProductId", tblProductReview.ProductId);
            ViewData["UserId"] = new SelectList(_context.TblUsers, "UserId", "UserId", tblProductReview.UserId);
            return View(tblProductReview);
        }

        // POST: Admin/ProductReviews/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProductReviewId,ProductId,UserId,CreatedDate,Detail,Star,IsActive")] TblProductReview tblProductReview)
        {
            if (id != tblProductReview.ProductReviewId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblProductReview);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblProductReviewExists(tblProductReview.ProductReviewId))
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
            ViewData["ProductId"] = new SelectList(_context.TblProducts, "ProductId", "ProductId", tblProductReview.ProductId);
            ViewData["UserId"] = new SelectList(_context.TblUsers, "UserId", "UserId", tblProductReview.UserId);
            return View(tblProductReview);
        }

        // GET: Admin/ProductReviews/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblProductReview = await _context.TblProductReviews
                .Include(t => t.Product)
                .Include(t => t.User)
                .FirstOrDefaultAsync(m => m.ProductReviewId == id);
            if (tblProductReview == null)
            {
                return NotFound();
            }

            return View(tblProductReview);
        }

        // POST: Admin/ProductReviews/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblProductReview = await _context.TblProductReviews.FindAsync(id);
            if (tblProductReview != null)
            {
                _context.TblProductReviews.Remove(tblProductReview);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblProductReviewExists(int id)
        {
            return _context.TblProductReviews.Any(e => e.ProductReviewId == id);
        }
    }
}
