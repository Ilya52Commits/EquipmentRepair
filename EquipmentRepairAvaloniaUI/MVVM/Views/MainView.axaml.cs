using Avalonia.Controls;

namespace EquipmentRepairAvaloniaUI.MVVM.Views;

public partial class MainView : Window
{
  public MainView()
  {
    InitializeComponent();
  }

  public void SetContent(Control content)
  {
    MainContent.Content = content;
  }
}