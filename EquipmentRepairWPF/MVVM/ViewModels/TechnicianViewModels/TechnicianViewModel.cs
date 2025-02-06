using System.Collections.ObjectModel;
using System.Windows;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using EquipmentRepair.MVVM.Views;
using EquipmentRepair.MVVM.Views.AuthViews;
using EquipmentRepair.MVVM.Views.TechnicianViews;
using EquipmentRepairDomain.EntityFramework.Models;
using EquipmentRepairDomain.Services;
using EquipmentRepairDomain.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace EquipmentRepair.MVVM.ViewModels.TechnicianViewModels;

public sealed partial class TechnicianViewModel:ObservableObject
{
  private readonly RequestService _requestService;
  private readonly ISessionService _sessionService;
  private readonly IServiceProvider _serviceProvider;

  [ObservableProperty] private ObservableCollection<Request> _requests;
  
  public TechnicianViewModel(ISessionService sessionService, RequestService requestService, IServiceProvider serviceProvider)
  {
    _requestService = requestService;
    _serviceProvider = serviceProvider;
    _sessionService = sessionService;

    _ = LoadRequests();
  }
  
  private async Task LoadRequests()
  {
    var requestCollection = (await _requestService.GetAllRequestsAsync()).ToList();
    Requests = new ObservableCollection<Request>(requestCollection.Where(r => r.MasterId == _sessionService.CurrentUser.Id));
  }

  /// <summary>
  ///     Переход на страницу авторизации
  /// </summary>
  [RelayCommand]
  private void NavigateToAuthorization()
  {
    var mainWindow = Application.Current.MainWindow as MainView;
    mainWindow?.MainFrame.NavigationService.Navigate(_serviceProvider.GetRequiredService<AuthorizationView>());
  }
  
  /// <summary>
  ///     Переход на страницу свободных заявок
  /// </summary>
  [RelayCommand]
  private void NavigateToFreeRequestsPage() 
  {
    var mainWindow = Application.Current.MainWindow as MainView;
    mainWindow?.MainFrame.NavigationService.Navigate(_serviceProvider.GetRequiredService<FreeRequestsView>());
  }

  /// <summary>
  ///     Завершение работы над заявкой
  /// </summary>
  [RelayCommand]
  private async Task FinishRequestAsync(Request request)
  {
    var finishedRequest = (await _requestService.GetAllRequestsAsync()).FirstOrDefault(r => r.Id == request.Id);

    if (finishedRequest == null) return;

    finishedRequest.Status = "Готова к выдаче";
    finishedRequest.CompletionDate = DateTime.Today.ToString("yyyy-MM-dd");
    finishedRequest.MasterId = null;
    
    await _requestService.UpdateRequestAsync(finishedRequest);
    Requests.Remove(finishedRequest);

    MessageBox.Show("Работа успешно выполнена!", "Успешно!", MessageBoxButton.OK, MessageBoxImage.Information);
  }
}