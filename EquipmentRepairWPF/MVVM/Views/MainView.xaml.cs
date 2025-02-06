using EquipmentRepair.MVVM.Views.AuthViews;

namespace EquipmentRepair.MVVM.Views;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainView
{
  public MainView(AuthorizationView view)
  {
    InitializeComponent();
    
    MainFrame.NavigationService.Navigate(view);
  }
}