using System.Windows;
using CommunityToolkit.Mvvm.Input;
using EquipmentRepair.EntityFramework;
using EquipmentRepair.ViewModel;
using EquipmentRepair.Viws;
using EquipmentRepair.Viws.ClientViews;
using EquipmentRepair.Viws.TechnicianViews;

namespace EquipmentRepair.MVVM.ViewModels;
internal sealed partial class AuthorizationViewModel : BaseViewModel
{
  private readonly Context _context;

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

  public AuthorizationViewModel()
  {
    _context = new Context();

    _login = string.Empty;
    _password = string.Empty;
  }

  /// <summary>
  /// Метод перехода на страницу авторизации
  /// </summary>
  [RelayCommand]
  private void NavigateToRegistrationPage()
  {
    _context.SaveChanges();

    var mainWindow = Application.Current.MainWindow as MainWindow;

    mainWindow?.MainFrame.NavigationService.Navigate(new RegistrationView());
  }

  /// <summary>
  /// Авторизация пользователя
  /// </summary>
  [RelayCommand]
  private void Authorization()
  {
    var foundClient = _context.Clients.FirstOrDefault(client => client.Login == _login && client.Password == _password);
    var foundTechnician = _context.Technicians.FirstOrDefault(client => client.Login == _login && client.Password == _password);

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
