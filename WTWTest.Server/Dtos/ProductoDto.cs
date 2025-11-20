namespace WTWTest.Server.Dtos
{
    public class ProductoDto
    {
        public int Id { get; set; }
        public string NombreProducto { get; set; } = null!;
        public decimal PrecioUnitario { get; set; }
        public byte[]? ImagenProducto { get; set; }
        public string? Ext { get; set; }
    }
}
