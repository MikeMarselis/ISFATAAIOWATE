using System.Collections.ObjectModel;
using System.Linq;
using ISFATAAIOWATE.Entities;
using ISFATAAIOWATE.Views;
using MsBox.Avalonia;
using MsBox.Avalonia.Enums;
using ReactiveUI;

namespace ISFATAAIOWATE.ViewModels;

public class EditingAndDeletingClothesVM : ViewModelBase
{
    private ObservableCollection<Clothing> _clothing;
    private string _name;
    private string _description;
    private string _size;
    private string _quantity;
    private string _supplierInfo;
    public static Clothing SelectedClothing { get; set; }
    
    public string Name
    {
        get => _name;
        set => this.RaiseAndSetIfChanged(ref _name, value);
    }
    public string Description
    {
        get => _description;
        set => this.RaiseAndSetIfChanged(ref _description, value);
    }
    public string Size
    {
        get => _size;
        set => this.RaiseAndSetIfChanged(ref _size, value);
    }
    public string Quantity
    {
        get => _quantity;
        set => this.RaiseAndSetIfChanged(ref _quantity, value);
    }
    public string SupplierInfo
    {
        get => _supplierInfo;
        set => this.RaiseAndSetIfChanged(ref _supplierInfo, value);
    }
    
    public ObservableCollection<Clothing> Clothings
    {
        get => _clothing;
        set => this.RaiseAndSetIfChanged(ref _clothing, value);
    }
    public void DeletingClothingImpl(Clothing clothing)
    {
        Clothings.Remove(clothing);
        Helper.GetContext().Clothings.Remove(clothing);
        Helper.GetContext().SaveChanges();
        MessageBoxManager.GetMessageBoxStandard("Успешно", "Одежда удалена", ButtonEnum.Ok, Icon.Success).ShowAsync();
    }
    public void EditingClothingImpl(Clothing clothing)
    {
        SelectedClothing = clothing;
        EditingClothingDataWindow editingClothingDataWindow = new EditingClothingDataWindow();
        editingClothingDataWindow.Show();
    }
    public void SumbitEdit()
    {
        if (string.IsNullOrEmpty(Name) || string.IsNullOrEmpty(Description) ||
            string.IsNullOrEmpty(Size))
        {
            MessageBoxManager.GetMessageBoxStandard( "Ошибка","Данные не заполнены", ButtonEnum.Ok, Icon.Error).ShowAsync();
            return;
        }

        var existingEmployee = Helper.GetContext().Clothings.Find(SelectedClothing.ClothingId);

        if (existingEmployee != null)
        {
            existingEmployee.Name = Name;
            existingEmployee.Description = Description;
            existingEmployee.Sizes = Size;
            existingEmployee.SupplierInfo = SupplierInfo;
            Helper.GetContext().SaveChanges();

            MessageBoxManager.GetMessageBoxStandard("Успешно", "Одежда редактирована", ButtonEnum.Ok, Icon.Success).ShowAsync();
        }
    }
    public EditingAndDeletingClothesVM()
    {
        Clothings = new ObservableCollection<Clothing>(Helper.GetContext().Clothings.ToList());
    }
}