using EquipmentRepair.Models;
using EquipmentRepair.Viws;
using GalaSoft.MvvmLight.Command;
using System.Collections.ObjectModel;
using System.Windows;

namespace EquipmentRepair.ViewModel.TechnicianViewModels;
internal sealed partial class TechnicianViewModel : BaseViewModel
{
  private readonly DbContext _dbContext;

  private readonly Technician _technician;

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

  public RelayCommand NavigateToAuthorizationCommand { get; set; }

  public TechnicianViewModel(Technician technician)
  {
    _dbContext = new();

    _technician = technician;

    _requests = new ObservableCollection<Request>(_dbContext.Requests.Where(r => r.MasterId == _technician.Id));

    NavigateToAuthorizationCommand = new RelayCommand(NavigateToAuthorizationCommandExecute);
  }

  /// <summary>
  /// Метод перехода на страницу авторизации
  /// </summary>
  private void NavigateToAuthorizationCommandExecute()
  {
    var mainWindow = Application.Current.MainWindow as MainWindow;

    mainWindow?.MainFrame.NavigationService.Navigate(new AuthorizationView());
  }
}

