using EquipmentRepair.Models;
using EquipmentRepair.Viws;
using GalaSoft.MvvmLight.Command;
using System.Collections.ObjectModel;
using System.Windows;
using EquipmentRepair.Viws.TechnicianViews;

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
  public RelayCommand NavigateToFreeRequestsPageCommand { get; set; }
  public RelayCommand<Request> FinishrequestCommand { get; set; }

  public TechnicianViewModel(Technician technician)
  {
    _dbContext = new();

    _technician = technician;

    _requests = new ObservableCollection<Request>(_dbContext.Requests.Where(r => r.MasterId == _technician.Id));

    NavigateToAuthorizationCommand = new RelayCommand(NavigateToAuthorizationCommandExecute);
    NavigateToFreeRequestsPageCommand = new RelayCommand(NavigateToFreeRequestsPageCommandExecute);
    FinishrequestCommand = new RelayCommand<Request>(FinishrequestCommandExecute);
  }

  /// <summary>
  /// Метод перехода на страницу авторизации
  /// </summary>
  private void NavigateToAuthorizationCommandExecute()
  {
    _dbContext.SaveChanges();

    var mainWindow = Application.Current.MainWindow as MainWindow;

    mainWindow?.MainFrame.NavigationService.Navigate(new AuthorizationView());
  }
  
  /// <summary>
  /// Метод перехода на страницу свободных заявок
  /// </summary>
  private void NavigateToFreeRequestsPageCommandExecute() 
  {
    _dbContext.SaveChanges();

    var mainWindow = Application.Current.MainWindow as MainWindow;

    mainWindow?.MainFrame.NavigationService.Navigate(new FreeRequestsView(_technician));
  }

  /// <summary>
  /// Метод завершения работы над заявкой
  /// </summary>
  private void FinishrequestCommandExecute(Request request)
  {
    _dbContext.SaveChanges();

    var finishedRequest = _dbContext.Requests.FirstOrDefault(r => r.Id == request.Id);

    if (finishedRequest != null)
    {
      if (finishedRequest.Status != "Готова к выдаче")
      {
        MessageBox.Show("Выбирите нужный статус для завершения!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);

        return;
      }

      finishedRequest.CompletionDate = DateTime.Today.ToString("yyyy-MM-dd");

      finishedRequest.MasterId = null;
   

      MessageBox.Show("Работа успешно выполнена!", "Успешно!", MessageBoxButton.OK, MessageBoxImage.Information);


      _dbContext.Requests.Update(finishedRequest);
      _dbContext.SaveChanges();

      _requests.Remove(finishedRequest);
    }
  }
}