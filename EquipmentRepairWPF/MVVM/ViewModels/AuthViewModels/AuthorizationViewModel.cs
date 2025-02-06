using System.Windows;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using EquipmentRepair.MVVM.Views;
using EquipmentRepair.MVVM.Views.AuthViews;
using EquipmentRepair.MVVM.Views.ClientViews;
using EquipmentRepair.MVVM.Views.TechnicianViews;
using EquipmentRepairDomain.Services;
using EquipmentRepairDomain.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace EquipmentRepair.MVVM.ViewModels.AuthViewModels;

public sealed partial class AuthorizationViewModel(
  ClientService clientService,
  TechnicianService technicianService,
  ISessionService sessionService,
  IServiceProvider serviceProvider) : ObservableObject
{
  [ObservableProperty] private string _login = string.Empty;
  [ObservableProperty] private string _password = string.Empty;

  /// <summary>
  ///     Переход на страницу авторизации
  /// </summary>
  [RelayCommand]
  private void NavigateToRegistrationPage()
  {
    var mainWindow = Application.Current.MainWindow as MainView;
    mainWindow?.MainFrame.NavigationService.Navigate(serviceProvider.GetRequiredService<RegistrationView>());
  }

  /// <summary>
  ///     Авторизация пользователя
  /// </summary>
  [RelayCommand]
  private async Task AuthorizationAsync()
  {
    var foundClientCollection = await clientService.GetAllClientsAsync();
    var foundTechnicianCollection = await technicianService.GetAllTechniciansAsync();

    var foundClient =
      foundClientCollection.FirstOrDefault(client => client.Login == Login && client.Password == Password);
    var foundTechnician =
      foundTechnicianCollection.FirstOrDefault(client => client.Login == Login && client.Password == Password);

    if (foundClient != null)
    {
      sessionService.SetCurrentUser(foundClient, "Client");

      MessageBox.Show("Здравствуйте, дорогой клиент!", "Успешно!", MessageBoxButton.OK, MessageBoxImage.Information);

      var mainWindow = Application.Current.MainWindow as MainView;
      mainWindow?.MainFrame.NavigationService.Navigate(serviceProvider.GetRequiredService<ClientView>());
    }
    else if (foundTechnician != null)
    {
      sessionService.SetCurrentUser(foundTechnician, "Technician");

      MessageBox.Show("Добрый день, уважаемый техник!", "Успешно!", MessageBoxButton.OK, MessageBoxImage.Information);

      var mainWindow = Application.Current.MainWindow as MainView;
      mainWindow?.MainFrame.NavigationService.Navigate(serviceProvider.GetRequiredService<TechnicianView>());
    }
    else
    {
      MessageBox.Show("Не удалось войти!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
    }
  }
}