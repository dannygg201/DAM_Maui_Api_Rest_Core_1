namespace AppMovil
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            // FORZAR LA VISTA DIRECTAMENTE (ignora el Shell por ahora)
            MainPage = new NavigationPage(new MainPage());
        }
    }
}
