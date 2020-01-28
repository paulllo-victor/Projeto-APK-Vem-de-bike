using Aplicativo.Models;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Aplicativo.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TelaGrupos : ContentPage
    {
       
        public TelaGrupos()
        {
            InitializeComponent();
            
        }

        private async void buttonMeusGrupos_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TelaMeusGrupos());
        }

        private async void buttonPesquisarGrupos_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TelaBuscarGrupo());
        }
    }
}