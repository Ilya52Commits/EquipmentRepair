using Avalonia.Controls;
using EquipmentRepairAvaloniaUI.MVVM.ViewModels.AuthViewModels;

namespace EquipmentRepairAvaloniaUI.MVVM.Views.AuthViews;

public partial class RegistrationView : UserControl
{
  public RegistrationView(RegistrationViewModel registrationViewModel)
  {
    InitializeComponent();
    
    DataContext = registrationViewModel; 
  }
}