﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace BlazorWrokshop.Data
{
    public class CustomerService
    {
        /// TODO: Change this to use your app's port number
        static string baseURL = "https://localhost:44344/";

        public static async Task<List<Customer>> GetAllCustomers()
        {
            using (var http = new HttpClient())
            {
                var uri = new Uri(baseURL + "api/customer");
                string json = await http.GetStringAsync(uri);
                var customers = JsonConvert.DeserializeObject<List<Customer>>(json);
                return customers;
            }
        }

        public static async Task<Customer> GetCustomer(int CustomerId)
        {
            using (var http = new HttpClient())
            {
                var uri = new Uri(baseURL + "api/customer/" + CustomerId.ToString());
                string json = await http.GetStringAsync(uri);
                var customer = JsonConvert.DeserializeObject<Customer>(json);
                return customer;
            }
        }

        public static async Task AddCustomer(Customer Customer)
        {
            using (var http = new HttpClient())
            {
                var uri = new Uri(baseURL + "api/customer");
                string json = JsonConvert.SerializeObject(Customer);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                await http.PostAsync(uri, content);
            }
        }

        public static async Task UpdateCustomer(Customer Customer)
        {
            using (var http = new HttpClient())
            {
                var uri = new Uri(baseURL + "api/customer/"
                                          + Customer.CustomerId.ToString());
                string json = JsonConvert.SerializeObject(Customer);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var result = await http.PutAsync(uri, content);
                if (result.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    throw new Exception("Customer was not updated");
                }
            }
        }

        public static async Task DeleteCustomer(int CustomerId)
        {

            using (var http = new HttpClient())
            {
                var uri = new Uri(baseURL + "api/customer/" + CustomerId);
                var result = await http.DeleteAsync(uri);
                if (result.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    throw new Exception("Customer was not deleted");
                }
            }
        }
    }
}
