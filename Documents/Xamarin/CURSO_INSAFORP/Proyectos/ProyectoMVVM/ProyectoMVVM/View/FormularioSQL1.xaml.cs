using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ProyectoMVVM.Model;
using ProyectoMVVM.ViewModel;

namespace ProyectoMVVM.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FormularioSQL1 : ContentPage
    {
        public FormularioSQL1()
        {
            InitializeComponent();
            BindingContext = new VMFormularioSQL1(Navigation);
        }
 
    }

}