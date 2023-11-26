using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using ISFATAAIOWATE.ViewModels;

namespace ISFATAAIOWATE.Views;

public partial class ClothesIssuanceLogsWindow : Window
{
    public ClothesIssuanceLogsWindow()
    {
        InitializeComponent();
        DataContext = new ClothesIssuanceLogsVM();
        this.AttachDevTools();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}