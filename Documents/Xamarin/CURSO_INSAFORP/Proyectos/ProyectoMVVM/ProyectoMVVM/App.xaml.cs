using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ProyectoMVVM.View;
using ProyectoMVVM.Model;

namespace ProyectoMVVM
{
    public partial class App : Application
    {
        //Conexion a SQLite
        static MDatabase database;
        public static MDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new MDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "people.db3"));
                }
                return database;
            }
        }
        public App()
        {
            InitializeComponent();

            //MainPage = new MainPage();
            //MainPage = new Page1();
            MainPage = new NavigationPage(new Page1());
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
