using WTWTest.Server.ViewModel;

namespace WTWTest.Server.Services
{
    public interface IProductoService
    {
        Task<List<ProductoViewModel>> GetAllProducto();
    }
}
