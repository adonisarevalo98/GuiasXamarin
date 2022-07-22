using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.IO;
using CRUD_Peliculas;

namespace CRUD_Peliculas
{
    public partial class App : Application
    {
        static SQLiteHelper db; //db es una referencia al SQLiteAsyncConnection en SQLiteHelper
        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
        }

        //Retornando cadena de conexion a traves de SQLiteDB
        public static SQLiteHelper SQLiteDB
        {
            get
            {
                if (db == null)
                {
                    db = new SQLiteHelper(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "PeliculaSQLite.db3"));
                }
                return db;
            }
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
