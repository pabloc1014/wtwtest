using Dapper;
using System.Data;
using WTWTest.Server.DB;
using WTWTest.Server.Dtos;

namespace WTWTest.Server.Repositories
{
    public class FacturaRepository : IFacturaRepository
    {
        private readonly IDbConnectionFactory _connectionFactory;

        public FacturaRepository(IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<int> InsertFactura(FacturaDto factura)
        {
            using var db = _connectionFactory.CreateConnection();

            var parameters = new DynamicParameters();
            parameters.Add("@FechaEmisionFactura", factura.FechaEmisionFactura);
            parameters.Add("@IdCliente", factura.IdCliente);
            parameters.Add("@NumeroFactura", factura.NumeroFactura);
            parameters.Add("@NumeroTotalArticulos", factura.NumeroTotalArticulos);
            parameters.Add("@SubTotalFacturas", factura.SubTotalFacturas);
            parameters.Add("@TotalImpuestos", factura.TotalImpuestos);
            parameters.Add("@TotalFactura", factura.TotalFactura);
            parameters.Add("@IdFactura", dbType: DbType.Int32, direction: ParameterDirection.Output);

            await db.ExecuteAsync("sp_InsertFactura", parameters, commandType: CommandType.StoredProcedure);

            return parameters.Get<int>("@IdFactura");
        }

        public async Task InsertDetalle(DetalleFacturaDto detalle)
        {
            using var db = _connectionFactory.CreateConnection();

            var parameters = new DynamicParameters();
            parameters.Add("@IdFactura", detalle.IdFactura);
            parameters.Add("@IdProducto", detalle.IdProducto);
            parameters.Add("@CantidadDeProducto", detalle.CantidadDeProducto);
            parameters.Add("@PrecioUnitarioProducto", detalle.PrecioUnitarioProducto);
            parameters.Add("@SubtotalProducto", detalle.SubtotalProducto);
            parameters.Add("@Notas", detalle.Notas);

            await db.ExecuteAsync("sp_InsertDetalleFactura", parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<FacturaResumenDto>> BuscarPorCliente(int idCliente)
        {
            using var db = _connectionFactory.CreateConnection();

            return await db.QueryAsync<FacturaResumenDto>(
                "sp_SearchFacturasByCliente",
                new { IdCliente = idCliente },
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task<IEnumerable<FacturaResumenDto>> BuscarPorNumero(int numero)
        {
            using var db = _connectionFactory.CreateConnection();

            return await db.QueryAsync<FacturaResumenDto>(
                "sp_SearchFacturasByNumero",
                new { NumeroFactura = numero },
                commandType: CommandType.StoredProcedure
            );
        }
    }

}
