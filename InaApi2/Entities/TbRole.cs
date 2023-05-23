using System;
using System.Collections.Generic;

namespace Entities;

public partial class TbRole
{
    public int IdRol { get; set; }

    public string Nombre { get; set; } = null!;

    public bool Estado { get; set; }

    public virtual ICollection<TbUsuario> TbUsuarios { get; set; } = new List<TbUsuario>();
}
