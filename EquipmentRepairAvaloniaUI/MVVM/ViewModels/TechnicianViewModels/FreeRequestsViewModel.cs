using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using EquipmentRepairAvaloniaUI.MVVM.Views.TechnicianViews;
using EquipmentRepairAvaloniaUI.MVVM.Views;
using EquipmentRepairDomain.EntityFramework.Models;
using EquipmentRepairDomain.Services;
using EquipmentRepairDomain.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace EquipmentRepairAvaloniaUI.MVVM.ViewModels.TechnicianViewModels;

public sealed partial class FreeRequestsViewModel(
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
      r.MasterId == null && r.Status == "Новая заявка"));
  }

  /// <summary>
  ///     Переход на страницу технолога
  /// </summary>
  [RelayCommand]
  private void NavigateToTechnicianPage()
  {
    var mainWindow = Application.Current?.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop
      ? desktop.MainWindow as MainView
      : null;

    // Navigate to the RegistrationView by setting the Content of the ContentControl
    if (mainWindow != null) mainWindow.Content = serviceProvider.GetRequiredService<TechnicianView>();
  }

  /// <summary>
  ///     Добавление заявки для выполнения
  /// </summary>
  [RelayCommand]
  private async Task ApplyRequest(Request request)
  {
    var requestCollection = (await requestService.GetAllRequestsAsync()).ToList();
    var addedRequest = requestCollection.FirstOrDefault(r => r.Id == request.Id);
    if (addedRequest == null) return;

    addedRequest.MasterId = sessionService.CurrentUser.Id;
    await requestService.UpdateRequestAsync(addedRequest);

    Requests.Remove(addedRequest);
  }
}