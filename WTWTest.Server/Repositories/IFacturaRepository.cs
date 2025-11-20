using WTWTest.Server.Dtos;

namespace WTWTest.Server.Repositories
{
    public interface IFacturaRepository
    {
        Task<int> InsertFactura(FacturaDto factura);
        Task InsertDetalle(DetalleFacturaDto detalle);
        Task<IEnumerable<FacturaResumenDto>> BuscarPorCliente(int idCliente);
        Task<IEnumerable<FacturaResumenDto>> BuscarPorNumero(int numero);
    }
}
