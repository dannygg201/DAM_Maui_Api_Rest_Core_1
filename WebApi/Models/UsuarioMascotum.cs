using System;
using System.Collections.Generic;

namespace WebApi.Models;

public partial class UsuarioMascotum
{
    public int Iidpersonamascota { get; set; }

    public int? Iidusuario { get; set; }

    public int? Iidmascota { get; set; }

    public int? Bhabilitado { get; set; }

    public virtual Mascotum? IidmascotaNavigation { get; set; }

    public virtual Usuario? IidusuarioNavigation { get; set; }
}
