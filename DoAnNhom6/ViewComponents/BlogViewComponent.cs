using Microsoft.AspNetCore.Mvc;
using DoAnNhom6.Models;
using Microsoft.EntityFrameworkCore;

namespace DoAnNhom6.ViewComponents
{
    public class BlogViewComponent : ViewComponent
    {
        private readonly DoAnNhom6Context _context;
        public BlogViewComponent(DoAnNhom6Context context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var items = await _context.TblBlogs
                .Include(m => m.Category)
                .Where(m => m.IsActive)
                .OrderBy(m => m.BlogId)
                .Take(2)
                .ToListAsync();

            return View(items);
        }
    }
}
