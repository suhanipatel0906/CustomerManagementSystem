using CustomerManagement.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace CustomerManagement.Controllers
{
    public class CustomerController : Controller
    {

        public string BaseURl = "https://localhost:44393/api/";
        public ActionResult Index()
        {

            IEnumerable<CustomerViewModel> customers = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseURl);
                //HTTP GET
                var responseTask = client.GetAsync("customer");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var customerJson = result.Content.ReadAsStringAsync();
                    customerJson.Wait();
                    // Here you can deserialize the JSON response if needed
                    // For example, using Newtonsoft.Json:
                    customers = JsonConvert.DeserializeObject<List<CustomerViewModel>>(customerJson.Result);
                    // Pass the students data to your view or process it as required

                }
                else //web api sent error response 
                {
                    //log response status here..

                    customers = Enumerable.Empty<CustomerViewModel>();

                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }

            return View(customers);

        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult create(CustomerViewModel customer)
        {
            if (ModelState.IsValid)
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(BaseURl);

                    //HTTP POST
                    var postTask = client.PostAsJsonAsync<CustomerViewModel>("customer", customer);
                    postTask.Wait();

                    var result = postTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index");
                    }
                }

                ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");

            }
            else
            {
                ModelState.AddModelError(string.Empty, "Please enter required fields.");
            }
           
            return View(customer);
        }

        public ActionResult Edit(int id)
        {
            CustomerViewModel customer = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseURl);
                //HTTP GET
                var responseTask = client.GetAsync("customer?id=" + id.ToString());
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<CustomerViewModel>();
                    readTask.Wait();

                    customer = readTask.Result;
                }
            }
            return View(customer);
        }

        [HttpPost]
        public ActionResult Edit(CustomerViewModel customer)
        {
            if (ModelState.IsValid)
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(BaseURl);

                    //HTTP POST
                    var putTask = client.PutAsJsonAsync<CustomerViewModel>("customer", customer);
                    putTask.Wait();

                    var result = putTask.Result;
                    if (result.IsSuccessStatusCode)
                    {

                        return RedirectToAction("Index");
                    }
                }

                ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Please enter required fields.");
            }

            return View(customer);
        }

       
        public ActionResult Delete(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseURl);

                //HTTP DELETE
                var deleteTask = client.DeleteAsync("customer/" + id.ToString());
                deleteTask.Wait();

                var result = deleteTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    return RedirectToAction("Index");
                }
            }

            return RedirectToAction("Index");
        }
    }

}

