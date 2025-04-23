using System;
using System.Collections.Generic;

namespace WebApi.Models;

public partial class Medicamento
{
    public string? Nombre { get; set; }

    public string? Concentracion { get; set; }

    public decimal? Precio { get; set; }

    public int? Stock { get; set; }

    public int? Bhabilitado { get; set; }

    public int Iidmedicamento { get; set; }

    public virtual ICollection<CitaMedicamento> CitaMedicamentos { get; set; } = new List<CitaMedicamento>();
}
