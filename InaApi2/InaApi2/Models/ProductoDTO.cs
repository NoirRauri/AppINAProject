using Entities;

namespace InaApi2.Models
{
    public class ProductoDTO
    {
        public string? IdProducto { get; set; }

        public string? Nombre { get; set; }

        public decimal? PrecioVenta { get; set; }

        public int? Stock { get; set; }

        public bool Estado { get; set; }

    }
}
