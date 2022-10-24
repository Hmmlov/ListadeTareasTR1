using System;
using TR1.Vistas.Tareas;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TR1
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new TareasListaPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
