using System.Collections.ObjectModel;
using System.Windows;
using CommunityToolkit.Mvvm.Input;
using EquipmentRepair.EntityFramework;
using EquipmentRepair.EntityFramework.Models;
using EquipmentRepair.ViewModel;
using EquipmentRepair.Viws.TechnicianViews;

namespace EquipmentRepair.MVVM.ViewModels.TechnicianViewModels;

internal sealed partial class FreeRequesrsViewModel : BaseViewModel
{
  private readonly Context _context;

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
  
  public FreeRequesrsViewModel(Technician technician)
  {
    _context = new();

    _technician = technician;
    
    _requests = new ObservableCollection<Request>(_context.Requests.Where(r => r.MasterId == null && r.Status == "Новая заявка"));
  }
  
  /// <summary>
  /// Метод перехода на страницу технолога
  /// </summary>
  [RelayCommand]
  public void NavigateToTechnicianPage()
  {
    _context.SaveChanges();

    var mainWindow = Application.Current.MainWindow as MainWindow;

    mainWindow?.MainFrame.NavigationService.Navigate(new TechnicianViews(_technician));
  }

  /// <summary>
  /// Метод добавления заявки для выполнения
  /// </summary>
  [RelayCommand]
  public void ApplyRequest(Request request)
  {

    var addedRequest = _context.Requests.FirstOrDefault(r => r.Id == request.Id);
    if (addedRequest == null) return; 

    addedRequest.MasterId = _technician.Id;
    _context.Update(addedRequest);
    _context.SaveChanges();

    _requests.Remove(addedRequest);
  }
}