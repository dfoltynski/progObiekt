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
            Load();
        }

        private void Load()
        {
            LoadRoles();
            LoadManagers();
            LoadCompanies();
        }

        private void LoadRoles()
        {
            _db.roles.ToList().ForEach(role =>
            {
                roleComboBox.Items.Add($"{role.role_name}");
            });
        }

        private void LoadManagers()
        {
            _db.managers.ToList().ForEach(manager =>
            {
                managerComboBox.Items.Add($"{manager.name} o nazwisku {manager.last_name}");
            });
        }

        private void LoadCompanies()
        {
            _db.companies.ToList().ForEach(company =>
            {
                companyComboBox.Items.Add($"{company.company_name}");
            });
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
