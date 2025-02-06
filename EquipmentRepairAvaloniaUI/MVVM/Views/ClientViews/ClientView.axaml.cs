using Avalonia.Controls;
using EquipmentRepairAvaloniaUI.MVVM.ViewModels.ClientViewModels;

namespace EquipmentRepairAvaloniaUI.MVVM.Views.ClientViews;

public partial class ClientView : UserControl
{
  public ClientView(ClientViewModel clientViewModel)
  {
    InitializeComponent();

    var viewModel = clientViewModel;
    DataContext = viewModel;

    Loaded += async (_, _) => await viewModel.InitializeAsync();
  }
}