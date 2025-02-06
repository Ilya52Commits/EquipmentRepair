using System;
using System.Threading.Tasks;
using System.Windows;
using Avalonia.Controls.ApplicationLifetimes;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using EquipmentRepairAvaloniaUI.MVVM.Views;
using EquipmentRepairAvaloniaUI.MVVM.Views.ClientViews;
using EquipmentRepairDomain.Services;
using EquipmentRepairDomain.EntityFramework.Models;
using EquipmentRepairDomain.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Application = Avalonia.Application;

namespace EquipmentRepairAvaloniaUI.MVVM.ViewModels.ClientViewModels;

public sealed partial class AddApplicationViewModel(
  ISessionService sessionService,
  IServiceProvider serviceProvider,
  RequestService requestService) : ObservableObject
{
  [ObservableProperty] private string _typeEquipment = string.Empty;
  [ObservableProperty] private string _modelEquipment = string.Empty;
  [ObservableProperty] private string _descriptionFault = string.Empty;

  /// <summary>
  ///     Переход на страницу авторизации
  /// </summary>
  [RelayCommand]
  private void NavigateToClientPage()
  {
    var mainWindow = Application.Current.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop
      ? desktop.MainWindow as MainView
      : null;
    
    if (mainWindow != null)
      mainWindow.Content = serviceProvider.GetRequiredService<ClientView>();
  }

  /// <summary>
  ///     Добавление нового пользователя
  /// </summary>
  [RelayCommand]
  private async Task AddNewRequest()
  {
    var newRequest = new Request
    {
      StartDate = DateTime.Today.ToString("yyyy-MM-dd"),
      TypeEquipment = TypeEquipment,
      ModelEquipment = ModelEquipment,
      DescriptionFault = DescriptionFault,
      ClientId = sessionService.CurrentUser.Id,
      Status = "Новая заявка",
    };

    await requestService.AddRequestAsync(newRequest);

    MessageBox.Show("Успешно!", "Заявление успешно добавлено!", MessageBoxButton.OK, MessageBoxImage.Information);
  }
}