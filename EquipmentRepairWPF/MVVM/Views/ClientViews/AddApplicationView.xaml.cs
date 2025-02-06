using EquipmentRepair.MVVM.ViewModels.ClientViewModels;

namespace EquipmentRepair.MVVM.Views.ClientViews;

/// <summary>
/// Логика взаимодействия для AddApplicationView.xaml
/// </summary>
public partial class AddApplicationView
{
  public AddApplicationView(AddApplicationViewModel addApplicationViewModel)
  {
    InitializeComponent();

    DataContext = addApplicationViewModel;
  }
}