using System.IO;
using System.Windows;
using EquipmentRepair.MVVM.ViewModels.AuthViewModels;
using EquipmentRepair.MVVM.ViewModels.ClientViewModels;
using EquipmentRepair.MVVM.ViewModels.TechnicianViewModels;
using EquipmentRepair.MVVM.Views;
using EquipmentRepair.MVVM.Views.AuthViews;
using EquipmentRepair.MVVM.Views.ClientViews;
using EquipmentRepair.MVVM.Views.TechnicianViews;
using EquipmentRepairDomain;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EquipmentRepair;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App
{
  protected override void OnStartup(StartupEventArgs e)
  {
    // Загрузка конфигурации
    var configuration = new ConfigurationBuilder()
      .SetBasePath(Directory.GetCurrentDirectory())
      .AddJsonFile("appsettings.json")
      .Build();

    var serviceCollection = new ServiceCollection();
    ServiceConfigurator.ConfigureServices(serviceCollection, configuration);

    serviceCollection.AddTransient<RegistrationViewModel>();
    serviceCollection.AddTransient<RegistrationView>();

    serviceCollection.AddTransient<ClientViewModel>();
    serviceCollection.AddTransient<ClientView>();

    serviceCollection.AddTransient<AuthorizationViewModel>();
    serviceCollection.AddTransient<AuthorizationView>();

    serviceCollection.AddTransient<TechnicianViewModel>();
    serviceCollection.AddTransient<TechnicianView>();

    serviceCollection.AddTransient<FreeRequestsViewModel>();
    serviceCollection.AddTransient<FreeRequestsView>();

    serviceCollection.AddTransient<AddApplicationViewModel>();
    serviceCollection.AddTransient<AddApplicationView>();

    var serviceProvider = serviceCollection.BuildServiceProvider();

    // Создание MainView с передачей AuthorizationView
    var mainView = new MainView(serviceProvider.GetRequiredService<AuthorizationView>());

    MainWindow = mainView;

    MainWindow.Show();
  }
}