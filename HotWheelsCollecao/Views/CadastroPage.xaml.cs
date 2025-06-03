using HotWheelsCollecao.Models;
using HotWheelsCollecao.Controllers;
using Microsoft.Maui.Controls;
using System;
using System.IO;
using System.Threading.Tasks;

namespace HotWheelsCollecao.Views
{
    public partial class CadastroPage : ContentPage
    {
        private string _fotoPath;
        private readonly CarController _controller;

        public CadastroPage()
        {
            InitializeComponent();
            _controller = new CarController();
        }

        private async void OnSelecionarFotoClicked(object sender, EventArgs e)
        {
            try
            {
                var result = await FilePicker.PickAsync(new PickOptions
                {
                    PickerTitle = "Selecione uma imagem do carrinho",
                    FileTypes = FilePickerFileType.Images
                });

                if (result != null)
                {
                    _fotoPath = result.FullPath;
                    imgFoto.Source = ImageSource.FromFile(_fotoPath);
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Erro", $"Erro ao selecionar imagem: {ex.Message}", "OK");
            }
        }

        private async void OnSalvarClicked(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(entryModelo.Text) ||
                string.IsNullOrWhiteSpace(entryLote.Text) ||
                string.IsNullOrWhiteSpace(entryAno.Text) ||
                string.IsNullOrWhiteSpace(_fotoPath))
            {
                await DisplayAlert("Erro", "Todos os campos são obrigatórios.", "OK");
                return;
            }

            if (!int.TryParse(entryAno.Text, out int ano))
            {
                await DisplayAlert("Erro", "Ano inválido.", "OK");
                return;
            }

            var novoCarro = new CarModelos
            {
                Modelo = entryModelo.Text,
                Lote = entryLote.Text,
                Ano = ano,
                FotoPath = _fotoPath,
                Obtido = switchObtido.IsToggled,
                Desejado = switchDesejado.IsToggled
            };

            try
            {
                await _controller.SalvarAsync(novoCarro);
                await DisplayAlert("Sucesso", "Carrinho salvo com sucesso!", "OK");

                // Limpar campos
                entryModelo.Text = string.Empty;
                entryLote.Text = string.Empty;
                entryAno.Text = string.Empty;
                switchObtido.IsToggled = false;
                switchDesejado.IsToggled = false;
                imgFoto.Source = null;
                _fotoPath = null;
            }
            catch (Exception ex)
            {
                await DisplayAlert("Erro", $"Erro ao salvar: {ex.Message}", "OK");
            }
        }
    }
}
