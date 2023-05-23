using System;
using System.Collections.Generic;

namespace Entities;

public partial class TbProducto
{
    public string IdProducto { get; set; } = null!;

    public string Nombre { get; set; } = null!;

    public decimal? PrecioVenta { get; set; }

    public int? Stock { get; set; }

    public bool Estado { get; set; }

    public virtual ICollection<TbDetalleFactura> TbDetalleFacturas { get; set; } = new List<TbDetalleFactura>();
}
