using System.Collections.ObjectModel;
using System.Windows;
using EquipmentRepair.Models;
using EquipmentRepair.Viws.TechnicianViews;
using GalaSoft.MvvmLight.Command;

namespace EquipmentRepair.ViewModel.TechnicianViewModels;

internal sealed partial class FreeRequesrsViewModel : BaseViewModel
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
  
  public RelayCommand NavigateToTechnicianPageCommand { get; set; }
  public RelayCommand<Request> ApplyRequestCommand { get; set; }
  
  public FreeRequesrsViewModel(Technician technician)
  {
    _dbContext = new();

    _technician = technician;
    
    _requests = new ObservableCollection<Request>(_dbContext.Requests.Where(r => r.MastersId == null && r.Status == "Новая заявка"));

    NavigateToTechnicianPageCommand = new RelayCommand(NavigateToTechnicianPageCommandExecute);
    ApplyRequestCommand = new RelayCommand<Request>(ApplyRequestCommandExecute);
  }
  
  /// <summary>
  /// Метод перехода на страницу технолога
  /// </summary>
  private void NavigateToTechnicianPageCommandExecute()
  {
    _dbContext.SaveChanges();

    var mainWindow = Application.Current.MainWindow as MainWindow;

    mainWindow?.MainFrame.NavigationService.Navigate(new TechnicianViews(_technician));
  }

  /// <summary>
  /// Метод добавления заявки для выполнения
  /// </summary>
  private void ApplyRequestCommandExecute(Request request)
  {

    var addedRequest = _dbContext.Requests.FirstOrDefault(r => r.Id == request.Id);
    if (addedRequest == null) return; 

    addedRequest.MastersId.Add(_technician.Id);
    _dbContext.Update(addedRequest);
    _dbContext.SaveChanges();

    _requests.Remove(addedRequest);
  }
}