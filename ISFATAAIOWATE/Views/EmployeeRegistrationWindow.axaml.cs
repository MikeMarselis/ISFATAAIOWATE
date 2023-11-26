using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using ISFATAAIOWATE.ViewModels;

namespace ISFATAAIOWATE.Views;

public partial class EmployeeRegistrationWindow : Window
{
    public EmployeeRegistrationWindow()
    {
        InitializeComponent();
        DataContext = new EmployeeRegistrationVM();
        this.AttachDevTools();
    }
    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}