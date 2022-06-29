using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
            string managerFullName;
            _db.managers.ToList().ForEach(manager =>
            {
                managerComboBox.Items.Add(Regex.Replace($"{manager.name}{manager.last_name}", @"\s+", " "));
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
            string managerName = managerComboBox.Text.Trim().Split(' ')[0];
            string managerLastName = managerComboBox.Text.Trim().Split(' ')[1];
            int managerId = _db.managers.Where(m => m.name == managerName && m.last_name == managerLastName).Single().id;
            int companyId = _db.companies.Where(c => c.company_name == companyComboBox.Text.Trim()).Single().id;
            int roleId = (from r in _db.roles where r.role_name == roleComboBox.Text.Trim() select r.id).Single();
            employee newEmployee = new employee()
            {
                name = nameTextBox.Text,
                last_name = lastNameTextBox.Text,
                role = roleId,
                manager = managerId,
                company = companyId,
            };

            _db.employees.Add(newEmployee);
            _db.SaveChanges();
            MainWindow.dataGrid.ItemsSource = _db.employees.ToList();

            this.Hide();
            
        }
    }
}
