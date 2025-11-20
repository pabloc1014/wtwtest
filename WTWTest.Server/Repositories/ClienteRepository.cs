using Dapper;
using System.Data;
using WTWTest.Server.DB;
using WTWTest.Server.Dtos;

namespace WTWTest.Server.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly IDbConnectionFactory _connectionFactory;

        public ClienteRepository(IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<IEnumerable<ClienteDto>> GetAllCliente()
        {
            using var db = _connectionFactory.CreateConnection();

            return await db.QueryAsync<ClienteDto>(
                "sp_GetAllClientes",
                commandType: CommandType.StoredProcedure
            );
        }
    }
}
