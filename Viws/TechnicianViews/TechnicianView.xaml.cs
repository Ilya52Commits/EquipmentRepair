using EquipmentRepair.Models;
using EquipmentRepair.ViewModel.TechnicianViewModels;
using System.Windows.Controls;

namespace EquipmentRepair.Viws.TechnicianViews;
/// <summary>
/// Логика взаимодействия для TechnicianViews.xaml
/// </summary>
public partial class TechnicianViews : Page
{
  public TechnicianViews(Technician technician)
  {
    InitializeComponent();

    DataContext = new TechnicianViewModel(technician);
  }
}
