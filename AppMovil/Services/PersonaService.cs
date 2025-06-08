using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using CapaEntidad;

namespace AppMovil.Services
{
    public class PersonaService
    {
        private readonly HttpClient _httpClient;

        public PersonaService()
        {
            var handler = new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true
            };

            _httpClient = new HttpClient(handler)
            {
                BaseAddress = new Uri("https://sitiodgs.somee.com/api/")
            };
        }

       
        public async Task<List<PersonaCLS>> GetPersonasAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync("persona");

                if (!response.IsSuccessStatusCode)
                {
                    Console.WriteLine("❌ Error al obtener personas: " + response.StatusCode);
                    return new List<PersonaCLS>();
                }

                var json = await response.Content.ReadAsStringAsync();
                var personas = JsonSerializer.Deserialize<List<PersonaCLS>>(json, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                return personas ?? new List<PersonaCLS>();
            }
            catch (Exception ex)
            {
                Console.WriteLine("❌ Error al deserializar personas: " + ex.Message);
                return new List<PersonaCLS>();
            }
        }

    
        public async Task<PersonaCLS> GetPersonaPorIdAsync(int id)
        {
            try
            {
                var response = await _httpClient.GetAsync($"persona/recuperarPersonaPorId/{id}");

                if (!response.IsSuccessStatusCode)
                {
                    Console.WriteLine("❌ Error al obtener persona por ID: " + response.StatusCode);
                    return null!;
                }

                var json = await response.Content.ReadAsStringAsync();
                var persona = JsonSerializer.Deserialize<PersonaCLS>(json, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                return persona!;
            }
            catch (Exception ex)
            {
                Console.WriteLine("❌ Error al deserializar persona por ID: " + ex.Message);
                return null!;
            }
        }

       
        public async Task<bool> ActualizarPersonaAsync(PersonaCLS persona)
        {
            try
            {
                var json = JsonSerializer.Serialize(persona);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync("Persona/actualizar", content);
                var result = await response.Content.ReadAsStringAsync();

                return response.IsSuccessStatusCode && result.Trim().ToLower() == "true";
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error al actualizar persona: {ex.Message}");
                return false;
            }
        }


       
        public async Task<(bool, string)> ActualizarPersonaConMensajeAsync(PersonaCLS persona)
        {
            try
            {
                var json = JsonSerializer.Serialize(persona);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

               
                var response = await _httpClient.PostAsync("Persona/actualizar", content);

                var responseText = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    return (responseText.Trim().ToLower() == "true", responseText);
                }

                return (false, $"Error HTTP: {response.StatusCode} - {responseText}");
            }
            catch (Exception ex)
            {
                return (false, $"Excepción: {ex.Message}");
            }
        }

        public async Task<bool> RegistrarPersonaAsync(PersonaCLS nuevaPersona)
        {
            try
            {
                var json = JsonSerializer.Serialize(nuevaPersona);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync("Persona/registrar", content);

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    return result.Trim().ToLower() == "true";
                }

                Console.WriteLine("❌ Error HTTP: " + response.StatusCode);
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine("❌ Error al registrar persona: " + ex.Message);
                return false;
            }
        }

        public async Task<bool> EliminarPersonaAsync(int id)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"Persona/eliminar/{id}");
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine("❌ Error al eliminar persona: " + ex.Message);
                return false;
            }
        }

        public async Task<List<PersonaCLS>> BuscarPersonasPorNombreAsync(string nombrecompleto)
        {
            try
            {
                var response = await _httpClient.GetAsync($"persona/{nombrecompleto}");

                if (!response.IsSuccessStatusCode)
                    return new List<PersonaCLS>();

                var json = await response.Content.ReadAsStringAsync();
                var personas = JsonSerializer.Deserialize<List<PersonaCLS>>(json, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                return personas ?? new List<PersonaCLS>();
            }
            catch
            {
                return new List<PersonaCLS>();
            }
        }


    }
}
