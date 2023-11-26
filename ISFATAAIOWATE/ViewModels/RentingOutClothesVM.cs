using System.Collections.ObjectModel;
using System.Linq;
using ISFATAAIOWATE.Entities;
using Microsoft.EntityFrameworkCore;
using MsBox.Avalonia;
using MsBox.Avalonia.Enums;
using ReactiveUI;

namespace ISFATAAIOWATE.ViewModels;

public class RentingOutClothesVM: ViewModelBase
{
    private EmployeeClothing _employeeClothings = new EmployeeClothing();
    private ObservableCollection<Employee> _employees;
    private ObservableCollection<EmployeeClothing> _employeeClothing;
    private static Employee _selectedEmployee;
    private static Clothing _selectedClothing;

    public ObservableCollection<Employee> Employees
    {
        get => _employees;
        set => this.RaiseAndSetIfChanged(ref _employees, value);
    }

    public ObservableCollection<EmployeeClothing> EmployeeClothings
    {
        get => _employeeClothing;
        set => this.RaiseAndSetIfChanged(ref _employeeClothing, value);
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

    public void DeletingEmployeeClothingImpl(EmployeeClothing employeeClothing)
    {
        EmployeeClothings.Remove(employeeClothing);
        Helper.GetContext().EmployeeClothings.Remove(employeeClothing);
        Helper.GetContext().SaveChanges();
        MessageBoxManager.GetMessageBoxStandard("Успешно", "Одежда возвращена", ButtonEnum.Ok, Icon.Success).ShowAsync();
    }
    public RentingOutClothesVM()
    {
        Employees = new ObservableCollection<Employee>(Helper.GetContext().Employees.Include(e => e.Position).ToList());
        EmployeeClothings = new ObservableCollection<EmployeeClothing>(Helper.GetContext().EmployeeClothings.Include(e => e.Clothing).ToList());
    }
}