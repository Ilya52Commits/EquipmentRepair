using EquipmentRepair.Models;
using EquipmentRepair.ViewModel.ClientViewModels;
using System.Windows.Controls;

namespace EquipmentRepair.Viws.ClientViews;
/// <summary>
/// Логика взаимодействия для AddApplicationView.xaml
/// </summary>
public partial class AddApplicationView : Page
{
  public AddApplicationView(Client client)
  {
    InitializeComponent();

    DataContext = new AddApplicationViewModel(client);
  }
}
