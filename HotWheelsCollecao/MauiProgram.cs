using Microsoft.Maui;
using Microsoft.Maui.Controls.Hosting;
using Microsoft.Maui.Hosting;
using HotWheelsCollecao.Controllers;
using HotWheelsCollecao.Services;

namespace HotWheelsCollecao
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();

            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                    // Adicione mais fontes se desejar
                });

            // Injeção de dependência (registrando os serviços)
            builder.Services.AddSingleton<CarService>();
            builder.Services.AddSingleton<CarController>();

            // Views (se quiser usar injeção nelas também)
            // builder.Services.AddTransient<ListaPage>();
            // builder.Services.AddTransient<CadastroPage>();

            return builder.Build();
        }
    }
}
