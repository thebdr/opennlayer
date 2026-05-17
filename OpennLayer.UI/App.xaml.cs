using Microsoft.Extensions.DependencyInjection;
using System.Windows;
using OpennLayer.Application.Services;
using OpennLayer.UI.ViewModels;

namespace OpennLayer.UI
{
    public partial class App : System.Windows.Application
    {
        public static ServiceProvider ServiceProvider { get; private set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            var services = new ServiceCollection();

            // Register services
            services.AddSingleton<TiaPortalService>();
            services.AddSingleton<MainViewModel>();

            ServiceProvider = services.BuildServiceProvider();

            var mainWindow = new MainWindow
            {
                DataContext = ServiceProvider.GetRequiredService<MainViewModel>()
            };

            mainWindow.Show();

            base.OnStartup(e);
        }
    }
}