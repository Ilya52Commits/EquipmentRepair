using EquipmentRepair.MVVM.ViewModels.ClientViewModels;

namespace EquipmentRepair.MVVM.Views.ClientViews;

/// <summary>
/// Логика взаимодействия для ClientView.xaml
/// </summary>
public partial class ClientView
{
  public ClientView(ClientViewModel clientViewModel)
  {
    InitializeComponent();

    var viewModel = clientViewModel;
    DataContext = viewModel;

    Loaded += async (_, _) => await viewModel.InitializeAsync();
  }
}