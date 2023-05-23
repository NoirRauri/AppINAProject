using System;
using System.Collections.Generic;

namespace Entities;

public partial class TbRegistroJuego
{
    public string Cedula { get; set; } = null!;

    public TimeSpan? Tiempo { get; set; }

    public int Id { get; set; }

    public virtual TbJugador CedulaNavigation { get; set; } = null!;
}
