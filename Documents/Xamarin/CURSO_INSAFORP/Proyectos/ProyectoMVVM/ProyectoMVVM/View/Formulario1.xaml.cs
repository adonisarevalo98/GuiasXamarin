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
    public partial class Formulario1 : ContentPage
    {
        public Formulario1()
        {
            InitializeComponent();
            BindingContext = new VMFormulario1(Navigation);
        }
    }
}