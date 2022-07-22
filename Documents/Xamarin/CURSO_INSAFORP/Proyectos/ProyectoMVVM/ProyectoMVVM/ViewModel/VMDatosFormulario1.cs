using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using ProyectoMVVM.View;

namespace ProyectoMVVM.ViewModel
{
    internal class VMDatosFormulario1 : BaseViewModel
    {
        #region Mis_Variables
        string _mensajerecibido;
        #endregion

        #region Mis_Constructores
        public VMDatosFormulario1(INavigation navigation, String Datos)
        {
            Navigation = navigation;
            _mensajerecibido = Datos;
        }
        #endregion

        #region Mis_Objetos
        public string MensajeRecibido
        {
            get { return _mensajerecibido; } //Devuelve el contenido de la variable en #Region Mis_Variables
            set { SetValue(ref _mensajerecibido, value); }
        }
        #endregion

        #region Mis_Procesos
        public async Task VolverAsyncrono()
        {
            Navigation.PopAsync();
        }
        #endregion

        #region Mis_Comandos
        //************************************** ASINCRONOS ****************************
        public ICommand VolverAsyncommand => new Command(async () => await VolverAsyncrono());

        //************************************** SINCRONOS ****************************
        #endregion

    }
}
