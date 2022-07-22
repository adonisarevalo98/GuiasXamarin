using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using ProyectoMVVM.Model;

namespace ProyectoMVVM.ViewModel
{
    internal class VMPage2:BaseViewModel
    {
        #region Mis_Variables
        string _Texto;
        public List<MPeliculas> listpeliculas { get; set; }
        #endregion

        #region Mis_Constructores
        public VMPage2(INavigation navigation)
        {
            Navigation = navigation;
            MostrarPeliculas();
        }
        #endregion

        #region Mis_Objetos
        public string Texto
        {
            get { return _Texto; } //Devuelve el contenido de la variable en #Region Mis_Variables
            set { SetValue(ref _Texto, value); }
        }
        #endregion

        #region Mis_Procesos
        public async Task VolverAsyncrono()
        {
            Navigation.PopAsync();
            
        }

        //Mostrar Peliculas
        public void MostrarPeliculas()
        {
            listpeliculas = new List<MPeliculas>() //Instancia de Objeto
            {
                new MPeliculas
                {
                    Nombre="Esta es una película, la película.",
                    Imagen="https://res.cloudinary.com/dream-music/image/upload/v1623483783/album_2/jazz_quen_wkerks.png"
                },
                new MPeliculas
                {
                    Nombre="La película 2, Orígenes",
                    Imagen="https://res.cloudinary.com/dream-music/image/upload/v1623479653/album_2/pontelo_zhapqi.jpg"
                },
                new MPeliculas
                {
                    Nombre="La película 3, más película que nunca",
                    Imagen="https://res.cloudinary.com/dream-music/image/upload/v1623479653/album_2/please_syblg1.jpg"
                }
            }; 

        }

        public async Task AlertaPeliculaAsyncrono(MPeliculas parametros)
        {
            await DisplayAlert("Titulo", parametros.Nombre, "Ok");
        }
        public void ProcesoSimple()
        {

        }
        #endregion

        #region Mis_Comandos
        //Asincronos
        public ICommand VolverAsyncommand => new Command(async () => await VolverAsyncrono());

        public ICommand AlertaPeliculaAsyncommand => new Command<MPeliculas>(async (P) => await AlertaPeliculaAsyncrono(P));

        //Sincronos
        public ICommand ProcesoSimplecommand => new Command(ProcesoSimple);
        #endregion
    }
}
