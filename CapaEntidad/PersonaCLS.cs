using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

using System.Text.Json.Serialization;

namespace CapaEntidad
{
    public class PersonaCLS
    {
        public int iidpersona { get; set; }
        public string? nombrecompleto { get; set; }
        public string correo { get; set; }
        public string fechanacimientocadena { get; set; }
        public int iidsexo { get; set; }

        // 
        public string nombre { get; set; }
        public string appaterno { get; set; }
        public string apmaterno { get; set; }
        public DateTime fechanacimiento { get; set; }
    }

}
