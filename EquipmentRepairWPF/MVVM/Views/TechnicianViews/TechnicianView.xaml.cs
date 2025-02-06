using EquipmentRepair.MVVM.ViewModels.TechnicianViewModels;

namespace EquipmentRepair.MVVM.Views.TechnicianViews;
/// <summary>
/// Логика взаимодействия для TechnicianViews.xaml
/// </summary>
public partial class TechnicianView
{
  public TechnicianView(TechnicianViewModel technicianViewModel)
  {
    InitializeComponent();

    DataContext = technicianViewModel;
  }
}
