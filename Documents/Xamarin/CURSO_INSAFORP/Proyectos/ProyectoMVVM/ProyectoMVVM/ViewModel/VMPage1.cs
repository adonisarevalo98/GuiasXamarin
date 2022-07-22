using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using ProyectoMVVM.View;

namespace ProyectoMVVM.ViewModel
{
    internal class VMPage1:BaseViewModel

    {
        #region Mis_Variables
        string _Texto;
        string _año_nace;
        string _año_actual;
        string _respuesta;
        string _cmbcombo;
        DateTime _datefechaselected;
        string _stringfechaselected;
        #endregion

        #region Mis_Constructores
        public VMPage1(INavigation navigation)
        {
            Navigation = navigation;
            FechaSeleccionada = DateTime.Now;//Asignamos la fecha actual al DatePicker
        }
        #endregion

        #region Mis_Objetos
        public string Texto
        {
            get { return _Texto; } //Devuelve el contenido de la variable en #Region Mis_Variables
            set { SetValue(ref _Texto, value); }
        }

        public string Año_Nace
        {
            get { return _año_nace; } 
            set { SetValue(ref _año_nace, value); }

        }
        public string Año_Actual
        {
            get { return _año_actual; }
            set { SetValue(ref _año_actual, value); }

        }
        public string Respuesta
        {
            get { return _respuesta; }
            set { SetValue(ref _respuesta, value); }

        }
        public string CmbCombo
        {
            get { return _cmbcombo; }
            set { SetValue(ref _cmbcombo, value); }

        }
        //Obtiene el valor seleccionado el ComboBox
        public string ComboSeleccionado
        {
            get { return _cmbcombo; }
            set
            {
                SetProperty(ref _cmbcombo, value);
                CmbCombo = _cmbcombo;
            }

        }
        public string FechaConvertida
        {
            get { return _stringfechaselected; }
            set { SetValue(ref _stringfechaselected, value); }

        }
        //Obtiene el valor seleccionado del DatePicker
        public DateTime FechaSeleccionada
        {
            get { return _datefechaselected; }
            set
            {
                SetValue(ref _datefechaselected, value);
                FechaConvertida = _datefechaselected.ToString("dd/MM/yyyy");
            }

        }
        #endregion

        #region Mis_Procesos
        //Calculo de Edad
        public async Task Calculo_Asyncrono()
        {
            int aa = 0;
            int an = 0;
            int res = 0;
            aa = Convert.ToInt16(_año_actual);
            an = Convert.ToInt16(_año_nace);
            res = aa - an;
            Respuesta = res.ToString();
            await DisplayAlert("XAMARIN FORMS", CmbCombo, "OK");
        }
        
        //Redirección a Formulario1
        public async Task ToFormulario1_Asyncrono()
        {
            await Navigation.PushAsync(new Formulario1());
        }

        //Redirección a Page2
        public async Task ToPage2_Asyncrono()
        {
            await Navigation.PushAsync(new Page2());
        }

        //Redirección a FormularioSQL1
        public async Task ToFormularioSQLAsyncrono()
        {
            await Navigation.PushAsync(new FormularioSQL1());
        }
        public void ProcesoSimple()
        {

        }
        #endregion

        #region Mis_Comandos
        //************************************** ASINCRONOS ****************************

        //Comando para calcular edad
        public ICommand CalculoCommand => new Command(async () => await Calculo_Asyncrono());
        //Comando para redirigir a Formulario1
        public ICommand ToFormulario1Command => new Command(async () => await ToFormulario1_Asyncrono());

        //Comando para redirigir a Page2
        public ICommand ToPage2Command => new Command(async () => await ToPage2_Asyncrono());
        
        //Comando para redirigir a FormularioSQL1
        public ICommand ToFormularioSQLCommand => new Command(async () => await ToFormularioSQLAsyncrono());

        //************************************** SINCRONOS ****************************
        public ICommand ProcesoSimplecommand => new Command(ProcesoSimple);
        #endregion

    }
}
