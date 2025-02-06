using Avalonia.Controls;
using EquipmentRepairAvaloniaUI.MVVM.ViewModels.ClientViewModels;

namespace EquipmentRepairAvaloniaUI.MVVM.Views.ClientViews;

public partial class ClientView : UserControl
{
  private readonly ClientViewModel _viewModel;
  
  public ClientView(ClientViewModel clientViewModel)
  {
    InitializeComponent();
    
    _viewModel = clientViewModel;
    DataContext = _viewModel;
    
    Loaded += async (_, _) => await _viewModel.InitializeAsync(); // не знаю насколько это правильно
  }
}