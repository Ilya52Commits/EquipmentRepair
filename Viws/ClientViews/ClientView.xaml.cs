using EquipmentRepair.Models;
using EquipmentRepair.ViewModel.ClientViewModels;
using System.Windows.Controls;

namespace EquipmentRepair.Viws.ClientViews;
/// <summary>
/// Логика взаимодействия для ClientView.xaml
/// </summary>
public partial class ClientView : Page
{
  public ClientView(Client client)
  {
    InitializeComponent();

    DataContext = new ClientViewModel(client);
  }
}
