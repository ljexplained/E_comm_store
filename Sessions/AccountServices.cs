using System.Data.SqlClient;
using System.Security.Principal;
using radiobutton.Models;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography.X509Certificates;

namespace radiobutton.Sessions
{
   
        public class AccountServices : IAccountServices
        {

        private List<Account> accounts;
     public string conn = "Data Source=SQL5110.site4now.net,1433;Initial Catalog=db_a9eacf_brainoservices;User Id=db_a9eacf_brainoservices_admin;Password=xAb@by#web1;";
     //public string conn = "Data Source=DESKTOP-6LQD0UJ\\SQLEXPRESS;Initial Catalog=MyUser;Integrated Security=True";
        public AccountServices()
            {
                accounts = new List<Account>();
                string query = "SELECT  * From Login_User ";

                SqlConnection connection = new SqlConnection(conn);
                SqlCommand cmd = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())

                {
                    Account account = new Account();
                    account.Username = reader.GetString(1);
                    account.Password = reader.GetString(2);
                    accounts.Add(account);
                }


                connection.Close();







            }
           public Account Login(string username, string password)
            {



               return accounts.SingleOrDefault(x => x.Username == username && x.Password == password);


            }

           
        }
    }

