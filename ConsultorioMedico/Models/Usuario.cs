using System;
using System.Collections.Generic;

namespace ConsultorioMedico.Models;

public partial class Usuario
{
    public int IdUsuario { get; set; }

    public string NomUser { get; set; } = null!;

    public string PassUser { get; set; } = null!;

    public string RespUser { get; set; } = null!;

    public int? Estado { get; set; }

    public int? IdPregunta { get; set; }

    public int? IdRol { get; set; }

    public virtual Pregunta? IdPreguntaNavigation { get; set; }

    public virtual Rol? IdRolNavigation { get; set; }

    public virtual ICollection<Medico> Medicos { get; set; } = new List<Medico>();

    public virtual ICollection<Secretarium> Secretaria { get; set; } = new List<Secretarium>();
}
