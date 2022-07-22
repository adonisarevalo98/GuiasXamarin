using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ProyectoMVVM.ViewModel;

namespace ProyectoMVVM.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DatosFormulario1 : ContentPage
    {
        public DatosFormulario1(string Datos)
        {
            InitializeComponent();
            BindingContext = new VMDatosFormulario1(Navigation,Datos);
        }
    }
}