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
    /// Interaction logic for InsertView.xaml
    /// </summary>
    public partial class InsertView : Window
    {
        AgregatorEntities _db = new AgregatorEntities();

        public InsertView()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            employee newEmployee = new employee()
            {
                name = nameTextBox.Text,
                last_name = lastNameTextBox.Text,
                role = _db.roles.Find(roleComboBox.Text).id,
                manager = _db.managers.Find(managerComboBox.Text).id,
                company = _db.companies.Find(companyComboBox.Text).id,
        };

            _db.employees.Add(newEmployee);
            _db.SaveChanges();
            MainWindow.dataGrid.ItemsSource = _db.employees.ToList();

            this.Hide();
            

        }
    }
}
