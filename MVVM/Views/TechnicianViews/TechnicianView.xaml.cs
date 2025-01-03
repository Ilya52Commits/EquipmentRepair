using System.Windows.Controls;
using EquipmentRepair.EntityFramework.Models;
using EquipmentRepair.MVVM.ViewModels.TechnicianViewModels;

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
