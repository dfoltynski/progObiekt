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
using System.Windows.Shapes;

namespace ProjektProgObiekt
{
    /// <summary>
    /// Interaction logic for UpdateView.xaml
    /// </summary>
    public partial class UpdateView : Window
    {

        AgregatorEntities _db = new AgregatorEntities();
        int id;
        public UpdateView(int id)
        {
            InitializeComponent();
            this.id = id;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            employee updateEmployee = (from em in _db.employees where em.id == id select em).Single();

            _db.SaveChanges();

            MainWindow.dataGrid.ItemsSource = _db.employees.ToList();
            this.Hide();
        }
    }
}
