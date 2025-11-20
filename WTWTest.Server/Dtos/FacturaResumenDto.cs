namespace WTWTest.Server.Dtos
{
    public class FacturaResumenDto
    {
        public int Id { get; set; }
        public int NumeroFactura { get; set; }
        public DateTime FechaEmisionFactura { get; set; }
        public decimal SubTotalFacturas { get; set; }
        public decimal TotalImpuestos { get; set; }
        public decimal TotalFactura { get; set; }
        public string Cliente { get; set; } = null!;
    }
}
