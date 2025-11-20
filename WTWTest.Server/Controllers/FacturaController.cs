using Microsoft.AspNetCore.Mvc;
using WTWTest.Server.Models;
using WTWTest.Server.Services;

namespace WTWTest.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacturaController : ControllerBase
    {
        private readonly IFacturaService _service;

        public FacturaController(IFacturaService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> CrearFactura(FacturaCreateModel model)
        {
            var id = await _service.CrearFactura(model);
            return Ok(new { IdFactura = id });
        }
    }
}
