using CustomerManagement.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement.API.Services.Interface
{
    public interface ICustomerService
    {
        IEnumerable<CustomerModel> GetAllCustomers();
        CustomerModel GetCustomerById(int id);

        int ManageCustomer(CustomerModel customer);

        bool DeleteCustomer(int id);
    }
}
