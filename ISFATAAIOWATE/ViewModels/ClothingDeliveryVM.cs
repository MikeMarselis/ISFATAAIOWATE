using System.Collections.ObjectModel;
using System.Linq;
using ISFATAAIOWATE.Entities;
using MsBox.Avalonia;
using MsBox.Avalonia.Enums;
using ReactiveUI;

namespace ISFATAAIOWATE.ViewModels;

public class ClothingDeliveryVM : ViewModelBase
{
    private EmployeeClothing _employeeClothing = new EmployeeClothing();
    private ObservableCollection<Employee> _employees;
    private ObservableCollection<Clothing> _clothings;
    private static Employee _selectedEmployee;
    private static Clothing _selectedClothing;

    public ObservableCollection<Employee> Employees
    {
        get => _employees;
        set => this.RaiseAndSetIfChanged(ref _employees, value);
    }

    public ObservableCollection<Clothing> Clothings
    {
        get => _clothings;
        set => this.RaiseAndSetIfChanged(ref _clothings, value);
    }
    public Employee SelectedEmployee
    {
        get => _selectedEmployee;
        set => this.RaiseAndSetIfChanged(ref _selectedEmployee, value);
    }
    public Clothing SelectedClothing
    {
        get => _selectedClothing;
        set => this.RaiseAndSetIfChanged(ref _selectedClothing, value);
    }

    public void extraditionImpl()
    {
        if (SelectedEmployee != null && SelectedClothing != null)
        {
            _employeeClothing.ClothingId = SelectedClothing.ClothingId;

            _employeeClothing.EmployeeId = SelectedEmployee.EmployeeId;
            Helper.GetContext().EmployeeClothings.Add(_employeeClothing);
            Helper.GetContext().SaveChanges();
            MessageBoxManager.GetMessageBoxStandard("Успешно", "Одежда выдана", ButtonEnum.Ok, Icon.Success).ShowAsync();
        }
        else
        {
            MessageBoxManager.GetMessageBoxStandard( "Ошибка","Данные не выполнены", ButtonEnum.Ok, Icon.Error).ShowAsync();
            return;
        }
        
    }
    public ClothingDeliveryVM()
    {
        Employees = new ObservableCollection<Employee>(Helper.GetContext().Employees.ToList());
        Clothings = new ObservableCollection<Clothing>(Helper.GetContext().Clothings.ToList());
    }
}