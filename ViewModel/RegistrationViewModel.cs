namespace EquipmentRepair.ViewModel;
internal sealed partial class RegistrationViewModel : BaseViewModel
{
  private readonly DbContext _dbContext;

  private string _passwordContent;
  private string _confPasswordContent; 
  
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
      _password = _passwordContent;
      OnPropertyChanged();
    }
  }

  private string _confPassword;
  public string ConfPassword
  {
    get => _confPassword;
    set
    {
      _confPassword = _confPasswordContent;
      OnPropertyChanged();
    }
  }
  
  public RegistrationViewModel(string password, string confPassword)
  {
    
  }
}

