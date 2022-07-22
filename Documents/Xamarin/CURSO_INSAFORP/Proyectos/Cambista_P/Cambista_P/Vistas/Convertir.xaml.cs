using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Cambista_P.Vistas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Convertir : ContentPage
    {
        public Convertir()
        {
            InitializeComponent();
        }

        private void btnCalcular_Clicked(object sender, EventArgs e)
        {
            Validar(); //Invocando al método de validación 
        }
        private void Validar()
        {
            if (!string.IsNullOrEmpty(txtSoles.Text))
            {
                Calcular(); //Invocando el método de cálculo
            }
            else
            {
                DisplayAlert("ERROR", "Ingrese un valor en Soles","Aceptar");
            }
        }

        private void Calcular()
        {
            double Soles;
            double Resultado;

            Soles = Convert.ToDouble(txtSoles.Text);
            Resultado = Soles / 3.98;
            lblResultado.Text = "$" + Resultado.ToString();
        }

        private void btnVolver_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}