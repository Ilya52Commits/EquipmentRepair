using EquipmentRepair.Models;
using EquipmentRepair.Viws;
using GalaSoft.MvvmLight.Command;
using System.Windows;

namespace EquipmentRepair.ViewModel;
internal sealed partial class RegistrationViewModel : BaseViewModel
{
  private readonly DbContext _dbContext;

  private string _login; 
  public string Login
  {
    get => _login;
    set
    {
      _login = value;
      OnPropertyChanged();
    }
  }

  private string _email;
  public string Email
  {
    get => _email;
    set
    {
      _email = value;
      OnPropertyChanged();
    }
  }

  private string _password;
  public string Password
  {
    get => _password;
    set
    {
      _password = value;
      OnPropertyChanged();
    }
  }


  private string _confPassword;
  public string ConfPassword
  {
    get => _confPassword;
    set
    {
      _confPassword = value;
      OnPropertyChanged();
    }
  }

  public RelayCommand AddNewClientCommand { get; } 
  public RelayCommand NavigateToAuthorizationPageCommand { get; }

  public RegistrationViewModel()
  {
    _dbContext = new();

    _login = string.Empty;
    _email = string.Empty;
    _password = string.Empty; 
    _confPassword = string.Empty;

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
      Login = _login,
      Email = _email,
      Password = _password,
    };

    _dbContext.Clients.Add(newClient);
    _dbContext.SaveChanges();

    MessageBox.Show("Успешно!", "Пользователь успешно добавлен!", MessageBoxButton.OK, MessageBoxImage.Information);

    NavigateToAuthorizationPageCommandExecude();
  }
}

