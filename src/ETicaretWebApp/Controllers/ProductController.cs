using ETicaretWebApp.Interfaces;
using ETicaretWebApp.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ETicaretWebApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [Authorize]
        public async Task<IActionResult> IndexAsync(int page = 1, int pageSize = 6)
        {
            if (page < 1 || pageSize < 1)
            {
                return NotFound();
            }
            var products = await _productRepository.GetSliceAsync((page - 1) * pageSize, pageSize);

            var count = await _productRepository.GetCountAsync();

            var productViewModel = new IndexProductViewModel
            {
                Products = products,
                Page = page,
                PageSize = pageSize,
                TotalClubs = count,
                TotalPages = (int)Math.Ceiling(count / (double)pageSize)
            };

            return View(productViewModel);
        }
    }
}
