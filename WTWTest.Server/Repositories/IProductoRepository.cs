using WTWTest.Server.Dtos;

namespace WTWTest.Server.Repositories
{
    public interface IProductoRepository
    {
        Task<IEnumerable<ProductoDto>> GetProductos();
        Task<ProductoDto?> GetProductoById(int id);
    }

}
