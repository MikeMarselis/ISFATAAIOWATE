using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Reactive;
using Avalonia.Controls;
using ISFATAAIOWATE.Entities;
using ISFATAAIOWATE.Views;
using Microsoft.EntityFrameworkCore;
using ReactiveUI;


namespace ISFATAAIOWATE.ViewModels;

public class HomePageVM : ViewModelBase
{
    private Employee _selectedEmployee;
    private ObservableCollection<Employee> _employees;
    private ObservableCollection<EmployeeClothing> _employeeClothings;
    private string _searchTBox_OnTextChanged;

    public string SearchTBox_OnTextChanged
    {
        get => _searchTBox_OnTextChanged;
        set
        {
            Employees = new ObservableCollection<Employee>(Helper.GetContext().Employees.Where(i => i.Lfs.Contains(value)));
            this.RaiseAndSetIfChanged(ref _searchTBox_OnTextChanged, value);
        }
    }

    public ObservableCollection<Employee> Employees
    {
        get => _employees;
        set => this.RaiseAndSetIfChanged(ref _employees, value);
    }
    
    public ObservableCollection<EmployeeClothing> EmployeeClothings
    {
        get => _employeeClothings;
        set => this.RaiseAndSetIfChanged(ref _employeeClothings, value);
    }
    private void OpenWindowImpl1(Window obj)
    {
        EmployeeRegistrationWindow employeeRegistrationWindow = new EmployeeRegistrationWindow();
        employeeRegistrationWindow.ShowDialog(obj);
    }
    private void OpenWindowImpl2(Window obj)
    {
        EmployeeEditingWindow employeeEditingWindow = new EmployeeEditingWindow();
        employeeEditingWindow.ShowDialog(obj);
        Employees = new ObservableCollection<Employee>(Helper.GetContext().Employees.Include(e => e.Position).ToList());
    }
    private void OpenWindowImpl3(Window obj)
    {
        ClothingDeliveryWindow clothingDeliveryWindow = new ClothingDeliveryWindow();
        clothingDeliveryWindow.ShowDialog(obj);
    }
    private void OpenWindowImpl4(Window obj)
    {
        ClothesIssuanceLogsWindow clothesIssuanceLogsWindow = new ClothesIssuanceLogsWindow();
        clothesIssuanceLogsWindow.ShowDialog(obj);
    }
    private void OpenWindowImpl5(Window obj)
    {
        RentingOutClothesWindow rentingOutClothesWindow = new RentingOutClothesWindow();
        rentingOutClothesWindow.ShowDialog(obj);
    }
    private void OpenWindowImpl6(Window obj)
    {
        EditingAndDeletingClothesWindow editingAndDeletingClothesWindow = new EditingAndDeletingClothesWindow();
        editingAndDeletingClothesWindow.ShowDialog(obj);
    }
    private void OpenWindowImpl7(Window obj)
    {
        AuthorizationWindow authorizationWindow = new AuthorizationWindow();
        authorizationWindow.Show();
        obj.Close();
    }
    public ReactiveCommand<Window, Unit> OpenWindow1 { get; }
    public ReactiveCommand<Window, Unit> OpenWindow2 { get; }
    public ReactiveCommand<Window, Unit> OpenWindow3 { get; }
    public ReactiveCommand<Window, Unit> OpenWindow4 { get; }
    public ReactiveCommand<Window, Unit> OpenWindow5 { get; }
    public ReactiveCommand<Window, Unit> OpenWindow6 { get; }
    public ReactiveCommand<Window, Unit> OpenWindow7 { get; }
    public ReactiveCommand<Window, Unit> EmployeesReport { get; }
    public ReactiveCommand<Window, Unit> ClothingReport { get; }
    public ReactiveCommand<Window, Unit> ClothingLogReport { get; }

    private void EmployeesReportImpl1(Window obj)
    {
        using (ExcelHelper helper = new ExcelHelper())
        {
            if (helper.Open(filePath: Path.Combine(Environment.CurrentDirectory,
                    @"\ISFATAAIOWATE\ISFATAAIOWATE\ExcelReports\EmployeesReport.xlsx")))
            {
                int i = 0;
                var application = new Microsoft.Office.Interop.Excel.Application();

                Excel.Workbook workbook = application.Workbooks.Add(Type.Missing);

                for (int j = 0; j < 20; ++j)
                {
                    int counter = 0;
                    int startRowIndex = 1;

                    Excel.Worksheet worksheet = application.Worksheets.Item[j + 1];

                    startRowIndex++;

                    while (allEmployees.Count > i)
                    {
                        if (allEmployees[i].DateAndTime.Month == j + 1)
                        {
                            worksheet.Cells[1][startRowIndex] = allEmployees[i].IdEmployee;
                            worksheet.Cells[2][startRowIndex] = allEmployees[i].Lfc;
                            worksheet.Cells[3][startRowIndex] = allEmployees[i].Departament;
                            counter++;
                        }
                        else
                        {
                            break;
                        }

                        i++;
                        startRowIndex++;
                    }

                    Excel.Range sumRange = worksheet.Range[worksheet.Cells[1][startRowIndex],
                        worksheet.Cells[2][startRowIndex]];
                    sumRange.Merge();

                    worksheet.Columns.AutoFit();
                    helper.Save();
                }
                application.Visible = true;
            }
        }
    }

