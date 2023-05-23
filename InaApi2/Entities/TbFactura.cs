using System;
using System.Collections.Generic;

namespace Entities;

public partial class TbFactura
{
    public int IdFactura { get; set; }

    public DateTime Fecha { get; set; }

    public string IdCliente { get; set; } = null!;

    public string TipoVenta { get; set; } = null!;

    public string TipoPago { get; set; } = null!;

    public bool Estado { get; set; }

    public virtual TbCliente IdClienteNavigation { get; set; } = null!;

    public virtual ICollection<TbDetalleFactura> TbDetalleFacturas { get; set; } = new List<TbDetalleFactura>();

    public virtual TbTipoPago TipoPagoNavigation { get; set; } = null!;

    public virtual TbTipoVenta TipoVentaNavigation { get; set; } = null!;
}
