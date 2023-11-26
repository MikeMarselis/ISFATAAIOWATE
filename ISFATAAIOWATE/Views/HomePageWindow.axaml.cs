using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using ISFATAAIOWATE.ViewModels;

namespace ISFATAAIOWATE.Views;

public partial class HomePageWindow : Window
{
    public HomePageWindow()
    {
        InitializeComponent();
        this.AttachDevTools();
        DataContext = new HomePageVM();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}