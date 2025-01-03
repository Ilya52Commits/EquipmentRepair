using System.Windows.Controls;
using EquipmentRepair.EntityFramework.Models;
using EquipmentRepair.MVVM.ViewModels.ClientViewModels;

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
