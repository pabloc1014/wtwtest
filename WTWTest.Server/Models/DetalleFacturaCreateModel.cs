using System.ComponentModel.DataAnnotations;

namespace WTWTest.Server.Models
{
    public class DetalleFacturaCreateModel
    {
        [Required]
        public int IdProducto { get; set; }

        [Range(1, int.MaxValue)]
        public int CantidadDeProducto { get; set; }
        public decimal PrecioUnitarioProducto { get; set; }
        public decimal SubtotalProducto { get; set; }
        public string? Notas { get; set; }
    }
}
