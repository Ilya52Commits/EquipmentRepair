using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Avalonia.Controls.ApplicationLifetimes;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using EquipmentRepairAvaloniaUI.MVVM.Views;
using EquipmentRepairAvaloniaUI.MVVM.Views.AuthViews;
using EquipmentRepairAvaloniaUI.MVVM.Views.TechnicianViews;
using EquipmentRepairDomain.EntityFramework.Models;
using EquipmentRepairDomain.Services;
using EquipmentRepairDomain.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Application = Avalonia.Application;

namespace EquipmentRepairAvaloniaUI.MVVM.ViewModels.TechnicianViewModels;

public sealed partial class TechnicianViewModel(
  ISessionService sessionService,
  RequestService requestService,
  IServiceProvider serviceProvider)
  : ObservableObject
{
  [ObservableProperty] private ObservableCollection<Request> _requests = [];

  /// <summary>
  ///     Асинхронная инициализация ViewModel
  /// </summary>
  public async Task InitializeAsync()
  {
    await LoadRequestsAsync();
  }

  /// <summary>
  ///     Загрузка заявок
  /// </summary>
  private async Task LoadRequestsAsync()
  {
    var requestCollection = (await requestService.GetAllRequestsAsync()).ToList();
    Requests = new ObservableCollection<Request>(requestCollection.Where(r =>
      r.MasterId == sessionService.CurrentUser.Id));
  }

  /// <summary>
  ///     Переход на страницу авторизации
  /// </summary>
  [RelayCommand]
  private void NavigateToAuthorization()
  {
    var mainWindow = Application.Current?.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop
      ? desktop.MainWindow as MainView
      : null;

    if (mainWindow != null)
      mainWindow.Content = serviceProvider.GetRequiredService<AuthorizationView>();
  }

  /// <summary>
  ///     Переход на страницу свободных заявок
  /// </summary>
  [RelayCommand]
  private void NavigateToFreeRequestsPage()
  {
    var mainWindow = Application.Current?.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop
      ? desktop.MainWindow as MainView
      : null;

    if (mainWindow != null)
      mainWindow.Content = serviceProvider.GetRequiredService<FreeRequestsView>();
  }

  /// <summary>
  ///     Завершение работы над заявкой
  /// </summary>
  [RelayCommand]
  private async Task FinishRequest(Request request)
  {
    var finishedRequest = (await requestService.GetAllRequestsAsync()).FirstOrDefault(r => r.Id == request.Id);

    if (finishedRequest == null) return;

    finishedRequest.Status = "Готова к выдаче";
    finishedRequest.CompletionDate = DateTime.Today.ToString("yyyy-MM-dd");
    finishedRequest.MasterId = null;

    await requestService.UpdateRequestAsync(finishedRequest);
    Requests.Remove(finishedRequest);

    MessageBox.Show("Работа успешно выполнена!", "Успешно!", MessageBoxButton.OK, MessageBoxImage.Information);
  }
}