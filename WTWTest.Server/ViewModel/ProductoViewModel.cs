namespace WTWTest.Server.ViewModel
{
    public class ProductoViewModel
    {
        public int Id { get; set; }
        public string NombreProducto { get; set; } = null!;
        public decimal PrecioUnitario { get; set; }
        public byte[]? ImagenProducto { get; set; }
    }
}
