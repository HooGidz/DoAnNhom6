using DoAnNhom6.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DoAnNhom6.Controllers
{
    public class ProductController : Controller
    {

        private readonly DoAnNhom6Context _context;

        public ProductController(DoAnNhom6Context context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        [Route("/product/{alias}-{id}.html")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TblProducts == null)
            {
                return NotFound();
            }
            var product = await _context.TblProducts.Include(i => i.Category)
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }
            ViewBag.productReView = _context.TblProductReviews
                .Where(i => i.ProductId == id).ToList();
            ViewBag.productRelated = _context.TblProducts.
                Where(i => i.ProductId != id && i.CategoryId == product.CategoryId).Take(5).
                OrderByDescending(i => i.ProductId).ToList();
            return View(product);
        }
    }
}
