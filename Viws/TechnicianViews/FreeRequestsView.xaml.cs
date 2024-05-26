using System.Windows.Controls;
using EquipmentRepair.Models;
using EquipmentRepair.ViewModel.TechnicianViewModels;

namespace EquipmentRepair.Viws.TechnicianViews;

public partial class FreeRequestsView : Page
{
  public FreeRequestsView(Technician technician)
  {
    InitializeComponent();

    DataContext = new FreeRequesrsViewModel(technician);
  }
}