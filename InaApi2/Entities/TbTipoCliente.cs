using System;
using System.Collections.Generic;

namespace Entities;

public partial class TbTipoCliente
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public bool Estado { get; set; }

    public virtual ICollection<TbCliente> TbClientes { get; set; } = new List<TbCliente>();
}
