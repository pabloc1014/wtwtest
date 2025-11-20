using WTWTest.Server.Dtos;

namespace WTWTest.Server.Repositories
{
    public interface IClienteRepository
    {
        Task<IEnumerable<ClienteDto>> GetAllCliente();
    }
}
