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
    /// Логика взаимодействия для PageAddEdit.xaml
    /// </summary>
    public partial class PageAddEdit : Page
    {
        Посещения _currentVisit = new Посещения();
        public PageAddEdit(Посещения visitlocal)
        {
            InitializeComponent();

            CmbNameShip.ItemsSource = mdkEntities.GetContext().Корабли.ToList();
            CmbNameShip.SelectedValuePath = "Код_корабля";
            CmbNameShip.DisplayMemberPath = "Название_корабля";

            CmbNamePort.ItemsSource = mdkEntities.GetContext().Порты.ToList();
            CmbNamePort.SelectedValuePath = "Код_порта";
            CmbNamePort.DisplayMemberPath = "Название_порта";
            
            if (visitlocal != null) _currentVisit = visitlocal;
            DataContext = _currentVisit;
         }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            if (_currentVisit.Код_посещения == 0)

                mdkEntities.GetContext().Посещения.Add(_currentVisit);

            mdkEntities.GetContext().SaveChanges();

            MessageBoxResult boxResult = MessageBox.Show("Данные добавлены. Добавить еще?","Сообщение", MessageBoxButton.YesNo);
            if (boxResult == MessageBoxResult.Yes)
            {
                TxtDateCome.Clear();
                TxtDateOut.Clear();
                TxtPrichal.Clear();
                TxtReason.Clear();
            }
            else
                Classes.ClassFrame.frmObj.Navigate(new Pages.PageVisits());
        }
    }
}
