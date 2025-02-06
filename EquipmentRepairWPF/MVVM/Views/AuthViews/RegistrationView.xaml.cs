using EquipmentRepair.MVVM.ViewModels.AuthViewModels;

namespace EquipmentRepair.MVVM.Views.AuthViews;
/// <summary>
/// Логика взаимодействия для RegistrationView.xaml
/// </summary>
public partial class RegistrationView
{
  public RegistrationView(RegistrationViewModel registrationViewModel)
  {
    InitializeComponent();
    
    DataContext = registrationViewModel; 
  }
}
