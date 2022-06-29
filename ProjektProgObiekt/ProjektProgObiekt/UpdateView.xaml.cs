﻿using System;
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
                managerComboBox.Items.Add($"{manager.name} {manager.last_name}");
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
            employee updateEmployee = (from em in _db.employees where em.id == id select em).Single();

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
