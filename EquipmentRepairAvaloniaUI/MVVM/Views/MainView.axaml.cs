using Avalonia.Controls;
using EquipmentRepairAvaloniaUI.MVVM.Views.AuthViews;

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