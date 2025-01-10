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
    public class BlogCommentsController : Controller
    {
        private readonly DoAnNhom6Context _context;

        public BlogCommentsController(DoAnNhom6Context context)
        {
            _context = context;
        }

        // GET: Admin/BlogComments
        public async Task<IActionResult> Index()
        {
            var doAnNhom6Context = _context.TblBlogComments.Include(t => t.Blog);
            return View(await doAnNhom6Context.ToListAsync());
        }

        // GET: Admin/BlogComments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblBlogComment = await _context.TblBlogComments
                .Include(t => t.Blog)
                .FirstOrDefaultAsync(m => m.CommentId == id);
            if (tblBlogComment == null)
            {
                return NotFound();
            }

            return View(tblBlogComment);
        }

        // GET: Admin/BlogComments/Create
        public IActionResult Create()
        {
            ViewData["BlogId"] = new SelectList(_context.TblBlogs, "BlogId", "BlogId");
            return View();
        }

        // POST: Admin/BlogComments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CommentId,Name,Phone,Email,CreatedDate,Detail,BlogId,IsActive")] TblBlogComment tblBlogComment)
        {
            if (ModelState.IsValid)
            {
                tblBlogComment.Name = DoAnNhom6.Utilities.Function.TitleSlugGenerationAlias(tblBlogComment.Name);
                _context.Add(tblBlogComment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BlogId"] = new SelectList(_context.TblBlogs, "BlogId", "BlogId", tblBlogComment.BlogId);
            return View(tblBlogComment);
        }

        // GET: Admin/BlogComments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblBlogComment = await _context.TblBlogComments.FindAsync(id);
            if (tblBlogComment == null)
            {
                return NotFound();
            }
            ViewData["BlogId"] = new SelectList(_context.TblBlogs, "BlogId", "BlogId", tblBlogComment.BlogId);
            return View(tblBlogComment);
        }

        // POST: Admin/BlogComments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CommentId,Name,Phone,Email,CreatedDate,Detail,BlogId,IsActive")] TblBlogComment tblBlogComment)
        {
            if (id != tblBlogComment.CommentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblBlogComment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblBlogCommentExists(tblBlogComment.CommentId))
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
            ViewData["BlogId"] = new SelectList(_context.TblBlogs, "BlogId", "BlogId", tblBlogComment.BlogId);
            return View(tblBlogComment);
        }

        // GET: Admin/BlogComments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblBlogComment = await _context.TblBlogComments
                .Include(t => t.Blog)
                .FirstOrDefaultAsync(m => m.CommentId == id);
            if (tblBlogComment == null)
            {
                return NotFound();
            }

            return View(tblBlogComment);
        }

        // POST: Admin/BlogComments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblBlogComment = await _context.TblBlogComments.FindAsync(id);
            if (tblBlogComment != null)
            {
                _context.TblBlogComments.Remove(tblBlogComment);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblBlogCommentExists(int id)
        {
            return _context.TblBlogComments.Any(e => e.CommentId == id);
        }
    }
}
