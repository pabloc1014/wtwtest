using Microsoft.AspNetCore.Mvc;
using WTWTest.Server.Services;

namespace WTWTest.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly IClienteService clienteService;

        public ClientesController(IClienteService clienteService)
        {
            this.clienteService = clienteService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCliente()
        {
            try
            {
                var clientes = await clienteService.GetAllCliente();
                return Ok(clientes);
            }
            catch (Exception)
            {
                return Problem();
            }
        }
    }
}
