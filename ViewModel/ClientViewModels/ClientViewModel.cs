using EquipmentRepair.Models;
using EquipmentRepair.Viws;
using EquipmentRepair.Viws.ClientViews;
using GalaSoft.MvvmLight.Command;
using System.Collections.ObjectModel;

namespace EquipmentRepair.ViewModel.ClientViewModels;
internal sealed partial class ClientViewModel : BaseViewModel
{
  private readonly DbContext _dbContext;

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

  public RelayCommand NavigateToAddApplicationCommand { get; set; }
  public RelayCommand NavigateToAuthorizationCommand { get; set; }

  public ClientViewModel(Client client)
  {
    _dbContext = new();

    _client = client;

    _requests = new ObservableCollection<Request>(_dbContext.Requests.Where(r => r.NameClient == client.Name).ToList());

    NavigateToAddApplicationCommand = new RelayCommand(NavigateToAddApplicationCommandExecute);
    NavigateToAuthorizationCommand = new RelayCommand(NavigateToAuthorizationCommandExecute);
  }

  /// <summary>
  /// Метод перехода на страницу авторизации
  /// </summary>
  private void NavigateToAuthorizationCommandExecute()
  {
    var mainWindow = System.Windows.Application.Current.MainWindow as MainWindow;

    mainWindow?.MainFrame.NavigationService.Navigate(new AuthorizationView());
  }

  /// <summary>
  /// Метод перехода на страницу добавления заявки
  /// </summary>
  private void NavigateToAddApplicationCommandExecute()
  {
    var mainWindow = System.Windows.Application.Current.MainWindow as MainWindow;

    mainWindow?.MainFrame.NavigationService.Navigate(new AddApplicationView(_client));
  }
}
