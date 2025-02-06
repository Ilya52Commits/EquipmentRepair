using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Avalonia.Controls.ApplicationLifetimes;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using EquipmentRepairAvaloniaUI.MVVM.Views;
using EquipmentRepairAvaloniaUI.MVVM.Views.AuthViews;
using EquipmentRepairAvaloniaUI.MVVM.Views.ClientViews;
using EquipmentRepairAvaloniaUI.MVVM.Views.TechnicianViews;
using EquipmentRepairDomain.Services;
using EquipmentRepairDomain.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Application = Avalonia.Application;

namespace EquipmentRepairAvaloniaUI.MVVM.ViewModels.AuthViewModels;

public partial class AuthorizationViewModel(
  ClientService clientService,
  TechnicianService technicianService,
  ISessionService sessionService,
  IServiceProvider serviceProvider)
  : ObservableObject
{
  [ObservableProperty] private string _login = string.Empty;
  [ObservableProperty] private string _password = string.Empty;

  /// <summary>
  ///     Переход на страницу авторизации
  /// </summary>
  [RelayCommand]
  private void NavigateToRegistrationPage()
  {
    var mainWindow = Application.Current.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop
      ? desktop.MainWindow as MainView
      : null;

    // Navigate to the RegistrationView by setting the Content of the ContentControl
    if (mainWindow != null)
    {
      mainWindow.Content = serviceProvider.GetRequiredService<RegistrationView>();
    }
  }

  /// <summary>
  ///     Авторизация пользователя
  /// </summary>
  [RelayCommand]
  private async Task Authorization()
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

      var mainWindow = Application.Current.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop
        ? desktop.MainWindow as MainView
        : null;

      // Navigate to the RegistrationView by setting the Content of the ContentControl
      if (mainWindow != null)
      {
        mainWindow.Content = serviceProvider.GetRequiredService<ClientView>();
      }
    }
    else if (foundTechnician != null)
    {
      sessionService.SetCurrentUser(foundTechnician, "Technician");

      MessageBox.Show("Добрый день, уважаемый техник!", "Успешно!", MessageBoxButton.OK, MessageBoxImage.Information);

      var mainWindow = Application.Current.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop
        ? desktop.MainWindow as MainView
        : null;

      // Navigate to the RegistrationView by setting the Content of the ContentControl
      if (mainWindow != null)
      {
        mainWindow.Content = serviceProvider.GetRequiredService<TechnicianView>();
      }
    }
    else
    {
      MessageBox.Show("Не удалось войти!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
    }
  }
}