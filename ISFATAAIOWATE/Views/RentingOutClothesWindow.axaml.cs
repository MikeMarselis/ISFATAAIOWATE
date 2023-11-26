using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using ISFATAAIOWATE.Entities;
using ISFATAAIOWATE.ViewModels;

namespace ISFATAAIOWATE.Views;

public partial class RentingOutClothesWindow : Window
{
    public RentingOutClothesWindow()
    {
        InitializeComponent();
        DataContext = new RentingOutClothesVM();
        this.AttachDevTools();
    }
    public void DeletingEmployeeClothing(EmployeeClothing employeeClothing)
    {
        (DataContext as RentingOutClothesVM).DeletingEmployeeClothingImpl(employeeClothing);
    }
    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}