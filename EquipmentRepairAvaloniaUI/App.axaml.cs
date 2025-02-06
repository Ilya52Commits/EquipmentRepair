using System.IO;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Data.Core.Plugins;
using Avalonia.Markup.Xaml;
using System.Linq;
using EquipmentRepairAvaloniaUI.MVVM.Views.ClientViews;
using EquipmentRepairAvaloniaUI.MVVM.ViewModels.AuthViewModels;
using EquipmentRepairAvaloniaUI.MVVM.ViewModels.ClientViewModels;
using EquipmentRepairAvaloniaUI.MVVM.ViewModels.TechnicianViewModels;
using EquipmentRepairAvaloniaUI.MVVM.Views;
using EquipmentRepairAvaloniaUI.MVVM.Views.AuthViews;
using EquipmentRepairAvaloniaUI.MVVM.Views.TechnicianViews;
using EquipmentRepairDomain;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EquipmentRepairAvaloniaUI;

public class App : Application
{
  public override void Initialize()
  {
    AvaloniaXamlLoader.Load(this);
  }

  public override void OnFrameworkInitializationCompleted()
  {
    var configuration = new ConfigurationBuilder()
      .SetBasePath(Directory.GetCurrentDirectory())
      .AddJsonFile("appsettings.json")
      .Build();

    var serviceCollection = new ServiceCollection();
    ServiceConfigurator.ConfigureServices(serviceCollection, configuration);

    serviceCollection.AddTransient<FreeRequestsViewModel>();
    serviceCollection.AddTransient<FreeRequestsView>();

    serviceCollection.AddTransient<AddApplicationViewModel>();
    serviceCollection.AddTransient<AddApplicationView>();

    serviceCollection.AddTransient<RegistrationViewModel>();
    serviceCollection.AddTransient<RegistrationView>();

    serviceCollection.AddTransient<ClientViewModel>();
    serviceCollection.AddTransient<ClientView>();

    serviceCollection.AddTransient<AuthorizationViewModel>();
    serviceCollection.AddTransient<AuthorizationView>();

    serviceCollection.AddTransient<TechnicianViewModel>();
    serviceCollection.AddTransient<TechnicianView>();

    var serviceProvider = serviceCollection.BuildServiceProvider();

    if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
    {
      DisableAvaloniaDataAnnotationValidation();
      var mainView = new MainView();

      var authorizationView = serviceProvider.GetRequiredService<AuthorizationView>();

      mainView.SetContent(authorizationView);

      desktop.MainWindow = mainView;
    }

    base.OnFrameworkInitializationCompleted();
  }

  private static void DisableAvaloniaDataAnnotationValidation()
  {
    // Get an array of plugins to remove
    var dataValidationPluginsToRemove =
      BindingPlugins.DataValidators.OfType<DataAnnotationsValidationPlugin>().ToArray();

    // remove each entry found
    foreach (var plugin in dataValidationPluginsToRemove) BindingPlugins.DataValidators.Remove(plugin);
  }
}