using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using ProyectoMVVM.View;

namespace ProyectoMVVM.ViewModel
{
    internal class VMFormulario1:BaseViewModel
    {
        #region Mis_Variables
        string _usuario;
        string _password;
        string _cmbarea;
        string _datosformulario;
        #endregion

        #region Mis_Constructores
        public VMFormulario1(INavigation navigation)
        {
            Navigation = navigation;
        }
        #endregion

        #region Mis_Objetos
        public string Usuario
        {
            get { return _usuario; } //Devuelve el contenido de la variable en #Region Mis_Variables
            set { SetValue(ref _usuario, value); }
        }

        public string Password
        {
            get { return _password; }
            set { SetValue(ref _password, value); }

        }
        public string CmbArea
        {
            get { return _cmbarea; }
            set { SetValue(ref _cmbarea, value); }

        }
        //Obtiene el valor seleccionado el ComboBox
        public string ComboSeleccionado
        {
            get { return _cmbarea; }
            set
            {
                SetProperty(ref _cmbarea, value);
                CmbArea = _cmbarea;
            }

        }
        public string DatosFormulario
        {
            get { return _datosformulario; }
            set { SetValue(ref _datosformulario, value); }

        }
        #endregion

        #region Mis_Procesos
        //Envio de datos
        public async Task EnvioDatos_Asyncrono()
        {
            if(_usuario=="" ||_usuario==null) {
               await DisplayAlert("Error", "Ingrese su usuario", "ok");
            }else if(_password=="" || _password == null) {
                await DisplayAlert("Error", "Ingrese su contraseña", "ok");
            }
            else if (_cmbarea=="" || _cmbarea==null) {
                await DisplayAlert("Error", "Seleccione un área", "ok");
            } else{
                DatosFormulario = "Bienvenido usuario " + _usuario + ", estas en el área de " + _cmbarea;
                await Navigation.PushAsync(new DatosFormulario1(DatosFormulario));
            }  
        }

        //Volver a Page1
        //Redirección a Page2
        public async Task ToPage1Asyncrono()
        {
            await Navigation.PushAsync(new Page1());
        }


        #endregion

        #region Mis_Comandos
        //************************************** ASINCRONOS ****************************

        //Comando para enviar datos
        public ICommand EnvioDatosCommand => new Command(async () => await EnvioDatos_Asyncrono());
        //Comando para regresar a Page1
        public ICommand ToPage1Asyncommand => new Command(async () => await ToPage1Asyncrono());

        //************************************** SINCRONOS ****************************
        #endregion

    }
}
