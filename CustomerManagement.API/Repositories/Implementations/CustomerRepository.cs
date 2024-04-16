
using CustomerManagement.API.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace CustomerManagement.API.Repositories.Implementations
{
    public class CustomerRepository 
    {
        public CustomerManagementEntities _dbContext = new CustomerManagementEntities();

        // get all customer list
        public IEnumerable<tbl_Customer> GetAllCustomers()
        {
            return _dbContext.tbl_Customer.ToList();
        }

        // get customer by customer id
        public tbl_Customer GetCustomerById(int id)
        {
            return _dbContext.tbl_Customer.Find(id);
        }

        // add new customer

        public int CreateCustomer(tbl_Customer customer)
        {
            _dbContext.tbl_Customer.Add(customer);
            return  _dbContext.SaveChanges();
        }

        // update customer
        public int UpdateCustomer(tbl_Customer customer)
        {
            var existingCustomer =  _dbContext.tbl_Customer.Find(customer.CustomerID);
            if (existingCustomer == null)
                return 0;

            existingCustomer.Name = customer.Name;
            existingCustomer.Email = customer.Email;
            existingCustomer.City = customer.City;

            return  _dbContext.SaveChanges();
        }

        // delete customer
        public bool DeleteCustomer(int id)
        {
            var existingCustomer =  _dbContext.tbl_Customer.Find(id);
            if (existingCustomer == null)
                return false;

            _dbContext.tbl_Customer.Remove(existingCustomer);
             _dbContext.SaveChanges();
            return true;
        }
    }
}