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

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        StoreWPFEntities db = new StoreWPFEntities();
        CustomerScript customerScript = new CustomerScript();
        public MainWindow()
        {
            InitializeComponent();
            customerDataGrid.ItemsSource = db.Customer.ToList();
        }

        private void btnAddCustomerWindow_Click(object sender, RoutedEventArgs e)
        {
            AddCustomerWindow addCustomerWindow = new AddCustomerWindow();
            addCustomerWindow.ShowDialog();
        }
        private void customerDataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var selectedItem = customerDataGrid.SelectedItem as Customer;
            UpdateCustomerWindow updateCustomerWindow = new UpdateCustomerWindow(selectedItem);
            updateCustomerWindow.ShowDialog();
        }
        private void btnRemoveCustomerWindow_Click(object sender, RoutedEventArgs e)
        {
            var selectedItem = customerDataGrid.SelectedItem as Customer;
            if(selectedItem != null)
            {
                customerScript.Delete(selectedItem.CustomerID);
                customerDataGrid.ItemsSource = db.Customer.ToList();
                customerDataGrid.Items.Refresh();
            }
        }

        private void btnRefreshCustomer_Click(object sender, RoutedEventArgs e)
        {
            customerDataGrid.ItemsSource = db.Customer.ToList();
            customerDataGrid.Items.Refresh();
        }        
    }
}
