using WTWTest.Server.Repositories;
using WTWTest.Server.ViewModel;

namespace WTWTest.Server.Services
{
    public class ProductoService : IProductoService
    {
        private readonly IProductoRepository productoRepository;

        public ProductoService(IProductoRepository productoRepository)
        {
            this.productoRepository = productoRepository;
        }

        public async Task<List<ProductoViewModel>> GetAllProducto()
        {
            var productos = await this.productoRepository.GetProductos();
            return productos.Select(x => new ProductoViewModel 
            {
                Id = x.Id,
                ImagenProducto = x.ImagenProducto,
                NombreProducto = x.NombreProducto,
                PrecioUnitario = x.PrecioUnitario
            }).ToList();
        }
    }
}
