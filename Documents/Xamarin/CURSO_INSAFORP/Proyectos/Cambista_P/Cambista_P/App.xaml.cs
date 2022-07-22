using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Cambista_P.Vistas;

namespace Cambista_P
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //MainPage = new MainPage();
            //MainPage = new Principal();
            MainPage = new NavigationPage(new Principal());//Requerido para la navegación entre páginas
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
