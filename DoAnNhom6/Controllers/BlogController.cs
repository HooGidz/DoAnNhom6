﻿using DoAnNhom6.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DoAnNhom6.Controllers
{
    public class BlogController : Controller
    {

        private readonly DoAnNhom6Context _context;

        public BlogController(DoAnNhom6Context context)
        {
            _context = context;
        }
        [Route("/blog/{alias}-{id}.html")]

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TblBlogs == null)
            {
                return NotFound();
            }

            var blog = await _context.TblBlogs
                .Include(m => m.Category)
                .Include(m => m.User)
                .FirstOrDefaultAsync(m => m.BlogId == id);
            if (blog == null)
            {
                return NotFound();
            }
            ViewBag.blogComment = _context.TblBlogComments.Where(i => i.BlogId == id).ToList();

            // lọc blog cùng loại
            var categoryBlog = await _context.TblProductCategories
                .Where(m => m.IsActive)
                .ToListAsync();
            //.FirstOrDefaultAsync(m => m.CategoryId == id);

            ViewBag.categoryBlog = categoryBlog;

            //lọc bài viết liên quan
            var relatedBlog = await _context.TblBlogs
                .Where(m => m.IsActive && m.CategoryId == blog.CategoryId && m.BlogId != blog.BlogId)
                .OrderBy(m  => m.BlogId)
                .ToListAsync();
            ViewBag.relatedBlog = relatedBlog;

            // lọc bài viết gần đây
            var recentBlog = await _context.TblBlogs
                .Where(m => m.IsActive && m.BlogId != blog.BlogId)
                .Take(5)
                .OrderByDescending(m => m.CreatedDate)
                .ToListAsync();
            ViewBag.recentBlog = recentBlog;

            // bài viết phổ biến
            var popularBlog = await _context.TblBlogs
                .Where(m => m.IsActive && m.BlogId != blog.BlogId)
                .Take(5)
                .OrderBy(m => m.BlogId)
                .ToListAsync();
            ViewBag.popularBlog = popularBlog;



            return View(blog);
        }
        public async Task<IActionResult> Index()
        {
            var blog = await _context.TblBlogs
                .Include(b => b.Category) // Nối bảng Category
                .Where(b => b.IsActive) // Lọc các bài viết hoạt động
                .ToListAsync();

            return View(blog);
        }

    }
}
