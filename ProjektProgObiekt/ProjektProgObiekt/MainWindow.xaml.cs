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
            myDataGrid.ItemsSource = _db.employees.ToList();
            dataGrid = myDataGrid;
        }

        private void insertBtn_Click(object sender, RoutedEventArgs e)
        {
            InsertView Insert = new InsertView();

            Insert.ShowDialog();
        }
    }
}
