using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Excel = Microsoft.Office.Interop.Excel;

namespace ISFATAAIOWATE.Views;

public partial class ReportsWindow : Window
{
    public ReportsWindow()
    {
        InitializeComponent();
#if DEBUG
        this.AttachDevTools();
#endif
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }

    private void ExportToExcelEmployees()
    {
        Excel.Application exApp = new Excel.ApplicationClass();
        exApp.Workbooks.Add();
        Excel.Worksheet wsh = (Excel.Worksheet)exApp.ActiveSheet;
        for (int i = 0; i <= 20-2; i++)
        {
            for (int j = 0; j <= 20-1; j++)
            {
                wsh.Cells[i + 1, j + 1] = dgv.Value.ToString();
            }
        }

        exApp.Visible = true;
    }
}