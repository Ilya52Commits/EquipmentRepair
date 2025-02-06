using Avalonia.Controls;
using EquipmentRepairAvaloniaUI.MVVM.ViewModels.TechnicianViewModels;
using EquipmentRepairDomain.EntityFramework.Models;

namespace EquipmentRepairAvaloniaUI.MVVM.Views.TechnicianViews;

public partial class FreeRequestsView : UserControl
{
  public FreeRequestsView(FreeRequestsViewModel viewModel)
  {
    InitializeComponent();

    DataContext = viewModel;
  }
}