using System.Collections.ObjectModel;
using System.Windows;
using CommunityToolkit.Mvvm.Input;
using EquipmentRepair.EntityFramework;
using EquipmentRepair.EntityFramework.Models;
using EquipmentRepair.ViewModel;
using EquipmentRepair.Viws;
using EquipmentRepair.Viws.TechnicianViews;

namespace EquipmentRepair.MVVM.ViewModels.TechnicianViewModels;
internal sealed partial class TechnicianViewModel : BaseViewModel
{
  private readonly Context _context;

  private readonly Technician _technician;

  private readonly ObservableCollection<Request> _requests;
  

  public TechnicianViewModel(Technician technician)
  {
    _context = new Context();

    _technician = technician;

    _requests = new ObservableCollection<Request>(_context.Requests.Where(r => r.MasterId == _technician.Id));
  }

  /// <summary>
  /// Метод перехода на страницу авторизации
  /// </summary>
  [RelayCommand]
  private void NavigateToAuthorizationCommandExecute()
  {
    _context.SaveChanges();

    var mainWindow = Application.Current.MainWindow as MainWindow;

    mainWindow?.MainFrame.NavigationService.Navigate(new AuthorizationView());
  }
  
  /// <summary>
  /// Метод перехода на страницу свободных заявок
  /// </summary>
  [RelayCommand]
  private void NavigateToFreeRequestsPageCommandExecute() 
  {
    _context.SaveChanges();

    var mainWindow = Application.Current.MainWindow as MainWindow;

    mainWindow?.MainFrame.NavigationService.Navigate(new FreeRequestsView(_technician));
  }

  /// <summary>
  /// Метод завершения работы над заявкой
  /// </summary>
  [RelayCommand]
  private void FinishRequestCommandExecute(Request request)
  {
    _context.SaveChanges();

    var finishedRequest = _context.Requests.FirstOrDefault(r => r.Id == request.Id);

    if (finishedRequest == null) return;
    if (finishedRequest.Status != "Готова к выдаче")
    {
      MessageBox.Show("Выбирите нужный статус для завершения!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);

      return;
    }

    finishedRequest.CompletionDate = DateTime.Today.ToString("yyyy-MM-dd");

    finishedRequest.MasterId = null;
   

    MessageBox.Show("Работа успешно выполнена!", "Успешно!", MessageBoxButton.OK, MessageBoxImage.Information);


    _context.Requests.Update(finishedRequest);
    _context.SaveChanges();

    _requests.Remove(finishedRequest);
  }
}