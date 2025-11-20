using System.Data;
using WTWTest.Server.DB;
using WTWTest.Server.Dtos;
using Dapper;

namespace WTWTest.Server.Repositories
{
    public class ProductoRepository : IProductoRepository
    {
        private readonly IDbConnectionFactory _connectionFactory;

        public ProductoRepository(IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<IEnumerable<ProductoDto>> GetProductos()
        {
            using var db = _connectionFactory.CreateConnection();

            return await db.QueryAsync<ProductoDto>(
                "sp_GetProductos",
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task<ProductoDto?> GetProductoById(int id)
        {
            using var db = _connectionFactory.CreateConnection();

            return await db.QueryFirstOrDefaultAsync<ProductoDto>(
                "sp_GetProductoById",
                new { IdProducto = id },
                commandType: CommandType.StoredProcedure
            );
        }
    }
}
