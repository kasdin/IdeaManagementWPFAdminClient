using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using IdeaManagementWPFAdminClient.Model;

namespace IdeaManagementWPFAdminClient.ViewController
{
    
    class LoginController
    {
        UserAccounts account = new UserAccounts();

        public void LoginTest(string username, string password)
        {
          
            HttpClient client = new HttpClient();

            client.BaseAddress = new Uri("https://localhost:44351/");


            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            account.fld_username = username;
            account.fld_password = password;

            Console.WriteLine(account.fld_password + " --- " + account.fld_username);


            client.PostAsJsonAsync("Api/login", account);

        }

    }
}
