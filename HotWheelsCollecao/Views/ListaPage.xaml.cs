using HotWheelsCollecao.Models;
using HotWheelsCollecao.Controllers;
using Microsoft.Maui.Controls;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotWheelsCollecao.Views
{
    public partial class ListaPage : ContentPage
    {
        private CarController _controller;

        public ListaPage()
        {
            InitializeComponent();
            _controller = new CarController();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await CarregarListaAsync();
        }

        private async Task CarregarListaAsync()
        {
            string modelo = searchBarModelo.Text;

            bool? obtido = chkObtido.IsChecked ? true : (bool?)null;
            bool? desejado = chkDesejado.IsChecked ? true : (bool?)null;

            var lista = await _controller.FiltrarAsync(modelo, obtido, desejado);

            foreach (var item in lista)
            {
                item.GetType().GetProperty("ObtidoIcon")?.SetValue(item, item.Obtido ? "check_filled.png" : "check_empty.png");
                item.GetType().GetProperty("DesejadoIcon")?.SetValue(item, item.Desejado ? "heart_filled.png" : "heart_outline.png");
            }

            collectionViewCarrinhos.ItemsSource = lista;
        }

        private async void OnFiltroAlterado(object sender, EventArgs e)
        {
            await CarregarListaAsync();
        }

        private async void OnToggleObtidoClicked(object sender, EventArgs e)
        {
            if (sender is ImageButton btn && btn.CommandParameter is CarModelos carro)
            {
                await _controller.AlternarObtidoAsync(carro);
                await CarregarListaAsync();
            }
        }

        private async void OnToggleDesejadoClicked(object sender, EventArgs e)
        {
            if (sender is ImageButton btn && btn.CommandParameter is CarModelos carro)
            {
                await _controller.AlternarDesejadoAsync(carro);
                await CarregarListaAsync();
            }
        }

        private async void OnDeleteClicked(object sender, EventArgs e)
        {
            if (sender is ImageButton btn && btn.CommandParameter is CarModelos carro)
            {
                bool confirmar = await DisplayAlert("Confirmar exclusão",
                    $"Deseja realmente remover o carrinho \"{carro.Modelo}\"?", "Sim", "Não");

                if (confirmar)
                {
                    await _controller.RemoverAsync(carro);
                    await CarregarListaAsync();
                }
            }
        }
    }
}
