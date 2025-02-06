using Avalonia.Controls;
using EquipmentRepairAvaloniaUI.MVVM.ViewModels.TechnicianViewModels;

namespace EquipmentRepairAvaloniaUI.MVVM.Views.TechnicianViews;

public partial class FreeRequestsView : UserControl
{
  public FreeRequestsView(FreeRequestsViewModel freeRequestsViewModel)
  {
    InitializeComponent();

    var viewModel = freeRequestsViewModel;
    DataContext = viewModel;

    Loaded += async (_, _) => await viewModel.InitializeAsync();
  }
}