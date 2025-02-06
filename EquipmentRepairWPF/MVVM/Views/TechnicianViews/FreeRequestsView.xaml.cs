using EquipmentRepair.MVVM.ViewModels.TechnicianViewModels;

namespace EquipmentRepair.MVVM.Views.TechnicianViews;

public partial class FreeRequestsView
{
  public FreeRequestsView(FreeRequestsViewModel freeRequestsViewModel)
  {
    InitializeComponent();

    var viewModel = freeRequestsViewModel;
    DataContext = viewModel;

    Loaded += async (_, _) => await viewModel.InitializeAsync();
  }
}