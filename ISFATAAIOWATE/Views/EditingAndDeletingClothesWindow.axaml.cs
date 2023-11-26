using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using ISFATAAIOWATE.Entities;
using ISFATAAIOWATE.ViewModels;

namespace ISFATAAIOWATE.Views;

public partial class EditingAndDeletingClothesWindow : Window
{
    public EditingAndDeletingClothesWindow()
    {
        InitializeComponent();
        DataContext = new EditingAndDeletingClothesVM();
        this.AttachDevTools();
    }
    public void DeleteClothing(Clothing clothing)
    {
        (DataContext as EditingAndDeletingClothesVM).DeletingClothingImpl(clothing);
    }
    public void EditingClothing(Clothing clothing)
    { 
        (DataContext as EditingAndDeletingClothesVM).EditingClothingImpl(clothing);
    }
    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}