using System;
using System.Collections.Generic;

namespace WebApi.Models;

public partial class Usuario
{
    public int Iidusuario { get; set; }

    public string? Nombreusuario { get; set; }

    public string? Contra { get; set; }

    public int? Iidpersona { get; set; }

    public int? Bhabilitado { get; set; }

    public int? Iidtipousuario { get; set; }

    public virtual ICollection<Citum> CitumIiddoctorasignacitausuarioNavigations { get; set; } = new List<Citum>();

    public virtual ICollection<Citum> CitumIidusuarioNavigations { get; set; } = new List<Citum>();

    public virtual Persona? IidpersonaNavigation { get; set; }

    public virtual TipoUsuario? IidtipousuarioNavigation { get; set; }

    public virtual ICollection<Mascotum> Mascota { get; set; } = new List<Mascotum>();

    public virtual ICollection<UsuarioMascotum> UsuarioMascota { get; set; } = new List<UsuarioMascotum>();
}
