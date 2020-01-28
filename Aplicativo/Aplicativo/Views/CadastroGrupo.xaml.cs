using Aplicativo.Models;
using Aplicativo.Services;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Aplicativo.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CadastroGrupo : ContentPage
    {
        ModelUsuario usarioPadrao;

        public CadastroGrupo(ModelUsuario usuario)
        {
            InitializeComponent();
            usarioPadrao = usuario;

        }
        public CadastroGrupo(ModelGrupo grupo)
        {
            InitializeComponent();
            buttonCriar.Text = "Alterar";
            buttonExcluir.IsVisible = true;
            txtCodigo.IsVisible = true;

            txtCodigo.Text = grupo.id.ToString();
            entryNome.Text = grupo.nome;
            entryHorarioSaida.Text = grupo.horarioSaida;
            entryLocal.Text = grupo.localSaida;
            entryDescricao.Text = grupo.descricaoGrupo;
        }


        private async void buttonCancelar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        private async void buttonCriar_Clicked(object sender, EventArgs e)
        {
            ModelGrupo grupoNv = new ModelGrupo();
            grupoNv.nome = entryNome.Text;
            grupoNv.horarioSaida = entryHorarioSaida.Text;
            grupoNv.localSaida = entryLocal.Text;
            grupoNv.descricaoGrupo = entryDescricao.Text;


            ServicesBdGrupos dbGrupo = new ServicesBdGrupos(App.DbPath);
            if (buttonCriar.Text == "Criar")
            {
                dbGrupo.inserirGrupo(grupoNv, usarioPadrao);
                await DisplayAlert("Resultado: ", dbGrupo.statusMessageGrupo, "ok");
                await Navigation.PopAsync();
            }
            else
            {
                grupoNv.id = int.Parse(txtCodigo.Text);
                dbGrupo.AtualizarGrupo(grupoNv);
                await Navigation.PopAsync();
            }


        }

        private async void buttonExcluir_Clicked(object sender, EventArgs e)
        {
            var resp = await DisplayAlert("Excluir Grupo", "Deseja excluir o grupo??", "Sim", "Não");
            if (resp)
            {
                ServicesBdGrupos dbGrupo = new ServicesBdGrupos(App.DbPath);
                int id = Convert.ToInt32(txtCodigo.Text);
                dbGrupo.ExcluirGrupo(id);
                await DisplayAlert("Resultado: ", dbGrupo.statusMessageGrupo, "ok");
                await Navigation.PushAsync(new TelaBuscarGrupo());
            }
        }
    }
}