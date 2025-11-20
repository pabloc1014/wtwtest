using System.ComponentModel.DataAnnotations;

namespace WTWTest.Server.Models
{
    public class FacturaCreateModel
    {
        [Required]
        public DateTime FechaEmisionFactura { get; set; }

        [Required]
        public int IdCliente { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int NumeroFactura { get; set; }

        public IEnumerable<DetalleFacturaCreateModel> Detalles { get; set; } = new List<DetalleFacturaCreateModel>();
    }
}
