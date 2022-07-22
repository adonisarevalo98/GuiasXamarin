using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using CRUD_Peliculas;

namespace CRUD_Peliculas
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        //***** OBTENER TODOS AL CARCAR LA VISTA
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            //Mostrar las películas
            var listapeliculas = await App.SQLiteDB.GetItemsAsync();
            if (listapeliculas != null)
            {
                lstpeliculas.ItemsSource = listapeliculas;
            }
        }

        //***** AGREGAR
        private async void btnAdd_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtPeliculaNombre.Text))
            {
                Peliculas peliculas = new Peliculas()
                {
                    NombrePelicula = txtPeliculaNombre.Text,

                };

                //adicionar la nueva pelicula
                await App.SQLiteDB.SaveItemAsync(peliculas);
                txtPeliculaNombre.Text = string.Empty;
                await DisplayAlert("Hecho", "Película registrada con éxito", "OK");

                //Mostrar las películas
                var listapeliculas = await App.SQLiteDB.GetItemsAsync();
                if(listapeliculas != null)
                {
                    lstpeliculas.ItemsSource = listapeliculas;
                }
            }
            else
            {
                await DisplayAlert("Error", "Ingrese el nombre de la película", "OK");
            }
        }


        //***** BUSCAR POR ID
        private async void btnSearch_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtPeliculaId.Text))
            {
                var pelicula = await App.SQLiteDB.GetItemAsync(Convert.ToInt32(txtPeliculaId.Text));
                if(pelicula != null)
                {
                    txtPeliculaNombre.Text = pelicula.NombrePelicula;
                }
                else
                {
                    await DisplayAlert("Error", "No se encontraron registros", "OK");
                }
            }
            else
            {
                await DisplayAlert("Error", "Ingrese el Código de la película", "OK");
            }
        }


        //***** ACTUALIZAR
        private async void btnUpdate_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtPeliculaId.Text))
            {
                await DisplayAlert("Error", "Ingrese el codigo de la película", "OK");
            }else if (string.IsNullOrEmpty(txtPeliculaNombre.Text))
            {
                await DisplayAlert("Error", "Ingrese el nombre de la película", "OK");
            }else
            {
                Peliculas peliculas = new Peliculas()
                {
                    IdPelicula = Convert.ToInt32(txtPeliculaId.Text),
                    NombrePelicula = txtPeliculaNombre.Text

                };
                await App.SQLiteDB.SaveItemAsync(peliculas);
                txtPeliculaId.Text = string.Empty;
                txtPeliculaNombre.Text = string.Empty;
                await DisplayAlert("Hecho", "Película actualizada con éxito", "OK");

                //Mostrar las películas
                var listapeliculas = await App.SQLiteDB.GetItemsAsync();
                if (listapeliculas != null)
                {
                    lstpeliculas.ItemsSource = listapeliculas;
                }
            }
        }

        //***** ELIMINAR
        private async void btnDelete_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtPeliculaId.Text))
            {
                await DisplayAlert("Error", "Ingrese el codigo de la película", "OK");
            }
            else
            {
                var pelicula = await App.SQLiteDB.GetItemAsync(Convert.ToInt32(txtPeliculaId.Text));
                if (pelicula != null)
                {
                    await App.SQLiteDB.DeleteItemAsync(pelicula);
                    txtPeliculaId.Text = string.Empty;
                    txtPeliculaNombre.Text= string.Empty;
                    await DisplayAlert("Hecho", "Película eliminada con éxito", "OK");

                    //Mostrar las películas
                    var listapeliculas = await App.SQLiteDB.GetItemsAsync();
                    if (listapeliculas != null)
                    {
                        lstpeliculas.ItemsSource = listapeliculas;
                    }
                }
                else
                {
                    await DisplayAlert("Error", "No se encontraron registros", "OK");
                }
            }
        }
    }
}
