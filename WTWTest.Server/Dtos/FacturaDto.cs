namespace WTWTest.Server.Dtos
{
    public class FacturaDto
    {
        public int Id { get; set; }
        public DateTime FechaEmisionFactura { get; set; }
        public int IdCliente { get; set; }
        public string Cliente { get; set; } = null!;
        public int NumeroFactura { get; set; }
        public int NumeroTotalArticulos { get; set; }
        public decimal SubTotalFacturas { get; set; }
        public decimal TotalImpuestos { get; set; }
        public decimal TotalFactura { get; set; }

        public List<DetalleFacturaDto> Detalles { get; set; } = new();
    }
}
