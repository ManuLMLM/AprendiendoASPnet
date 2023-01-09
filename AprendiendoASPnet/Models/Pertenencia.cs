using System;
using System.Collections.Generic;

namespace AprendiendoASPnet.Models;

public partial class Pertenencia
{
    public int IdPertenencia { get; set; }

    public int? IdUsuario { get; set; }

    public string? Nombre { get; set; }

    public double? Precio { get; set; }

    public int? Cantidad { get; set; }

    public virtual Usuario? IdUsuarioNavigation { get; set; }
}
