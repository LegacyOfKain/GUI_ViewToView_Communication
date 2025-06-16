using Microsoft.Extensions.DependencyInjection;
using System.Windows;
using WpfViewToViewCommunication.EventAggregators;
using WpfViewToViewCommunication.Services;
using WpfViewToViewCommunication.ViewModels;
using WpfViewToViewCommunication.Views;

namespace WpfViewToViewCommunication;

public partial class App : Application
{
    public IServiceProvider ServiceProvider { get; private set; }

    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);

        var serviceCollection = new ServiceCollection();
        ConfigureServices(serviceCollection);

        ServiceProvider = serviceCollection.BuildServiceProvider();

        var mainWindow = ServiceProvider.GetRequiredService<MainWindow>();
        mainWindow.Show();
    }

    private void ConfigureServices(IServiceCollection services)
    {
        // Register your services here
        services.AddSingleton<EventAggregator>();
        services.AddTransient<MainViewModel>();
        services.AddTransient<PersonDialogViewModel>();

        // Register your views
        services.AddTransient<MainWindow>();
        services.AddTransient<PersonDialogView>();

        // Register any other services your application needs
        services.AddSingleton<IDialogService, DialogService>();
    }
}

