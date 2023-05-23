using System;
using System.Collections.Generic;

namespace Entities;

public partial class TbDetalleFactura
{
    public int IdDetalleFactura { get; set; }

    public int IdFactura { get; set; }

    public string IdProducto { get; set; } = null!;

    public int Cant { get; set; }

    public decimal Precio { get; set; }

    public bool? Estado { get; set; }

    public virtual TbFactura IdFacturaNavigation { get; set; } = null!;

    public virtual TbProducto IdProductoNavigation { get; set; } = null!;
}
