using System;
using System.Collections.Generic;

namespace ConsultorioMedico.Models;

public partial class Citum
{
    public int IdCita { get; set; }

    public DateTime Fecha { get; set; }

    public TimeSpan Hora { get; set; }

    public int? Estado { get; set; }

    public int? IdPaciente { get; set; }

    public int? IdServicio { get; set; }

    public virtual Paciente? IdPacienteNavigation { get; set; }

    public virtual ServicioMedico? IdServicioNavigation { get; set; }
}
