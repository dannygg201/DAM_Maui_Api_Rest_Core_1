using System;
using System.Collections.Generic;

namespace WebApi.Models;

public partial class PaginaTipoUsuario
{
    public int Iidpaginatipousuario { get; set; }

    public int? Iidpagina { get; set; }

    public int? Iidtipousuario { get; set; }

    public int? Bhabilitado { get; set; }

    public int? Iidvista { get; set; }

    public virtual Pagina? IidpaginaNavigation { get; set; }

    public virtual TipoUsuario? IidtipousuarioNavigation { get; set; }
}
