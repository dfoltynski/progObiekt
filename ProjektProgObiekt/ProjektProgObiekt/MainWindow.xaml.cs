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

        /// <summary>
        /// Metoda Load za pomocą kwerendy pobiera nam wszystkie niezbędne informacje o pracowniku i łączy tabele.
        /// </summary>
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

        }
        /// <summary>
        /// Metoda insertBtn_Click po kliknięciu wywołuje metode ShowDialog na obiekcie klasy InsertView.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void insertBtn_Click(object sender, RoutedEventArgs e)
        {
            InsertView Insert = new InsertView();

            Insert.ShowDialog();
        }
        /// <summary>
        /// Metoda updateBtn_Click po kliknięciu wywołuje metode ShowDialog na obiekcie klasy UpdateView. Do konstruktora klasy UpdateView przesyłany jest ID pracownika, który zostal wybrany.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void updateBtn_Click(object sender, RoutedEventArgs e)
        {
            int id = (myDataGrid.SelectedItem as employee).id;
            UpdateView Update = new UpdateView(id);

            Update.ShowDialog();
        }
        /// <summary>
        /// Metoda deleteBtn_Click po kliknięciu usuwa wybranego użytkownika z bazy danych i odswieża liste zawarta w myDataGrid w parametrze ItemsSource.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
