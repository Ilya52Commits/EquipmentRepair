using EquipmentRepair.Models;
using EquipmentRepair.Viws;
using EquipmentRepair.Viws.ClientViews;
using GalaSoft.MvvmLight.Command;
using Microsoft.VisualBasic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace EquipmentRepair.ViewModel.ClientViewModels;
internal sealed partial class ClientViewModel : BaseViewModel
{
  private readonly DbContext _dbContext = new();

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
    }
  }

  private ObservableCollection<Request> _selected;
  public ObservableCollection<Request> Selected
  {
    get =>_selected;
    private set
    {
      _selected = value; 
      OnPropertyChanged();
    }
  }

  public RelayCommand NavigateToAddApplicationCommand { get; set; }
  public RelayCommand NavigateToAuthorizationCommand { get; set; }

  public ClientViewModel(Client client)
  {
    _dbContext = new();

    _client = client;

    _requests = new ObservableCollection<Request>(_dbContext.Requests.Where(r => r.ClientId == client.Id).ToList());
  

    _selected = new ObservableCollection<Request>(_dbContext.Requests.Where(r => r.ClientId == client.Id).ToList());
    

    NavigateToAddApplicationCommand = new RelayCommand(NavigateToAddApplicationCommandExecute);
    NavigateToAuthorizationCommand = new RelayCommand(NavigateToAuthorizationCommandExecute);
  }

  /// <summary>
  /// Метод перехода на страницу авторизации
  /// </summary>
  private void NavigateToAuthorizationCommandExecute()
  {
    _dbContext.SaveChanges();

    var mainWindow = System.Windows.Application.Current.MainWindow as MainWindow;

    mainWindow?.MainFrame.NavigationService.Navigate(new AuthorizationView());
  }

  /// <summary>
  /// Метод перехода на страницу добавления заявки
  /// </summary>
  private void NavigateToAddApplicationCommandExecute()
  {
    _dbContext.SaveChanges();

    var mainWindow = System.Windows.Application.Current.MainWindow as MainWindow;

    mainWindow?.MainFrame.NavigationService.Navigate(new AddApplicationView(_client));
  }


}
