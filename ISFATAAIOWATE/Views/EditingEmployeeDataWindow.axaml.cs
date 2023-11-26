using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using ISFATAAIOWATE.Entities;
using ISFATAAIOWATE.ViewModels;

namespace ISFATAAIOWATE.Views;

public partial class EditingEmployeeDataWindow : Window
{
    public EditingEmployeeDataWindow()
    {
        InitializeComponent();
        DataContext = new EmployeeEditingVM();
        this.AttachDevTools();
    }
    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}