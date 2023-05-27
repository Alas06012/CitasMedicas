using System;
using System.Collections.Generic;

namespace ConsultorioMedico.Models;

public partial class ServicioMedico
{
    public int IdServicio { get; set; }

    public string CodServicio { get; set; } = null!;

    public DateTime Fecha { get; set; }

    public int? Estado { get; set; }

    public int IdMedico { get; set; }

    public virtual ICollection<Citum> Cita { get; set; } = new List<Citum>();

    public virtual Medico IdMedicoNavigation { get; set; } = null!;
}
