using Aplicativo.Models;
using Aplicativo.Services;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Aplicativo.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TelaRoteiros : ContentPage
    {
        ModelUsuario usuarioPadrao;
        public TelaRoteiros(ModelUsuario usuarioLogado)
        {
            usuarioPadrao = usuarioLogado;
            InitializeComponent();
            atualizarListar();

        }
        public void atualizarListar()
        {
            ServicesBdGrupos bdGrupos = new ServicesBdGrupos(App.DbPath);
            ListaGrupos.ItemsSource = bdGrupos.listarGrupos();
        }

        private async void ListaGrupos_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            string actionf = await DisplayActionSheet("Escolha para onde deseja ir:", "cancelar", null, "Participates", "Informações");

            if (actionf == "Informações")
            {
                ModelGrupo mdGrupo = (ModelGrupo)ListaGrupos.SelectedItem;
                await DisplayAlert(mdGrupo.nome, "Descrição: " + mdGrupo.descricaoGrupo + "  Horario de saída:" + mdGrupo.horarioSaida + "  Local de saída: " + mdGrupo.localSaida, "cancelar");
            }
            else
            {
                ModelGrupo selectedGrupo = (ModelGrupo)ListaGrupos.SelectedItem;
                await Navigation.PushAsync(new TelaParticipantesGrupo(usuarioPadrao, selectedGrupo));
            }
        }

        private void SearchPesquisa_SearchButtonPressed(object sender, EventArgs e)
        {
            ServicesBdGrupos dbGrupos = new ServicesBdGrupos(App.DbPath);
            ListaGrupos.ItemsSource = dbGrupos.localizar(SearchPesquisa.Text);
        }
    }
}