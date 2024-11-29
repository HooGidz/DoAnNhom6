using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using DoAnNhom6.Models;

namespace DoAnNhom6.ViewComponents
{
    public class ProductViewComponent: ViewComponent
    {
        private readonly DoAnNhom6Context _context;
        public ProductViewComponent(DoAnNhom6Context context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync() 
        {
            var items = await _context.TblProducts
                .Include(m => m.Category)
                .Where(m => (bool)m.IsActive)
                .ToListAsync();
            return View(items);
        }
    }
}
