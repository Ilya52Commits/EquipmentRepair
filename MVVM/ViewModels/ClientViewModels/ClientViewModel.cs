using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.Input;
using EquipmentRepair.EntityFramework;
using EquipmentRepair.EntityFramework.Models;
using EquipmentRepair.ViewModel;
using EquipmentRepair.Viws;
using EquipmentRepair.Viws.ClientViews;

namespace EquipmentRepair.MVVM.ViewModels.ClientViewModels;
internal sealed partial class ClientViewModel : BaseViewModel
{
  private readonly Context _context;

  private readonly Client _client;

  private ObservableCollection<Request> _requests;
  public ObservableCollection<Request> Requests
  {
    get => _requests;
    private set
    {
      _requests = value;
      OnPropertyChanged();
    }
  }

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


  private ObservableCollection<Request> _selected;
  public ObservableCollection<Request> Selected
  {
    get =>_selected;
    set
    {
      _selected = value; 
      OnPropertyChanged();
    }
  }


  private ObservableCollection<String> _notification;
  public ObservableCollection<String> Notifications
  {
    get => _notification; 
    set
    {
      _notification = value;
      OnPropertyChanged();
    }
  }

  public ClientViewModel(Client client)
  {
    _context = new Context();

    _client = client;

    _requests = new ObservableCollection<Request>(_context.Requests.Where(r => r.ClientId == client.Id).ToList());

    _selected = new ObservableCollection<Request>(_context.Requests.Where(r => r.ClientId == client.Id).ToList());

    _pattern = string.Empty;

    _notification = [];

  }

  /// <summary>
  /// Метод перехода на страницу авторизации
  /// </summary>
  [RelayCommand]
  private void NavigateToAuthorization()
  {
    _context.SaveChanges();

    var mainWindow = System.Windows.Application.Current.MainWindow as MainWindow;

    mainWindow?.MainFrame.NavigationService.Navigate(new AuthorizationView());
  }

  /// <summary>
  /// Метод перехода на страницу добавления заявки
  /// </summary>
  [RelayCommand]
  private void NavigateToAddApplication()
  {
    _context.SaveChanges();

    var mainWindow = System.Windows.Application.Current.MainWindow as MainWindow;

    mainWindow?.MainFrame.NavigationService.Navigate(new AddApplicationView(_client));
  }

  // Как это работет, ебать??

  /// <summary>
  /// Метод для поиска
  /// </summary>
  private void PerformSearch()
  {
    // Очистите коллекцию результатов поиска перед выполнением нового поиска
    Requests.Clear();

    // Выполните поиск в коллекции MyCollection на основе поискового запроса
    foreach (var item in Selected)
    {
      if (item.Id.ToString().StartsWith(Pattern, StringComparison.OrdinalIgnoreCase))
      {
        Requests.Add(item);
      }
    }
  }

  //***************************
}
