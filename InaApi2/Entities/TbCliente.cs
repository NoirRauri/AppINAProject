using System;
using System.Collections.Generic;

namespace Entities;

public partial class TbCliente
{
    public string Cedula { get; set; } = null!;

    public int TipoCliente { get; set; }

    public int DescMax { get; set; }

    public byte[]? Foto { get; set; }

    public bool Estado { get; set; }

    public virtual TbPersona CedulaNavigation { get; set; } = null!;

    public virtual ICollection<TbFactura> TbFacturas { get; set; } = new List<TbFactura>();

    public virtual TbTipoCliente TipoClienteNavigation { get; set; } = null!;
}
