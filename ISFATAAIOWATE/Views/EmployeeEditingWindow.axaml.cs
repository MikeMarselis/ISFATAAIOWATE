using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using ISFATAAIOWATE.Entities;
using ISFATAAIOWATE.ViewModels;

namespace ISFATAAIOWATE.Views;

public partial class EmployeeEditingWindow : Window
{
    
    public EmployeeEditingWindow()
    {
        InitializeComponent();
        DataContext = new EmployeeEditingVM();
        this.AttachDevTools();
    }
    public void DeleteEmployee(Employee employee)
    {
        (DataContext as EmployeeEditingVM).DeletingEmployeeImpl(employee);
    }
    public void EditingEmployee(Employee employee)
    {
        (DataContext as EmployeeEditingVM).EditingEmployeeImpl(employee);
    }
    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}