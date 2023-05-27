using System;
using System.Collections.Generic;

namespace ConsultorioMedico.Models;

public partial class Medico
{
    public int IdMedico { get; set; }

    public string CodMedico { get; set; } = null!;

    public string DuiMedico { get; set; } = null!;

    public string NomMedico { get; set; } = null!;

    public string ApeMedico { get; set; } = null!;

    public string DirMedico { get; set; } = null!;

    public string TelMedico { get; set; } = null!;

    public int? Estado { get; set; }

    public int IdEspecialidad { get; set; }

    public int? IdUsuario { get; set; }

    public virtual Especialidad IdEspecialidadNavigation { get; set; } = null!;

    public virtual Usuario? IdUsuarioNavigation { get; set; }

    public virtual ICollection<ServicioMedico> ServicioMedicos { get; set; } = new List<ServicioMedico>();
}
