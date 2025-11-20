using Microsoft.AspNetCore.Mvc;
using WTWTest.Server.Services;

namespace WTWTest.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        private readonly IProductoService productoService;

        public ProductosController(IProductoService productoService)
        {
            this.productoService = productoService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducto()
        {
            try
            {
                var productos = await productoService.GetAllProducto();
                return Ok(productos);
            }
            catch (Exception)
            {
                return Problem();
            }
        }
    }
}
