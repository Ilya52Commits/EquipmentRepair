using System.Collections.ObjectModel;
using System.Windows;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using EquipmentRepair.MVVM.Views;
using EquipmentRepair.MVVM.Views.TechnicianViews;
using EquipmentRepairDomain.EntityFramework.Models;
using EquipmentRepairDomain.Services;
using EquipmentRepairDomain.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace EquipmentRepair.MVVM.ViewModels.TechnicianViewModels;

public sealed partial class FreeRequestsViewModel : ObservableObject
{
  private readonly RequestService _requestService;
  private readonly ISessionService _sessionService;
  private readonly IServiceProvider _serviceProvider;

  [ObservableProperty] private ObservableCollection<Request> _requests;

  public FreeRequestsViewModel(ISessionService sessionService, RequestService requestService,
    IServiceProvider serviceProvider)
  {
    _requestService = requestService;
    _serviceProvider = serviceProvider;
    _sessionService = sessionService;

    _ = LoadRequests();
  }

  private async Task LoadRequests()
  {
    var requestCollection = (await _requestService.GetAllRequestsAsync()).ToList();

    Requests = new ObservableCollection<Request>(requestCollection.Where(r =>
      r.MasterId == null && r.Status == "Новая заявка"));
  }

  /// <summary>
  ///     Переход на страницу технолога
  /// </summary>
  [RelayCommand]
  private void NavigateToTechnicianPage()
  {
    var mainWindow = Application.Current.MainWindow as MainView;
    mainWindow?.MainFrame.NavigationService.Navigate(_serviceProvider.GetRequiredService<TechnicianView>());
  }

  /// <summary>
  ///     Добавление заявки для выполнения
  /// </summary>
  [RelayCommand]
  private async Task ApplyRequestAsync(Request request)
  {
    var requestCollection = (await _requestService.GetAllRequestsAsync()).ToList();
    var addedRequest = requestCollection.FirstOrDefault(r => r.Id == request.Id);
    if (addedRequest == null) return;

    addedRequest.MasterId = _sessionService.CurrentUser.Id;
    await _requestService.UpdateRequestAsync(addedRequest);

    Requests.Remove(addedRequest);
  }
}