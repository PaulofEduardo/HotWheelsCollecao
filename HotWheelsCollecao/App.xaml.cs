using Microsoft.Maui.Controls;

namespace HotWheelsCollecao
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            // Define a página inicial do app
            MainPage = new AppShell();
        }
    }
}