    private void ClothingReportImpl1(Window obj)
    {
        using (ExcelHelper helper = new ExcelHelper())
        {
            if (helper.Open(filePath: Path.Combine(Environment.CurrentDirectory,
                    @"\ISFATAAIOWATE\ISFATAAIOWATE\ExcelReports\ClotingReport.xlsx")))
            {
                int i = 0;
                var application = new Microsoft.Office.Interop.Excel.Application();

                Excel.Workbook workbook = application.Workbooks.Add(Type.Missing);

                for (int j = 0; j < 20; ++j)
                {
                    int counter = 0;
                    int startRowIndex = 1;

                    Excel.Worksheet worksheet = application.Worksheets.Item[j + 1];

                    startRowIndex++;

                    while (allCloting.Count > i)
                    {
                        if (allCloting[i].DateAndTime.Month == j + 1)
                        {
                            worksheet.Cells[1][startRowIndex] = allCloting[i].IdCloting;
                            worksheet.Cells[2][startRowIndex] = allCloting[i].Name;
                            worksheet.Cells[3][startRowIndex] = allCloting[i].Position;
                            counter++;
                        }
                        else
                        {
                            break;
                        }

                        i++;
                        startRowIndex++;
                    }

                    Excel.Range sumRange = worksheet.Range[worksheet.Cells[1][startRowIndex],
                        worksheet.Cells[2][startRowIndex]];
                    sumRange.Merge();

                    worksheet.Columns.AutoFit();
                    helper.Save();
                }
                application.Visible = true;
            }
        }
    }

    private void ClothingLogReport(Window obj)
    {
        using (ExcelHelper helper = new ExcelHelper())
        {
            if (helper.Open(filePath: Path.Combine(Environment.CurrentDirectory,
                    @"\ISFATAAIOWATE\ISFATAAIOWATE\ExcelReports\ClotingLogReport.xlsx")))
            {
                int i = 0;
                var application = new Microsoft.Office.Interop.Excel.Application();

                Excel.Workbook workbook = application.Workbooks.Add(Type.Missing);

                for (int j = 0; j < 20; ++j)
                {
                    int counter = 0;
                    int startRowIndex = 1;

                    Excel.Worksheet worksheet = application.Worksheets.Item[j + 1];

                    startRowIndex++;

                    while (allLogCloting.Count > i)
                    {
                        if (allLogCloting[i].DateAndTime.Month == j + 1)
                        {
                            worksheet.Cells[1][startRowIndex] = allLogCloting[i].IdCloting;
                            worksheet.Cells[2][startRowIndex] = allLogCloting[i].Name;
                            worksheet.Cells[3][startRowIndex] = allLogCloting[i].Position;
                            counter++;
                        }
                        else
                        {
                            break;
                        }

                        i++;
                        startRowIndex++;
                    }

                    Excel.Range sumRange = worksheet.Range[worksheet.Cells[1][startRowIndex],
                        worksheet.Cells[2][startRowIndex]];
                    sumRange.Merge();

                    worksheet.Columns.AutoFit();
                    helper.Save();
                }
                application.Visible = true;
            }
        }
    }

    public HomePageVM()
    {
        OpenWindow1 = ReactiveCommand.Create<Window>(OpenWindowImpl1);
        OpenWindow2 = ReactiveCommand.Create<Window>(OpenWindowImpl2);
        OpenWindow3 = ReactiveCommand.Create<Window>(OpenWindowImpl3);
        OpenWindow4 = ReactiveCommand.Create<Window>(OpenWindowImpl4);
        OpenWindow5 = ReactiveCommand.Create<Window>(OpenWindowImpl5);
        OpenWindow6 = ReactiveCommand.Create<Window>(OpenWindowImpl6);
        OpenWindow7 = ReactiveCommand.Create<Window>(OpenWindowImpl7);
        EmployeesReport = ReactiveCommand.Create<Window>(EmployeesReportImpl1);
        ClothingReport = ReactiveCommand.Create<Window>(ClothingReportImpl1);
        ClothingLogReport = ReactiveCommand.Create<Window>(ClothingLogReport);
        Employees = new ObservableCollection<Employee>(Helper.GetContext().Employees.Include(e => e.Position).ToList());
        EmployeeClothings = new ObservableCollection<EmployeeClothing>(Helper.GetContext().EmployeeClothings.Include(e => e.Clothing).ToList());
    }
}