using System.Windows;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using EquipmentRepair.MVVM.Views;
using EquipmentRepair.MVVM.Views.AuthViews;
using EquipmentRepairDomain.EntityFramework.Models;
using EquipmentRepairDomain.Services;
using Microsoft.Extensions.DependencyInjection;

namespace EquipmentRepair.MVVM.ViewModels.AuthViewModels;

public sealed partial class RegistrationViewModel(ClientService clientService, IServiceProvider serviceProvider)
  :ObservableObject
{
  [ObservableProperty] private string _login = string.Empty; 
  [ObservableProperty] private string _email = string.Empty;
  [ObservableProperty] private string _password = string.Empty;
  [ObservableProperty] private string _confPassword = string.Empty;

  /// <summary>
  ///     Переход на страницу авторизации
  /// </summary>
  [RelayCommand]
  private void NavigateToAuthorizationPage()
  {
    var mainWindow = Application.Current.MainWindow as MainView;
    mainWindow?.MainFrame.NavigationService.Navigate(serviceProvider.GetRequiredService<AuthorizationView>());
  }

  /// <summary>
  ///     Добавление нового пользователя
  /// </summary>
  [RelayCommand]
  private async Task AddNewClientAsync()
  {
    var newClient = new Client
    {
      Login = Login,
      Password = Password
    };

    await clientService.AddClientAsync(newClient);

    MessageBox.Show("Успешно!", "Пользователь успешно добавлен!", MessageBoxButton.OK, MessageBoxImage.Information);

    NavigateToAuthorizationPage();
  }
}