using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using ISFATAAIOWATE.ViewModels;

namespace ISFATAAIOWATE.Views;

public partial class EditingClothingDataWindow : Window
{
    public EditingClothingDataWindow()
    {
        InitializeComponent();
        DataContext = new EditingAndDeletingClothesVM();
        this.AttachDevTools();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}