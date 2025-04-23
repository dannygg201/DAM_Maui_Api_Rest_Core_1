using System;
using System.Collections.Generic;

namespace WebApi.Models;

public partial class HistorialCitum
{
    public int Iidhistorialcita { get; set; }

    public int? Iidcita { get; set; }

    public int? Iidestado { get; set; }

    public int? Iidusuario { get; set; }

    public DateTime? Dfecha { get; set; }

    public string? Vobservacion { get; set; }
}
