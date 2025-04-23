using System;
using System.Collections.Generic;

namespace WebApi.Models;

public partial class TipoMascotum
{
    public int Iidtipomascota { get; set; }

    public string? Nombre { get; set; }

    public string? Descripcion { get; set; }

    public int? Bhabilitado { get; set; }

    public virtual ICollection<Citum> Cita { get; set; } = new List<Citum>();

    public virtual ICollection<Mascotum> Mascota { get; set; } = new List<Mascotum>();
}
