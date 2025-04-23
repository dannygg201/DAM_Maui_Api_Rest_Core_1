using System;
using System.Collections.Generic;

namespace WebApi.Models;

public partial class TipoUsuario
{
    public int Iidtipousuario { get; set; }

    public string? Nombre { get; set; }

    public string? Descripcion { get; set; }

    public int? Bhabilitado { get; set; }

    public virtual ICollection<PaginaTipoUsuario> PaginaTipoUsuarios { get; set; } = new List<PaginaTipoUsuario>();

    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
