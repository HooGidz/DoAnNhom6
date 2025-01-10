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
    public class BlogsController : Controller
    {
        private readonly DoAnNhom6Context _context;

        public BlogsController(DoAnNhom6Context context)
        {
            _context = context;
        }

        // GET: Admin/Blogs
        public async Task<IActionResult> Index()
        {
            var doAnNhom6Context = _context.TblBlogs.Include(t => t.Category).Include(t => t.User);
            return View(await doAnNhom6Context.ToListAsync());
        }

        // GET: Admin/Blogs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblBlog = await _context.TblBlogs
                .Include(t => t.Category)
                .Include(t => t.User)
                .FirstOrDefaultAsync(m => m.BlogId == id);
            if (tblBlog == null)
            {
                return NotFound();
            }

            return View(tblBlog);
        }

        // GET: Admin/Blogs/Create
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_context.TblProductCategories, "CategoryId", "CategoryId");
            ViewData["UserId"] = new SelectList(_context.TblUsers, "UserId", "UserId");
            return View();
        }

        // POST: Admin/Blogs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BlogId,UserId,Title,Alias,CategoryId,Description,Detail,Image,SeoTitle,SeoDescription,SeoKeywords,CreatedDate,CreatedBy,ModifiedDate,ModifiedBy,IsActive")] TblBlog tblBlog)
        {
            if (ModelState.IsValid)
            {
                tblBlog.Alias = DoAnNhom6.Utilities.Function.TitleSlugGenerationAlias(tblBlog.Alias);
                _context.Add(tblBlog);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_context.TblProductCategories, "CategoryId", "CategoryId", tblBlog.CategoryId);
            ViewData["UserId"] = new SelectList(_context.TblUsers, "UserId", "UserId", tblBlog.UserId);
            return View(tblBlog);
        }

        // GET: Admin/Blogs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblBlog = await _context.TblBlogs.FindAsync(id);
            if (tblBlog == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(_context.TblProductCategories, "CategoryId", "CategoryId", tblBlog.CategoryId);
            ViewData["UserId"] = new SelectList(_context.TblUsers, "UserId", "UserId", tblBlog.UserId);
            return View(tblBlog);
        }

        // POST: Admin/Blogs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BlogId,UserId,Title,Alias,CategoryId,Description,Detail,Image,SeoTitle,SeoDescription,SeoKeywords,CreatedDate,CreatedBy,ModifiedDate,ModifiedBy,IsActive")] TblBlog tblBlog)
        {
            if (id != tblBlog.BlogId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblBlog);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblBlogExists(tblBlog.BlogId))
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
            ViewData["CategoryId"] = new SelectList(_context.TblProductCategories, "CategoryId", "CategoryId", tblBlog.CategoryId);
            ViewData["UserId"] = new SelectList(_context.TblUsers, "UserId", "UserId", tblBlog.UserId);
            return View(tblBlog);
        }

        // GET: Admin/Blogs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblBlog = await _context.TblBlogs
                .Include(t => t.Category)
                .Include(t => t.User)
                .FirstOrDefaultAsync(m => m.BlogId == id);
            if (tblBlog == null)
            {
                return NotFound();
            }

            return View(tblBlog);
        }

        // POST: Admin/Blogs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblBlog = await _context.TblBlogs.FindAsync(id);
            if (tblBlog != null)
            {
                _context.TblBlogs.Remove(tblBlog);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblBlogExists(int id)
        {
            return _context.TblBlogs.Any(e => e.BlogId == id);
        }
    }
}
