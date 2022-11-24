using OnlineShop.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Net6_Angular.Data;
using Net6_Angular.Models;

namespace Net6_Angular.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class ProductController : ControllerBase
    {

        private readonly IContactService _contactService;


        public ProductController(
          IHttpContextAccessor httpContextAccessor,
          IContactService contactService)
        {
            _contactService = contactService;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetContacts()
        {
            var contact = await _contactService.GetContact().ConfigureAwait(false);
            return Ok();
        }
    }
}
