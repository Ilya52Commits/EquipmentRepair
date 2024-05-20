using EquipmentRepair.Viws;
using System.Windows;

namespace EquipmentRepair;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
  public MainWindow()
  {
    InitializeComponent();
    MainFrame.NavigationService.Navigate(new RegistrationView());
  }
}
