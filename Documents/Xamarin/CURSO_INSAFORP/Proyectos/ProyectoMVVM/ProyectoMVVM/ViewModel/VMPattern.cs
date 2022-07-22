using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace ProyectoMVVM.ViewModel
{
    internal class VMPattern:BaseViewModel
    {
        #region Mis_Variables
        string _Texto;
        #endregion

        #region Mis_Constructores
        public VMPattern(INavigation navigation)
        {
            Navigation = navigation;
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
        public async Task ProcesoAsyncrono()
        {
            
        }
        public void ProcesoSimple()
        {

        }
        #endregion

        #region Mis_Comandos
        //Asincronos
        public ICommand ProcesoAsyncommand => new Command(async () => await ProcesoAsyncrono());
        //Sincronos
        public ICommand ProcesoSimplecommand => new Command(ProcesoSimple);
        #endregion

    }
}
