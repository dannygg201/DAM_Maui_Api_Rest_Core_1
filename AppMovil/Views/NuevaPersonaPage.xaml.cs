using AppMovil.Services;
using CapaEntidad;
using Microsoft.Maui.Storage;

namespace AppMovil.Views;

public partial class NuevaPersonaPage : ContentPage
{
    private readonly PersonaService personaService = new();

    public NuevaPersonaPage()
    {
        InitializeComponent();
        InicializarPicker();
    }

    private void InicializarPicker()
    {
        SexoPicker.ItemsSource = new List<KeyValuePair<int, string>>
        {
            new(1, "Masculino"),
            new(2, "Femenino")
        };
    }

    private async void Guardar_Clicked(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(NombreCompletoEntry.Text))
        {
            await DisplayAlert("Error", "El nombre completo es obligatorio.", "OK");
            return;
        }

        var partes = NombreCompletoEntry.Text.Split(' ');
        var nuevaPersona = new PersonaCLS
        {
            nombre = partes.Length > 0 ? partes[0] : "Nombre",
            appaterno = partes.Length > 1 ? partes[1] : "Apellido",
            apmaterno = partes.Length > 2 ? partes[2] : "Apellido",
            nombrecompleto = NombreCompletoEntry.Text,
            correo = !string.IsNullOrWhiteSpace(CorreoEntry.Text) ? CorreoEntry.Text : "correo@prueba.com",
            iidsexo = SexoPicker.SelectedItem is KeyValuePair<int, string> kv ? kv.Key : 1
        };

        if (!DateTime.TryParse(FechaNacimientoEntry.Text, out DateTime fecha))
            fecha = new DateTime(2000, 1, 1);

        nuevaPersona.fechanacimientocadena = fecha.ToString("dd/MM/yyyy");

        bool registrado = await personaService.RegistrarPersonaAsync(nuevaPersona);

        if (registrado)
        {
            Preferences.Set("RegistroExitoso", true);
            await Navigation.PopAsync();
        }
        else
        {
            await DisplayAlert("❌ Error", "No se pudo registrar a la persona.", "OK");
        }
    }
}
