using System.Windows.Controls;
using EquipmentRepair.MVVM.ViewModels.AuthViewModels;

namespace EquipmentRepair.MVVM.Views.AuthViews;
/// <summary>
/// Логика взаимодействия для AuthorizationView.xaml
/// </summary>
public partial class AuthorizationView
{
  public AuthorizationView(AuthorizationViewModel authorizationViewModel)
  {
    InitializeComponent();
    
    DataContext = authorizationViewModel;
  }
}
