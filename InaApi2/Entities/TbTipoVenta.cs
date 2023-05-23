using System;
using System.Collections.Generic;

namespace Entities;

public partial class TbTipoVenta
{
    public string Id { get; set; } = null!;

    public string Nombre { get; set; } = null!;

    public bool Estado { get; set; }

    public virtual ICollection<TbFactura> TbFacturas { get; set; } = new List<TbFactura>();
}
