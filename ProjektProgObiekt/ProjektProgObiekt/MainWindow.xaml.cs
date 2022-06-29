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

namespace ProjektProgObiekt
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        AgregatorEntities _db = new AgregatorEntities();
        public static DataGrid dataGrid;

        public MainWindow()
        {
            InitializeComponent();
            Load();
        }

        private void Load()
        {
            myDataGrid.ItemsSource = (from em in _db.employees 
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
            dataGrid = myDataGrid;
    //        db.Requests.Where(req => req.Code == code)
    //.Include(req => req.Results) // Joining is performed here
    //.Include(req => req.SomeOtherProperty)
    //.ToList()
        }

        private void insertBtn_Click(object sender, RoutedEventArgs e)
        {
            InsertView Insert = new InsertView();

            Insert.ShowDialog();
        }

        private void updateBtn_Click(object sender, RoutedEventArgs e)
        {
            int id = (myDataGrid.SelectedItem as employee).id;
            UpdateView Update = new UpdateView(id);

            Update.ShowDialog();
        }

        private void deleteBtn_Click(object sender, RoutedEventArgs e)
        {
            int id = (myDataGrid.SelectedItem as employee).id;
            employee employeeToDelete = (from em in _db.employees where em.id == id select em).Single();
            _db.employees.Remove(employeeToDelete);
            _db.SaveChanges();
            myDataGrid.ItemsSource = _db.employees.ToList();

        }
    }
}
