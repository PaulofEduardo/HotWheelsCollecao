using Microsoft.Maui.Controls;

namespace HotWheelsCollecao.Views
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnCadastroClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//Cadastro");
        }

        private async void OnListaClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//Lista de Carrinhos");
        }
    }
}
