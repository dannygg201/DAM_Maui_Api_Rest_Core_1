using AppMovil.Services;
using CapaEntidad;
using Microsoft.Maui.Storage;

namespace AppMovil.Views;

public partial class EditarPersonaPage : ContentPage
{
    private readonly PersonaService personaService = new();
    private PersonaCLS persona;

    private List<KeyValuePair<int, string>> sexoItems = new()
    {
        new KeyValuePair<int, string>(1, "Masculino"),
        new KeyValuePair<int, string>(2, "Femenino")
    };

    public EditarPersonaPage(int idPersona)
    {
        InitializeComponent();
        SexoPicker.ItemsSource = sexoItems;
        CargarPersona(idPersona);
    }

    private async void CargarPersona(int id)
    {
        persona = await personaService.GetPersonaPorIdAsync(id);

        if (persona == null)
        {
            await DisplayAlert("Error", "No se pudo cargar la persona", "OK");
            await Navigation.PopAsync();
            return;
        }

        SexoPicker.SelectedItem = sexoItems.FirstOrDefault(x => x.Key == persona.iidsexo);
        NombreCompletoEntry.Text = $"{persona.nombre} {persona.appaterno} {persona.apmaterno}";
        CorreoEntry.Text = persona.correo ?? "";
        FechaNacimientoEntry.Text = persona.fechanacimientocadena ?? "";
    }

    private async void Guardar_Clicked(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(NombreCompletoEntry.Text))
        {
            await DisplayAlert("Error", "El nombre completo es obligatorio.", "OK");
            return;
        }

        var partes = NombreCompletoEntry.Text.Split(' ');
        persona.nombre = partes.Length > 0 ? partes[0] : "Nombre";
        persona.appaterno = partes.Length > 1 ? partes[1] : "Apellido";
        persona.apmaterno = partes.Length > 2 ? partes[2] : "Apellido";

        persona.nombrecompleto = NombreCompletoEntry.Text;
        persona.correo = !string.IsNullOrWhiteSpace(CorreoEntry.Text) ? CorreoEntry.Text : "correo@prueba.com";

        if (!DateTime.TryParse(FechaNacimientoEntry.Text, out DateTime fecha))
        {
            fecha = new DateTime(2000, 1, 1);
        }
        persona.fechanacimientocadena = fecha.ToString("dd/MM/yyyy");

        if (SexoPicker.SelectedItem is KeyValuePair<int, string> sexoSeleccionado)
        {
            persona.iidsexo = sexoSeleccionado.Key;
        }
        else
        {
            await DisplayAlert("Error", "Selecciona un sexo válido.", "OK");
            return;
        }

        bool actualizado = await personaService.ActualizarPersonaAsync(persona);

        if (actualizado)
        {
            Preferences.Set("EdicionExitosa", true);
            await Navigation.PopAsync();
        }
        else
        {
            await DisplayAlert("❌ Error", "No se pudo actualizar la persona. Verifica los datos.", "OK");
        }
    }
}
