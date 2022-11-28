using OnlineShop.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Repo.Interfaces;

namespace Net6_Angular.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ProductController : ControllerBase
    {

        private readonly IProductRepository _productRepositoryService;


        public ProductController(
          IProductRepository productRepository)
        {
            _productRepositoryService = productRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var contact = await _productRepositoryService.GetAllProducts().ConfigureAwait(false);
            return Ok();
        }
    }
}
