using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using ISFATAAIOWATE.ViewModels;

namespace ISFATAAIOWATE.Views;

public partial class ClothingDeliveryWindow : Window
{
    public ClothingDeliveryWindow()
    {
        InitializeComponent();
        DataContext = new ClothingDeliveryVM();
        this.AttachDevTools();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}