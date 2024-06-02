using EquipmentRepair.Viws;

namespace EquipmentRepair;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow
{
  public MainWindow()
  {
    InitializeComponent();
    MainFrame.NavigationService.Navigate(new RegistrationView());
  }
}
