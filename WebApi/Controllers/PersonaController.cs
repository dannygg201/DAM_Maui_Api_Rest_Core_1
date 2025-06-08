using Microsoft.AspNetCore.Mvc;
using CapaEntidad;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonaController : ControllerBase
    {
        // GET: api/Persona
        [HttpGet]
        public List<PersonaCLS> ListarPersonas()
        {
            try
            {
                using var bd = new DbAb7ff9BdveterinariaContext();
                return (from persona in bd.Personas
                        where persona.Bhabilitado == 1
                        select new PersonaCLS
                        {
                            iidpersona = persona.Iidpersona,
                            nombrecompleto = $"{persona.Nombre} {persona.Appaterno} {persona.Apmaterno}",
                            correo = persona.Correo,
                            fechanacimientocadena = persona.Fechanacimiento == null ? "" :
                                persona.Fechanacimiento.Value.ToString("dd/MM/yyyy")
                        }).ToList();
            }
            catch
            {
                return new List<PersonaCLS>();
            }
        }

        // GET: api/Persona/{nombrecompleto}
        [HttpGet("{nombrecompleto}")]
        public List<PersonaCLS> FiltrarPersonas(string nombrecompleto)
        {
            try
            {
                using var bd = new DbAb7ff9BdveterinariaContext();
                return (from persona in bd.Personas
                        where persona.Bhabilitado == 1 &&
                              (persona.Nombre + " " + persona.Appaterno + " " + persona.Apmaterno).Contains(nombrecompleto)
                        select new PersonaCLS
                        {
                            iidpersona = persona.Iidpersona,
                            nombrecompleto = $"{persona.Nombre} {persona.Appaterno} {persona.Apmaterno}",
                            correo = persona.Correo,
                            fechanacimientocadena = persona.Fechanacimiento == null ? "" :
                                persona.Fechanacimiento.Value.ToString("dd/MM/yyyy")
                        }).ToList();
            }
            catch
            {
                return new List<PersonaCLS>();
            }
        }

        // GET: api/Persona/recuperarPersonaPorId/{id}
        [HttpGet("recuperarPersonaPorId/{id}")]
        public PersonaCLS RecuperarPersonaPorId(int id)
        {
            try
            {
                using var bd = new DbAb7ff9BdveterinariaContext();
                return (from persona in bd.Personas
                        where persona.Bhabilitado == 1 && persona.Iidpersona == id
                        select new PersonaCLS
                        {
                            iidpersona = persona.Iidpersona,
                            nombre = persona.Nombre,
                            appaterno = persona.Appaterno,
                            apmaterno = persona.Apmaterno,
                            correo = persona.Correo,
                            fechanacimiento = persona.Fechanacimiento ?? DateTime.MinValue,
                            fechanacimientocadena = persona.Fechanacimiento == null ? "" :
                                persona.Fechanacimiento.Value.ToString("dd/MM/yyyy"),
                            iidsexo = persona.Iidsexo ?? 0
                        }).FirstOrDefault() ?? new PersonaCLS();
            }
            catch
            {
                return new PersonaCLS();
            }
        }

        // POST para AppMóvil (actualizar)
        [HttpPost("actualizar")]
        public IActionResult ActualizarDesdeMovil([FromBody] PersonaCLS persona)
        {
            return ActualizarPersonaBase(persona);
        }

        // POST para WebCliente (actualizar)
        [HttpPost("ActualizarPersona")]
        public IActionResult ActualizarDesdeWeb([FromBody] PersonaCLS persona)
        {
            return ActualizarPersonaBase(persona);
        }

        private IActionResult ActualizarPersonaBase(PersonaCLS persona)
        {
            if (persona == null || persona.iidpersona == 0)
                return BadRequest("Datos inválidos");

            try
            {
                using var bd = new DbAb7ff9BdveterinariaContext();
                var personaBD = bd.Personas.FirstOrDefault(p => p.Iidpersona == persona.iidpersona);

                if (personaBD == null)
                    return NotFound("Persona no encontrada");

                personaBD.Nombre = persona.nombre ?? "";
                personaBD.Appaterno = persona.appaterno ?? "";
                personaBD.Apmaterno = persona.apmaterno ?? "";
                personaBD.Correo = persona.correo ?? "";

                if (DateTime.TryParse(persona.fechanacimientocadena, out var fecha))
                    personaBD.Fechanacimiento = fecha;

                personaBD.Iidsexo = persona.iidsexo;

                bd.SaveChanges();
                return Ok(true);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error interno del servidor: " + ex.Message);
            }
        }

        // POST para AppMóvil (registrar)
        [HttpPost("registrar")]
        public IActionResult RegistrarDesdeMovil([FromBody] PersonaCLS persona)
        {
            return RegistrarPersonaBase(persona);
        }

        // POST para WebCliente (registrar)
        [HttpPost("RegistrarPersona")]
        public IActionResult RegistrarDesdeWeb([FromBody] PersonaCLS persona)
        {
            return RegistrarPersonaBase(persona);
        }

        private IActionResult RegistrarPersonaBase(PersonaCLS persona)
        {
            if (persona == null)
                return BadRequest("Datos incompletos");

            try
            {
                using var db = new DbAb7ff9BdveterinariaContext();
                var nueva = new Persona
                {
                    Nombre = persona.nombre,
                    Appaterno = persona.appaterno,
                    Apmaterno = persona.apmaterno,
                    Correo = persona.correo,
                    Fechanacimiento = DateTime.TryParse(persona.fechanacimientocadena, out var fecha) ? fecha : DateTime.Now,
                    Iidsexo = persona.iidsexo,
                    Bhabilitado = 1
                };

                db.Personas.Add(nueva);
                db.SaveChanges();
                return Ok(true);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error al registrar: " + ex.Message);
            }
        }

        // DELETE: api/Persona/eliminar/{id}
        [HttpDelete("eliminar/{id}")]
        public IActionResult EliminarPersona(int id)
        {
            try
            {
                using var bd = new DbAb7ff9BdveterinariaContext();
                var persona = bd.Personas.FirstOrDefault(p => p.Iidpersona == id);
                if (persona == null)
                    return NotFound();

                persona.Bhabilitado = 0;
                bd.SaveChanges();
                return Ok(true);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error interno: " + ex.Message);
            }
        }
    }
}
