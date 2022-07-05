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

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for UpdateCustomerWindow.xaml
    /// </summary>
    public partial class UpdateCustomerWindow : Window
    {
        CustomerScript customerScript = new CustomerScript();
        private int id;
        public UpdateCustomerWindow(Customer _customer)
        {
            InitializeComponent();
            id = _customer.CustomerID;
            textBoxCustomerName.Text = _customer.CustomerName;
            textBoxPhoneNumber.Text = _customer.PhoneNumber;
            textBoxBankName.Text = _customer.BankName;
            textBoxBankAccountNumber.Text = _customer.BankAccountNumber;
            textBoxAdress.Text = _customer.Adress;
            textBoxEmailAdress.Text = _customer.EmailAdress;
        }
        private bool Save()
        {
            if (Validation() == true)
            {
                Customer customer = new Customer()
                {
                    CustomerID = id,
                    CustomerName = textBoxCustomerName.Text,
                    PhoneNumber = textBoxPhoneNumber.Text,
                    BankName = textBoxBankName.Text,
                    BankAccountNumber = textBoxBankAccountNumber.Text,
                    Adress = textBoxAdress.Text,
                    EmailAdress = textBoxEmailAdress.Text,
                };

                customerScript.Update(customer);
                return true;
            }
            return false;
        }
        private bool Validation()
        {
            if (String.IsNullOrEmpty(textBoxCustomerName.Text))
            {
                if (MessageBox.Show("No name!", "Name", MessageBoxButton.OK, MessageBoxImage.Warning) == MessageBoxResult.OK)
                    return false;
            }
            if (String.IsNullOrEmpty(textBoxPhoneNumber.Text))
            {
                if (MessageBox.Show("No Phone Number!", "Phone Number", MessageBoxButton.OK, MessageBoxImage.Warning) == MessageBoxResult.OK)
                    return false;
            }
            if (!IsDigitsOnly(textBoxPhoneNumber.Text))
            {
                if (MessageBox.Show("Phone number contains 9 digits. Enter correct data!", "Phone Number", MessageBoxButton.OK, MessageBoxImage.Warning) == MessageBoxResult.OK)
                    return false;
            }
            if (textBoxPhoneNumber.Text.Length != 9)
            {
                if (MessageBox.Show("Phone number contains 9 digits. Enter correct data!", "Phone Number", MessageBoxButton.OK, MessageBoxImage.Warning) == MessageBoxResult.OK)
                    return false;
            }

            if (String.IsNullOrEmpty(textBoxBankName.Text))
            {
                if (MessageBox.Show("No Bank Name!", "Bank Account", MessageBoxButton.OK, MessageBoxImage.Warning) == MessageBoxResult.OK)
                    return false;
            }

            if (String.IsNullOrEmpty(textBoxBankAccountNumber.Text))
            {
                if (MessageBox.Show("No Bank Account Number!", "Bank Account", MessageBoxButton.OK, MessageBoxImage.Warning) == MessageBoxResult.OK)
                    return false;
            }
            if (!IsDigitsOnly(textBoxBankAccountNumber.Text))
            {
                if (MessageBox.Show("Bank Account contains 26 digits. Enter correct data!", "Bank Account", MessageBoxButton.OK, MessageBoxImage.Warning) == MessageBoxResult.OK)
                    return false;
            }
            if (textBoxBankAccountNumber.Text.Length != 26)
            {
                if (MessageBox.Show("Bank Account contains 26 digits. Enter correct data!", "Bank Account", MessageBoxButton.OK, MessageBoxImage.Warning) == MessageBoxResult.OK)
                    return false;
            }
            if (String.IsNullOrEmpty(textBoxAdress.Text))
            {
                if (MessageBox.Show("No Adress!", "Adress", MessageBoxButton.OK, MessageBoxImage.Warning) == MessageBoxResult.OK)
                    return false;
            }
            if (String.IsNullOrEmpty(textBoxEmailAdress.Text))
            {
                if (MessageBox.Show("No Email!", "Email Adress", MessageBoxButton.OK, MessageBoxImage.Warning) == MessageBoxResult.OK)
                    return false;
            }
            if (!IsEmail(textBoxEmailAdress.Text))
            {
                if (MessageBox.Show("Wrong email format!", "Email Adress", MessageBoxButton.OK, MessageBoxImage.Warning) == MessageBoxResult.OK)
                    return false;
            }

            return true;
        }

        public bool IsDigitsOnly(string dane)
        {
            foreach (char c in dane)
            {
                if (!char.IsDigit(c))
                    return false;
            }
            return true;
        }
        public bool IsEmail(string dane)
        {
            foreach (char c in dane)
            {
                if (c == '@')
                    return true;
            }
            return false;
        }
        private void btnUpdateCustomer_Click(object sender, RoutedEventArgs e)
        {
            if (Save() == true)
            {
                this.Close();
            }
        }
    }
}
