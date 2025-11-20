using WTWTest.Server.Dtos;
using WTWTest.Server.ViewModel;

namespace WTWTest.Server.Services
{
    public interface IClienteService
    {
        Task<List<ClienteViewModel>> GetAllCliente();
    }
}
