using WTWTest.Server.Dtos;
using WTWTest.Server.Models;
using WTWTest.Server.Repositories;

namespace WTWTest.Server.Services
{
    public class FacturaService : IFacturaService
    {
        private readonly IFacturaRepository _repo;

        public FacturaService(IFacturaRepository repo)
        {
            _repo = repo;
        }

        public async Task<int> CrearFactura(FacturaCreateModel factura)
        {
            var facturaDto = new FacturaDto 
            {
                FechaEmisionFactura = DateTime.Now,
                IdCliente = factura.IdCliente,
                NumeroFactura = factura.NumeroFactura,
                NumeroTotalArticulos = factura.Detalles.Sum(x => x.CantidadDeProducto),
                SubTotalFacturas = factura.Detalles.Sum(x => x.SubtotalProducto)
            };
            
            var idFactura = await _repo.InsertFactura(facturaDto);

            var detallesDto = factura.Detalles.Select(x => new DetalleFacturaDto 
            {
                IdFactura = idFactura,
                IdProducto = x.IdProducto,
                CantidadDeProducto = x.CantidadDeProducto,
                PrecioUnitarioProducto = x.PrecioUnitarioProducto,
                SubtotalProducto = x.SubtotalProducto,
                Notas = x.Notas
            }).ToList();

            foreach (var det in detallesDto)
            {
                try
                {
                    await _repo.InsertDetalle(det);
                }
                catch (Exception ex)
                {

                    throw ex;
                }    
                
            }

            return idFactura;
        }
    }

}
