using System;
using System.Collections.Generic;

namespace ConsultorioMedico.Models;

public partial class Receta
{
    public int IdRecetas { get; set; }

    public string? CodRecetas { get; set; }

    public string? Medicamento { get; set; }

    public int? Cantidad { get; set; }

    public string? Prescripcion { get; set; }

    public int? Estado { get; set; }

    public virtual ICollection<Consultum> Consulta { get; set; } = new List<Consultum>();
}
