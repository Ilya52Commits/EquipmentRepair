using System.Windows;
using CommunityToolkit.Mvvm.Input;
using EquipmentRepair.EntityFramework;
using EquipmentRepair.EntityFramework.Models;
using EquipmentRepair.ViewModel;
using EquipmentRepair.Viws.ClientViews;

namespace EquipmentRepair.MVVM.ViewModels.ClientViewModels;

internal sealed partial class AddApplicationViewModel : BaseViewModel
{
  private readonly Context _context;

  private readonly Client _client;

  private string _typeEquipment;
  public string TypeEquipment
  {
    get => _typeEquipment;
    set
    {
      _typeEquipment = value;
      OnPropertyChanged();
    }
  }

  private string _modelEquipment;
  public string ModelEquipment
  {
    get => _modelEquipment;
    set
    {
      _modelEquipment = value;
      OnPropertyChanged();
    }
  }

  private string _descriptionFault;
  public string DescriptionFault
  {
    get => _descriptionFault;
    set
    {
      _descriptionFault = value;
      OnPropertyChanged();
    }
  }

  public AddApplicationViewModel(Client client)
  {
    _context = new Context();

    _client = client;

    _descriptionFault = string.Empty;
    _typeEquipment = string.Empty;
    _modelEquipment = string.Empty;
    
  }

  /// <summary>
  /// Метод перехода на страницу авторизации
  /// </summary>
  [RelayCommand]
  private void NavigateToClientPage()
  {
    _context.SaveChanges();

    var mainWindow = Application.Current.MainWindow as MainWindow;

    mainWindow?.MainFrame.NavigationService.Navigate(new ClientView(_client));
  }

  /// <summary>
  /// Добавление нового пользователя
  /// </summary>
  [RelayCommand]
  private void AddNewRequest()
  {
    var k = 1;

    while (true)
    {
      var isAlreadyBeenId = _context.Requests.FirstOrDefault(r => r.Id == k);

      if (isAlreadyBeenId == null)
        break;

      k++;
    }
    
    var newRequest = new Request
    {
      Id = k,
      StartDate = DateTime.Today.ToString("yyyy-MM-dd"),
      TypeEquipment = _typeEquipment,
      ModelEquipment = _modelEquipment,
      DescriptionFault = _descriptionFault,
      ClientId = _client.Id,
      Status = "Новая заявка",
    };

    _context.Requests.Add(newRequest);
    _context.SaveChanges();

    MessageBox.Show("Успешно!", "Заявление успешно добавлено!", MessageBoxButton.OK, MessageBoxImage.Information);
  }
}

