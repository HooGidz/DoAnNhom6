using DoAnNhom6.Models;
using Microsoft.AspNetCore.Mvc;




namespace DoAnNhom6.ViewComponents
{
    public class MenuTopViewComponent : ViewComponent
    {
        private readonly DoAnNhom6Context _context;

        public MenuTopViewComponent(DoAnNhom6Context context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var items = _context.TblMenus
                .Where(m => (bool)m.IsActive)
                .OrderBy(m => m.Position).ToList();

            return await Task.FromResult<IViewComponentResult>(View(items));
        }

    }
}