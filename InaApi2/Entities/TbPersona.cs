using System;
using System.Collections.Generic;

namespace Entities;

public partial class TbPersona
{
    public string Cedula { get; set; } = null!;

    public string Nombre { get; set; } = null!;

    public string Apellido1 { get; set; } = null!;

    public string Apellido2 { get; set; } = null!;

    public int Genero { get; set; }

    public DateTime FechaNac { get; set; }

    public virtual TbCliente? TbCliente { get; set; }
}
