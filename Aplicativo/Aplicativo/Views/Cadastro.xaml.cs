using Aplicativo.Models;
using Aplicativo.Services;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Aplicativo.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Cadastro : ContentPage
    {
        public Cadastro()
        {
            InitializeComponent();
        }

        private async void buttonRegistar_Clicked(object sender, EventArgs e)
        {
            ModelUsuario usuario = new ModelUsuario();
            string login = entryLogin.Text;
            string senha = entrySenha.Text;

            usuario.login = login;
            usuario.senha = senha;

            ServicesBdUsuario bd = new ServicesBdUsuario(App.DbPath);
            bd.InserirUsuario(usuario);
            await DisplayAlert("Resultado: ", bd.statusMessage, "OK");
            await Navigation.PushAsync(new Login());
        }
    }
}