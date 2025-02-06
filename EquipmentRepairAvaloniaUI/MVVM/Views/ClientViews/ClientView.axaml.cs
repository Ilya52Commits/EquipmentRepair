using Avalonia.Controls;
using EquipmentRepairAvaloniaUI.MVVM.ViewModels.ClientViewModels;

namespace EquipmentRepairAvaloniaUI.MVVM.Views.ClientViews;

public partial class ClientView : UserControl
{
  public ClientView(ClientViewModel clientViewModel)
  {
    InitializeComponent();
    
    DataContext = clientViewModel;
  }
}