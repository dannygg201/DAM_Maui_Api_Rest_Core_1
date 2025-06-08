using System;
using Microsoft.Maui.Controls;

namespace SensoresApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void GoToGeolocalizacion(object sender, EventArgs e) =>
            await Navigation.PushAsync(new Views.GeolocalizacionView());

        private async void GoToAcelerometro(object sender, EventArgs e) =>
            await Navigation.PushAsync(new Views.AcelerometroView());

        private async void GoToCercania(object sender, EventArgs e) =>
            await Navigation.PushAsync(new Views.CercaniaView());

        private async void GoToBrujula(object sender, EventArgs e) =>
            await Navigation.PushAsync(new Views.BrujulaView());

        private async void GoToBarometro(object sender, EventArgs e) =>
            await Navigation.PushAsync(new Views.BarometroView());

        private async void GoToGiroscopio(object sender, EventArgs e) =>
            await Navigation.PushAsync(new Views.GiroscopioView());

        private async void GoToPodometro(object sender, EventArgs e) =>
            await Navigation.PushAsync(new Views.PodometroView());

        private async void GoToEspectroColor(object sender, EventArgs e) =>
            await Navigation.PushAsync(new Views.EspectroColorView());
    }
}
