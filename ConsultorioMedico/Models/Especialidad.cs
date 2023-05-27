using System;
using System.Collections.Generic;

namespace ConsultorioMedico.Models;

public partial class Especialidad
{
    public int IdEspecialidad { get; set; }

    public string CodEspecialidad { get; set; } = null!;

    public string Especialidad1 { get; set; } = null!;

    public int? Estado { get; set; }

    public virtual ICollection<Medico> Medicos { get; set; } = new List<Medico>();
}
