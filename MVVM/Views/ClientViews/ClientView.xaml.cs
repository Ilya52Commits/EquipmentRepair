using System.Windows.Controls;
using EquipmentRepair.EntityFramework.Models;
using EquipmentRepair.MVVM.ViewModels.ClientViewModels;

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
