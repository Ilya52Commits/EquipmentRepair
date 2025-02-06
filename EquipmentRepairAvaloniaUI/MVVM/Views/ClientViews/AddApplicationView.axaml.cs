using Avalonia.Controls;
using EquipmentRepairAvaloniaUI.MVVM.ViewModels.ClientViewModels;

namespace EquipmentRepairAvaloniaUI.MVVM.Views.ClientViews;

public partial class AddApplicationView : UserControl
{
  public AddApplicationView(AddApplicationViewModel addApplicationViewModel)
  {
    InitializeComponent();
    
    DataContext = addApplicationViewModel;
  }
}