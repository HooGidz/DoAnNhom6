using Microsoft.AspNetCore.Mvc;
using DoAnNhom6.Models;
using Microsoft.EntityFrameworkCore;

namespace DoAnNhom6.ViewComponents
{
    public class ProductViewcomponent : ViewComponent
    {
        private readonly DoAnNhom6Context _context;
        public ProductViewcomponent(DoAnNhom6Context context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync(int categoryid)
        {
            var item = await _context.TblProducts
                .Include(m => m.Category)
                .Where(m => m.CategoryId  == categoryid)
                //.Where(m => m.IsActive)
                //.Where (m => m.IsNew)
                .ToListAsync();

            return View(item);

        }
    }
}
