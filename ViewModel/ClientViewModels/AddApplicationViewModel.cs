using EquipmentRepair.Models;
using EquipmentRepair.Viws.ClientViews;
using GalaSoft.MvvmLight.Command;
using System.Windows;

namespace EquipmentRepair.ViewModel.ClientViewModels;

internal sealed partial class AddApplicationViewModel : BaseViewModel
{
  private readonly DbContext _dbContext;

  private readonly Client _client;

  private int _numberApplication;
  public int NumberApplication
  {
    get => _numberApplication;
    set
    {
      _numberApplication = value;
      OnPropertyChanged();
    }
  }

  private string _addDate;
  public string AddDate
  {
    get => _addDate;
    set
    {
      _addDate = value;
      OnPropertyChanged();
    }
  }

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

  private string _nameClient;
  public string NameClient
  {
    get => _nameClient;
    set
    {
      _nameClient = value;
      OnPropertyChanged();
    }
  }

  private string _phone;
  public string Phone
  {
    get => _phone;
    set
    {
      _phone = value;
      OnPropertyChanged();
    }
  }

  public RelayCommand AddNewRequestCommand { get; }
  public RelayCommand NavigateToClientPageCommand { get; }

  public AddApplicationViewModel(Client client)
  {
    _dbContext = new();

    _client = client;

    _numberApplication = 0;
    _addDate = string.Empty;
    _descriptionFault = string.Empty;
    _typeEquipment = string.Empty;
    _modelEquipment = string.Empty;
    _nameClient = string.Empty;
    _phone = string.Empty;

    AddNewRequestCommand = new RelayCommand(AddNewRequestCommandExecude);
    NavigateToClientPageCommand = new RelayCommand(NavigateToClientPageCommandExecude);
  }

  /// <summary>
  /// Метод перехода на страницу авторизации
  /// </summary>
  private void NavigateToClientPageCommandExecude()
  {
    _dbContext.SaveChanges();

    var mainWindow = System.Windows.Application.Current.MainWindow as MainWindow;

    mainWindow?.MainFrame.NavigationService.Navigate(new ClientView(_client));
  }

  /// <summary>
  /// Добавление нового пользователя
  /// </summary>
  private void AddNewRequestCommandExecude()
  {
    var isNameClientValidate = _dbContext.Clients.FirstOrDefault(c => c.Name == _client.Name && c.Name == NameClient);

    if (isNameClientValidate == null)
    {
      MessageBox.Show("Некорректное имя!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
      return;
    }

    var newRequest = new Request
    {
      NubmerApplication = _numberApplication,
      AddDate = _addDate,
      TypeEquipment = _typeEquipment,
      ModelEquipment = _modelEquipment,
      DescriptionFault = _descriptionFault,
      NameClient = _nameClient,
      Phone = _phone,
      Status = "Новая заявка",
    };

    _dbContext.Requests.Add(newRequest);
    _dbContext.SaveChanges();

    MessageBox.Show("Успешно!", "Заявление успешно добавлено!", MessageBoxButton.OK, MessageBoxImage.Information);
  }
}

