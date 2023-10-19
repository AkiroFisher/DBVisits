using DBVisits.Classes;
using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Excel = Microsoft.Office.Interop.Excel;

namespace DBVisits.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageVisits.xaml
    /// </summary>
    public partial class PageVisits : System.Windows.Controls.Page
    {
        public PageVisits()
        {
            InitializeComponent();
            dtgListVisits.ItemsSource = mdkEntities.GetContext().Посещения.ToList();

            CmbPrichal.ItemsSource = mdkEntities.GetContext().Посещения.Select(x => x.Номер_причала).Distinct().ToList();

            CmbShip.ItemsSource = mdkEntities.GetContext().Корабли.ToList();
            CmbShip.SelectedValue = "Код_корабля";
            CmbShip.DisplayMemberPath = "Название_корабля";
        }

        private void CmbShip_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int ship = CmbShip.SelectedIndex + 1;
            dtgListVisits.ItemsSource = mdkEntities.GetContext().Посещения.Where(x => x.Код_корабля == ship).ToList();
        }
        
        private void CmbPrichal_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int prichal = (int)(CmbPrichal.SelectedValue);
            dtgListVisits.ItemsSource = mdkEntities.GetContext().Посещения.Where(x => x.Номер_причала == prichal).ToList();
        }
        private void BtnResetFiltr_Click(object sender, RoutedEventArgs e)
        {
            dtgListVisits.ItemsSource = mdkEntities.GetContext().Посещения.ToList();

        }

        private void TxtSearchReason_TextChanged(object sender, TextChangedEventArgs e)
        {
            string search = TxtSearchReason.Text;
            dtgListVisits.ItemsSource = mdkEntities.GetContext().Посещения.Where(x => x.Цель_посещения.Contains(search)).ToList();
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            Classes.ClassFrame.frmObj.Navigate(new Pages.PageAddEdit(null));
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            Classes.ClassFrame.frmObj.Navigate(new Pages.PageAddEdit((sender as System.Windows.Controls.Button).DataContext as Посещения));
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            var lstForDelete = dtgListVisits.SelectedItems.Cast<Посещения>().ToList();
            if (MessageBox.Show($"Удалить {lstForDelete.Count()} записей?",
                "Внимание", MessageBoxButton.YesNo,
                MessageBoxImage.Question) == MessageBoxResult.Yes)

                try
                {
                    mdkEntities.GetContext().Посещения.RemoveRange(lstForDelete);
                    mdkEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены");
                    dtgListVisits.ItemsSource = mdkEntities.GetContext().Посещения.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
        }

        private void BtnListView_Click(object sender, RoutedEventArgs e)
        {
            Classes.ClassFrame.frmObj.Navigate(new Pages.PageListView());
        }

        private void BtnCreateExcel_Click(object sender, RoutedEventArgs e)
        {
            var app = new Excel.Application();

            Excel.Workbook wb = app.Workbooks.Add();
            Excel.Worksheet worksheet = app.Worksheets.Item[1];

            Excel.Range Header = worksheet.Range[worksheet.Cells[1][1], worksheet.Cells[7][1]];
            Header.Merge();
            Header.Value = "Корабли";
            Header.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

            int indexRows = 3;
            worksheet.Cells[1][indexRows] = "Номер визита";
            worksheet.Cells[2][indexRows] = "Название корабля";
            worksheet.Cells[3][indexRows] = "Название порта";
            worksheet.Cells[4][indexRows] = "Дата прибытия";
            worksheet.Cells[5][indexRows] = "Дата отплытия";
            worksheet.Cells[6][indexRows] = "Номер причала";
            worksheet.Cells[7][indexRows] = "Цель посещения";

            var listBooks = mdkEntities.GetContext().Посещения.ToList();

            foreach (var book in listBooks)
            {
                indexRows++;
                worksheet.Cells[1][indexRows] = indexRows - 3;
                worksheet.Cells[2][indexRows] = book.Корабли.Название_корабля;
                worksheet.Cells[3][indexRows] = book.Порты.Название_порта;
                worksheet.Cells[4][indexRows] = book.Дата_прибытия;
                worksheet.Cells[5][indexRows] = book.Дата_отплытия;
                worksheet.Cells[6][indexRows] = book.Номер_причала;
                worksheet.Cells[7][indexRows] = book.Цель_посещения;
            }

            indexRows++;

            app.Visible = true;

            Excel.Range Countt = worksheet.Range[worksheet.Cells[1][indexRows], worksheet.Cells[6][indexRows]];
            Countt.Merge();
            Countt.Value = "Колличество регистраций";
            Countt.HorizontalAlignment = Excel.XlHAlign.xlHAlignRight;

            worksheet.Cells[7][indexRows].Formula = "=Count(A3:A" + (indexRows - 1) + ")";

            Countt.Font.Bold = worksheet.Cells[7][indexRows].Font.Bold = true;

            Excel.Range rangeBorders = worksheet.Range[worksheet.Cells[1][1], worksheet.Cells[7][indexRows]];
            rangeBorders.Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle =
            rangeBorders.Borders[Excel.XlBordersIndex.xlEdgeLeft].LineStyle =
            rangeBorders.Borders[Excel.XlBordersIndex.xlEdgeRight].LineStyle =
            rangeBorders.Borders[Excel.XlBordersIndex.xlEdgeTop].LineStyle =
            rangeBorders.Borders[Excel.XlBordersIndex.xlInsideHorizontal].LineStyle =
            rangeBorders.Borders[Excel.XlBordersIndex.xlInsideVertical].LineStyle = Excel.XlLineStyle.xlContinuous;

            worksheet.Columns.AutoFit();
        }

        private void BtnExcel_Click(object sender, RoutedEventArgs e)
        {
            var app = new Excel.Application();
            Excel.Workbook wb = app.Workbooks.Open($"" + $"{Directory.GetCurrentDirectory()}" + $"\\Шаблон.xlsx");
            Excel.Worksheet worksheet = (Excel.Worksheet)wb.Worksheets[1];

            Excel.Range Header = worksheet.Range[worksheet.Cells[1][1], worksheet.Cells[7][1]];
            Header.Merge();
            Header.Value = "Корабли";
            Header.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

            int indexRows = 3;
            worksheet.Cells[1][indexRows] = "Номер визита";
            worksheet.Cells[2][indexRows] = "Название корабля";
            worksheet.Cells[3][indexRows] = "Название порта";
            worksheet.Cells[4][indexRows] = "Дата прибытия";
            worksheet.Cells[5][indexRows] = "Дата отплытия";
            worksheet.Cells[6][indexRows] = "Номер причала";
            worksheet.Cells[7][indexRows] = "Цель посещения";

            var listBooks = mdkEntities.GetContext().Посещения.ToList();

            foreach (var book in listBooks)
            {
                indexRows++;
                worksheet.Cells[1][indexRows] = indexRows - 3;
                worksheet.Cells[2][indexRows] = book.Корабли.Название_корабля;
                worksheet.Cells[3][indexRows] = book.Порты.Название_порта;
                worksheet.Cells[4][indexRows] = book.Дата_прибытия;
                worksheet.Cells[5][indexRows] = book.Дата_отплытия;
                worksheet.Cells[6][indexRows] = book.Номер_причала;
                worksheet.Cells[7][indexRows] = book.Цель_посещения;
            }

            indexRows++;

            app.Visible = true;

            Excel.Range Countt = worksheet.Range[worksheet.Cells[1][indexRows], worksheet.Cells[6][indexRows]];
            Countt.Merge();
            Countt.Value = "Колличество регистраций";
            Countt.HorizontalAlignment = Excel.XlHAlign.xlHAlignRight;

            worksheet.Cells[7][indexRows].Formula = "=Count(A3:A" + (indexRows - 1) + ")";

            Countt.Font.Bold = worksheet.Cells[7][indexRows].Font.Bold = true;

            Excel.Range rangeBorders = worksheet.Range[worksheet.Cells[1][1], worksheet.Cells[7][indexRows]];
            rangeBorders.Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle =
            rangeBorders.Borders[Excel.XlBordersIndex.xlEdgeLeft].LineStyle =
            rangeBorders.Borders[Excel.XlBordersIndex.xlEdgeRight].LineStyle =
            rangeBorders.Borders[Excel.XlBordersIndex.xlEdgeTop].LineStyle =
            rangeBorders.Borders[Excel.XlBordersIndex.xlInsideHorizontal].LineStyle =
            rangeBorders.Borders[Excel.XlBordersIndex.xlInsideVertical].LineStyle = Excel.XlLineStyle.xlContinuous;

            worksheet.Columns.AutoFit();
        }
    }
}
