using AppMovil.Services;
using CapaEntidad;
using Microsoft.Maui.Storage;


namespace AppMovil;

public partial class MainPage : ContentPage
{
    private readonly PersonaService _personaService;

    public MainPage()
    {
        InitializeComponent();
        _personaService = new PersonaService();
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        // ✅ Mostrar alerta si venimos de una edición exitosa
        if (Preferences.ContainsKey("EdicionExitosa"))
        {
            bool fueExito = Preferences.Get("EdicionExitosa", false);
            if (fueExito)
            {
                await DisplayAlert("✅ Éxito", "La persona fue actualizada correctamente.", "OK");
                Preferences.Remove("EdicionExitosa");
            }
        }


        await CargarPersonas();
    }

    private async void Nuevo_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Views.NuevaPersonaPage());
    }

    private async Task CargarPersonas()
    {
        var lista = await _personaService.GetPersonasAsync();
        PersonasList.ItemsSource = lista;
    }

    private async void EditarPersona_Clicked(object sender, EventArgs e)
    {
        if (sender is ImageButton boton && boton.CommandParameter is PersonaCLS persona)
        {
            await Navigation.PushAsync(new Views.EditarPersonaPage(persona.iidpersona));
        }
    }

    private async void EliminarPersona_Clicked(object sender, EventArgs e)
    {
        if (sender is ImageButton boton && boton.CommandParameter is PersonaCLS persona)
        {
            bool confirmacion = await DisplayAlert("Confirmar", $"¿Eliminar a {persona.nombrecompleto}?", "Sí", "No");
            if (confirmacion)
            {
                bool eliminado = await _personaService.EliminarPersonaAsync(persona.iidpersona);
                if (eliminado)
                {
                    await DisplayAlert("✅ Éxito", "Persona eliminada correctamente.", "OK");
                    await CargarPersonas(); // Recargar lista
                }
                else
                {
                    await DisplayAlert("❌ Error", "No se pudo eliminar la persona.", "OK");
                }
            }
        }
    }

    private async void Buscar_Clicked(object sender, EventArgs e)
    {
        string nombre = BuscarEntry.Text?.Trim();

        if (!string.IsNullOrWhiteSpace(nombre))
        {
            var listaFiltrada = await _personaService.BuscarPersonasPorNombreAsync(nombre);
            PersonasList.ItemsSource = listaFiltrada;
        }
        else
        {
            await DisplayAlert("Advertencia", "Ingresa un nombre para buscar.", "OK");
        }
    }

    private async void Limpiar_Clicked(object sender, EventArgs e)
    {
        BuscarEntry.Text = string.Empty;
        await CargarPersonas(); // Recargar todo
    }


}
