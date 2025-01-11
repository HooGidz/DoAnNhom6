using DoAnNhom6.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

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
        [Route("/product/{alias}-{id}")]
        public async Task<IActionResult> Details(int? id)
        {
            //if (id == null || _context.TblProducts == null)
            //{
            //    return NotFound();
            //}
            var product = await _context.TblProductReviews
                .Include(i => i.Product)
                .ThenInclude(i => i.Category)
                .FirstOrDefaultAsync(m => m.ProductId == id);

            if (product == null)
            {
                return NotFound();
            }



            ViewBag.productReView = _context.TblProductReviews
                .Where(i => i.ProductId == id)
                .ToList();

            ViewBag.productRelated = _context.TblProducts
                .Where(i => i.ProductId != id && i.CategoryId == product.Product.Category.CategoryId)
                .Take(5)
                .OrderByDescending(i => i.ProductId)
                .ToList();
            return View(product);
        }

        [HttpPost("/product/{alias}-{id}")]
        public async Task<IActionResult> Add([Bind("Name,Phone,Email,Detail,Star")] TblProductReview review, int id, string alias)
        {
            if (ModelState.IsValid)
            {
                review.IsActive = true;
                review.CreatedDate = DateTime.Now;
                review.ProductId = id;  // Lưu ID sản phẩm vào review

                _context.Add(review);
                await _context.SaveChangesAsync();

                TempData["StatusMessage"] = "Gửi liên hệ thành công!";

                return Redirect($"/product/{alias}-{id}");
            }

            TempData["StatusMessage"] = "Đã có lỗi xảy ra. Vui lòng kiểm tra lại thông tin.";

            // Nếu có lỗi, trả về cùng đường dẫn
            return Redirect($"/product/{alias}-{id}");
        }


    }
}
