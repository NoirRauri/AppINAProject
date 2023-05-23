using System;
using System.Collections.Generic;

namespace Entities;

public partial class TbUsuario
{
    public string Cedula { get; set; } = null!;

    public int Rol { get; set; }

    public DateTime FechaIngreso { get; set; }

    public string NombreUsuario { get; set; } = null!;

    public string Contraseña { get; set; } = null!;

    public bool? Estado { get; set; }

    public virtual TbPersona CedulaNavigation { get; set; } = null!;

    public virtual TbRole RolNavigation { get; set; } = null!;
}
