using System.Windows;
using Verf1xWeatherApp.ViewModels;

namespace Verf1xWeatherApp;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public sealed partial class App : Application
{
    protected override void OnStartup(StartupEventArgs args)
    {
        Window main = new MainWindow();
        main.DataContext = new MainViewModel();
        main.Show();

        base.OnStartup(args);
    }
}
