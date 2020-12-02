using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using IdeaManagementWPFAdminClient.Model;
using Newtonsoft.Json;

namespace IdeaManagementWPFAdminClient.ViewController
{
    class CustomersController
    {
        public bool CreateCustomers(Customers customer)
        {
            Boolean isSuccess; 
            HttpClient client = new HttpClient();

            client.BaseAddress = new Uri("https://localhost:44351/");



            client.DefaultRequestHeaders.Accept.Add(

                new MediaTypeWithQualityHeaderValue("application/json"));


            var response = client.PostAsJsonAsync("api/customers", customer).Result;



            if (response.IsSuccessStatusCode)

            {
                isSuccess = true;
            }

            else

            {

                isSuccess = false;
                MessageBox.Show("Error Code" + response.StatusCode + " : Message - " + response.ReasonPhrase);

            }

            return isSuccess;
        }

        public List<Button> GenerateCustomerList()
        {
                var listOfBtn = new List<Button>();

                IEnumerable<Customers> customersList = null;

                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("https://localhost:44351/");
                //client.DefaultRequestHeaders.Add("appkey", "myapp_key");
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = client.GetAsync("api/customers").Result;
                if (response.IsSuccessStatusCode)
                {
                    customersList = response.Content.ReadAsAsync<IEnumerable<Customers>>().Result;

                }
                else
                {
                    MessageBox.Show("Error Code" + response.StatusCode + " : Message - " + response.ReasonPhrase);
                }


                foreach (var customer in customersList)
                {
                    System.Windows.Controls.Button newBtn = new Button();
                    //Button newBtn = new Button();
                    newBtn.Content = customer.fld_name;
                    newBtn.Name = customer.fld_name;
                    

                    listOfBtn.Add(newBtn);
                }

                return listOfBtn; 
        }



        public Customers GetCustomerInfo(string name)
        {
            Console.WriteLine(name);
            Customers customer = new Customers();


            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44351/");
            //client.DefaultRequestHeaders.Add("appkey", "myapp_key");
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            
            var response = client.GetAsync("api/customers?name=" + name).Result;
            if (response.IsSuccessStatusCode)
            {

                customer = response.Content.ReadAsAsync<Customers>().Result;

            }
            else
            {
                MessageBox.Show("Error Code" + response.StatusCode + " : Message - " + response.ReasonPhrase);
            }


            return customer;
        }

        public void DeleteCustomer(string name)
        {

            Console.WriteLine("Delete CUstomer" + name);

            HttpClient client = new HttpClient();

            client.BaseAddress = new Uri("https://localhost:44351/");


            var url = "api/customers?name=" + name;


            HttpResponseMessage response = client.DeleteAsync(url).Result;


            if (response.IsSuccessStatusCode)

            {

                MessageBox.Show("Company Deleted");

               

            }

            else

            {

                MessageBox.Show("Error Code" + response.StatusCode + " : Message - " + response.ReasonPhrase);

            }

        }


    }
}
