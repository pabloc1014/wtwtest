using WTWTest.Server.Repositories;
using WTWTest.Server.ViewModel;

namespace WTWTest.Server.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository clienteRepository;

        public ClienteService(IClienteRepository clienteRepository)
        {
            this.clienteRepository = clienteRepository;
        }

        public async Task<List<ClienteViewModel>> GetAllCliente()
        {
            var clientes = await this.clienteRepository.GetAllCliente();
            return clientes.Select(x => new ClienteViewModel 
            {
                ClienteId = x.Id,
                RazonSocial = x.RazonSocial
            }).ToList();
        }
    }
}
