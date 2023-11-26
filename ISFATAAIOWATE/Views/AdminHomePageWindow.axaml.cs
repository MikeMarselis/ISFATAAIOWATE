using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using ISFATAAIOWATE.ViewModels;
using Excel = Microsoft.Office.Interop.Excel;

namespace ISFATAAIOWATE.Views;

public partial class AdminHomePageWindow : Window
{
    private Window _windowImplementation;

    public AdminHomePageWindow()
    {
        InitializeComponent();
        DataContext = new HomePageVM();
        this.AttachDevTools();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }

    private void EmployeesExportExcel(object? sender, RoutedEventArgs e)
    {
        Excel.Application exApp = new Excel.Application();
        
        exApp.Workbooks.Add();
        Excel.Worksheet wsh = (Excel.Worksheet)exApp.ActiveSheet;
        int i, j;
        for (i = 0; i < EmployeeDataGrid.Columns.Count; i++)
        {
            for ( j = 0; j < EmployeeDataGrid.SelectedItems.Count; j++)
            {
                TextBlock b = EmployeeDataGrid.Columns[i].GetCellContent(EmployeeDataGrid.SelectedItems[j]) as TextBlock;
                Excel.Range myRange = (Excel.Range)wsh.Cells[j + 2, i + 1];
                myRange.Value2 = b.Text;
            }
        }
    }
}