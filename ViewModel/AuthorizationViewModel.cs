using EquipmentRepair.Viws;
using EquipmentRepair.Viws.ClientViews;
using GalaSoft.MvvmLight.Command;
using System.Windows;

namespace EquipmentRepair.ViewModel;
internal sealed partial class AuthorizationViewModel : BaseViewModel
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

  public RelayCommand AuthorizationCommand { get; }
  public RelayCommand NavigateToRegistrationPageCommand { get; }

  public AuthorizationViewModel()
  {
    _dbContext = new();

    _login = string.Empty;
    _password = string.Empty;

    AuthorizationCommand = new RelayCommand(AuthorizationCommandExecute);
    NavigateToRegistrationPageCommand = new RelayCommand(NavigateToRegistrationPageCommandExecude);
  }

  /// <summary>
  /// Метод перехода на страницу авторизации
  /// </summary>
  private void NavigateToRegistrationPageCommandExecude()
  {
    _dbContext.SaveChanges();

    var mainWindow = Application.Current.MainWindow as MainWindow;

    mainWindow?.MainFrame.NavigationService.Navigate(new RegistrationView());
  }

  /// <summary>
  /// Авторизация пользователя
  /// </summary>
  private void AuthorizationCommandExecute()
  {
    var findedClient = _dbContext.Clients.FirstOrDefault(client => client.Login == _login && client.Password == _password);

    if (findedClient != null)
    {
      MessageBox.Show("Здравствуйте, дорогой клиент!", "Успешно!", MessageBoxButton.OK, MessageBoxImage.Information);

      var mainWindow = Application.Current.MainWindow as MainWindow;

      mainWindow?.MainFrame.NavigationService.Navigate(new ClientView(findedClient));
    }
    else
    {
      MessageBox.Show("Не удалось войти!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
    }
  }
}
