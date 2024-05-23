using EquipmentRepair.Models;
using EquipmentRepair.Viws;
using GalaSoft.MvvmLight.Command;
using System.Windows;

namespace EquipmentRepair.ViewModel.ClientViewModels;

internal sealed partial class AddApplicationViewModel : BaseViewModel
{
  private readonly DbContext _dbContext;

  private string _numberApplication;
  public string NumberApplication
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

  private string _status;
  public string Status
  {
    get => _status;
    set
    {
      _status = value;
      OnPropertyChanged();
    }
  }

  public RelayCommand AddNewClientCommand { get; }
  public RelayCommand NavigateToAuthorizationPageCommand { get; }

  public AddApplicationViewModel()
  {
    _dbContext = new();


    _numberApplication = string.Empty;
    _descriptionFault = string.Empty;
    _typeEquipment = string.Empty;

    AddNewClientCommand = new RelayCommand(AddNewClientCommandExecude);
    NavigateToAuthorizationPageCommand = new RelayCommand(NavigateToAuthorizationPageCommandExecude);
  }

  /// <summary>
  /// Метод перехода на страницу авторизации
  /// </summary>
  private void NavigateToAuthorizationPageCommandExecude()
  {
    _dbContext.SaveChanges();

    var mainWindow = System.Windows.Application.Current.MainWindow as MainWindow;

    mainWindow?.MainFrame.NavigationService.Navigate(new AuthorizationView());
  }

  /// <summary>
  /// Добавление нового пользователя
  /// </summary>
  private void AddNewClientCommandExecude()
  {
    var newClient = new Client
    {
      
      Password = _descriptionFault,
    };

    _dbContext.Clients.Add(newClient);
    _dbContext.SaveChanges();

    MessageBox.Show("Успешно!", "Пользователь успешно добавлен!", MessageBoxButton.OK, MessageBoxImage.Information);

    NavigateToAuthorizationPageCommandExecude();
  }
}

