using EquipmentRepair.MVVM.ViewModels.TechnicianViewModels;

namespace EquipmentRepair.MVVM.Views.TechnicianViews;

public partial class FreeRequestsView
{
  public FreeRequestsView(FreeRequestsViewModel viewModel)
  {
    InitializeComponent();

    DataContext = viewModel;
  }
}