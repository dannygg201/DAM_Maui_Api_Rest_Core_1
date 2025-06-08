using CapaEntidad;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Text.Json;
using WebCliente.Clases;

namespace WebCliente.Controllers
{
    public class PersonaController : Controller
    {
        private string urlbase;
        private readonly IHttpClientFactory _httpClientFactory;

        public PersonaController(IConfiguration configuracion, IHttpClientFactory httpClientFactory)
        {
            urlbase = configuracion["baseurl"];
            _httpClientFactory = httpClientFactory;
        }

        
        public async Task<List<PersonaCLS>> ListarPersonas()
        {
            return await ClientHttp.GetAll<PersonaCLS>(_httpClientFactory, urlbase, "/api/Persona");
        }

        
        public async Task<List<PersonaCLS>> FiltrarPersonas(string nombrecompleto)
        {
            return await ClientHttp.GetAll<PersonaCLS>(_httpClientFactory, urlbase, "/api/Persona/" + nombrecompleto);
        }

        
        public async Task<PersonaCLS> RecuperarPersona(int id)
        {
            return await ClientHttp.Get<PersonaCLS>(_httpClientFactory, urlbase, "/api/Persona/recuperarPersonaPorId/" + id);
        }

        
        [HttpPost]
        public async Task<IActionResult> ActualizarPersona([FromBody] PersonaCLS persona)
        {
            try
            {
                var cliente = _httpClientFactory.CreateClient();
                var contenido = new StringContent(JsonSerializer.Serialize(persona), System.Text.Encoding.UTF8, "application/json");

                var response = await cliente.PostAsync($"{urlbase}/api/persona/actualizar", contenido);
                var resultado = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode && resultado.Trim().ToLower() == "true")
                {
                    return Json(new { success = true });
                }
                else
                {
                    return Json(new { success = false, error = resultado });
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, error = ex.Message });
            }
        }

        
        [HttpPost]
        public async Task<IActionResult> RegistrarPersona([FromBody] PersonaCLS persona)
        {
            try
            {
                var cliente = _httpClientFactory.CreateClient();

                var contenido = new StringContent(JsonSerializer.Serialize(persona), Encoding.UTF8, "application/json");

                var response = await cliente.PostAsync($"{urlbase}/api/persona/registrar", contenido);
                var resultado = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode && resultado.Trim().ToLower() == "true")
                {
                    return Json(new { success = true });
                }
                else
                {
                    return Json(new { success = false, error = resultado });
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, error = ex.Message });
            }
        }


        [HttpDelete]
        public async Task<IActionResult> EliminarPersona(int id)
        {
            try
            {
                var cliente = _httpClientFactory.CreateClient();
                var response = await cliente.DeleteAsync($"{urlbase}/api/Persona/eliminar/{id}");

                if (response.IsSuccessStatusCode)
                    return Json(new { success = true });

                return Json(new { success = false, error = await response.Content.ReadAsStringAsync() });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, error = ex.Message });
            }
        }


        public IActionResult Index()
        {
            return View();
        }
    }
}
