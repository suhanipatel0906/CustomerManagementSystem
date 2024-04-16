using CustomerManagement.API.Models;
using CustomerManagement.API.Services.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CustomerManagement.API.Controllers
{
    public class CustomerController : ApiController
    {
       
        public CustomerService CustomerService = new CustomerService();

        // get all customer list 
        public IHttpActionResult GetAllCustomer()
        {
            try
            {
                IEnumerable<CustomerModel> customers = CustomerService.GetAllCustomers();
                return Ok(customers);
            }
            catch (Exception ex)
            {

                return BadRequest();
            }
           
        }

        // get customer by customer id
        public IHttpActionResult GetCustomerById(int id)
        {
            try
            {
                CustomerModel customer = CustomerService.GetCustomerById(id);

                if (customer == null)
                    return NotFound();
                else
                    return Ok(customer);
            }
            catch (Exception ex)
            {

                return BadRequest();
            }

            
        }

        // add new customer 
        [HttpPost]
        public IHttpActionResult PostNewStudent(CustomerModel customer)
        {
            try
            {
                int CustomerID = CustomerService.ManageCustomer(customer);

                if (CustomerID == 0)
                    return NotFound();
                else
                    return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest();
            }

            
        }

        // update customer 
        [HttpPut]
        public IHttpActionResult Put(CustomerModel customer)
        {
            try
            {
                int CustomerID = CustomerService.ManageCustomer(customer);

                if (CustomerID == 0)
                    return NotFound();
                else
                    return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest();
            }

            
        }

        // delete customer by id
        public IHttpActionResult Delete(int id)
        {
            try
            {
                if (id <= 0)
                    return BadRequest("Not a valid student id");

                bool result = CustomerService.DeleteCustomer(id);
                if (!result)
                    return NotFound();
                else
                    return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest();
            }

            
        }

    }
}
