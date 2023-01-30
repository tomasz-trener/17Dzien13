using Microsoft.AspNetCore.Mvc;
using P05Sklep.Shared;

namespace P04Sklep.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        [HttpGet]
        public async Task<ActionResult<ServiceReponse<Product[]>>> GetProducts()
        {
            throw new NotImplementedException();
        }
    }
}
