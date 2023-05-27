using System;
using System.Collections.Generic;

namespace ConsultorioMedico.Models;

public partial class Rol
{
    public int IdRol { get; set; }

    public string Tipo { get; set; } = null!;

    public int? Estado { get; set; }

    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
