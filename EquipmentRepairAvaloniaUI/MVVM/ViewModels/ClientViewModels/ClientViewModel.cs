using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using EquipmentRepairAvaloniaUI.MVVM.Views;
using EquipmentRepairAvaloniaUI.MVVM.Views.AuthViews;
using EquipmentRepairAvaloniaUI.MVVM.Views.ClientViews;
using EquipmentRepairDomain.EntityFramework.Models;
using EquipmentRepairDomain.Services;
using EquipmentRepairDomain.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace EquipmentRepairAvaloniaUI.MVVM.ViewModels.ClientViewModels;

public partial class ClientViewModel : ObservableObject
{
  private readonly RequestService _requestService;
  private readonly ISessionService _sessionService;
  private readonly IServiceProvider _serviceProvider;

  [ObservableProperty] private ObservableCollection<Request> _requests;
  [ObservableProperty] private ObservableCollection<Request> _selected;
  [ObservableProperty] private ObservableCollection<string> _notification;

  private string _pattern;
  public string Pattern
  {
    get => _pattern;
    set
    {
      _pattern = value;
      OnPropertyChanged();
      PerformSearch();
    }
  }

  public ClientViewModel(ISessionService sessionService, RequestService requestService,
    IServiceProvider serviceProvider)
  {
    _requestService = requestService;
    _sessionService = sessionService;
    _serviceProvider = serviceProvider;

    _ = LoadAsync();

    _pattern = string.Empty;
    _notification = [];
  }

  /// <summary>
  ///     Загрузка контента
  /// </summary>
  private async Task LoadAsync()
  {
    var requestsCollection = (await _requestService.GetAllRequestsAsync()).ToList();

    Requests = new ObservableCollection<Request>(requestsCollection.Where(r =>
      r.ClientId == _sessionService.CurrentUser.Id));
    Selected = new ObservableCollection<Request>(requestsCollection
      .Where(r => r.ClientId == _sessionService.CurrentUser.Id).ToList());
  }

  /// <summary>
  ///     Переход на страницу авторизации
  /// </summary>
  [RelayCommand]
  private void NavigateToAuthorization()
  {
    var mainWindow = Application.Current.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop
      ? desktop.MainWindow as MainView
      : null;

    if (mainWindow != null)
      mainWindow.Content = _serviceProvider.GetRequiredService<AuthorizationView>();
  }

  /// <summary>
  ///     Переход на страницу добавления заявки
  /// </summary>
  [RelayCommand]
  private void NavigateToAddApplication()
  {
    var mainWindow = Application.Current.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop
      ? desktop.MainWindow as MainView
      : null;

    if (mainWindow != null)
      mainWindow.Content = _serviceProvider.GetRequiredService<AddApplicationView>();
  }

  /// <summary>
  ///     Удаление заявки
  /// </summary>
  /// <param name="request"></param>
  [RelayCommand]
  private async Task DeleteRequestAsync(Request request)
  {
    await _requestService.DeleteRequestAsync(request.Id);
    Requests.Remove(request);
  }

  /// <summary>
  ///     Поиск данных
  /// </summary>
  private void PerformSearch()
  {
    Requests.Clear();

    foreach (var item in Selected)
      if (item.Id.ToString().StartsWith(Pattern, StringComparison.OrdinalIgnoreCase))
        Requests.Add(item);
  }
}