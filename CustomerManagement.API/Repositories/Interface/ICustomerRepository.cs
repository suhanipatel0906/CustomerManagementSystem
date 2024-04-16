using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement.API.Repositories.Interface
{
    public interface ICustomerRepository
    {
        IEnumerable<tbl_Customer> GetAllCustomers();
        tbl_Customer GetCustomerById(int id);
        int CreateCustomer(tbl_Customer customer);
        int UpdateCustomer(tbl_Customer customer);
        bool DeleteCustomer(int id);


    }
}
