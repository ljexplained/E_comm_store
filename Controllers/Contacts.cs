using Microsoft.AspNetCore.Mvc;
using radiobutton.Models;
using System.Data.SqlClient;

namespace radiobutton.Controllers
{
    public class Contacts : Controller
    {


        public string conn = "Data Source=SQL5110.site4now.net,1433;Initial Catalog=db_a9eacf_brainoservices;User Id=db_a9eacf_brainoservices_admin;Password=xAb@by#web1;";
        // public string conn = "Data Source=DESKTOP-6LQD0UJ\\SQLEXPRESS;Initial Catalog=MyUser;Integrated Security=True";

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AboutUs()
        {


            ViewBag.uname = HttpContext.Session.GetString("username");
            var CartProductsCookie = Request.Cookies["CartProducts"];
            if (CartProductsCookie == null || CartProductsCookie.Length == 0)
            {

                ViewBag.count = 0;
                Console.WriteLine("no product added");


            }
            else
            {
                var productsids = CartProductsCookie.Split('-');
                ViewBag.count = productsids.Length;
                Console.WriteLine(ViewBag.count);
            }

            return View();
        }

        public IActionResult BillingTerms()
        {
            ViewBag.uname = HttpContext.Session.GetString("username");
            var CartProductsCookie = Request.Cookies["CartProducts"];
            if (CartProductsCookie == null || CartProductsCookie.Length == 0)
            {

                ViewBag.count = 0;
                Console.WriteLine("no product added");


            }
            else
            {
                var productsids = CartProductsCookie.Split('-');
                ViewBag.count = productsids.Length;
                Console.WriteLine(ViewBag.count);
            }

            return View();
        }
        public IActionResult ContactUs()
        {
            ViewBag.uname = HttpContext.Session.GetString("username");
            var CartProductsCookie = Request.Cookies["CartProducts"];
            if (CartProductsCookie == null || CartProductsCookie.Length == 0)
            {

                ViewBag.count = 0;
                Console.WriteLine("no product added");


            }
            else
            {
                var productsids = CartProductsCookie.Split('-');
                ViewBag.count = productsids.Length;
                Console.WriteLine(ViewBag.count);
            }

            return View();
        }

        public IActionResult Privacy()
        {
            ViewBag.uname = HttpContext.Session.GetString("username");
            var CartProductsCookie = Request.Cookies["CartProducts"];
            if (CartProductsCookie == null || CartProductsCookie.Length == 0)
            {

                ViewBag.count = 0;
                Console.WriteLine("no product added");


            }
            else
            {
                var productsids = CartProductsCookie.Split('-');
                ViewBag.count = productsids.Length;
                Console.WriteLine(ViewBag.count);
            }

            return View();
        }


        public IActionResult ReturnPolicy()
        {
            ViewBag.uname = HttpContext.Session.GetString("username");
            var CartProductsCookie = Request.Cookies["CartProducts"];
            if (CartProductsCookie == null || CartProductsCookie.Length == 0)
            {

                ViewBag.count = 0;
                Console.WriteLine("no product added");


            }
            else
            {
                var productsids = CartProductsCookie.Split('-');
                ViewBag.count = productsids.Length;
                Console.WriteLine(ViewBag.count);
            }

            return View();
        }


        public IActionResult Shipping()
        {
            ViewBag.uname = HttpContext.Session.GetString("username");
            var CartProductsCookie = Request.Cookies["CartProducts"];
            if (CartProductsCookie == null || CartProductsCookie.Length == 0)
            {

                ViewBag.count = 0;
                Console.WriteLine("no product added");


            }
            else
            {
                var productsids = CartProductsCookie.Split('-');
                ViewBag.count = productsids.Length;
                Console.WriteLine(ViewBag.count);
            }

            return View();
        }


        public IActionResult TarrifsAndSurcharges()
        {
            ViewBag.uname = HttpContext.Session.GetString("username");
            var CartProductsCookie = Request.Cookies["CartProducts"];
            if (CartProductsCookie == null || CartProductsCookie.Length == 0)
            {

                ViewBag.count = 0;
                Console.WriteLine("no product added");


            }
            else
            {
                var productsids = CartProductsCookie.Split('-');
                ViewBag.count = productsids.Length;
                Console.WriteLine(ViewBag.count);
            }

            return View();
        }


        public IActionResult mailUs()
        {
            return View();
        }

        [HttpPost]
        public IActionResult mailUs(string cname, string cemail, string decript)
        {
            Console.WriteLine(cname);
            Console.WriteLine(cemail);
            Console.WriteLine(decript);

            DateTime dt = DateTime.Now;

            string query = "Insert into Cmessage(cname,cemail,decript,datecreated) Values(@cname,@cemail,@decript,@datecreated)";
            SqlConnection connection = new SqlConnection(conn);
            connection.Open();
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@cname", cname);
            cmd.Parameters.AddWithValue("@cemail", cemail);
            cmd.Parameters.AddWithValue("@decript", decript);
            cmd.Parameters.AddWithValue("@datecreated", dt);
            cmd.ExecuteNonQuery();

            return View();



        }



     




    }
}
