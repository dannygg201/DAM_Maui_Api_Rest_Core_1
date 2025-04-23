using System;
using System.Collections.Generic;

namespace WebApi.Models;

public partial class Sede
{
    public int Iidsede { get; set; }

    public string? Vnombre { get; set; }

    public string? Vdireccion { get; set; }

    public int? Bhabilitado { get; set; }

    public virtual ICollection<Citum> Cita { get; set; } = new List<Citum>();
}
