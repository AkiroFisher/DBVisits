using DBVisits.Classes;
using System;
using System.Collections.Generic;
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

namespace DBVisits.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageVisits.xaml
    /// </summary>
    public partial class PageVisits : Page
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

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            Classes.ClassFrame.frmObj.Navigate(new Pages.PageAddEdit((sender as Button).DataContext as Посещения));
        }
    }
}
