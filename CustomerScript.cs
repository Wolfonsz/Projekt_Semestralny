using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp
{
    public class CustomerScript
    {
        StoreWPFEntities db = new StoreWPFEntities();
        public void Save(Customer customer)
        {
            db.Customer.Add(customer);
            db.SaveChanges();
        }
        public void Update(Customer customer)
        {
            if (customer != null)
            {
                Customer editCustomer = db.Customer.Find(customer.CustomerID);
                editCustomer.CustomerID = customer.CustomerID;
                editCustomer.CustomerName = customer.CustomerName;
                editCustomer.PhoneNumber = customer.PhoneNumber;
                editCustomer.BankName = customer.BankName;
                editCustomer.BankAccountNumber = customer.BankAccountNumber;
                editCustomer.Adress = customer.Adress;
                editCustomer.EmailAdress = customer.EmailAdress;
                db.SaveChanges();
            }
        }
        public void Delete(int id)
        {
            Customer customer = db.Customer.Find(id);
            db.Customer.Remove(customer);
            db.SaveChanges();
        }
    }
}
