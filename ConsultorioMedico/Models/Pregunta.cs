using System;
using System.Collections.Generic;

namespace ConsultorioMedico.Models;

public partial class Pregunta
{
    public int IdPreguntas { get; set; }

    public string Pregunta1 { get; set; } = null!;

    public int? Estado { get; set; }

    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
