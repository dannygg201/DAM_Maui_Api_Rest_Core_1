using System;
using System.Collections.Generic;

namespace WebApi.Models;

public partial class EstadoCitum
{
    public int Iidestado { get; set; }

    public string? Vnombre { get; set; }

    public string? Vdescripcion { get; set; }

    public int? Bhabilitado { get; set; }

    public virtual ICollection<Citum> Cita { get; set; } = new List<Citum>();
}
