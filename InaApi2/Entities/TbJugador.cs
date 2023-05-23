using System;
using System.Collections.Generic;

namespace Entities;

public partial class TbJugador
{
    public string Cedula { get; set; } = null!;

    public string? Nombre { get; set; }

    public virtual ICollection<TbRegistroJuego> TbRegistroJuegos { get; set; } = new List<TbRegistroJuego>();
}
