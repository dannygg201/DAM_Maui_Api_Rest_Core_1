using CapaEntidad;

namespace AppMovil.Services
{
    public interface IPersonaService
    {
        Task<List<PersonaCLS>> GetPersonasAsync();
    }
}
