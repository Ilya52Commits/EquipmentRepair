using Avalonia.Controls;
using EquipmentRepairAvaloniaUI.MVVM.ViewModels.AuthViewModels;

namespace EquipmentRepairAvaloniaUI.MVVM.Views.AuthViews;

public partial class AuthorizationView : UserControl
{
  public AuthorizationView(AuthorizationViewModel authorizationViewModel)
  {
    InitializeComponent();

    DataContext = authorizationViewModel;
  }
}