using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive;
using Avalonia.Controls;
using ISFATAAIOWATE.Entities;
using ISFATAAIOWATE.Views;
using Microsoft.EntityFrameworkCore;
using MsBox.Avalonia;
using MsBox.Avalonia.Enums;
using ReactiveUI;

namespace ISFATAAIOWATE.ViewModels;

public class EmployeeEditingVM : ViewModelBase
{
    private ObservableCollection<Employee> _employees;
    
    private string _password;
    private string _login;
    private string _lastname;
    private string _firstname;
    private string _secondname;
    private string _department;
    private string _contactInfo;
    private ObservableCollection<Position> _positionId;
    private static Position _selectedPosition;
    public static Employee SelectedEmployee { get; set; }

    public string Login
    {
        get => _login;
        set => this.RaiseAndSetIfChanged(ref _login, value);
    }
    public string Password
    {
        get => _password;
        set => this.RaiseAndSetIfChanged(ref _password, value);
    }
    public string LastName
    {
        get => _lastname;
        set => this.RaiseAndSetIfChanged(ref _lastname, value);
    }
    public string FirstName
    {
        get => _firstname;
        set => this.RaiseAndSetIfChanged(ref _firstname, value);
    }
    public string SecondName
    {
        get => _secondname;
        set => this.RaiseAndSetIfChanged(ref _secondname, value);
    }
    public ObservableCollection<Position> Position
    {
        get => _positionId;
        set => this.RaiseAndSetIfChanged(ref _positionId, value);
    }

    public Position SelectedPosition
    {
        get => _selectedPosition;
        set => this.RaiseAndSetIfChanged(ref _selectedPosition, value);
    }
    public string Department
    {
        get => _department;
        set => this.RaiseAndSetIfChanged(ref _department, value);
    }
    public string ContactInfo
    {
        get => _contactInfo;
        set => this.RaiseAndSetIfChanged(ref _contactInfo, value);
    }
    public ObservableCollection<Employee> Employees
    {
        get => _employees;
        set => this.RaiseAndSetIfChanged(ref _employees, value);
    }
    
    private void OpenWindowImpl1(Window obj)
    {
        EditingEmployeeDataWindow editingEmployeeDataWindow = new EditingEmployeeDataWindow();
        editingEmployeeDataWindow.ShowDialog(obj);
    }
    public ReactiveCommand<Window, Unit> OpenWindow1 { get; }
    public void DeletingEmployeeImpl(Employee employee)
    {
        Employees.Remove(employee);
        Helper.GetContext().Employees.Remove(employee);
        Helper.GetContext().SaveChanges();
        MessageBoxManager.GetMessageBoxStandard("Успешно", "Сотрудник удалён.", ButtonEnum.Ok, Icon.Success).ShowAsync();
    }
    public void EditingEmployeeImpl(Employee employee)
    {
        SelectedEmployee = employee;
        EditingEmployeeDataWindow editingEmployeeDataWindow = new EditingEmployeeDataWindow();
        editingEmployeeDataWindow.Show();
    }

    public void SumbitEdit()
    {
        if (_selectedPosition == null)
        {
            MessageBoxManager.GetMessageBoxStandard( "Ошибка","Данные не заполнены", ButtonEnum.Ok, Icon.Error).ShowAsync();
            return;
        }
        // Проверка на наличие данных в обязательных полях
        if (string.IsNullOrEmpty(FirstName) || string.IsNullOrEmpty(LastName) ||
            string.IsNullOrEmpty(Department) || string.IsNullOrEmpty(ContactInfo) ||
            string.IsNullOrEmpty(Login) || string.IsNullOrEmpty(Password) || string.IsNullOrEmpty(SecondName))
        {
            // Вывести сообщение об ошибке или предпринять соответствующие действия
            MessageBoxManager.GetMessageBoxStandard( "Ошибка","Данные не заполнены", ButtonEnum.Ok, Icon.Error).ShowAsync();
            return;
        }

        var existingEmployee = Helper.GetContext().Employees.Find(SelectedEmployee.EmployeeId);

        if (existingEmployee != null)
        {
            // Выполнить редактирование только если проверка прошла успешно
            existingEmployee.FirstName = FirstName;
            existingEmployee.LastName = LastName;
            existingEmployee.SecondName = SecondName;
            existingEmployee.Department = Department;
            existingEmployee.ContactInfo = ContactInfo;
            existingEmployee.Login = Login;
            existingEmployee.Password = Password;
            existingEmployee.PositionId = _selectedPosition.PositionId;

            Helper.GetContext().SaveChanges();

            // Вывести сообщение об успешном редактировании
            MessageBoxManager.GetMessageBoxStandard("Успешно", "Сотрудник успешно отредактирован.", ButtonEnum.Ok, Icon.Success).ShowAsync();
        }
    }

    public EmployeeEditingVM()
    {
        OpenWindow1 = ReactiveCommand.Create<Window>(OpenWindowImpl1);
        Employees = new ObservableCollection<Employee>(Helper.GetContext().Employees.Include(e => e.Position).ToList());
        Position = new ObservableCollection<Position>(Helper.GetContext().Positions.ToList());
    }
    
}