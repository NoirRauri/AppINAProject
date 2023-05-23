using Entities;

namespace InaApi2.Models
{
    public class FacturaDTO
    {
        public int IdFactura { get; set; }

        public DateTime Fecha { get; set; }

        public string? IdCliente { get; set; }

        public string? TipoVenta { get; set; }

        public string? TipoPago { get; set; }

        public bool Estado { get; set; }

        public List<DetalleFacturaDTO> TbDetalleFacturas { get; set; }

    }
}
