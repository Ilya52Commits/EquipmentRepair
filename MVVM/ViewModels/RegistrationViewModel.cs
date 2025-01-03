using System.Windows;
using CommunityToolkit.Mvvm.Input;
using EquipmentRepair.EntityFramework;
using EquipmentRepair.EntityFramework.Models;
using EquipmentRepair.ViewModel;
using EquipmentRepair.Viws;

namespace EquipmentRepair.MVVM.ViewModels;
internal sealed partial class RegistrationViewModel : BaseViewModel
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

  public RegistrationViewModel()
  {
    _context = new Context();

    _login = string.Empty;
    _email = string.Empty;
    _password = string.Empty; 
    _confPassword = string.Empty;
  }

  /// <summary>
  /// Метод перехода на страницу авторизации
  /// </summary>
  [RelayCommand]
  private void NavigateToAuthorizationPage()
  {
    _context.SaveChanges();

    var mainWindow = Application.Current.MainWindow as MainWindow;

    mainWindow?.MainFrame.NavigationService.Navigate(new AuthorizationView());
  }

  /// <summary>
  /// Добавление нового пользователя
  /// </summary>
  [RelayCommand]
  private void AddNewClient()
  {
    var newClient = new Client
    {
      Login = _login,
      Password = _password
    };

    _context.Clients.Add(newClient);
    _context.SaveChanges();

    MessageBox.Show("Успешно!", "Пользователь успешно добавлен!", MessageBoxButton.OK, MessageBoxImage.Information);

    NavigateToAuthorizationPage();
  }
}

