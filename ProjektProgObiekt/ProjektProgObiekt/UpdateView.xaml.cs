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
            Load();
        }
        /// <summary>
        /// Metoda Load uruchamia wszystkie zawarte w niej metody odpowiedzialne za załadowanie roli, menadzerów i firm.
        /// </summary>
        private void Load()
        {
            LoadEmployee();
            LoadRoles();
            LoadManagers();
            LoadCompanies();
        }

        private void LoadEmployee()
        {
            employeeName.Text = _db.employees.Where(e => e.id == id).Select(e => e).Single().name + " " + _db.employees.Where(e => e.id == id).Select(e => e).Single().last_name;
        }
        /// <summary>
        /// Metoda LoadRoles wybiera wszystkie role z bazy danych, transferuje je na liste i za pomocą metody ForEach dynamicznie dodaje nowe wybory do ComboBox'a
        /// </summary>
        private void LoadRoles()
        {
            _db.roles.ToList().ForEach(role =>
            {
                roleComboBox.Items.Add($"{role.role_name}");
            });
        }
        /// <summary>
        /// Metoda LoadManagers wybiera imię i nazwisko z bazy danych z tabeli managers, transferuje je na liste i za pomocą metody ForEach dynamicznie dodaje nowe wybory do ComboBox'a. W metodzie Add w ComboBox'ie dokonujemy konkatenacji dwóch stringów ze sobą i za pomocą klasy statycznej Regex podmieniamy niepotrzebne spacje, na tylko jedną.
        /// </summary>
        private void LoadManagers()
        {
            _db.managers.ToList().ForEach(manager =>
            {
                managerComboBox.Items.Add(Regex.Replace($"{manager.name}{manager.last_name}", @"\s+", " "));
            });
        }
        /// <summary>
        /// Metoda LoadCompanies wybiera wszystkie firmy z bazy danych, transferuje je na liste i za pomocą metody ForEach dynamicznie dodaje nowe wybory do ComboBox'a
        /// </summary>
        private void LoadCompanies()
        {
            _db.companies.ToList().ForEach(company =>
            {
                companyComboBox.Items.Add($"{company.company_name}");
            });
        }

        /// <summary>
        /// Metoda UpdateEmployee_Click po kliknięciu aktualizuje użytkownika i odswieża dane jak Load w klasie MainWindow. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpdateEmployee_Click(object sender, RoutedEventArgs e)
        {
            string managerName = "";
            string managerLastName = "";
            
            if(managerComboBox.Text != "")
            {
                managerName = managerComboBox.Text.Trim().Split(' ')[0];
                managerLastName = managerComboBox.Text.Trim().Split(' ')[1];
            }

            manager managerId = _db.managers.Where(m => m.name == managerName && m.last_name == managerLastName).FirstOrDefault();
            company companyId = _db.companies.Where(c => c.company_name == companyComboBox.Text.Trim()).FirstOrDefault();
            role roleId = (from r in _db.roles where r.role_name == roleComboBox.Text.Trim() select r).FirstOrDefault();

            employee updateEmployee = (from em in _db.employees where em.id == id select em).FirstOrDefault();
            updateEmployee.manager = managerId != null ? (int)managerId.id : updateEmployee.manager;
            updateEmployee.company = companyId != null ? (int)companyId.id : updateEmployee.company;
            updateEmployee.role = roleId != null ? (int)roleId.id : updateEmployee.role;

            _db.SaveChanges();

            MainWindow.dataGrid.ItemsSource = (from em in _db.employees
                                               join r in _db.roles on em.role equals r.id
                                               join c in _db.companies on em.company equals c.id
                                               join m in _db.managers on em.manager equals m.id
                                               select new
                                               {
                                                   id = em.id,
                                                   name = em.name,
                                                   last_name = em.last_name,
                                                   role = r.role_name,
                                                   company = c.company_name,
                                                   manager = m.name + " " + m.last_name,
                                               }).ToList();
            this.Hide();
        }
    }
}
