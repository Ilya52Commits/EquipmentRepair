using System.Net;
using System.Windows.Controls;
using EquipmentRepair.ViewModel;

namespace EquipmentRepair.Viws
{
  /// <summary>
  /// Логика взаимодействия для RegistrationView.xaml
  /// </summary>
  public partial class RegistrationView : Page
  {
    public RegistrationView()
    {
      InitializeComponent();

      var password = new NetworkCredential(string.Empty, PasswordBoxName.SecurePassword).Password;
      var confPassword = new NetworkCredential(string.Empty, ConfPasswordBoxName.SecurePassword).Password;
      
      DataContext = new RegistrationViewModel(password, confPassword);
    }
  }
}
