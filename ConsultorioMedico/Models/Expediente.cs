using System;
using System.Collections.Generic;

namespace ConsultorioMedico.Models;

public partial class Expediente
{
    public int IdExpediente { get; set; }

    public string CodExpediente { get; set; } = null!;

    public string Responsable { get; set; } = null!;

    public int? Estado { get; set; }

    public virtual ICollection<Paciente> Pacientes { get; set; } = new List<Paciente>();
}
