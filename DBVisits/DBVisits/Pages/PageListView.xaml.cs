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
    /// Логика взаимодействия для PageListView.xaml
    /// </summary>
    public partial class PageListView : Page
    {
        public PageListView()
        {
            InitializeComponent();
            LstViewShips.ItemsSource = mdkEntities.GetContext().Корабли.ToList();
        }
    }
}
