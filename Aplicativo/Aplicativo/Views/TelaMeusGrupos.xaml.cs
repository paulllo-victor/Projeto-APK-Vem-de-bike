using Aplicativo.Models;
using Aplicativo.Services;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Aplicativo.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TelaMeusGrupos : ContentPage
    {
        ModelUsuario usuarioLogado;
        public TelaMeusGrupos()
        {
            InitializeComponent();
            atualizarListar();

            //usuarioLogado = usuarioPadrao;
        }
        public void atualizarListar()
        {
            ServicesBdGrupos bdGrupos = new ServicesBdGrupos(App.DbPath);
            ListaMeuGrupos.ItemsSource = bdGrupos.listarGrupos();// bdGrupos.localizarGrupoUsuario(usuarioLogado);
        }
        private async void ListaMeuGrupos_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            ModelGrupo modGrupo = (ModelGrupo)ListaMeuGrupos.SelectedItem;
            await Navigation.PushAsync(new CadastroGrupo(modGrupo));

        }

        private void PesquisarGrupo_SearchButtonPressed(object sender, EventArgs e)
        {
            ServicesBdGrupos bdGrupos = new ServicesBdGrupos(App.DbPath);
            ListaMeuGrupos.ItemsSource = bdGrupos.localizar(PesquisarGrupo.Text);
        }
    }
}