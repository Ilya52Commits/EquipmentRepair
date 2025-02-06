using Avalonia.Controls;
using EquipmentRepairAvaloniaUI.MVVM.ViewModels.TechnicianViewModels;

namespace EquipmentRepairAvaloniaUI.MVVM.Views.TechnicianViews;

public partial class TechnicianView : UserControl
{
  public TechnicianView(TechnicianViewModel technicianViewModel)
  {
    InitializeComponent();

    var viewModel = technicianViewModel;
    DataContext = viewModel;

    Loaded += async (_, _) => await viewModel.InitializeAsync();
  }
}