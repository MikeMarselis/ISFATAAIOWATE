using System;
using System.Linq;
using System.Reactive;
using Avalonia.Controls;
using Metsys.Bson;
using ReactiveUI;
using ISFATAAIOWATE.Entities;
using ISFATAAIOWATE.Views;
using Microsoft.EntityFrameworkCore;
using MsBox.Avalonia;
using MsBox.Avalonia.Enums;

namespace ISFATAAIOWATE.ViewModels;

public class AuthorizationVM : ViewModelBase
{
    private string _password;
    private string _login;
    public static Employee AuthorizedEmployee { get; set; }
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
    public ReactiveCommand<Window, Unit> OpenWindow { get; }
    public AuthorizationVM()
    {
        OpenWindow = ReactiveCommand.Create<Window>(OpenWindowImpl);
    }
    private void OpenWindowImpl(Window obj)
    {
        var employee = Helper.GetContext().Employees.Include(e => e.Position).SingleOrDefault(x => x.Login == Login & x.Password == Password);
        if (employee is { Position.PositionName: "Администратор" })
        {
            AuthorizedEmployee = employee;
            AdminHomePageWindow adminHomePageWindow = new AdminHomePageWindow();
            adminHomePageWindow.Show();
            obj.Close();
        }
        if (employee is { Position.PositionName: "Старший сотрудник" })
        {
            AuthorizedEmployee = employee;
            HomePageWindow homePage = new HomePageWindow();
            homePage.Show();
            obj.Close();
        }
        if (employee == null)
        {
            MessageBoxManager.GetMessageBoxStandard("Ошибка", "Данные введены неверно", ButtonEnum.Ok, Icon.Error).ShowAsync();
            return;
        }

            
    }
}