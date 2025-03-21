using System;
using System.Threading.Tasks;
using System.Windows;
using Avalonia.Controls.ApplicationLifetimes;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using EquipmentRepairAvaloniaUI.MVVM.Views;
using EquipmentRepairAvaloniaUI.MVVM.Views.AuthViews;
using EquipmentRepairDomain.EntityFramework.Models;
using EquipmentRepairDomain.Exceptions;
using EquipmentRepairDomain.Services;
using Microsoft.Extensions.DependencyInjection;
using Application = Avalonia.Application;

namespace EquipmentRepairAvaloniaUI.MVVM.ViewModels.AuthViewModels;

public partial class RegistrationViewModel(ClientService clientService, IServiceProvider serviceProvider)
  : ObservableObject
{
  [ObservableProperty] private string _login = string.Empty;
  [ObservableProperty] private string _name = string.Empty;
  [ObservableProperty] private string _phone = string.Empty;
  [ObservableProperty] private string _password = string.Empty;
  [ObservableProperty] private string _confPassword = string.Empty;

  /// <summary>
  ///     Переход на страницу авторизации
  /// </summary>
  [RelayCommand]
  private void NavigateToAuthorizationPage()
  {
    var mainWindow = Application.Current?.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop
      ? desktop.MainWindow as MainView
      : null;

    // Navigate to the RegistrationView by setting the Content of the ContentControl
    if (mainWindow != null)
      mainWindow.Content = serviceProvider.GetRequiredService<AuthorizationView>();
  }

  /// <summary>
  ///     Добавление нового пользователя
  /// </summary>
  [RelayCommand]
  private async Task AddNewClient()
  {
    if (Password != ConfPassword)
    {
      MessageBox.Show("Пароли не совпадают", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
      return;
    }

    var newClient = new Client
    {
      Login = Login,
      Name = Name,
      Password = Password,
      Phone = Phone
    };

    try
    {
      await clientService.AddClientAsync(newClient);

      MessageBox.Show("Успешно!", "Пользователь успешно добавлен!", MessageBoxButton.OK, MessageBoxImage.Information);
      NavigateToAuthorizationPage();
    }
    catch (UserValidationException ex)
    {
      // Обработка ошибок валидации
      MessageBox.Show($"Ошибка валидации пользователя \"{ex.Message}\"", "Ошибка", MessageBoxButton.OK,
        MessageBoxImage.Error);
    }
  }
}