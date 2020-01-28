using Aplicativo.Services;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
namespace Aplicativo.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TelaBuscarGrupo : ContentPage
    {
        public TelaBuscarGrupo()
        {
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
            /*ModelGrupo grupo = (ModelGrupo)ListaGrupos.SelectedItem;
            await Navigation.PushAsync(new CadastroGrupo(grupo));*/
        }

        private void PesquisarGrupo_SearchButtonPressed(object sender, EventArgs e)
        {
            ServicesBdGrupos bdGrupo = new ServicesBdGrupos(App.DbPath);
            ListaGrupos.ItemsSource = bdGrupo.localizar(PesquisarGrupo.Text);
        }


    }
}