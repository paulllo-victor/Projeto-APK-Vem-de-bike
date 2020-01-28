using Aplicativo.Models;
using Aplicativo.Services;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Aplicativo.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {
        public Login()
        {
            InitializeComponent();

        }

        private async void button_Registrar(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Cadastro());
        }

        private async void buttonEntrar_Clicked(object sender, EventArgs e)
        {
            ServicesBdUsuario bd = new ServicesBdUsuario(App.DbPath);
            string lg = loginn.Text;
            string sn = senhaa.Text;

            ModelUsuario usuarioValidaca = bd.wrere(lg, sn);
            if (usuarioValidaca != null)
            {
                await DisplayAlert("Sucesso", "Login realizado com sucesso", "OK");
                await Navigation.PushAsync(new TelaInicial(usuarioValidaca));
            }
            else
            {
                await DisplayAlert("erro", "Login ou senha são invalidas", "OK");
            }

            loginn.Text = "";
            senhaa.Text = "";

        }
    }
}