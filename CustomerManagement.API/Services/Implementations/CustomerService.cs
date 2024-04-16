using CustomerManagement.API.Models;
using CustomerManagement.API.Repositories.Implementations;
using CustomerManagement.API.Repositories.Interface;
using CustomerManagement.API.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace CustomerManagement.API.Services.Implementations
{
    public class CustomerService 
    {
        public CustomerRepository _customerRepository = new CustomerRepository();

        // get all customer list
        public IEnumerable<CustomerModel> GetAllCustomers()
        {
            IEnumerable<tbl_Customer> customers =  _customerRepository.GetAllCustomers();
            IEnumerable<CustomerModel> customerModels = customers.Select(c => new CustomerModel()
                            {
                                CustomerID = c.CustomerID,
                                CustomerName = c.Name,
                                CustomerEmail = c.Email,
                                CustomerCity = c.City
                            }).ToList<CustomerModel>();

            return customerModels;
        }

        // get customer by customer id
        public CustomerModel GetCustomerById(int id)
        {
            tbl_Customer tbl_Customer =  _customerRepository.GetCustomerById(id);
            CustomerModel customerModel = new CustomerModel();

            customerModel.CustomerID = tbl_Customer.CustomerID;
            customerModel.CustomerName = tbl_Customer.Name;
            customerModel.CustomerEmail = tbl_Customer.Email;
            customerModel.CustomerCity = tbl_Customer.City;

            return customerModel; 
        }

        // add or update customer
        public int ManageCustomer(CustomerModel customer)
        {
            tbl_Customer tbl_Customer = new tbl_Customer();
            tbl_Customer.CustomerID = customer.CustomerID;
            tbl_Customer.Name = customer.CustomerName;
            tbl_Customer.Email = customer.CustomerEmail;
            tbl_Customer.City = customer.CustomerCity;

            // if customer id is 0 than add new customer 
            // else customer id is not 0 than update existing customer
            if(customer.CustomerID == 0)
                 return  _customerRepository.CreateCustomer(tbl_Customer);
            else 
                return  _customerRepository.UpdateCustomer(tbl_Customer);
        }

        // remove customer by customer id
        public bool DeleteCustomer(int id)
        {
            return _customerRepository.DeleteCustomer(id);
        }
    }
}