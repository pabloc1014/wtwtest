using WTWTest.Server.Dtos;
using WTWTest.Server.Models;

namespace WTWTest.Server.Services
{
    public interface IFacturaService
    {
        Task<int> CrearFactura(FacturaCreateModel factura);
    }
}
