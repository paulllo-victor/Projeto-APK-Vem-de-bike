using Aplicativo.Models;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Aplicativo.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TelaInicial : ContentPage
    {
        ModelUsuario usuarioPadrao;
        public TelaInicial(ModelUsuario usuarioLogado)
        {
            InitializeComponent();
            apresentacao.Text = "Bem vindo " + usuarioLogado.login;
            usuarioPadrao = usuarioLogado;
        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CadastroGrupo(usuarioPadrao));
        }

        private async void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TelaGrupos());
        }

        private async void TapGestureRecognizer_Tapped_2(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TelaRoteiros(usuarioPadrao));
        }
    }
}