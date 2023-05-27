using System;
using System.Collections.Generic;

namespace ConsultorioMedico.Models;

public partial class Consultum
{
    public int IdConsulta { get; set; }

    public DateTime Fecha { get; set; }

    public TimeSpan Hora { get; set; }

    public string? Diagnostico { get; set; }

    public string Tratamiento { get; set; } = null!;

    public string NombreDoctor { get; set; } = null!;

    public int? Estado { get; set; }

    public int? IdPac { get; set; }

    public int? IdRecetas { get; set; }

    public virtual Paciente? IdPacNavigation { get; set; }

    public virtual Receta? IdRecetasNavigation { get; set; }
}
