using System;
using System.Collections.Generic;

namespace WebApi.Models;

public partial class Sexo
{
    public int Iidsexo { get; set; }

    public string? Nombre { get; set; }

    public int? Bhabilitado { get; set; }

    public virtual ICollection<Mascotum> Mascota { get; set; } = new List<Mascotum>();

    public virtual ICollection<Persona> Personas { get; set; } = new List<Persona>();
}
