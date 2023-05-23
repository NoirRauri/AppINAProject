using Entities;

namespace InaApi2.Models
{
    public class DetalleFacturaDTO
    {
        public int IdDetalleFactura { get; set; }

        public int IdFactura { get; set; }

        public string? IdProducto { get; set; }

        public int Cant { get; set; }

        public decimal Precio { get; set; }

        public bool? Estado { get; set; }
    }
}
