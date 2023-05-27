using System;
using System.Collections.Generic;

namespace ConsultorioMedico.Models;

public partial class Secretarium
{
    public int IdSecretaria { get; set; }

    public string CodSecre { get; set; } = null!;

    public string DuiSecre { get; set; } = null!;

    public string NomSecre { get; set; } = null!;

    public string ApeSecre { get; set; } = null!;

    public string DirSecre { get; set; } = null!;

    public string TelSecre { get; set; } = null!;

    public int? Estado { get; set; }

    public int? IdUsuario { get; set; }

    public virtual Usuario? IdUsuarioNavigation { get; set; }
}
