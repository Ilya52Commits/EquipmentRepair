using EquipmentRepair.Viws;
using EquipmentRepair.Viws.ClientViews;
using EquipmentRepair.Viws.TechnicianViews;
using GalaSoft.MvvmLight.Command;
using System.Windows;

namespace EquipmentRepair.ViewModel;
internal sealed class AuthorizationViewModel : BaseViewModel
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
    _dbContext = new DbContext();

    _login = string.Empty;
    _password = string.Empty;

    AuthorizationCommand = new RelayCommand(AuthorizationCommandExecute);
    NavigateToRegistrationPageCommand = new RelayCommand(NavigateToRegistrationPageCommandExecute);
  }

  /// <summary>
  /// Метод перехода на страницу авторизации
  /// </summary>
  private void NavigateToRegistrationPageCommandExecute()
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
    var foundClient = _dbContext.Clients.FirstOrDefault(client => client.Login == _login && client.Password == _password);
    var foundTechnician = _dbContext.Technicians.FirstOrDefault(client => client.Login == _login && client.Password == _password);

    if (foundClient != null)
    {
      MessageBox.Show("Здравствуйте, дорогой клиент!", "Успешно!", MessageBoxButton.OK, MessageBoxImage.Information);

      var mainWindow = Application.Current.MainWindow as MainWindow;

      mainWindow?.MainFrame.NavigationService.Navigate(new ClientView(foundClient));
    }
    else if (foundTechnician != null)
    {
      MessageBox.Show("Добрый день, уважаемый техник!", "Успешно!", MessageBoxButton.OK, MessageBoxImage.Information);

      var mainWindow = Application.Current.MainWindow as MainWindow;

      mainWindow?.MainFrame.NavigationService.Navigate(new TechnicianViews(foundTechnician));
    }
    else
    {
      MessageBox.Show("Не удалось войти!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
    }
  }
}
