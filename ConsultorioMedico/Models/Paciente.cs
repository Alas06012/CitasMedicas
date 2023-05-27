using System;
using System.Collections.Generic;

namespace ConsultorioMedico.Models;

public partial class Paciente
{
    public int IdPaciente { get; set; }

    public string CodPaciente { get; set; } = null!;

    public string NomPaciente { get; set; } = null!;

    public string ApePaciente { get; set; } = null!;

    public DateTime FechaNac { get; set; }

    public int EdadAnio { get; set; }

    public int EdadMes { get; set; }

    public int EdadDia { get; set; }

    public string Genero { get; set; } = null!;

    public string? Dui { get; set; }

    public string Ocupacion { get; set; } = null!;

    public string DirPaciente { get; set; } = null!;

    public string Telefono { get; set; } = null!;

    public string NomPadre { get; set; } = null!;

    public string NomMadre { get; set; } = null!;

    public string Responsable { get; set; } = null!;

    public string DirRespon { get; set; } = null!;

    public string TelRespon { get; set; } = null!;

    public string DuiRespon { get; set; } = null!;

    public string Observaciones { get; set; } = null!;

    public int? Estado { get; set; }

    public int? IdExpediente { get; set; }

    public virtual ICollection<Citum> Cita { get; set; } = new List<Citum>();

    public virtual ICollection<Consultum> Consulta { get; set; } = new List<Consultum>();

    public virtual Expediente? IdExpedienteNavigation { get; set; }
}
