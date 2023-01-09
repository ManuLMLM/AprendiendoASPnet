using System;
using System.Collections.Generic;

namespace AprendiendoASPnet.Models;

public partial class Usuario
{
    public int IdUsuario { get; set; }

    public string? Email { get; set; }

    public string? Password { get; set; }

    public virtual ICollection<Pertenencia> Pertenencia { get; } = new List<Pertenencia>();
}
