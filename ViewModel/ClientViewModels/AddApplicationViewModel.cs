using EquipmentRepair.Models;
using EquipmentRepair.Viws.ClientViews;
using GalaSoft.MvvmLight.Command;
using System.Windows;

namespace EquipmentRepair.ViewModel.ClientViewModels;

internal sealed class AddApplicationViewModel : BaseViewModel
{
  private readonly DbContext _dbContext;

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

  public RelayCommand AddNewRequestCommand { get; }
  public RelayCommand NavigateToClientPageCommand { get; }

  public AddApplicationViewModel(Client client)
  {
    _dbContext = new DbContext();

    _client = client;

    _descriptionFault = string.Empty;
    _typeEquipment = string.Empty;
    _modelEquipment = string.Empty;

    AddNewRequestCommand = new RelayCommand(AddNewRequestCommandExecute);
    NavigateToClientPageCommand = new RelayCommand(NavigateToClientPageCommandExecute);
  }

  /// <summary>
  /// Метод перехода на страницу авторизации
  /// </summary>
  private void NavigateToClientPageCommandExecute()
  {
    _dbContext.SaveChanges();

    var mainWindow = Application.Current.MainWindow as MainWindow;

    mainWindow?.MainFrame.NavigationService.Navigate(new ClientView(_client));
  }

  /// <summary>
  /// Добавление нового пользователя
  /// </summary>
  private void AddNewRequestCommandExecute()
  {
    var k = 1;

    while (true)
    {
      var isAlreadyBeenId = _dbContext.Requests.FirstOrDefault(r => r.Id == k);

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

    _dbContext.Requests.Add(newRequest);
    _dbContext.SaveChanges();

    MessageBox.Show("Успешно!", "Заявление успешно добавлено!", MessageBoxButton.OK, MessageBoxImage.Information);
  }
}

