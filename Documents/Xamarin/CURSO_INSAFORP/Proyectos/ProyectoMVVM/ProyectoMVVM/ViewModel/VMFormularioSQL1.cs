using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using ProyectoMVVM.View;
using ProyectoMVVM.Model;


namespace ProyectoMVVM.ViewModel
{
    internal class VMFormularioSQL1:BaseViewModel
    {
        #region Mis_Variables
        string _Texto;
        string _nuevonombre;
        string _nuevaedad;
        string _nombre;
        string _edad;
        public List<MPersona> _listpersonas;
        #endregion

        #region Mis_Constructores
        public VMFormularioSQL1(INavigation navigation)
        {
            Navigation = navigation;
            ObtienePersonas();

        }
        #endregion

        #region Mis_Objetos
        public string Texto
        {
            get { return _Texto; } //Devuelve el contenido de la variable en #Region Mis_Variables
            set { SetValue(ref _Texto, value); }
        }
        public string NuevoNombre
        {
            get { return _nuevonombre; } //DE ENTRY NOMBRE
            set { SetValue(ref _nuevonombre, value); }
        }
        public string NuevaEdad
        {
            get { return _nuevaedad; } //DE ENTRY EDAD
            set { SetValue(ref _nuevaedad, value); }
        }
        public string Nombre
        {
            get { return _nombre; } //PARA LABEL NOMBRE
            set { SetValue(ref _nombre, value); }
        }
        public string Edad
        {
            get { return _edad; } //PARA LABEL EDAD
            set { SetValue(ref _edad, value); }
        }

        public List<MPersona> ListaPersonas
        {
            get { return _listpersonas; } //PARA COLLECTION VIEW
            set { SetValue(ref _listpersonas, value); }
        }
        #endregion

        #region Mis_Procesos

        public async Task GuardarPersona()
        {
            if (!string.IsNullOrWhiteSpace(_nuevonombre) && !string.IsNullOrWhiteSpace(_nuevaedad))
            {
                await App.Database.SavePersonAsync(new MPersona
                {
                    Nombre = _nuevonombre,
                    Edad = int.Parse(_nuevaedad)
                });

                _nombre = _edad = string.Empty;

                 ObtienePersonas();

            }
        }

        public  void  ObtienePersonas()
        {
            ObtienePersonasAsync();
        }
        public async Task ObtienePersonasAsync()
        {
            try
            {
                ListaPersonas = await App.Database.GetPeopleAsync();
            }
            catch(Exception ex)
            {

            }
            
        }

        public void ProcesoSimple()
        {

        }
        #endregion

        #region Mis_Comandos
        //Asincronos
        public ICommand GuardarPersonacommand => new Command(async () => await GuardarPersona());


        //Sincronos
        public ICommand ProcesoSimplecommand => new Command(ProcesoSimple);
        #endregion
    }
}
