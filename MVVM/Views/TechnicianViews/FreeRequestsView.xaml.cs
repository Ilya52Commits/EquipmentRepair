using System.Windows.Controls;
using EquipmentRepair.EntityFramework.Models;
using FreeRequesrsViewModel = EquipmentRepair.MVVM.ViewModels.TechnicianViewModels.FreeRequesrsViewModel;

namespace EquipmentRepair.Viws.TechnicianViews;

public partial class FreeRequestsView : Page
{
  public FreeRequestsView(Technician technician)
  {
    InitializeComponent();

    DataContext = new FreeRequesrsViewModel(technician);
  }
}