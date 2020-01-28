using Aplicativo.Models;
using Aplicativo.Services;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Aplicativo.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TelaParticipantesGrupo : ContentPage
    {
        ModelUsuario usuaarioPadrao;
        ModelGrupo grupoPadrao;
        public TelaParticipantesGrupo(ModelUsuario usuarioLogado, ModelGrupo grupoSelecionado)
        {
            usuaarioPadrao = usuarioLogado;
            grupoPadrao = grupoSelecionado;
            InitializeComponent();
            AtualizarListar();

        }
        public void AtualizarListar()
        {
            ServicesBdParticipantes bdParticipantes = new ServicesBdParticipantes(App.DbPath);
            string idG = Convert.ToString(grupoPadrao.id);
            ListarParticipantes.ItemsSource = bdParticipantes.listarParticipantes(idG);
        }

        private async void PariticiparGrupo_Clicked(object sender, EventArgs e)
        {
            ServicesBdGrupos bdGrupo = new ServicesBdGrupos(App.DbPath);
            bool confirmacao = bdGrupo.adicionarParticipantes(usuaarioPadrao.login, grupoPadrao.id);
            if (confirmacao)
            {
                await DisplayAlert("Sucesso", "sucesso, participante adicionado com sucesso!!", "ok");
                AtualizarListar();
            }
            else
            {
                await DisplayAlert("Erro", "Você já está participando do Grupo!!", "ok");
            }
        }
    }
}