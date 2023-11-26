using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive;
using Avalonia.Controls;
using ISFATAAIOWATE.Views;
using MsBox.Avalonia;
using MsBox.Avalonia.Enums;
using ReactiveUI;
using ISFATAAIOWATE.Entities;

namespace ISFATAAIOWATE.ViewModels;

public class EmployeeRegistrationVM: ViewModelBase
{
        private Employee _employee = new Employee();
        private string _password;
        private string _login;
        private string _lastname;
        private string _firstname;
        private string _secondname;
        private string _department;
        private string _contactInfo;
        private ObservableCollection<Position> _positionId;
        private static Position _selectedPosition;
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
        public ReactiveCommand<Window, Unit> SumbitRegistration { get; }
        

        public EmployeeRegistrationVM()
        {
            SumbitRegistration = ReactiveCommand.Create<Window>(SumbitRegistrationImpl);
            Position = new ObservableCollection<Position>(Helper.GetContext().Positions.ToList());
        }


        private void SumbitRegistrationImpl(Window obj)
        {
            if (_selectedPosition == null)
            {
                MessageBoxManager.GetMessageBoxStandard( "Ошибка","Данные не заполнены", ButtonEnum.Ok, Icon.Error).ShowAsync();
                return;
            }

            if (string.IsNullOrWhiteSpace(_login) || string.IsNullOrWhiteSpace(_password) || 
                string.IsNullOrWhiteSpace(_firstname) || string.IsNullOrWhiteSpace(_lastname) || string.IsNullOrWhiteSpace(_secondname) || 
                string.IsNullOrWhiteSpace(_department))
            {
                MessageBoxManager.GetMessageBoxStandard( "Ошибка","Данные не заполнены", ButtonEnum.Ok, Icon.Error).ShowAsync();
                return;
            }
            
            _employee.Login = _login;
            _employee.Password = _password;
            _employee.LastName = _lastname;
            _employee.FirstName = _firstname;
            _employee.SecondName = _secondname;
            _employee.ContactInfo = _contactInfo;
            _employee.Department = _department;
            _employee.PositionId = _selectedPosition.PositionId;

            Helper.GetContext().Employees.Add(_employee);
            Helper.GetContext().SaveChanges();

            MessageBoxManager.GetMessageBoxStandard("Пользователь Зарегистрирован", "Зарегистрирован", ButtonEnum.Ok, Icon.Success).ShowAsync();
            obj.Close();
        }
}