using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using radiobutton.Models;
using System.Data.SqlClient;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;
using radiobutton.Sessions;
using System.Runtime.Intrinsics.X86;
using Microsoft.AspNetCore.Authorization;
using System.Net.Mail;
using System.Net;
using System;
using System.Net.Mime;
using System.Diagnostics.Eventing.Reader;
using System.Security.Cryptography;
using System.Text;
using Microsoft.Extensions.Hosting;
using System.IO;
using System.Numerics;
using System.Linq;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;
using Razorpay.Api;
using iTextSharp.text.pdf.security;

namespace radiobutton.Controllers
{



    public class Products : Controller
    {
        private readonly IHostingEnvironment _environment;
        private readonly Random _random = new Random();
        private IAccountServices _accountService;
        public Products(IAccountServices accountService, IHostingEnvironment environment)
        {
            _accountService = accountService;
            _environment = environment;
        }
        public int RandomNumber(int min, int max)
        {
            return _random.Next(min, max);
        }

     public string conn = "Data Source=SQL5110.site4now.net,1433;Initial Catalog=db_a9eacf_brainoservices;User Id=db_a9eacf_brainoservices_admin;Password=xAb@by#web1;";
    // public string conn = "Data Source=DESKTOP-6LQD0UJ\\SQLEXPRESS;Initial Catalog=MyUser;Integrated Security=True";
        public IActionResult Index()
        {

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


            string uname = HttpContext.Session.GetString("username");
            ViewBag.uname = uname;  
            SqlConnection connection = new SqlConnection(conn);
            connection.Open();
            var box = new List<Box>();
            string query = "select * from Products";
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {

                Box box1 = new Box();
                box1.Id = reader.GetInt32(0);
                box1.img = reader.GetString(1);
                box1.Pname = reader.GetString(2);
                box1.Pqty = (Int32)reader.GetValue(3);
                box1.Pcategory = reader.GetString(4);   
                box1.salePrice = (float)(Double)reader.GetValue(5);
                box1.Type = reader.GetString(6);
                box1.Sku = reader.GetString(7);
                box1.Dimension = reader.GetString(8);   

                box1.saler = reader.GetString(9);
                box1.brand = reader.GetString(10);
                box1.Description = reader.GetString(11);
                box1.Premark = reader.GetString(22);
                box.Add(box1);

                ViewData["box"] = box;

            }

            connection.Close();
               return View();
        }


        public IActionResult Allproducts()
        {

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


            string uname = HttpContext.Session.GetString("username");
            ViewBag.uname = uname;
            SqlConnection connection = new SqlConnection(conn);
            connection.Open();
            var box = new List<Box>();
            string query = "select TOP 8 * from Products";
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                 
                Box box1 = new Box();
                box1.Id = reader.GetInt32(0);
                box1.img = reader.GetString(1);
                box1.Pname = reader.GetString(2);
                box1.Pqty = (Int32)reader.GetValue(3);
                box1.Pcategory = reader.GetString(4);
                box1.salePrice = (float)(Double)reader.GetValue(5);
                box1.Type = reader.GetString(6);
                box1.Sku = reader.GetString(7);
                box1.Dimension = reader.GetString(8);

                box1.saler = reader.GetString(9);
                box1.brand = reader.GetString(10);
                box1.Description = reader.GetString(11);
                box1.Premark = reader.GetString(22);
                box.Add(box1);

                ViewData["box"] = box;

            }
            reader.Close();


            var boxes = new List<Box>();
            string query1 = "select TOP 4 * from Products where Pcategory=@Pcategory";
            SqlCommand command1 = new SqlCommand(query1, connection);
            command1.Parameters.AddWithValue("@Pcategory", "Fingerprint");
            SqlDataReader reader1 = command1.ExecuteReader();
            while (reader1.Read())
            {

                Box box2 = new Box();
                box2.Id = reader1.GetInt32(0);
                box2.img = reader1.GetString(1);
                box2.Pname = reader1.GetString(2);
                box2.Pqty = (Int32)reader1.GetValue(3);
                box2.Pcategory = reader1.GetString(4);
                box2.salePrice = (float)(Double)reader1.GetValue(5);
                box2.Type = reader1.GetString(6);
                box2.Sku = reader1.GetString(7);
                box2.Dimension = reader1.GetString(8);

                box2.saler = reader1.GetString(9);
                box2.brand = reader1.GetString(10);
                box2.Description = reader1.GetString(11);
                box2.Premark = reader1.GetString(22);
                boxes.Add(box2);

                ViewData["boxes"] = boxes;

            }
            reader1.Close();




            var boxes1 = new List<Box>();
            string query2 = "select TOP 4 * from Products where Pcategory=@Pcategory";
            SqlCommand command2 = new SqlCommand(query2, connection);
            command2.Parameters.AddWithValue("@Pcategory", "Cables");
            SqlDataReader reader2 = command2.ExecuteReader();
            while (reader2.Read())
            {

                Box box3 = new Box();
                box3.Id = reader2.GetInt32(0);
                box3.img = reader2.GetString(1);
                box3.Pname = reader2.GetString(2);
                box3.Pqty = (Int32)reader2.GetValue(3);
                box3.Pcategory = reader2.GetString(4);
                box3.salePrice = (float)(Double)reader2.GetValue(5);
                box3.Type = reader2.GetString(6);
                box3.Sku = reader2.GetString(7);
                box3.Dimension = reader2.GetString(8);

                box3.saler = reader2.GetString(9);
                box3.brand = reader2.GetString(10);
                box3.Description = reader2.GetString(11);
                box3.Premark = reader2.GetString(12);
                boxes1.Add(box3);

                ViewData["boxes1"] = boxes1;

            }
            reader2.Close();




            var boxes2 = new List<Box>();
            string query3 = "select TOP 4 * from Products where pname like '%' + @Pname + '%'";
            SqlCommand command3 = new SqlCommand(query3, connection);
            command3.Parameters.AddWithValue("@Pname", "Laptop");
            SqlDataReader reader3 = command3.ExecuteReader();
            while (reader3.Read())
            {

                Box box4 = new Box();
                box4.Id = reader3.GetInt32(0);
                box4.img = reader3.GetString(1);
                box4.Pname = reader3.GetString(2);
                box4.Pqty = (Int32)reader3.GetValue(3);
                box4.Pcategory = reader3.GetString(4);
                box4.salePrice = (float)(Double)reader3.GetValue(5);
                box4.Type = reader3.GetString(6);
                box4.Sku = reader3.GetString(7);
                box4.Dimension = reader3.GetString(8);

                box4.saler = reader3.GetString(9);
                box4.brand = reader3.GetString(10);
                box4.Description = reader3.GetString(11);
                box4.Premark = reader3.GetString(22);
                boxes2.Add(box4);

                ViewData["boxes2"] = boxes2;

            }
            reader3.Close();



            var boxes3 = new List<Box>();
            string query4 = "select TOP 4 * from Products where Pcategory=@Pcategory";
            SqlCommand command4 = new SqlCommand(query4, connection);
            command4.Parameters.AddWithValue("@Pcategory", "Smartphone");
            SqlDataReader reader4 = command4.ExecuteReader();
            while (reader4.Read())
            {

                Box box5 = new Box();
                box5.Id = reader4.GetInt32(0);
                box5.img = reader4.GetString(1);
                box5.Pname = reader4.GetString(2);
                box5.Pqty = (Int32)reader4.GetValue(3);
                box5.Pcategory = reader4.GetString(4);
                box5.salePrice = (float)(Double)reader4.GetValue(5);
                box5.Type = reader4.GetString(6);
                box5.Sku = reader4.GetString(7);
                box5.Dimension = reader4.GetString(8);
                box5.saler = reader4.GetString(9);
                box5.brand = reader4.GetString(10);
                box5.Description = reader4.GetString(11);
                box5.Premark = reader4.GetString(22);
                boxes3.Add(box5);

                ViewData["boxes3"] = boxes3;

            }
            reader4.Close();





            connection.Close();
            return View();

        }


        






        public IActionResult OrderDetails()
        {
            string id = Request.Query["id"];
            ViewBag.orderId = id;
            SqlConnection connection = new SqlConnection(conn);
            connection.Open();
            var orders = new List<Orders>();
            string query = "select *,CONVERT(varchar(50),convert(datetime,datecreated),100) as rec_time from Orders where OrderId = @OrderId ";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@OrderId", id);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {

                Orders order = new Orders();
                // order.Id = (Int32)reader.GetValue(0);
                order.orderName = (String)reader.GetValue(2);
                order.Username = (String)reader.GetValue(3);
                order.Uname = (String)reader.GetValue(4);
                order.Img = (String)reader.GetValue(5);
                order.Qty = (Int32)reader.GetValue(6);
                int qty = (Int32)reader.GetValue(6);
                order.Saleprice = (float)(Double)reader.GetValue(7);
                float price = (float)(Double)reader.GetValue(7);
                price = qty * price;
                ViewBag.price = price;
                order.Saleprice = price;
               
                order.Paytype = (String)reader.GetValue(9);
                ViewBag.Paytype = order.Paytype;
                order.OrerStatus = (String)reader.GetValue(10);
                ViewBag.OrderStatus = order.OrerStatus;
                order.PaymentStatus = (String)reader.GetValue(11);
                ViewBag.PaymentStatus = order.PaymentStatus;
                order.dateoforder = reader.GetString(16);
                ViewBag.orderDate = order.dateoforder;
                //order.Trackno = (String)reader.GetValue(12); 
                //order.Trackurl = (String)reader.GetValue(14);
                orders.Add(order);
                ViewData["orders"] = orders;

            }




            connection.Close();
            return View();
        }


        public IActionResult Details()
        {
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



            string id = Request.Query["id"];
            HttpContext.Session.SetString("pid", id);
            //HttpContext.Session.SetString("q","0");
            ViewBag.id = id;
            ViewBag.uname = HttpContext.Session.GetString("username");
            SqlConnection connection = new SqlConnection(conn);
            connection.Open();
            string query = "select id,img,pname,pqty,pcategory,saleprice,type,sku,Dimension,saler,brand, Col1,Col2,Col3,Col4,Pdesc,Premark,Col5,Col6,Col7,Col8,Col9,Col10 from products where id = @id";
            SqlCommand sqlCommand = new SqlCommand(query, connection);
            sqlCommand.Parameters.AddWithValue("@id", id);
            SqlDataReader reader = sqlCommand.ExecuteReader();
            while (reader.Read())
            {

                ViewBag.img1 = reader.GetString(1);
                ViewBag.name = reader.GetString(2);
                ViewBag.qty = (Int32)reader.GetValue(3);

                ViewBag.category = reader.GetString(4);
                ViewBag.saleprice = (float)(Double)reader.GetValue(5);
                ViewBag.type = reader.GetString(6);
                ViewBag.sku = reader.GetString(7);
                ViewBag.dimension = reader.GetString(8);
                ViewBag.saler = reader.GetString(9);
                ViewBag.brand = reader.GetString(10);

                ViewBag.weight = reader.GetString(11);
                ViewBag.color = reader.GetString(12);
                ViewBag.model = reader.GetString(13);
                ViewBag.origin = reader.GetString(14);


                ViewBag.desc = reader.GetString(15);
                ViewBag.Premark1 = reader.GetString(16);
                ViewBag.Premark2 = reader.GetString(17);
                ViewBag.Premark3 = reader.GetString(18);
                ViewBag.Premark4 = reader.GetString(19);

                ViewBag.Premark5 = reader.GetString(20);
                ViewBag.Premark6 = reader.GetString(21);
                ViewBag.Premark = reader.GetString(22);


            }
            connection.Close();

            return View();
        }

         
        public IActionResult DetailsCopy()
        {
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



            string id = Request.Query["id"];
            HttpContext.Session.SetString("pid", id);
            //HttpContext.Session.SetString("q","0");
            ViewBag.id = id;
            ViewBag.uname = HttpContext.Session.GetString("username");
            SqlConnection connection = new SqlConnection(conn);
            connection.Open();
            string query = "select * from products where Premark = @id";
            SqlCommand sqlCommand = new SqlCommand(query, connection);
            sqlCommand.Parameters.AddWithValue("@id", id);
            SqlDataReader reader = sqlCommand.ExecuteReader();
            while (reader.Read())
            {

                ViewBag.img1 = reader.GetString(1);
                ViewBag.name = reader.GetString(2);
                ViewBag.qty = (Int32)reader.GetValue(3);
                ViewBag.category = reader.GetString(4);
                ViewBag.saleprice = (float)(Double)reader.GetValue(5);
                ViewBag.type = reader.GetString(6);
                ViewBag.sku = reader.GetString(7);
                ViewBag.dimension = reader.GetString(8);
                ViewBag.saler = reader.GetString(9);
                ViewBag.brand = reader.GetString(10);
                ViewBag.desc = reader.GetString(11);
                ViewBag.premark = reader.GetString(22);


            }
            connection.Close();

            return View();
        }




        public IActionResult Cart()
        {


            ViewBag.count = 0;
            string uname = HttpContext.Session.GetString("username");
            ViewBag.uname = uname;
            var CartProductsCookie = Request.Cookies["CartProducts"];
            

            if (CartProductsCookie==null || CartProductsCookie.Length==0)
            {
                 
                
                    return RedirectToAction("Allproducts", "Products");
               
            }


            else
            {

                var carts = new List<Box>();
                Dictionary<int, int> frequency = new Dictionary<int, int>();
                var productsids = CartProductsCookie.Split('-');
                
                List<int> pIDs = productsids.Select(x => int.Parse(x)).ToList();
                ViewBag.count = pIDs.Count;
                for (int i = 0; i < pIDs.Count; i++)
                {

                    if (frequency.ContainsKey(pIDs[i]))
                    {
                        frequency[pIDs[i]]++;
                    }
                    else
                    {
                        frequency.Add(pIDs[i], 1);
                    }









                    // int id = pIDs[i];
                    // SqlConnection connection = new SqlConnection(conn);
                    // connection.Open();
                    // string query = "select * from Products where id = @id";
                    //SqlCommand command = new SqlCommand(query, connection);
                    //command.Parameters.AddWithValue("@id",id);
                    //SqlDataReader reader = command.ExecuteReader();
                    // while (reader.Read())
                    //  {
                    // Cart cart = new Cart(); 
                    // cart.pName = reader.GetString(2);
                    //  carts.Add(cart);
                    //   ViewData["carts"] = carts;   
                    //}

                }
                foreach (KeyValuePair<int, int> entry in frequency)
                    if (entry.Value > 1)
                    {
                        Console.WriteLine(entry.Key + "-->" + entry.Value);
                        int id = entry.Key;
                        float qty = entry.Value;  
                        
                        SqlConnection connection = new SqlConnection(conn);
                         connection.Open();
                        string query = "select * from Products where id = @id";
                       SqlCommand command = new SqlCommand(query, connection);
                        command.Parameters.AddWithValue("@id",id);
                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                     {
                            Box cart = new Box();
                            //cart.pName = reader.GetString(2);
                            //  carts.Add(cart);
                            //   ViewData["carts"] = carts;
                            //   
                            //Console.WriteLine("productd id = "+entry.Key);
                            //Console.WriteLine("quantity = " + entry.Value);
                            cart.Id = (Int32)reader.GetValue(0);
                            cart.img = reader.GetString(1);
                            cart.Pname = reader.GetString(2);
                            float price = (float)(Double)reader.GetValue(5);
                            cart.oldPrice = price;
                            cart.salePrice = price * qty;
                           // ViewBag.ordertotal = ViewBag.ordertotal + cart.salePrice;
                            cart.Pqty = (Int32)qty;
                            carts.Add(cart);
                            ViewData["carts"] = carts;
                        }
                        connection.Close();
                    }

                    else
                    {

                        int id = entry.Key;
                        float qty = entry.Value;

                        SqlConnection connection = new SqlConnection(conn);
                        connection.Open();
                        string query = "select * from Products where id = @id";
                        SqlCommand command = new SqlCommand(query, connection);
                        command.Parameters.AddWithValue("@id", id);
                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            Box cart = new Box();
                            //cart.pName = reader.GetString(2);
                            //  carts.Add(cart);
                            //   ViewData["carts"] = carts;
                            //   
                            //Console.WriteLine("productd id = "+entry.Key);
                            //Console.WriteLine("quantity = " + entry.Value);
                            cart.Id = (Int32)reader.GetValue(0);
                            cart.img = reader.GetString(1);
                            cart.Pname = reader.GetString(2);
                            float price = (float)(Double)reader.GetValue(5);
                            cart.oldPrice = price;
                            cart.salePrice = price * qty;
                           // ViewBag.ordertotal = ViewBag.ordertotal + cart.salePrice;
                            cart.Pqty = (Int32)qty;
                            carts.Add(cart);
                            ViewData["carts"] = carts;
                        }
                        connection.Close();
                         Console.WriteLine(entry.Key);
                    }
                       


            }
           


            return View();





          
        }



        public IActionResult Checkout()
        {

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

            string pid = HttpContext.Session.GetString("pid");
            ViewBag.uname = HttpContext.Session.GetString("username");
            SqlConnection connection = new SqlConnection(conn);
            connection.Open();
            string query4 = "select * from Products where id= @id";
            SqlCommand cmd4 = new SqlCommand(query4, connection);
            cmd4.Parameters.AddWithValue("@id", pid);
            SqlDataReader dataReader = cmd4.ExecuteReader();
            while (dataReader.Read())
            {
                ViewBag.img = dataReader.GetString(1);
                ViewBag.pname = dataReader.GetString(2);
                ViewBag.saleprice = dataReader.GetValue(5);


            }

            connection.Close();
            return View();  
        }

        [HttpPost]
        public IActionResult Checkout(string custname, string email, string password, string street, string city, string post, string phone)
        {


            string pid = HttpContext.Session.GetString("pid");
            SqlConnection connection = new SqlConnection(conn);
            connection.Open();
            string query = "select count(*) from registereduser where email = @email";
            SqlCommand sqlCommand = new SqlCommand(query, connection);
            sqlCommand.Parameters.AddWithValue("@email", email);
            int count = (Int32)sqlCommand.ExecuteScalar();


            if (count > 0)
            {
                Console.WriteLine("User alresdy exists!");
            }
            else
            {
                string query1 = "insert into registereduser (custname,email,password,street,city,post,phone) values(@custname,@email,@password,@street,@city,@post,@phone)";
                SqlCommand cmd = new SqlCommand(query1, connection);
                cmd.Parameters.AddWithValue("@custname", custname);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@password", password);
                cmd.Parameters.AddWithValue("@street", street);
                cmd.Parameters.AddWithValue("@city", city);
                cmd.Parameters.AddWithValue("@post", post);
                cmd.Parameters.AddWithValue("@phone", phone);
                cmd.ExecuteNonQuery();

                string query3 = "insert into login_User (Username,Password)values(@Username,@Password)";
                SqlCommand cmd3 = new SqlCommand(query3, connection);
                cmd3.Parameters.AddWithValue("@Username", email);
                cmd3.Parameters.AddWithValue("@Password", password);
                cmd3.ExecuteNonQuery();

            }


            string query4 = "select * from Products where id= @id";
            SqlCommand cmd4 = new SqlCommand(query4, connection);
            cmd4.Parameters.AddWithValue("@id", pid);
            SqlDataReader dataReader = cmd4.ExecuteReader();
            while (dataReader.Read())
            {
                ViewBag.img = dataReader.GetString(1);
                ViewBag.pname = dataReader.GetString(2);
                ViewBag.saleprice = dataReader.GetValue(5);


            }

            connection.Close();

            return View();
        }

        public IActionResult Loginfromcheckout(string Username,string Password)
        {
            var account = _accountService.Login(Username, Password);

            if (account != null)
            {
                string uname = account.Username;
                string folder = "";

                string url = "";

                List<Claim> claims = new List<Claim>();
                claims.Add(new Claim(ClaimTypes.NameIdentifier, Username));
                claims.Add(new Claim(ClaimTypes.Name, Username));
                if (uname == "admin")
                {
                    claims.Add(new Claim(ClaimTypes.Role, "Admin"));
                    folder = "Products";
                    url = "Index";

                }
                else
                {
                    claims.Add(new Claim(ClaimTypes.Role, "User"));
                    folder = "Products";
                    url = "Checkout";
                }



                ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIdentity);


                HttpContext.SignInAsync(claimsPrincipal);

                HttpContext.Session.SetString("username", uname);




                return RedirectToAction(url, folder);



            }
            else
            {
                ViewBag.Message = "Invalid login";
                return View();
            }







            
        }





        public IActionResult Order()
        {

            return View();
        }



        [HttpPost]
        public IActionResult Order(string paytype)
        {
            int qty = 1;
            DateTime dateTime = DateTime.Now;
            dateTime = dateTime.Date;
            string Orderstatus = "processing";
            string Paymentstatus = "pending";
            string uname = HttpContext.Session.GetString("username");
            string pid = HttpContext.Session.GetString("pid");
            SqlConnection connection = new SqlConnection(conn);
            connection.Open();
            string query = "select * from Products where id = @id";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@id", pid);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                ViewBag.img = reader.GetString(1);
                ViewBag.pname = reader.GetString(2);
                ViewBag.saleprice = reader.GetValue(5);



            }
            reader.Close();
            string query1 = "select * from RegisteredUser where email = @email";
            SqlCommand cmd1 = new SqlCommand(query1, connection);
            cmd1.Parameters.AddWithValue("@email", uname);
            SqlDataReader reader1 = cmd1.ExecuteReader();
            while (reader1.Read())
            {
                ViewBag.custname = reader1.GetString(1);
                Console.WriteLine(ViewBag.custname);

            }
            reader1.Close();
            string query2 = "insert into Orders (Ordername,Username,Uname,Img,Qty,Saleprice,Datecreated,Paytype,Orderstatus,Paymentstatus)values(@Ordername,@Username,@Uname,@Img,@Qty,@Saleprice,@Datecreated,@Paytype,@Orderstatus,@Paymentstatus)";
            SqlCommand cmd2 = new SqlCommand(query2, connection);
            cmd2.Parameters.AddWithValue("@Ordername", ViewBag.pname);
            cmd2.Parameters.AddWithValue("@Username", uname);
            cmd2.Parameters.AddWithValue("@Uname", ViewBag.custname);
            cmd2.Parameters.AddWithValue("@Img", ViewBag.img);
            cmd2.Parameters.AddWithValue("@Qty", qty);
            cmd2.Parameters.AddWithValue("@Saleprice", ViewBag.saleprice);
            cmd2.Parameters.AddWithValue("@Datecreated", dateTime);
            cmd2.Parameters.AddWithValue("@Paytype", paytype);
            cmd2.Parameters.AddWithValue("@Orderstatus", Orderstatus);
            cmd2.Parameters.AddWithValue("@Paymentstatus", Paymentstatus);
            cmd2.ExecuteNonQuery();
            connection.Close();
            return View();
        }



        public IActionResult DeleteCart()
        {

           
            return View();
        }

        private void  Empty()
        {

            string key = "CartProducts";
            string value = string.Empty;
            CookieOptions options = new CookieOptions
            {
                Expires = DateTime.Now.AddDays(-1)

            };
            Response.Cookies.Append(key, value, options);
            
        }

        public IActionResult Checkout1()
        {




            ViewBag.count = 0;

            ViewBag.ordertotal = 0;
            ViewBag.uname = HttpContext.Session.GetString("username");
            var CartProductsCookie = Request.Cookies["CartProducts"];

            if (CartProductsCookie == null || CartProductsCookie.Length == 0)
            {


                return RedirectToAction("Allproducts", "Products");

            }

            else 
            {

                var carts = new List<Box>();
                Dictionary<int, int> frequency = new Dictionary<int, int>();
                var productsids = CartProductsCookie.Split('-');
                List<int> pIDs = productsids.Select(x => int.Parse(x)).ToList();
                ViewBag.count = pIDs.Count;
                for (int i = 0; i < pIDs.Count; i++)
                {

                    if (frequency.ContainsKey(pIDs[i]))
                    {
                        frequency[pIDs[i]]++;
                    }
                    else
                    {
                        frequency.Add(pIDs[i], 1);
                    }









                    // int id = pIDs[i];
                    // SqlConnection connection = new SqlConnection(conn);
                    // connection.Open();
                    // string query = "select * from Products where id = @id";
                    //SqlCommand command = new SqlCommand(query, connection);
                    //command.Parameters.AddWithValue("@id",id);
                    //SqlDataReader reader = command.ExecuteReader();
                    // while (reader.Read())
                    //  {
                    // Cart cart = new Cart(); 
                    // cart.pName = reader.GetString(2);
                    //  carts.Add(cart);
                    //   ViewData["carts"] = carts;   
                    //}

                }
                foreach (KeyValuePair<int, int> entry in frequency)
                    if (entry.Value > 1)
                    {
                        Console.WriteLine(entry.Key + "-->" + entry.Value);
                        int id = entry.Key;
                        float qty = entry.Value;

                        SqlConnection connection = new SqlConnection(conn);
                        connection.Open();
                        string query = "select * from Products where id = @id";
                        SqlCommand command = new SqlCommand(query, connection);
                        command.Parameters.AddWithValue("@id", id);
                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            Box cart = new Box();
                            //cart.pName = reader.GetString(2);
                            //  carts.Add(cart);
                            //   ViewData["carts"] = carts;
                            //   
                            //Console.WriteLine("productd id = "+entry.Key);
                            //Console.WriteLine("quantity = " + entry.Value);
                            cart.img = reader.GetString(1);
                            cart.Pname = reader.GetString(2);
                            cart.Dimension = reader.GetString(8);
                            cart.oldPrice = (float)(Double)reader.GetValue(5);
                            float price = (float)(Double)reader.GetValue(5);
                            cart.salePrice = price * qty;
                            ViewBag.ordertotal = ViewBag.ordertotal + cart.salePrice;
                            cart.Pqty = (Int32)qty;
                            carts.Add(cart);
                            ViewData["carts"] = carts;
                        }
                        connection.Close();
                    }

                    else
                    {

                        int id = entry.Key;
                        float qty = entry.Value;

                        SqlConnection connection = new SqlConnection(conn);
                        connection.Open();
                        string query = "select * from Products where id = @id";
                        SqlCommand command = new SqlCommand(query, connection);
                        command.Parameters.AddWithValue("@id", id);
                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            Box cart = new Box();
                            //cart.pName = reader.GetString(2);
                            //  carts.Add(cart);
                            //   ViewData["carts"] = carts;
                            //   
                            //Console.WriteLine("productd id = "+entry.Key);
                            //Console.WriteLine("quantity = " + entry.Value);

                            cart.img = reader.GetString(1);
                            cart.Pname = reader.GetString(2);
                            cart.Dimension = reader.GetString(8);
                            float price = (float)(Double)reader.GetValue(5);
                            cart.oldPrice = (float)(Double)reader.GetValue(5);
                            cart.salePrice = price * qty;
                            ViewBag.ordertotal = ViewBag.ordertotal + cart.salePrice;
                            cart.Pqty = (Int32)qty;
                            carts.Add(cart);
                            ViewData["carts"] = carts;
                        }
                        connection.Close();
                        // Console.WriteLine(entry.Key);
                    }



            }
           


            return View();

        }

       


        [HttpPost]
        public IActionResult Checkout1(string custname, string email, string password, string street, string city, string post, string phone)
        {



            /*------------------*/

            ViewBag.count = 0;

            ViewBag.ordertotal = 0;
            ViewBag.uname = HttpContext.Session.GetString("username");
            var CartProductsCookie = Request.Cookies["CartProducts"];

            if (CartProductsCookie == null || CartProductsCookie.Length == 0)
            {


                return RedirectToAction("Allproducts", "Products");

            }

            else
            {

                var carts = new List<Box>();
                Dictionary<int, int> frequency = new Dictionary<int, int>();
                var productsids = CartProductsCookie.Split('-');
                List<int> pIDs = productsids.Select(x => int.Parse(x)).ToList();
                ViewBag.count = pIDs.Count;
                for (int i = 0; i < pIDs.Count; i++)
                {

                    if (frequency.ContainsKey(pIDs[i]))
                    {
                        frequency[pIDs[i]]++;
                    }
                    else
                    {
                        frequency.Add(pIDs[i], 1);
                    }









                    // int id = pIDs[i];
                    // SqlConnection connection = new SqlConnection(conn);
                    // connection.Open();
                    // string query = "select * from Products where id = @id";
                    //SqlCommand command = new SqlCommand(query, connection);
                    //command.Parameters.AddWithValue("@id",id);
                    //SqlDataReader reader = command.ExecuteReader();
                    // while (reader.Read())
                    //  {
                    // Cart cart = new Cart(); 
                    // cart.pName = reader.GetString(2);
                    //  carts.Add(cart);
                    //   ViewData["carts"] = carts;   
                    //}

                }
                foreach (KeyValuePair<int, int> entry in frequency)
                    if (entry.Value > 1)
                    {
                        Console.WriteLine(entry.Key + "-->" + entry.Value);
                        int id = entry.Key;
                        float qty = entry.Value;

                        SqlConnection connection = new SqlConnection(conn);
                        connection.Open();
                        string query = "select * from Products where id = @id";
                        SqlCommand command = new SqlCommand(query, connection);
                        command.Parameters.AddWithValue("@id", id);
                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            Box cart = new Box();
                            //cart.pName = reader.GetString(2);
                            //  carts.Add(cart);
                            //   ViewData["carts"] = carts;
                            //   
                            //Console.WriteLine("productd id = "+entry.Key);
                            //Console.WriteLine("quantity = " + entry.Value);
                            cart.img = reader.GetString(1);
                            cart.Pname = reader.GetString(2);
                            cart.oldPrice = (float)(Double)reader.GetValue(5);
                            float price = (float)(Double)reader.GetValue(5);
                            cart.salePrice = price * qty;
                            ViewBag.ordertotal = ViewBag.ordertotal + cart.salePrice;
                            cart.Pqty = (Int32)qty;
                            carts.Add(cart);
                            ViewData["carts"] = carts;
                        }
                        connection.Close();
                    }

                    else
                    {

                        int id = entry.Key;
                        float qty = entry.Value;

                        SqlConnection connection = new SqlConnection(conn);
                        connection.Open();
                        string query = "select * from Products where id = @id";
                        SqlCommand command = new SqlCommand(query, connection);
                        command.Parameters.AddWithValue("@id", id);
                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            Box cart = new Box();
                            //cart.pName = reader.GetString(2);
                            //  carts.Add(cart);
                            //   ViewData["carts"] = carts;
                            //   
                            //Console.WriteLine("productd id = "+entry.Key);
                            //Console.WriteLine("quantity = " + entry.Value);

                            cart.img = reader.GetString(1);
                            cart.Pname = reader.GetString(2);
                            float price = (float)(Double)reader.GetValue(5);
                            cart.oldPrice = (float)(Double)reader.GetValue(5);
                            cart.salePrice = price * qty;
                            ViewBag.ordertotal = ViewBag.ordertotal + cart.salePrice;
                            cart.Pqty = (Int32)qty;
                            carts.Add(cart);
                            ViewData["carts"] = carts;
                        }
                        connection.Close();
                        // Console.WriteLine(entry.Key);
                    }



            }


            /*----------------*/







            string uname = HttpContext.Session.GetString("username");
            ViewBag.uname = uname;
            string pid = HttpContext.Session.GetString("pid");
            SqlConnection connection1 = new SqlConnection(conn);
            connection1.Open();
            string querys = "select count(*) from registereduser where email = @email";
            SqlCommand sqlCommand = new SqlCommand(querys, connection1);
            sqlCommand.Parameters.AddWithValue("@email", email);
            int count = (Int32)sqlCommand.ExecuteScalar();


            if (count > 0)
            {
                ViewBag.msg = "user already exists";
                Console.WriteLine("User alresdy exists!");
            }
            else
            {
                string query1 = "insert into registereduser (custname,email,password,street,city,post,phone) values(@custname,@email,@password,@street,@city,@post,@phone)";
                SqlCommand cmd = new SqlCommand(query1, connection1);
                cmd.Parameters.AddWithValue("@custname", custname);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@password", password);
                cmd.Parameters.AddWithValue("@street", street);
                cmd.Parameters.AddWithValue("@city", city);
                cmd.Parameters.AddWithValue("@post", post);
                cmd.Parameters.AddWithValue("@phone", phone);
                cmd.ExecuteNonQuery();

                string query3 = "insert into login_User (Username,Password)values(@Username,@Password)";
                SqlCommand cmd3 = new SqlCommand(query3, connection1);
                cmd3.Parameters.AddWithValue("@Username", email);
                cmd3.Parameters.AddWithValue("@Password", password);
                cmd3.ExecuteNonQuery();
                ViewBag.msg = " you are successfully Registered";
            }


          

            connection1.Close();

            return View();
        }




        public IActionResult LoginfromCheckout1(string Username, string Password)
        {
               ViewBag.count = 0;

            ViewBag.ordertotal = 0;
            ViewBag.uname = HttpContext.Session.GetString("username");
            var CartProductsCookie = Request.Cookies["CartProducts"];

            if (CartProductsCookie == null || CartProductsCookie.Length == 0)
            {


                return RedirectToAction("Allproducts", "Products");

            }

            else 
            {

                var carts = new List<Box>();
                Dictionary<int, int> frequency = new Dictionary<int, int>();
                var productsids = CartProductsCookie.Split('-');
                List<int> pIDs = productsids.Select(x => int.Parse(x)).ToList();
                ViewBag.count = pIDs.Count;
                for (int i = 0; i < pIDs.Count; i++)
                {

                    if (frequency.ContainsKey(pIDs[i]))
                    {
                        frequency[pIDs[i]]++;
                    }
                    else
                    {
                        frequency.Add(pIDs[i], 1);
                    }









                    // int id = pIDs[i];
                    // SqlConnection connection = new SqlConnection(conn);
                    // connection.Open();
                    // string query = "select * from Products where id = @id";
                    //SqlCommand command = new SqlCommand(query, connection);
                    //command.Parameters.AddWithValue("@id",id);
                    //SqlDataReader reader = command.ExecuteReader();
                    // while (reader.Read())
                    //  {
                    // Cart cart = new Cart(); 
                    // cart.pName = reader.GetString(2);
                    //  carts.Add(cart);
                    //   ViewData["carts"] = carts;   
                    //}

                }
                foreach (KeyValuePair<int, int> entry in frequency)
                    if (entry.Value > 1)
                    {
                        Console.WriteLine(entry.Key + "-->" + entry.Value);
                        int id = entry.Key;
                        float qty = entry.Value;

                        SqlConnection connection = new SqlConnection(conn);
                        connection.Open();
                        string query = "select * from Products where id = @id";
                        SqlCommand command = new SqlCommand(query, connection);
                        command.Parameters.AddWithValue("@id", id);
                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            Box cart = new Box();
                            //cart.pName = reader.GetString(2);
                            //  carts.Add(cart);
                            //   ViewData["carts"] = carts;
                            //   
                            //Console.WriteLine("productd id = "+entry.Key);
                            //Console.WriteLine("quantity = " + entry.Value);
                            cart.img = reader.GetString(1);
                            cart.Pname = reader.GetString(2);
                            cart.oldPrice = (float)(Double)reader.GetValue(5);
                            float price = (float)(Double)reader.GetValue(5);
                            cart.salePrice = price * qty;
                            ViewBag.ordertotal = ViewBag.ordertotal + cart.salePrice;
                            cart.Pqty = (Int32)qty;
                            carts.Add(cart);
                            ViewData["carts"] = carts;
                        }
                        connection.Close();
                    }

                    else
                    {

                        int id = entry.Key;
                        float qty = entry.Value;

                        SqlConnection connection = new SqlConnection(conn);
                        connection.Open();
                        string query = "select * from Products where id = @id";
                        SqlCommand command = new SqlCommand(query, connection);
                        command.Parameters.AddWithValue("@id", id);
                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            Box cart = new Box();
                            //cart.pName = reader.GetString(2);
                            //  carts.Add(cart);
                            //   ViewData["carts"] = carts;
                            //   
                            //Console.WriteLine("productd id = "+entry.Key);
                            //Console.WriteLine("quantity = " + entry.Value);

                            cart.img = reader.GetString(1);
                            cart.Pname = reader.GetString(2);
                            float price = (float)(Double)reader.GetValue(5);
                            cart.oldPrice = (float)(Double)reader.GetValue(5);
                            cart.salePrice = price * qty;
                            ViewBag.ordertotal = ViewBag.ordertotal + cart.salePrice;
                            cart.Pqty = (Int32)qty;
                            carts.Add(cart);
                            ViewData["carts"] = carts;
                        }
                        connection.Close();
                        // Console.WriteLine(entry.Key);
                    }



            }
           







            var account = _accountService.Login(Username, Password);

            if (account != null)
            {
                string uname = account.Username;
                string folder = "";

                string url = "";

                List<Claim> claims = new List<Claim>();
                claims.Add(new Claim(ClaimTypes.NameIdentifier, Username));
                claims.Add(new Claim(ClaimTypes.Name, Username));
                if (uname == "admin")
                {
                    claims.Add(new Claim(ClaimTypes.Role, "Admin"));
                    folder = "Products";
                    url = "Allproducts";

                }

               

                else
                {
                    claims.Add(new Claim(ClaimTypes.Role, "User"));
                    folder = "Products";
                    url = "Checkout1";
                }



                ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIdentity);


                HttpContext.SignInAsync(claimsPrincipal);

                HttpContext.Session.SetString("username", uname);




                return RedirectToAction(url, folder);



            }
            else
            {
                ViewBag.msg = "Invalid Username Or Password";
                return View();
            }








        }

        /*public IActionResult Order1()
        {

            return View();
        }*/
        public IActionResult Order1(string paytype)
        {

            if(paytype!="cod")
            {
                return RedirectToAction("Order2","Products");
            }


            ViewBag.OrderTotal = 0;
            float salprice = 0;
            DateTime dateTime = DateTime.Now;
            string Orderstatus = "processing";
            string Paymentstatus = "pending";
            string uname = HttpContext.Session.GetString("username");

            var CartProductsCookie = Request.Cookies["CartProducts"];

            if (CartProductsCookie != null)
            {

                SqlConnection sqlConnection = new SqlConnection(conn);
                sqlConnection.Open();
                string query3 = "insert into myorder (placed,Username,Datecreated,Paytype,Orderstatus,Paymentstatus,TrackNo,Shippingp,Trackurl,Shippingdate)values(@placed,@Username,@Datecreated,@Paytype,@Orderstatus,@Paymentstatus,@TrackNo,@Shippingp,@Trackurl,@Shippingdate);" + "select SCOPE_IDENTITY();";
                SqlCommand command1 = new SqlCommand(query3, sqlConnection);
                command1.Parameters.AddWithValue("@placed", "placed");
                command1.Parameters.AddWithValue("@Username", uname);
                command1.Parameters.AddWithValue("@Datecreated", dateTime); 
                command1.Parameters.AddWithValue("@Paytype", paytype);
                command1.Parameters.AddWithValue("@Orderstatus", Orderstatus);
                command1.Parameters.AddWithValue("@Paymentstatus", Paymentstatus);
                command1.Parameters.AddWithValue("@Trackno", "");
                command1.Parameters.AddWithValue("@Shippingp", "");
                command1.Parameters.AddWithValue("@Trackurl", "");
                command1.Parameters.AddWithValue("@Shippingdate", dateTime);
                int igetlastid = Convert.ToInt32(command1.ExecuteScalar());
                ViewBag.OrderId = igetlastid;

                sqlConnection.Close();


                var carts = new List<Box>();
                Dictionary<int, int> frequency = new Dictionary<int, int>();
                var productsids = CartProductsCookie.Split('-');
                List<int> pIDs = productsids.Select(x => int.Parse(x)).ToList();
                for (int i = 0; i < pIDs.Count; i++)
                {

                    if (frequency.ContainsKey(pIDs[i]))
                    {
                        frequency[pIDs[i]]++;
                    }
                    else
                    {
                        frequency.Add(pIDs[i], 1);
                    }

                }
                foreach (KeyValuePair<int, int> entry in frequency)
                {
                    if (entry.Value > 1)
                    {
                        Console.WriteLine(entry.Key + "-->" + entry.Value);
                        int id = entry.Key;
                        float qty = entry.Value;

                        SqlConnection connection = new SqlConnection(conn);
                        connection.Open();
                        string query = "select * from Products where id = @id";
                        SqlCommand command = new SqlCommand(query, connection);
                        command.Parameters.AddWithValue("@id", id);
                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            Box cart = new Box();


                            cart.Pname = reader.GetString(2);
                            ViewBag.img = reader.GetString(1);
                            ViewBag.pname = reader.GetString(2);
                            ViewBag.saleprice = reader.GetValue(5);
                            salprice = (float)(double)reader.GetValue(5); 
                            salprice = salprice * qty; 
                            carts.Add(cart);
                            
                            

                        }
                        reader.Close();

                        string query1 = "select * from RegisteredUser where email = @email";
                        SqlCommand cmd1 = new SqlCommand(query1, connection);
                        cmd1.Parameters.AddWithValue("@email", uname);
                        SqlDataReader reader1 = cmd1.ExecuteReader();
                        while (reader1.Read())
                        {
                            ViewBag.custname = reader1.GetString(1);
                            Console.WriteLine(ViewBag.custname);

                        }
                        reader1.Close();

                       
                        

                       string query2 = "insert into Orders (OrderId,Ordername,Username,Uname,Img,Qty,Saleprice,Datecreated,Paytype,Orderstatus,Paymentstatus,TrackNo,Shippingp,Trackurl,Shippingdate)values(@OrderId,@Ordername,@Username,@Uname,@Img,@Qty,@Saleprice,@Datecreated,@Paytype,@Orderstatus,@Paymentstatus,@Trackno,@Shippingp,@Trackurl,@Shippingdate)";
                        SqlCommand cmd2 = new SqlCommand(query2, connection);
                        cmd2.Parameters.AddWithValue("@OrderId", ViewBag.OrderId);
                        cmd2.Parameters.AddWithValue("@Ordername", ViewBag.pname);
                        cmd2.Parameters.AddWithValue("@Username", uname);
                        cmd2.Parameters.AddWithValue("@Uname", ViewBag.custname);
                        cmd2.Parameters.AddWithValue("@Img", ViewBag.img);
                        cmd2.Parameters.AddWithValue("@Qty", qty);
                        cmd2.Parameters.AddWithValue("@Saleprice", ViewBag.saleprice);
                        cmd2.Parameters.AddWithValue("@Datecreated", dateTime);
                        cmd2.Parameters.AddWithValue("@Paytype", paytype);
                        cmd2.Parameters.AddWithValue("@Orderstatus", Orderstatus);
                        cmd2.Parameters.AddWithValue("@Paymentstatus", Paymentstatus);
                        cmd2.Parameters.AddWithValue("@Trackno", "");
                        cmd2.Parameters.AddWithValue("@Shippingp", "");
                        cmd2.Parameters.AddWithValue("@Trackurl", "");
                       
                        cmd2.Parameters.AddWithValue("@Shippingdate", dateTime);
                        cmd2.ExecuteNonQuery();


                        connection.Close();

                    }

                    else
                    {

                        int id = entry.Key;
                        float qty = entry.Value;

                        SqlConnection connection = new SqlConnection(conn);
                        connection.Open();
                        string query = "select * from Products where id = @id";
                        SqlCommand command = new SqlCommand(query, connection);
                        command.Parameters.AddWithValue("@id", id);
                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            Box cart = new Box();

                            cart.Pname = reader.GetString(2);
                            ViewBag.img = reader.GetString(1);
                            ViewBag.pname = reader.GetString(2);
                            ViewBag.saleprice = reader.GetValue(5);
                            carts.Add(cart);
                        }
                        // Console.WriteLine(entry.Key);
                        reader.Close();

                        string query1 = "select * from RegisteredUser where email = @email";
                        SqlCommand cmd1 = new SqlCommand(query1, connection);
                        cmd1.Parameters.AddWithValue("@email", uname);
                        SqlDataReader reader1 = cmd1.ExecuteReader();
                        while (reader1.Read())
                        {
                            ViewBag.custname = reader1.GetString(1);
                            Console.WriteLine(ViewBag.custname);

                        }
                        reader1.Close();

                        string query2 = "insert into Orders (OrderId,Ordername,Username,Uname,Img,Qty,Saleprice,Datecreated,Paytype,Orderstatus,Paymentstatus,TrackNo,Shippingp,Trackurl,Shippingdate)values(@OrderId,@Ordername,@Username,@Uname,@Img,@Qty,@Saleprice,@Datecreated,@Paytype,@Orderstatus,@Paymentstatus,@Trackno,@Shippingp,@Trackurl,@Shippingdate)";
                        SqlCommand cmd2 = new SqlCommand(query2, connection);
                        cmd2.Parameters.AddWithValue("@OrderId", ViewBag.OrderId);
                        cmd2.Parameters.AddWithValue("@Ordername", ViewBag.pname);
                        cmd2.Parameters.AddWithValue("@Username", uname);
                        cmd2.Parameters.AddWithValue("@Uname", ViewBag.custname);
                        cmd2.Parameters.AddWithValue("@Img", ViewBag.img);
                        cmd2.Parameters.AddWithValue("@Qty", qty);
                        cmd2.Parameters.AddWithValue("@Saleprice", ViewBag.saleprice);
                        cmd2.Parameters.AddWithValue("@Datecreated", dateTime);
                        cmd2.Parameters.AddWithValue("@Paytype", paytype);
                        cmd2.Parameters.AddWithValue("@Orderstatus", Orderstatus);
                        cmd2.Parameters.AddWithValue("@Paymentstatus", Paymentstatus);
                        cmd2.Parameters.AddWithValue("@Trackno", "");
                        cmd2.Parameters.AddWithValue("@Shippingp", "");
                        cmd2.Parameters.AddWithValue("@Trackurl", "");
                        
                        cmd2.Parameters.AddWithValue("@Shippingdate", dateTime);
                        cmd2.ExecuteNonQuery();

                        connection.Close();




                    }
                }




                Console.WriteLine(salprice);
                MailMessage mail = new MailMessage("brainoservices8@gmail.com", uname);
                mail.Subject = "New Email";
                mail.Subject = "Orders";
                mail.Body = "hello";


                mail.AlternateViews.Add(AlternateView.CreateAlternateViewFromString(CreateBody(), null, MediaTypeNames.Text.Html));
               


                mail.Priority = MailPriority.Low;
                mail.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;

                smtp.Credentials = new NetworkCredential()
                {
                    UserName = "brainoservices8@gmail.com",
                    Password = "wagglazvlslqeebg",
                };

                smtp.EnableSsl = true;
                smtp.Send(mail);
                


                MailMessage mail1 = new MailMessage("brainoservices8@gmail.com", "brainoservices8@gmail.com");
                mail1.Subject = "New Email";
                mail1.Subject = "Orders";
                mail1.Body = "hello";


                mail1.AlternateViews.Add(AlternateView.CreateAlternateViewFromString(CreateBody1(), null, MediaTypeNames.Text.Html));



                mail1.Priority = MailPriority.Low;
                mail1.IsBodyHtml = true;
                SmtpClient smtp1 = new SmtpClient("smtp.gmail.com", 587);
                smtp1.DeliveryMethod = SmtpDeliveryMethod.Network;

                smtp1.Credentials = new NetworkCredential()
                {
                    UserName = "brainoservices8@gmail.com",
                    Password = "wagglazvlslqeebg",
                };

                smtp1.EnableSsl = true;
                smtp1.Send(mail1);
                Empty();


                /*string key = "rzp_live_3NLZP2r70O1kQx";
                string secret = "3NPzxPPbyrn1tRqVtxef5sqZ";

                Random _random = new Random();

                string TransactionId = _random.Next(0, 10000).ToString();


                Dictionary<string, object> input = new Dictionary<string, object>();
                input.Add("amount", Convert.ToDecimal(1) * 100); // this amount should be same as transaction amount
                input.Add("currency", "INR");
                input.Add("receipt", TransactionId);


                RazorpayClient client = new RazorpayClient(key, secret);

                Razorpay.Api.Order order = client.Order.Create(input);
                ViewBag.orderid = order["id"].ToString();
                return View("Payment");*/










            }
            else
            {
                return RedirectToAction("Allproducts", "Products");
            }


            return RedirectToAction("Myaccount", "Products");


            




        }

        /* this is the start of Online order*/

         public IActionResult Order2()
      {
          //string paytype ="online";
          ViewBag.OrderTotal = 0;
          float salprice = 0;
          DateTime dateTime = DateTime.Now;
          dateTime = dateTime.Date;
          dateTime = dateTime.Date;
          string Orderstatus = "processing";
          string Paymentstatus = "Pending";
          string uname = HttpContext.Session.GetString("username");

          var CartProductsCookie = Request.Cookies["CartProducts"];

          if (CartProductsCookie != null)
          {

              /*SqlConnection sqlConnection = new SqlConnection(conn);
               sqlConnection.Open();
              string query3 = "insert into myorder (placed,Username,Datecreated,Paytype,Orderstatus,Paymentstatus,TrackNo,Shippingp,Trackurl,Shippingdate)values(@placed,@Username,@Datecreated,@Paytype,@Orderstatus,@Paymentstatus,@TrackNo,@Shippingp,@Trackurl,@Shippingdate);" + "select SCOPE_IDENTITY();";
              SqlCommand command1 = new SqlCommand(query3, sqlConnection);
              command1.Parameters.AddWithValue("@placed", "placed");
              command1.Parameters.AddWithValue("@Username", uname);
              command1.Parameters.AddWithValue("@Datecreated", dateTime);
              command1.Parameters.AddWithValue("@Paytype", paytype);
              command1.Parameters.AddWithValue("@Orderstatus", Orderstatus);
              command1.Parameters.AddWithValue("@Paymentstatus", Paymentstatus);
              command1.Parameters.AddWithValue("@Trackno", "");
              command1.Parameters.AddWithValue("@Shippingp", "");
              command1.Parameters.AddWithValue("@Trackurl", "");
              command1.Parameters.AddWithValue("@Shippingdate", dateTime);
              int igetlastid = Convert.ToInt32(command1.ExecuteScalar());
              ViewBag.OrderId = igetlastid;


              sqlConnection.Close();

              HttpContext.Session.SetString("latestid",igetlastid.ToString());
              */
              var carts = new List<Box>();
              Dictionary<int, int> frequency = new Dictionary<int, int>();
              var productsids = CartProductsCookie.Split('-');
              List<int> pIDs = productsids.Select(x => int.Parse(x)).ToList();
              for (int i = 0; i < pIDs.Count; i++)
              {

                  if (frequency.ContainsKey(pIDs[i]))
                  {
                      frequency[pIDs[i]]++;
                  }
                  else
                  {
                      frequency.Add(pIDs[i], 1);
                  }

              }
              foreach (KeyValuePair<int, int> entry in frequency)
              {
                  if (entry.Value > 1)
                  {
                      Console.WriteLine(entry.Key + "-->" + entry.Value);
                      int id = entry.Key;
                      float qty = entry.Value;

                      SqlConnection connection = new SqlConnection(conn);
                      connection.Open();
                      string query = "select * from Products where id = @id";
                      SqlCommand command = new SqlCommand(query, connection);
                      command.Parameters.AddWithValue("@id", id);
                      SqlDataReader reader = command.ExecuteReader();
                      while (reader.Read())
                      {
                          Box cart = new Box();


                          cart.Pname = reader.GetString(2);
                          ViewBag.img = reader.GetString(1);
                          ViewBag.pname = reader.GetString(2);
                          ViewBag.saleprice = reader.GetValue(5);
                          salprice = (float)(double)reader.GetValue(5);
                          salprice = salprice * qty;
                          carts.Add(cart);



                      }
                      reader.Close();

                      string query1 = "select * from RegisteredUser where email = @email";
                      SqlCommand cmd1 = new SqlCommand(query1, connection);
                      cmd1.Parameters.AddWithValue("@email", uname);
                      SqlDataReader reader1 = cmd1.ExecuteReader();
                      while (reader1.Read())
                      {
                          ViewBag.custname = reader1.GetString(1);
                          ViewBag.email = reader1.GetString(2);
                          ViewBag.phone = reader1.GetString(7);
                          Console.WriteLine(ViewBag.custname);

                      }
                      reader1.Close();




                     /* string query2 = "insert into Orders (OrderId,Ordername,Username,Uname,Img,Qty,Saleprice,Datecreated,Paytype,Orderstatus,Paymentstatus,TrackNo,Shippingp,Trackurl,Shippingdate)values(@OrderId,@Ordername,@Username,@Uname,@Img,@Qty,@Saleprice,@Datecreated,@Paytype,@Orderstatus,@Paymentstatus,@Trackno,@Shippingp,@Trackurl,@Shippingdate)";
                      SqlCommand cmd2 = new SqlCommand(query2, connection);
                      cmd2.Parameters.AddWithValue("@OrderId", ViewBag.OrderId);
                      cmd2.Parameters.AddWithValue("@Ordername", ViewBag.pname);
                      cmd2.Parameters.AddWithValue("@Username", uname);
                      cmd2.Parameters.AddWithValue("@Uname", ViewBag.custname);
                      cmd2.Parameters.AddWithValue("@Img", ViewBag.img);
                      cmd2.Parameters.AddWithValue("@Qty", qty);
                      cmd2.Parameters.AddWithValue("@Saleprice", ViewBag.saleprice);
                      cmd2.Parameters.AddWithValue("@Datecreated", dateTime);
                      cmd2.Parameters.AddWithValue("@Paytype", paytype);
                      cmd2.Parameters.AddWithValue("@Orderstatus", Orderstatus);
                      cmd2.Parameters.AddWithValue("@Paymentstatus", Paymentstatus);
                      cmd2.Parameters.AddWithValue("@Trackno", "");
                      cmd2.Parameters.AddWithValue("@Shippingp", "");
                      cmd2.Parameters.AddWithValue("@Trackurl", "");

                      cmd2.Parameters.AddWithValue("@Shippingdate", dateTime);
                      cmd2.ExecuteNonQuery();*/


                      connection.Close();

                  }

                  else
                  {

                      int id = entry.Key;
                      float qty = entry.Value;

                      SqlConnection connection = new SqlConnection(conn);
                      connection.Open();
                      string query = "select * from Products where id = @id";
                      SqlCommand command = new SqlCommand(query, connection);
                      command.Parameters.AddWithValue("@id", id);
                      SqlDataReader reader = command.ExecuteReader();
                      while (reader.Read())
                      {
                          Box cart = new Box();

                          cart.Pname = reader.GetString(2);
                          ViewBag.img = reader.GetString(1);
                          ViewBag.pname = reader.GetString(2);
                          ViewBag.saleprice = reader.GetValue(5);
                          float price = (float)(double)reader.GetValue(5);
                          price = price * qty;
                          salprice = salprice + price;
                          carts.Add(cart);
                      }
                      // Console.WriteLine(entry.Key);
                      reader.Close();

                      string query1 = "select * from RegisteredUser where email = @email";
                      SqlCommand cmd1 = new SqlCommand(query1, connection);
                      cmd1.Parameters.AddWithValue("@email", uname);
                      SqlDataReader reader1 = cmd1.ExecuteReader();
                      while (reader1.Read())
                      {
                          ViewBag.custname = reader1.GetString(1);
                            ViewBag.email = reader1.GetString(2);
                            ViewBag.phone = reader1.GetString(7);
                            Console.WriteLine(ViewBag.custname);

                      }
                      reader1.Close();

                     /* string query2 = "insert into Orders (OrderId,Ordername,Username,Uname,Img,Qty,Saleprice,Datecreated,Paytype,Orderstatus,Paymentstatus,TrackNo,Shippingp,Trackurl,Shippingdate)values(@OrderId,@Ordername,@Username,@Uname,@Img,@Qty,@Saleprice,@Datecreated,@Paytype,@Orderstatus,@Paymentstatus,@Trackno,@Shippingp,@Trackurl,@Shippingdate)";
                      SqlCommand cmd2 = new SqlCommand(query2, connection);
                      cmd2.Parameters.AddWithValue("@OrderId", ViewBag.OrderId);
                      cmd2.Parameters.AddWithValue("@Ordername", ViewBag.pname);
                      cmd2.Parameters.AddWithValue("@Username", uname);
                      cmd2.Parameters.AddWithValue("@Uname", ViewBag.custname);
                      cmd2.Parameters.AddWithValue("@Img", ViewBag.img);
                      cmd2.Parameters.AddWithValue("@Qty", qty);
                      cmd2.Parameters.AddWithValue("@Saleprice", ViewBag.saleprice);
                      cmd2.Parameters.AddWithValue("@Datecreated", dateTime);
                      cmd2.Parameters.AddWithValue("@Paytype", paytype);
                      cmd2.Parameters.AddWithValue("@Orderstatus", Orderstatus);
                      cmd2.Parameters.AddWithValue("@Paymentstatus", Paymentstatus);
                      cmd2.Parameters.AddWithValue("@Trackno", "");
                      cmd2.Parameters.AddWithValue("@Shippingp", "");
                      cmd2.Parameters.AddWithValue("@Trackurl", "");

                      cmd2.Parameters.AddWithValue("@Shippingdate", dateTime);
                      cmd2.ExecuteNonQuery();*/

                      connection.Close();




                  }
              }




              Console.WriteLine(salprice);
            /*  MailMessage mail = new MailMessage("shopgems02@gmail.com", uname);
              mail.Subject = "New Email";
              mail.Subject = "Orders";
              mail.Body = "hello";


              mail.AlternateViews.Add(AlternateView.CreateAlternateViewFromString(CreateBody(), null, MediaTypeNames.Text.Html));



              mail.Priority = MailPriority.Low;
              mail.IsBodyHtml = true;
              SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
              smtp.DeliveryMethod = SmtpDeliveryMethod.Network;

              smtp.Credentials = new NetworkCredential()
              {
                  UserName = "shopgems02@gmail.com",
                  Password = "wagglazvlslqeebg",
              };

              smtp.EnableSsl = true;
              smtp.Send(mail);



              MailMessage mail1 = new MailMessage("shopgems02@gmail.com", "shopgems02@gmail.com");
              mail1.Subject = "New Email";
              mail1.Subject = "Orders";
              mail1.Body = "hello";


              mail1.AlternateViews.Add(AlternateView.CreateAlternateViewFromString(CreateBody1(), null, MediaTypeNames.Text.Html));



              mail1.Priority = MailPriority.Low;
              mail1.IsBodyHtml = true;
              SmtpClient smtp1 = new SmtpClient("smtp.gmail.com", 587);
              smtp1.DeliveryMethod = SmtpDeliveryMethod.Network;

              smtp1.Credentials = new NetworkCredential()
              {
                  UserName = "shopgems02@gmail.com",
                  Password = "wagglazvlslqeebg",
              };

              smtp1.EnableSsl = true;
              smtp1.Send(mail1);
              Empty();
            */

              string key = "rzp_live_3NLZP2r70O1kQx";
              string secret = "3NPzxPPbyrn1tRqVtxef5sqZ";

              Random _random = new Random();

              string TransactionId = _random.Next(0, 10000).ToString();


              Dictionary<string, object> input = new Dictionary<string, object>();
              input.Add("amount", Convert.ToDecimal(salprice) * 100); // this amount should be same as transaction amount
              input.Add("currency", "INR");
              input.Add("receipt", TransactionId);


              RazorpayClient client = new RazorpayClient(key, secret);

              Razorpay.Api.Order order = client.Order.Create(input);
              ViewBag.orderid = order["id"].ToString();
              return View("Payment");










          }
          else
          {
              return RedirectToAction("Allproducts", "Products");
          }


          //return RedirectToAction("Myaccount", "Products");







      }
     




         public IActionResult Order3()
         {
             string paytype ="Prepaid";
             ViewBag.OrderTotal = 0;
             float salprice = 0;
             DateTime dateTime = DateTime.Now;
            
             string Orderstatus = "processing";
             string Paymentstatus = "Completed";
             string uname = HttpContext.Session.GetString("username");

             var CartProductsCookie = Request.Cookies["CartProducts"];

             if (CartProductsCookie != null)
             {

                 SqlConnection sqlConnection = new SqlConnection(conn);
                 sqlConnection.Open();
                 string query3 = "insert into myorder (placed,Username,Datecreated,Paytype,Orderstatus,Paymentstatus,TrackNo,Shippingp,Trackurl,Shippingdate)values(@placed,@Username,@Datecreated,@Paytype,@Orderstatus,@Paymentstatus,@TrackNo,@Shippingp,@Trackurl,@Shippingdate);" + "select SCOPE_IDENTITY();";
                 SqlCommand command1 = new SqlCommand(query3, sqlConnection);
                 command1.Parameters.AddWithValue("@placed", "placed");
                 command1.Parameters.AddWithValue("@Username", uname);
                 command1.Parameters.AddWithValue("@Datecreated", dateTime);
                 command1.Parameters.AddWithValue("@Paytype", paytype);
                 command1.Parameters.AddWithValue("@Orderstatus", Orderstatus);
                 command1.Parameters.AddWithValue("@Paymentstatus", Paymentstatus);
                 command1.Parameters.AddWithValue("@Trackno", "");
                 command1.Parameters.AddWithValue("@Shippingp", "");
                 command1.Parameters.AddWithValue("@Trackurl", "");
                 command1.Parameters.AddWithValue("@Shippingdate", dateTime);
                 int igetlastid = Convert.ToInt32(command1.ExecuteScalar());
                 ViewBag.OrderId = igetlastid;


                 sqlConnection.Close();

                // HttpContext.Session.SetString("latestid",igetlastid.ToString());

                 var carts = new List<Box>();
                 Dictionary<int, int> frequency = new Dictionary<int, int>();
                 var productsids = CartProductsCookie.Split('-');
                 List<int> pIDs = productsids.Select(x => int.Parse(x)).ToList();
                 for (int i = 0; i < pIDs.Count; i++)
                 {

                     if (frequency.ContainsKey(pIDs[i]))
                     {
                         frequency[pIDs[i]]++;
                     }
                     else
                     {
                         frequency.Add(pIDs[i], 1);
                     }

                 }
                 foreach (KeyValuePair<int, int> entry in frequency)
                 {
                     if (entry.Value > 1)
                     {
                         Console.WriteLine(entry.Key + "-->" + entry.Value);
                         int id = entry.Key;
                         float qty = entry.Value;

                         SqlConnection connection = new SqlConnection(conn);
                         connection.Open();
                         string query = "select * from Products where id = @id";
                         SqlCommand command = new SqlCommand(query, connection);
                         command.Parameters.AddWithValue("@id", id);
                         SqlDataReader reader = command.ExecuteReader();
                         while (reader.Read())
                         {
                             Box cart = new Box();


                             cart.Pname = reader.GetString(2);
                             ViewBag.img = reader.GetString(1);
                             ViewBag.pname = reader.GetString(2);
                             ViewBag.saleprice = reader.GetValue(5);
                             salprice = (float)(double)reader.GetValue(5);
                             salprice = salprice * qty;
                             carts.Add(cart);



                         }
                         reader.Close();

                         string query1 = "select * from RegisteredUser where email = @email";
                         SqlCommand cmd1 = new SqlCommand(query1, connection);
                         cmd1.Parameters.AddWithValue("@email", uname);
                         SqlDataReader reader1 = cmd1.ExecuteReader();
                         while (reader1.Read())
                         {
                             ViewBag.custname = reader1.GetString(1);
                             ViewBag.email = reader1.GetString(2);
                             ViewBag.phone = reader1.GetString(7);
                             Console.WriteLine(ViewBag.custname);

                         }
                         reader1.Close();




                         string query2 = "insert into Orders (OrderId,Ordername,Username,Uname,Img,Qty,Saleprice,Datecreated,Paytype,Orderstatus,Paymentstatus,TrackNo,Shippingp,Trackurl,Shippingdate)values(@OrderId,@Ordername,@Username,@Uname,@Img,@Qty,@Saleprice,@Datecreated,@Paytype,@Orderstatus,@Paymentstatus,@Trackno,@Shippingp,@Trackurl,@Shippingdate)";
                         SqlCommand cmd2 = new SqlCommand(query2, connection);
                         cmd2.Parameters.AddWithValue("@OrderId", ViewBag.OrderId);
                         cmd2.Parameters.AddWithValue("@Ordername", ViewBag.pname);
                         cmd2.Parameters.AddWithValue("@Username", uname);
                         cmd2.Parameters.AddWithValue("@Uname", ViewBag.custname);
                         cmd2.Parameters.AddWithValue("@Img", ViewBag.img);
                         cmd2.Parameters.AddWithValue("@Qty", qty);
                         cmd2.Parameters.AddWithValue("@Saleprice", ViewBag.saleprice);
                         cmd2.Parameters.AddWithValue("@Datecreated", dateTime);
                         cmd2.Parameters.AddWithValue("@Paytype", paytype);
                         cmd2.Parameters.AddWithValue("@Orderstatus", Orderstatus);
                         cmd2.Parameters.AddWithValue("@Paymentstatus", Paymentstatus);
                         cmd2.Parameters.AddWithValue("@Trackno", "");
                         cmd2.Parameters.AddWithValue("@Shippingp", "");
                         cmd2.Parameters.AddWithValue("@Trackurl", "");

                         cmd2.Parameters.AddWithValue("@Shippingdate", dateTime);
                         cmd2.ExecuteNonQuery();


                         connection.Close();

                     }

                     else
                     {

                         int id = entry.Key;
                         float qty = entry.Value;

                         SqlConnection connection = new SqlConnection(conn);
                         connection.Open();
                         string query = "select * from Products where id = @id";
                         SqlCommand command = new SqlCommand(query, connection);
                         command.Parameters.AddWithValue("@id", id);
                         SqlDataReader reader = command.ExecuteReader();
                         while (reader.Read())
                         {
                             Box cart = new Box();

                             cart.Pname = reader.GetString(2);
                             ViewBag.img = reader.GetString(1);
                             ViewBag.pname = reader.GetString(2);
                             ViewBag.saleprice = reader.GetValue(5);
                             float price = (float)(double)reader.GetValue(5);
                             price = price * qty;
                             salprice = salprice + price;
                             carts.Add(cart);
                         }
                         // Console.WriteLine(entry.Key);
                         reader.Close();

                         string query1 = "select * from RegisteredUser where email = @email";
                         SqlCommand cmd1 = new SqlCommand(query1, connection);
                         cmd1.Parameters.AddWithValue("@email", uname);
                         SqlDataReader reader1 = cmd1.ExecuteReader();
                         while (reader1.Read())
                         {
                             ViewBag.custname = reader1.GetString(1);
                             Console.WriteLine(ViewBag.custname);

                         }
                         reader1.Close();

                         string query2 = "insert into Orders (OrderId,Ordername,Username,Uname,Img,Qty,Saleprice,Datecreated,Paytype,Orderstatus,Paymentstatus,TrackNo,Shippingp,Trackurl,Shippingdate)values(@OrderId,@Ordername,@Username,@Uname,@Img,@Qty,@Saleprice,@Datecreated,@Paytype,@Orderstatus,@Paymentstatus,@Trackno,@Shippingp,@Trackurl,@Shippingdate)";
                         SqlCommand cmd2 = new SqlCommand(query2, connection);
                         cmd2.Parameters.AddWithValue("@OrderId", ViewBag.OrderId);
                         cmd2.Parameters.AddWithValue("@Ordername", ViewBag.pname);
                         cmd2.Parameters.AddWithValue("@Username", uname);
                         cmd2.Parameters.AddWithValue("@Uname", ViewBag.custname);
                         cmd2.Parameters.AddWithValue("@Img", ViewBag.img);
                         cmd2.Parameters.AddWithValue("@Qty", qty);
                         cmd2.Parameters.AddWithValue("@Saleprice", ViewBag.saleprice);
                         cmd2.Parameters.AddWithValue("@Datecreated", dateTime);
                         cmd2.Parameters.AddWithValue("@Paytype", paytype);
                         cmd2.Parameters.AddWithValue("@Orderstatus", Orderstatus);
                         cmd2.Parameters.AddWithValue("@Paymentstatus", Paymentstatus);
                         cmd2.Parameters.AddWithValue("@Trackno", "");
                         cmd2.Parameters.AddWithValue("@Shippingp", "");
                         cmd2.Parameters.AddWithValue("@Trackurl", "");

                         cmd2.Parameters.AddWithValue("@Shippingdate", dateTime);
                         cmd2.ExecuteNonQuery();

                         connection.Close();




                     }
                 }




                 Console.WriteLine(salprice);
                 MailMessage mail = new MailMessage("brainoservices8@gmail.com", uname);
                 mail.Subject = "New Email";
                 mail.Subject = "Orders";
                 mail.Body = "hello";


                 mail.AlternateViews.Add(AlternateView.CreateAlternateViewFromString(CreateBody(), null, MediaTypeNames.Text.Html));



                 mail.Priority = MailPriority.Low;
                 mail.IsBodyHtml = true;
                 SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                 smtp.DeliveryMethod = SmtpDeliveryMethod.Network;

                 smtp.Credentials = new NetworkCredential()
                 {
                     UserName = "brainoservices8@gmail.com",
                     Password = "wagglazvlslqeebg",
                 };

                 smtp.EnableSsl = true;
                 smtp.Send(mail);



                 MailMessage mail1 = new MailMessage("brainoservices8@gmail.com", "brainoservices8@gmail.com");
                 mail1.Subject = "New Email";
                 mail1.Subject = "Orders";
                 mail1.Body = "hello";


                 mail1.AlternateViews.Add(AlternateView.CreateAlternateViewFromString(CreateBody1(), null, MediaTypeNames.Text.Html));



                 mail1.Priority = MailPriority.Low;
                 mail1.IsBodyHtml = true;
                 SmtpClient smtp1 = new SmtpClient("smtp.gmail.com", 587);
                 smtp1.DeliveryMethod = SmtpDeliveryMethod.Network;

                 smtp1.Credentials = new NetworkCredential()
                 {
                     UserName = "brainoservices8@gmail.com",
                     Password = "wagglazvlslqeebg",
                 };

                 smtp1.EnableSsl = true;
                 smtp1.Send(mail1);
                 Empty();


                
                 










             }
             else
             {
                 return RedirectToAction("Allproducts", "Products");
             }


             return RedirectToAction("Myaccount", "Products");







         }
        







        public IActionResult Payment(string razorpay_payment_id, string razorpay_order_id, string razorpay_signature)
        {


          /*  string id = HttpContext.Session.GetString("latestid");

            int pid = Int32.Parse(id);*/

            Dictionary<string, string> attributes = new Dictionary<string, string>();
            attributes.Add("razorpay_payment_id", razorpay_payment_id);
            attributes.Add("razorpay_order_id", razorpay_order_id);
            attributes.Add("razorpay_signature", razorpay_signature);

            Utils.verifyPaymentSignature(attributes);

            OrderEntity orderdetails = new OrderEntity();

            orderdetails.TransactionId = razorpay_payment_id;
            orderdetails.OrderId = razorpay_order_id;

           


           /* SqlConnection connection = new SqlConnection(conn);
            connection.Open();

            string query = "update MyOrder set Paymentstatus = @Paymentstatus where Id=@Id";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Paymentstatus","Completed");
            command.Parameters.AddWithValue("@Id",pid);
            command.ExecuteNonQuery();


            string query1 = "update Orders set Paymentstatus = @Paymentstatus where OrderId=@Id";
            SqlCommand command1 = new SqlCommand(query1, connection);
            command1.Parameters.AddWithValue("@Paymentstatus", "Completed");
            command1.Parameters.AddWithValue("@Id", pid);
            command1.ExecuteNonQuery();*/

            if(razorpay_order_id!=null)
            {
                Console.WriteLine(razorpay_payment_id);
                return RedirectToAction("Order3", "Products");
            }

            return RedirectToAction("Allproducts","Products");



        }

        private string CreateBody()
        {
            ViewBag.uname = HttpContext.Session.GetString("username");
            ViewBag.street = "";
            ViewBag.city = "";
            ViewBag.post = "";
            ViewBag.phone = "";
            Console.WriteLine(ViewBag.OrderId);
            StringBuilder sb = new StringBuilder();
            ViewBag.total = 0;
            sb.Append("<h1>Order#"+ViewBag.OrderId+"<h1>");
            DateTime dateTime = DateTime.Now;
            dateTime = dateTime.Date;
            string Orderstatus = "processing";
            string Paymentstatus = "pending";
            string uname = HttpContext.Session.GetString("username");

            var CartProductsCookie = Request.Cookies["CartProducts"];

            if (CartProductsCookie != null)
            {

                var carts = new List<Box>();
                Dictionary<int, int> frequency = new Dictionary<int, int>();
                var productsids = CartProductsCookie.Split('-');
                List<int> pIDs = productsids.Select(x => int.Parse(x)).ToList();
                for (int i = 0; i < pIDs.Count; i++)
                {

                    if (frequency.ContainsKey(pIDs[i]))
                    {
                        frequency[pIDs[i]]++;
                    }
                    else
                    {
                        frequency.Add(pIDs[i], 1);
                    }

                }
                foreach (KeyValuePair<int, int> entry in frequency)
                {
                    if (entry.Value > 1)
                    {
                        Console.WriteLine(entry.Key + "-->" + entry.Value);
                        int id = entry.Key;
                        float qty = entry.Value;

                        SqlConnection connection = new SqlConnection(conn);
                        connection.Open();
                        string query = "select * from Products where id = @id";
                        SqlCommand command = new SqlCommand(query, connection);
                        command.Parameters.AddWithValue("@id", id);
                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            Box cart = new Box();
                            cart.Pname = reader.GetString(2);
                            float price = (float)(Double)reader.GetValue(5);
                            cart.salePrice = price * qty;
                            cart.Pqty = (Int32)qty;
                            ViewBag.total = ViewBag.total + cart.salePrice;
                            ViewBag.img = reader.GetString(1);
                            ViewBag.pname = reader.GetString(2);
                            ViewBag.saleprice = reader.GetValue(5);
                            carts.Add(cart);



                        }
                        reader.Close();
                        string query1 = "select * from RegisteredUser where email = @email";
                        SqlCommand cmd1 = new SqlCommand(query1, connection);
                        cmd1.Parameters.AddWithValue("@email", uname);
                        SqlDataReader reader1 = cmd1.ExecuteReader();
                        while (reader1.Read())
                        {
                            ViewBag.custname = reader1.GetString(1);
                            ViewBag.email = reader1.GetString(2);
                            ViewBag.street = reader1.GetString(4);
                            ViewBag.city = reader1.GetString(5);
                            ViewBag.post = reader1.GetString(6);
                            ViewBag.phone = reader1.GetString(7);
                            Console.WriteLine(ViewBag.custname);

                        }
                        reader1.Close();

                        connection.Close();


                    }

                    else
                    {

                        int id = entry.Key;
                        float qty = entry.Value;

                        SqlConnection connection = new SqlConnection(conn);
                        connection.Open();
                        string query = "select * from Products where id = @id";
                        SqlCommand command = new SqlCommand(query, connection);
                        command.Parameters.AddWithValue("@id", id);
                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            Box cart = new Box();
                            cart.Pname = reader.GetString(2);
                            float price = (float)(Double)reader.GetValue(5);
                            cart.salePrice = price * qty;
                            cart.Pqty = (Int32)qty;
                            ViewBag.total = ViewBag.total + cart.salePrice;
                            ViewBag.img = reader.GetString(1);
                            ViewBag.pname = reader.GetString(2);
                            ViewBag.saleprice = reader.GetValue(5);
                            carts.Add(cart);
                        }
                        // Console.WriteLine(entry.Key);
                       

                        reader.Close();
                        string query1 = "select * from RegisteredUser where email = @email";
                        SqlCommand cmd1 = new SqlCommand(query1, connection);
                        cmd1.Parameters.AddWithValue("@email", uname);
                        SqlDataReader reader1 = cmd1.ExecuteReader();
                        while (reader1.Read())
                        {
                            ViewBag.custname = reader1.GetString(1);
                            ViewBag.email = reader1.GetString(2);
                            ViewBag.street = reader1.GetString(4);
                            ViewBag.city = reader1.GetString(5);
                            ViewBag.post = reader1.GetString(6);
                            ViewBag.phone = reader1.GetString(7);
                            Console.WriteLine(ViewBag.custname);

                        }
                        reader1.Close();


                        connection.Close();

                    }
                }

                string addr = ViewBag.street +" "+ ViewBag.city+ " " +ViewBag.post+" "+ViewBag.phone;
                sb.Append("<p style=\"font-size:15px;font-weight:300px;\">Hi,"+ViewBag.uname+"</p>");
                sb.Append("<div style=\"width:450px;height:auto;border:1px solid #686868;\">");
                sb.Append("<div style=\"width:450px;height:50px;color:#fff;text-align:center;font-size:16px;padding-top:15px;padding-bottom:15px; background:#C43B68;\"><h3>Thanks for ordering from Braino Services</h3></div>");
                sb.Append("<h6>Shipping Address:</h6><p  style=\"width:150px; font-size:13px;font-weight:300;\">"+addr+"</p>");
               

                sb.Append("<table style=\"border:0.5px solid #C43B68;width:450px;height:auto;background:#F1F3F4;\"><tr><th style=\"font-size:11px; width:300px; border-bottom:0.5px solid black;\" >Name</th><th style=\" font-size:11px; width:300px; border-bottom:0.5px solid black;\">Quantity</th><th style=\" font-size:11px; width:300px; border-bottom:0.5px solid black;\">Price</th></tr>");
                
                foreach (var item in carts)
                {

                    sb.Append("<tr><td  style=\"font-size:11px; width:300px; border-bottom:0.5px solid black;text-align: center;\">" + item.Pname+ "</td>"+ "<td style=\"font-size:11px; width:300px; border-bottom:0.5px solid black; text-align: center;\">" + item.Pqty + "</td>"+"<td style=\"font-size:11px; width:300px; border-bottom:0.5px solid black; text-align: center;\">Rs"+ item.salePrice+"</td></tr>");
                  
                }
                sb.Append("<tr><td  style=\"font-size:11px; width:300px; border-bottom:0.5px solid black;text-align: center;\">Order Total</td><td style=\"font-size:11px; width:300px; border-bottom:0.5px solid black; text-align: center;\">Rs" +ViewBag.total+"</td></tr>");
                sb.Append("</table></div>");


            }


           string sbs = sb.ToString();
            return sbs;


        }




        private string CreateBody1()
        {
            ViewBag.uname = HttpContext.Session.GetString("username");
            ViewBag.street = "";
            ViewBag.city = "";
            ViewBag.post = "";
            ViewBag.phone = "";
            Console.WriteLine(ViewBag.OrderId);
            StringBuilder sb = new StringBuilder();
            ViewBag.total = 0;
            sb.Append("<h1>Order#" + ViewBag.OrderId + "<h1>");
            DateTime dateTime = DateTime.Now;
            dateTime = dateTime.Date;
            string Orderstatus = "processing";
            string Paymentstatus = "pending";
            string uname = HttpContext.Session.GetString("username");

            var CartProductsCookie = Request.Cookies["CartProducts"];

            if (CartProductsCookie != null)
            {

                var carts = new List<Box>();
                Dictionary<int, int> frequency = new Dictionary<int, int>();
                var productsids = CartProductsCookie.Split('-');
                List<int> pIDs = productsids.Select(x => int.Parse(x)).ToList();
                for (int i = 0; i < pIDs.Count; i++)
                {

                    if (frequency.ContainsKey(pIDs[i]))
                    {
                        frequency[pIDs[i]]++;
                    }
                    else
                    {
                        frequency.Add(pIDs[i], 1);
                    }

                }
                foreach (KeyValuePair<int, int> entry in frequency)
                {
                    if (entry.Value > 1)
                    {
                        Console.WriteLine(entry.Key + "-->" + entry.Value);
                        int id = entry.Key;
                        float qty = entry.Value;

                        SqlConnection connection = new SqlConnection(conn);
                        connection.Open();
                        string query = "select * from Products where id = @id";
                        SqlCommand command = new SqlCommand(query, connection);
                        command.Parameters.AddWithValue("@id", id);
                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            Box cart = new Box();
                            cart.Pname = reader.GetString(2);
                            float price = (float)(Double)reader.GetValue(5);
                            cart.salePrice = price * qty;
                            cart.Pqty = (Int32)qty;
                            ViewBag.total = ViewBag.total + cart.salePrice;
                            ViewBag.img = reader.GetString(1);
                            ViewBag.pname = reader.GetString(2);
                            ViewBag.saleprice = reader.GetValue(5);
                            carts.Add(cart);



                        }
                        reader.Close();
                        string query1 = "select * from RegisteredUser where email = @email";
                        SqlCommand cmd1 = new SqlCommand(query1, connection);
                        cmd1.Parameters.AddWithValue("@email", uname);
                        SqlDataReader reader1 = cmd1.ExecuteReader();
                        while (reader1.Read())
                        {
                            ViewBag.custname = reader1.GetString(1);
                            ViewBag.email = reader1.GetString(2);
                            ViewBag.street = reader1.GetString(4);
                            ViewBag.city = reader1.GetString(5);
                            ViewBag.post = reader1.GetString(6);
                            ViewBag.phone = reader1.GetString(7);
                            Console.WriteLine(ViewBag.custname);

                        }
                        reader1.Close();

                        connection.Close();


                    }

                    else
                    {

                        int id = entry.Key;
                        float qty = entry.Value;

                        SqlConnection connection = new SqlConnection(conn);
                        connection.Open();
                        string query = "select * from Products where id = @id";
                        SqlCommand command = new SqlCommand(query, connection);
                        command.Parameters.AddWithValue("@id", id);
                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            Box cart = new Box();
                            cart.Pname = reader.GetString(2);
                            float price = (float)(Double)reader.GetValue(5);
                            cart.salePrice = price * qty;
                            cart.Pqty = (Int32)qty;
                            ViewBag.total = ViewBag.total + cart.salePrice;
                            ViewBag.img = reader.GetString(1);
                            ViewBag.pname = reader.GetString(2);
                            ViewBag.saleprice = reader.GetValue(5);
                            carts.Add(cart);
                        }
                        // Console.WriteLine(entry.Key);


                        reader.Close();
                        string query1 = "select * from RegisteredUser where email = @email";
                        SqlCommand cmd1 = new SqlCommand(query1, connection);
                        cmd1.Parameters.AddWithValue("@email", uname);
                        SqlDataReader reader1 = cmd1.ExecuteReader();
                        while (reader1.Read())
                        {
                            ViewBag.custname = reader1.GetString(1);
                            ViewBag.email = reader1.GetString(2);
                            ViewBag.street = reader1.GetString(4);
                            ViewBag.city = reader1.GetString(5);
                            ViewBag.post = reader1.GetString(6);
                            ViewBag.phone = reader1.GetString(7);
                            Console.WriteLine(ViewBag.custname);

                        }
                        reader1.Close();


                        connection.Close();

                    }
                }

                string addr =ViewBag.uname + " "+ ViewBag.street + " " + ViewBag.city + " " + ViewBag.post + " " + ViewBag.phone;
                sb.Append("<div style=\"width:450px;height:auto;border:1px solid #686868;\">");
                sb.Append("<div style=\"width:450px;height:50px;color:#fff;text-align:center;font-size:16px;padding-top:15px;padding-bottom:15px; background:#C43B68;\"><h3>New Order To Braino Services</h3></div>");
                sb.Append("<h6>Shipping Address:</h6><p  style=\"width:150px; font-size:13px;font-weight:300;\">" + addr + "</p>");


                sb.Append("<table style=\"border:0.5px solid #C43B68;width:450px;height:auto;background:#F1F3F4;\"><tr><th style=\"font-size:11px; width:300px; border-bottom:0.5px solid black;\" >Name</th><th style=\" font-size:11px; width:300px; border-bottom:0.5px solid black;\">Quantity</th><th style=\" font-size:11px; width:300px; border-bottom:0.5px solid black;\">Price</th></tr>");

                foreach (var item in carts)
                {

                    sb.Append("<tr><td  style=\"font-size:11px; width:300px; border-bottom:0.5px solid black;text-align: center;\">" + item.Pname + "</td>" + "<td style=\"font-size:11px; width:300px; border-bottom:0.5px solid black; text-align: center;\">" + item.Pqty + "</td>" + "<td style=\"font-size:11px; width:300px; border-bottom:0.5px solid black; text-align: center;\">Rs" + item.salePrice + "</td></tr>");

                }
                sb.Append("<tr><td  style=\"font-size:11px; width:300px; border-bottom:0.5px solid black;text-align: center;\">Order Total</td><td style=\"font-size:11px; width:300px; border-bottom:0.5px solid black; text-align: center;\">Rs" + ViewBag.total + "</td></tr>");
                sb.Append("</table></div>");


            }


            string sbs = sb.ToString();
            return sbs;


        }


















        public IActionResult EmptyCart()
        {
            return View();
        }

        
        public IActionResult Myaccount()
        {

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




            string uname = HttpContext.Session.GetString("username");
            ViewBag.uname = uname;
            SqlConnection connection = new SqlConnection(conn);
            connection.Open();
            var orders = new List<Orders>();
            string query = "select *, CONVERT(VARCHAR(50),convert(datetime,datecreated),100) as rec_time  from MyOrder where Username=@Username";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Username",uname);
            if(uname!=null)
            {
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {

                    Orders order = new Orders();
                    order.Id = (Int32)reader.GetValue(0);   
                    order.Trackno = reader.GetString(7);
                    order.Trackurl = reader.GetString(9);
                    order.dateoforder = (string)reader.GetValue(11);
                    orders.Add(order);
                    ViewData["orders"] = orders;

                }
                reader.Close();
                
            }


            string query1 = "select * from RegisteredUser where email=@email";
            SqlCommand command1 = new SqlCommand(query1, connection);
            command1.Parameters.AddWithValue("@email", uname);
            if(uname!=null)
            {
                SqlDataReader sqlDataReader = command1.ExecuteReader();
                while(sqlDataReader.Read())
                {
                    ViewBag.custname = (String)sqlDataReader.GetValue(1);
                    ViewBag.email = (String)sqlDataReader.GetValue(2);
                    ViewBag.street = (String)sqlDataReader.GetValue(4);
                    ViewBag.city = (String)sqlDataReader.GetValue(5);
                    ViewBag.post = (String)sqlDataReader.GetValue(6);
                    ViewBag.phone = (String)sqlDataReader.GetValue(7);

                }
            }


            connection.Close();

            return View();
        }

        public IActionResult UserLogin()
        {

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
        [HttpPost]
        public IActionResult UserLogin(string custname, string email, string password, string street, string city, string post, string phone)
        {

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



            SqlConnection connection = new SqlConnection(conn);
            connection.Open();
            string query = "select count(*) from registereduser where email = @email";
            SqlCommand sqlCommand = new SqlCommand(query, connection);
            sqlCommand.Parameters.AddWithValue("@email", email);
            int count = (Int32)sqlCommand.ExecuteScalar();


            if (count > 0)
            {
                ViewBag.msg = "User Alredy Exists";
                Console.WriteLine("User already exists!");
            }
            else
            {
                string query1 = "insert into registereduser (custname,email,password,street,city,post,phone) values(@custname,@email,@password,@street,@city,@post,@phone)";
                SqlCommand cmd = new SqlCommand(query1, connection);
                cmd.Parameters.AddWithValue("@custname", custname);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@password", password);
                cmd.Parameters.AddWithValue("@street", street);
                cmd.Parameters.AddWithValue("@city", city);
                cmd.Parameters.AddWithValue("@post", post);
                cmd.Parameters.AddWithValue("@phone", phone);
                cmd.ExecuteNonQuery();

                string query3 = "insert into login_User (Username,Password)values(@Username,@Password)";
                SqlCommand cmd3 = new SqlCommand(query3, connection);
                cmd3.Parameters.AddWithValue("@Username", email);
                cmd3.Parameters.AddWithValue("@Password", password);
                cmd3.ExecuteNonQuery();
                ViewBag.msg = "You are registered successfully, you can login now";

            }

            connection.Close();
            return View();
        }

        public IActionResult LoginfromLoginUser(string Username,string Password)
        {
            var account = _accountService.Login(Username, Password);

            if (account != null)
            {
                string uname = account.Username;
                string folder = "";

                string url = "";

                List<Claim> claims = new List<Claim>();
                claims.Add(new Claim(ClaimTypes.NameIdentifier, Username));
                claims.Add(new Claim(ClaimTypes.Name, Username));
                if (uname == "admin")
                {
                    claims.Add(new Claim(ClaimTypes.Role, "Admin"));
                    folder = "Products";
                    url = "LoginUser";

                }
                else
                {
                    claims.Add(new Claim(ClaimTypes.Role, "User"));
                    folder = "Products";
                    url = "Allproducts";
                }



                ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIdentity);


                HttpContext.SignInAsync(claimsPrincipal);

                HttpContext.Session.SetString("username", uname);




                return RedirectToAction(url, folder);



            }
            else
            {
                ViewBag.Message = "Invalid login";
                return RedirectToAction("UserLogin","Products");        
            }









        }

        public IActionResult Product_Search()
        {

            return View();
        }


        [HttpGet]
        public IActionResult Product_Search(string str)
        {
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




            string uname = HttpContext.Session.GetString("username");
            ViewBag.uname = uname;
            SqlConnection connection = new SqlConnection(conn);
            connection.Open();
            var box = new List<Box>();
            string query = "select * from Products where pname like '%' + @str + '%'";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@str",str);
            if (str != null)
            {


                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {

                    Box box1 = new Box();
                    box1.Id = reader.GetInt32(0);
                    box1.img = reader.GetString(1);
                    box1.Pname = reader.GetString(2);
                    box1.Pqty = (Int32)reader.GetValue(3);
                    box1.Pcategory = reader.GetString(4);
                    box1.salePrice = (float)(Double)reader.GetValue(5);
                    box1.Type = reader.GetString(6);
                    box1.Sku = reader.GetString(7);
                    box1.Dimension = reader.GetString(8);

                    box1.saler = reader.GetString(9);
                    box1.brand = reader.GetString(10);
                    box1.Description = reader.GetString(11);
                    box1.Premark = reader.GetString(22);
                    box.Add(box1);

                    ViewData["box"] = box;

                }

            }

            connection.Close();

            return View();
        }




        
        public IActionResult FingerPrint()
        {
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

            string str = Request.Query["str"];
            if(str == "Cable")
              str =  "Cables";
            

           

           
            string uname = HttpContext.Session.GetString("username");
            ViewBag.uname = uname;
            SqlConnection connection = new SqlConnection(conn);
            connection.Open();
            var box = new List<Box>();
            string query = "select * from Products where Pcategory = @Pcategory";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Pcategory", str);
            if (str != null)
            {


                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {

                    Box box1 = new Box();
                    box1.Id = reader.GetInt32(0);
                    box1.img = reader.GetString(1);
                    box1.Pname = reader.GetString(2);
                    box1.Pqty = (Int32)reader.GetValue(3);
                    box1.Pcategory = reader.GetString(4);
                    box1.salePrice = (float)(Double)reader.GetValue(5);
                    box1.Type = reader.GetString(6);
                    box1.Sku = reader.GetString(7);
                    box1.Dimension = reader.GetString(8);

                    box1.saler = reader.GetString(9);
                    box1.brand = reader.GetString(10);
                    box1.Description = reader.GetString(11);
                    box1.Premark = reader.GetString(22);
                    box.Add(box1);

                    ViewData["box"] = box;

                }

            }


            connection.Close();
            return View();
        }




       



        public IActionResult IRIS()
        {
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

            string str = Request.Query["str"];


            string uname = HttpContext.Session.GetString("username");
            ViewBag.uname = uname;
            SqlConnection connection = new SqlConnection(conn);
            connection.Open();
            var box = new List<Box>();
            string query = "select * from Products where Pcategory = @str";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@str", str);
            if (str != null)
            {


                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {

                    Box box1 = new Box();
                    box1.Id = reader.GetInt32(0);
                    box1.img = reader.GetString(1);
                    box1.Pname = reader.GetString(2);
                    box1.Pqty = (Int32)reader.GetValue(3);
                    box1.Pcategory = reader.GetString(4);
                    box1.salePrice = (float)(Double)reader.GetValue(5);
                    box1.Type = reader.GetString(6);
                    box1.Sku = reader.GetString(7);
                    box1.Dimension = reader.GetString(8);

                    box1.saler = reader.GetString(9);
                    box1.brand = reader.GetString(10);
                    box1.Description = reader.GetString(11);
                    box1.Premark = reader.GetString(22);
                    box.Add(box1);

                    ViewData["box"] = box;

                }

            }


            connection.Close();
            return View();
        }


        public IActionResult Aadhaar()
        {
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

            string str = Request.Query["str"];


            string uname = HttpContext.Session.GetString("username");
            ViewBag.uname = uname;
            SqlConnection connection = new SqlConnection(conn);
            connection.Open();
            var box = new List<Box>();
            string query = "select * from Products where Pcategory = @str";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@str", str);
            if (str != null)
            {


                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {

                    Box box1 = new Box();
                    box1.Id = reader.GetInt32(0);
                    box1.img = reader.GetString(1);
                    box1.Pname = reader.GetString(2);
                    box1.Pqty = (Int32)reader.GetValue(3);
                    box1.Pcategory = reader.GetString(4);
                    box1.salePrice = (float)(Double)reader.GetValue(5);
                    box1.Type = reader.GetString(6);
                    box1.Sku = reader.GetString(7);
                    box1.Dimension = reader.GetString(8);

                    box1.saler = reader.GetString(9);
                    box1.brand = reader.GetString(10);
                    box1.Description = reader.GetString(11);
                    box1.Premark = reader.GetString(22);
                    box.Add(box1);

                    ViewData["box"] = box;

                }

            }


            connection.Close();
            return View();
        }
        public IActionResult New()
        {
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

            string str = Request.Query["str"];


            string uname = HttpContext.Session.GetString("username");
            ViewBag.uname = uname;
            SqlConnection connection = new SqlConnection(conn);
            connection.Open();
            var box = new List<Box>();
            string query = "select * from Products where pname like '%' + @str + '%' or  Pdesc like '%' + @str + '%'";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@str", str);
            if (str != null)
            {


                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {

                    Box box1 = new Box();
                    box1.Id = reader.GetInt32(0);
                    box1.img = reader.GetString(1);
                    box1.Pname = reader.GetString(2);
                    box1.Pqty = (Int32)reader.GetValue(3);
                    box1.Pcategory = reader.GetString(4);
                    box1.salePrice = (float)(Double)reader.GetValue(5);
                    box1.Type = reader.GetString(6);
                    box1.Sku = reader.GetString(7);
                    box1.Dimension = reader.GetString(8);

                    box1.saler = reader.GetString(9);
                    box1.brand = reader.GetString(10);
                    box1.Description = reader.GetString(11);
                    box1.Premark = reader.GetString(22);
                    box.Add(box1);

                    ViewData["box"] = box;

                }

            }


            connection.Close();
            return View();
        }

        public IActionResult Refurbished()
        {
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

            string str = Request.Query["str"];
          

            string uname = HttpContext.Session.GetString("username");
            ViewBag.uname = uname;
            SqlConnection connection = new SqlConnection(conn);
            connection.Open();
            var box = new List<Box>();
            string query = "select * from Products where Pcategory = @str";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@str", str);
            if (str != null)
            {


                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {

                    Box box1 = new Box();
                    box1.Id = reader.GetInt32(0);
                    box1.img = reader.GetString(1);
                    box1.Pname = reader.GetString(2);
                    box1.Pqty = (Int32)reader.GetValue(3);
                    box1.Pcategory = reader.GetString(4);
                    box1.salePrice = (float)(Double)reader.GetValue(5);
                    box1.Type = reader.GetString(6);
                    box1.Sku = reader.GetString(7);
                    box1.Dimension = reader.GetString(8);

                    box1.saler = reader.GetString(9);
                    box1.brand = reader.GetString(10);
                    box1.Description = reader.GetString(11);
                    box1.Premark = reader.GetString(22);
                    box.Add(box1);

                    ViewData["box"] = box;

                }

            }

            connection.Close();

            return View();
        }


        public IActionResult Accessories()
        {
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

            string str = Request.Query["str"];


            string uname = HttpContext.Session.GetString("username");
            ViewBag.uname = uname;
            SqlConnection connection = new SqlConnection(conn);
            connection.Open();
            var box = new List<Box>();
            string query = "select * from Products where pname like '%' + @str + '%' or  Pdesc like '%' + @str + '%'";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@str", str);
            if (str != null)
            {


                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {

                    Box box1 = new Box();
                    box1.Id = reader.GetInt32(0);
                    box1.img = reader.GetString(1);
                    box1.Pname = reader.GetString(2);
                    box1.Pqty = (Int32)reader.GetValue(3);
                    box1.Pcategory = reader.GetString(4);
                    box1.salePrice = (float)(Double)reader.GetValue(5);
                    box1.Type = reader.GetString(6);
                    box1.Sku = reader.GetString(7);
                    box1.Dimension = reader.GetString(8);

                    box1.saler = reader.GetString(9);
                    box1.brand = reader.GetString(10);
                    box1.Description = reader.GetString(11);
                    box1.Premark = reader.GetString(22);
                    box.Add(box1);

                    ViewData["box"] = box;

                }

            }


            connection.Close();
            return View();
        }

        public IActionResult Bags()
        {
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

            string str = Request.Query["str"];


            string uname = HttpContext.Session.GetString("username");
            ViewBag.uname = uname;
            SqlConnection connection = new SqlConnection(conn);
            connection.Open();
            var box = new List<Box>();
            string query = "select * from Products where Pcategory = @str";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@str", str);
            if (str != null)
            {


                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {

                    Box box1 = new Box();
                    box1.Id = reader.GetInt32(0);
                    box1.img = reader.GetString(1);
                    box1.Pname = reader.GetString(2);
                    box1.Pqty = (Int32)reader.GetValue(3);
                    box1.Pcategory = reader.GetString(4);
                    box1.salePrice = (float)(Double)reader.GetValue(5);
                    box1.Type = reader.GetString(6);
                    box1.Sku = reader.GetString(7);
                    box1.Dimension = reader.GetString(8);

                    box1.saler = reader.GetString(9);
                    box1.brand = reader.GetString(10);
                    box1.Description = reader.GetString(11);
                    box1.Premark = reader.GetString(22);
                    box.Add(box1);

                    ViewData["box"] = box;

                }

            }


            connection.Close();
            return View();
        }

        public IActionResult Battery()
        {
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

            string str = Request.Query["str"];


            string uname = HttpContext.Session.GetString("username");
            ViewBag.uname = uname;
            SqlConnection connection = new SqlConnection(conn);
            connection.Open();
            var box = new List<Box>();
            string query = "select * from Products where Pcategory = @str";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@str", str);
            if (str != null)
            {


                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {

                    Box box1 = new Box();
                    box1.Id = reader.GetInt32(0);
                    box1.img = reader.GetString(1);
                    box1.Pname = reader.GetString(2);
                    box1.Pqty = (Int32)reader.GetValue(3);
                    box1.Pcategory = reader.GetString(4);
                    box1.salePrice = (float)(Double)reader.GetValue(5);
                    box1.Type = reader.GetString(6);
                    box1.Sku = reader.GetString(7);
                    box1.Dimension = reader.GetString(8);

                    box1.saler = reader.GetString(9);
                    box1.brand = reader.GetString(10);
                    box1.Description = reader.GetString(11);
                    box1.Premark = reader.GetString(22);
                    box.Add(box1);

                    ViewData["box"] = box;

                }

            }

            connection.Close();

            return View();
        }


        public IActionResult Charger()
        {
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

            string str = Request.Query["str"];


            string uname = HttpContext.Session.GetString("username");
            ViewBag.uname = uname;
            SqlConnection connection = new SqlConnection(conn);
            connection.Open();
            var box = new List<Box>();
            string query = "select * from Products where Pcategory = @str";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@str", str);
            if (str != null)
            {


                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {

                    Box box1 = new Box();
                    box1.Id = reader.GetInt32(0);
                    box1.img = reader.GetString(1);
                    box1.Pname = reader.GetString(2);
                    box1.Pqty = (Int32)reader.GetValue(3);
                    box1.Pcategory = reader.GetString(4);
                    box1.salePrice = (float)(Double)reader.GetValue(5);
                    box1.Type = reader.GetString(6);
                    box1.Sku = reader.GetString(7);
                    box1.Dimension = reader.GetString(8);

                    box1.saler = reader.GetString(9);
                    box1.brand = reader.GetString(10);
                    box1.Description = reader.GetString(11);
                    box1.Premark = reader.GetString(22);
                    box.Add(box1);

                    ViewData["box"] = box;

                }

            }


            connection.Close();
            return View();
        }

        public IActionResult Smartphone()
        {
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

            string str = "Smartphone";


            string uname = HttpContext.Session.GetString("username");
            ViewBag.uname = uname;
            SqlConnection connection = new SqlConnection(conn);
            connection.Open();
            var boxes3 = new List<Box>();
            string query = "select * from Products where Pcategory = @Pcategory";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Pcategory", str);
            if (str != null)
            {


                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {

                    Box box1 = new Box();
                    box1.Id = reader.GetInt32(0);
                    box1.img = reader.GetString(1);
                    box1.Pname = reader.GetString(2);
                    box1.Pqty = (Int32)reader.GetValue(3);
                    box1.Pcategory = reader.GetString(4);
                    box1.salePrice = (float)(Double)reader.GetValue(5);
                    box1.Type = reader.GetString(6);
                    box1.Sku = reader.GetString(7);
                    box1.Dimension = reader.GetString(8);

                    box1.saler = reader.GetString(9);
                    box1.brand = reader.GetString(10);
                    box1.Description = reader.GetString(11);
                    box1.Premark = reader.GetString(22);
                    boxes3.Add(box1);

                    ViewData["boxes3"] = boxes3;

                }

            }


            connection.Close();
            return View();
        }


        public IActionResult Tablets()
        {
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

            string str = Request.Query["str"];


            string uname = HttpContext.Session.GetString("username");
            ViewBag.uname = uname;
            SqlConnection connection = new SqlConnection(conn);
            connection.Open();
            var box = new List<Box>();
            string query = "select * from Products where pname = str";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@str", str);
            if (str != null)
            {


                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {

                    Box box1 = new Box();
                    box1.Id = reader.GetInt32(0);
                    box1.img = reader.GetString(1);
                    box1.Pname = reader.GetString(2);
                    box1.Pqty = (Int32)reader.GetValue(3);
                    box1.Pcategory = reader.GetString(4);
                    box1.salePrice = (float)(Double)reader.GetValue(5);
                    box1.Type = reader.GetString(6);
                    box1.Sku = reader.GetString(7);
                    box1.Dimension = reader.GetString(8);

                    box1.saler = reader.GetString(9);
                    box1.brand = reader.GetString(10);
                    box1.Description = reader.GetString(11);
                    box1.Premark = reader.GetString(22);
                    box.Add(box1);

                    ViewData["box"] = box;

                }

            }

            connection.Close();

            return View();
        }







        public IActionResult Mobile()
        {
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

            string str = Request.Query["str"];


            string uname = HttpContext.Session.GetString("username");
            ViewBag.uname = uname;
            SqlConnection connection = new SqlConnection(conn);
            connection.Open();
            var box = new List<Box>();
            string query = "select * from Products where pname = str";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@str", str);
            if (str != null)
            {


                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {

                    Box box1 = new Box();
                    box1.Id = reader.GetInt32(0);
                    box1.img = reader.GetString(1);
                    box1.Pname = reader.GetString(2);
                    box1.Pqty = (Int32)reader.GetValue(3);
                    box1.Pcategory = reader.GetString(4);
                    box1.salePrice = (float)(Double)reader.GetValue(5);
                    box1.Type = reader.GetString(6);
                    box1.Sku = reader.GetString(7);
                    box1.Dimension = reader.GetString(8);

                    box1.saler = reader.GetString(9);
                    box1.brand = reader.GetString(10);
                    box1.Description = reader.GetString(11);
                    box1.Premark = reader.GetString(22);
                    box.Add(box1);

                    ViewData["box"] = box;

                }

            }

            connection.Close();

            return View();
        }


        public IActionResult MobileAccessories()
        {
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

            string str = Request.Query["str"];


            string uname = HttpContext.Session.GetString("username");
            ViewBag.uname = uname;
            SqlConnection connection = new SqlConnection(conn);
            connection.Open();
            var box = new List<Box>();
            string query = "select * from Products where Pcategory = @str";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@str", str);
            if (str != null)
            {


                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {

                    Box box1 = new Box();
                    box1.Id = reader.GetInt32(0);
                    box1.img = reader.GetString(1);
                    box1.Pname = reader.GetString(2);
                    box1.Pqty = (Int32)reader.GetValue(3);
                    box1.Pcategory = reader.GetString(4);
                    box1.salePrice = (float)(Double)reader.GetValue(5);
                    box1.Type = reader.GetString(6);
                    box1.Sku = reader.GetString(7);
                    box1.Dimension = reader.GetString(8);

                    box1.saler = reader.GetString(9);
                    box1.brand = reader.GetString(10);
                    box1.Description = reader.GetString(11);
                    box1.Premark = reader.GetString(22);
                    box.Add(box1);

                    ViewData["box"] = box;

                }

            }


            connection.Close();
            return View();
        }



        public IActionResult Biometrics()
        {
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

            string str = "scanner";


            string uname = HttpContext.Session.GetString("username");
            ViewBag.uname = uname;
            SqlConnection connection = new SqlConnection(conn);
            connection.Open();
            var box = new List<Box>();
            string query = "select * from Products where pname like '%' + @str + '%'";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@str", str);
            if (str != null)
            {


                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {

                    Box box1 = new Box();
                    box1.Id = reader.GetInt32(0);
                    box1.img = reader.GetString(1);
                    box1.Pname = reader.GetString(2);
                    box1.Pqty = (Int32)reader.GetValue(3);
                    box1.Pcategory = reader.GetString(4);
                    box1.salePrice = (float)(Double)reader.GetValue(5);
                    box1.Type = reader.GetString(6);
                    box1.Sku = reader.GetString(7);
                    box1.Dimension = reader.GetString(8);

                    box1.saler = reader.GetString(9);
                    box1.brand = reader.GetString(10);
                    box1.Description = reader.GetString(11);
                    box1.Premark = reader.GetString(22);
                    box.Add(box1);

                    ViewData["box"] = box;

                }

            }

            connection.Close();

            return View();
        }


        public IActionResult Byget()
        {
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

            string str = "By 1 get 1 free";


            string uname = HttpContext.Session.GetString("username");
            ViewBag.uname = uname;
            SqlConnection connection = new SqlConnection(conn);
            connection.Open();
            var box = new List<Box>();
            string query = "select * from Products where Pcategory like '%' + @str + '%'";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@str", str);
            if (str != null)
            {


                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {

                    Box box1 = new Box();
                    box1.Id = reader.GetInt32(0);
                    box1.img = reader.GetString(1);
                    box1.Pname = reader.GetString(2);
                    box1.Pqty = (Int32)reader.GetValue(3);
                    box1.Pcategory = reader.GetString(4);
                    box1.salePrice = (float)(Double)reader.GetValue(5);
                    box1.Type = reader.GetString(6);
                    box1.Sku = reader.GetString(7);
                    box1.Dimension = reader.GetString(8);

                    box1.saler = reader.GetString(9);
                    box1.brand = reader.GetString(10);
                    box1.Description = reader.GetString(11);
                    box1.Premark = reader.GetString(22);
                    box.Add(box1);

                    ViewData["box"] = box;

                }

            }

            connection.Close();

            return View();
        }

        public IActionResult Bulk()
        {
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

            string str = "Pack of";


            string uname = HttpContext.Session.GetString("username");
            ViewBag.uname = uname;
            SqlConnection connection = new SqlConnection(conn);
            connection.Open();
            var box = new List<Box>();
            string query = "select * from Products where pname like '%' + @str + '%'";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@str", str);
            if (str != null)
            {


                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {

                    Box box1 = new Box();
                    box1.Id = reader.GetInt32(0);
                    box1.img = reader.GetString(1);
                    box1.Pname = reader.GetString(2);
                    box1.Pqty = (Int32)reader.GetValue(3);
                    box1.Pcategory = reader.GetString(4);
                    box1.salePrice = (float)(Double)reader.GetValue(5);
                    box1.Type = reader.GetString(6);
                    box1.Sku = reader.GetString(7);
                    box1.Dimension = reader.GetString(8);

                    box1.saler = reader.GetString(9);
                    box1.brand = reader.GetString(10);
                    box1.Description = reader.GetString(11);
                    box1.Premark = reader.GetString(22);
                    box.Add(box1);

                    ViewData["box"] = box;

                }

            }

            connection.Close();

            return View();
        }

        public IActionResult Laptops()
        {
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

            string str = "Laptop";


            string uname = HttpContext.Session.GetString("username");
            ViewBag.uname = uname;
            SqlConnection connection = new SqlConnection(conn);
            connection.Open();
            var box = new List<Box>();
            string query = "select * from Products where pname like '%' + @str + '%'";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@str", str);
            if (str != null)
            {


                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {

                    Box box1 = new Box();
                    box1.Id = reader.GetInt32(0);
                    box1.img = reader.GetString(1);
                    box1.Pname = reader.GetString(2);
                    box1.Pqty = (Int32)reader.GetValue(3);
                    box1.Pcategory = reader.GetString(4);
                    box1.salePrice = (float)(Double)reader.GetValue(5);
                    box1.Type = reader.GetString(6);
                    box1.Sku = reader.GetString(7);
                    box1.Dimension = reader.GetString(8);

                    box1.saler = reader.GetString(9);
                    box1.brand = reader.GetString(10);
                    box1.Description = reader.GetString(11);
                    box1.Premark = reader.GetString(22);
                    box.Add(box1);

                    ViewData["box"] = box;

                }

            }

            connection.Close();

            return View();
        }


        public IActionResult Logout()
        {


            HttpContext.Session.Remove("username");
            HttpContext.SignOutAsync();

          return RedirectToAction("Allproducts","Products");
        }




        public IActionResult Forget1()
        {


            return View();
          }


        [HttpPost]
        public IActionResult Forget1(string username)
        {
            
            SqlConnection connection = new SqlConnection(conn);
            connection.Open();

            string query3 = "select count(*) from RegisteredUser Where email = @email";
            SqlCommand command = new SqlCommand(query3,connection);
            command.Parameters.AddWithValue("@email", username);
            Int32 count1 = (Int32)command.ExecuteScalar();

            if(count1>0)
            {
                int num = RandomNumber(1000, 9999);
                string query = "select count(*) from OTP Where Username = @Username";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@Username", username);

                Int32 count = (Int32)cmd.ExecuteScalar();

                if (count == 1)
                {

                    string query1 = "Update OTP set Otp = @Otp Where Username = @Username ";
                    SqlCommand cmd1 = new SqlCommand(query1, connection);
                    cmd1.Parameters.AddWithValue("@Otp", num);
                    cmd1.Parameters.AddWithValue("@Username", username);
                    cmd1.ExecuteNonQuery();
                    HttpContext.Session.SetString("MyUserName", username);
                }
                else
                {
                    string query2 = "Insert Into OTP (Username,Otp) Values(@Username,@Otp)";
                    SqlCommand cmd2 = new SqlCommand(query2, connection);

                    cmd2.Parameters.AddWithValue("@Username", username);
                    cmd2.Parameters.AddWithValue("@Otp", num);
                    cmd2.ExecuteNonQuery();
                    HttpContext.Session.SetString("MyUserName", username);
                }

                connection.Close();
                MailMessage mail = new MailMessage("brainoservices8@gmail.com", username);
                mail.Subject = "New Email";
                mail.Subject = "OTP for password reset";
                mail.Body = "your otp is :" + " " + num;
                mail.Priority = MailPriority.Low;
                mail.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;

                smtp.Credentials = new NetworkCredential()
                {
                    UserName = "brainoservices8@gmail.com",
                    Password = "wagglazvlslqeebg",
                };

                smtp.EnableSsl = true;
                smtp.Send(mail);
                return RedirectToAction("Enterotp1", "Products");

            }
            
            else
            {
                Console.WriteLine("User Does Not Exists");
                ViewBag.error = "User Does Not Exists";
                
            }

            return View();

           

        }


        public IActionResult Forget()
        {


            return View();
        }


        [HttpPost]
        public IActionResult Forget(string username)
        {

            SqlConnection connection = new SqlConnection(conn);
            connection.Open();

            string query3 = "select count(*) from RegisteredUser Where email = @email";
            SqlCommand command = new SqlCommand(query3, connection);
            command.Parameters.AddWithValue("@email", username);
            Int32 count1 = (Int32)command.ExecuteScalar();

            if (count1 > 0)
            {
                int num = RandomNumber(1000, 9999);
                string query = "select count(*) from OTP Where Username = @Username";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@Username", username);

                Int32 count = (Int32)cmd.ExecuteScalar();

                if (count == 1)
                {

                    string query1 = "Update OTP set Otp = @Otp Where Username = @Username ";
                    SqlCommand cmd1 = new SqlCommand(query1, connection);
                    cmd1.Parameters.AddWithValue("@Otp", num);
                    cmd1.Parameters.AddWithValue("@Username", username);
                    cmd1.ExecuteNonQuery();
                    HttpContext.Session.SetString("MyUserName", username);
                }
                else
                {
                    string query2 = "Insert Into OTP (Username,Otp) Values(@Username,@Otp)";
                    SqlCommand cmd2 = new SqlCommand(query2, connection);

                    cmd2.Parameters.AddWithValue("@Username", username);
                    cmd2.Parameters.AddWithValue("@Otp", num);
                    cmd2.ExecuteNonQuery();
                    HttpContext.Session.SetString("MyUserName", username);
                }

                connection.Close();
                MailMessage mail = new MailMessage("brainoservices8@gmail.com", username);
                mail.Subject = "New Email";
                mail.Subject = "OTP for password reset";
                mail.Body = "your otp is :" + " " + num;
                mail.Priority = MailPriority.Low;
                mail.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;

                smtp.Credentials = new NetworkCredential()
                {
                    UserName = "brainoservices8@gmail.com",
                    Password = "wagglazvlslqeebg",
                };

                smtp.EnableSsl = true;
                smtp.Send(mail);
                return RedirectToAction("Enterotp", "Products");

            }

            else
            {
                Console.WriteLine("User Does Not Exists");
                ViewBag.error = "User Does Not Exists";

            }

            return View();



        }







        public IActionResult Enterotp()
        {


            return View();
        }
        [HttpPost]
        public IActionResult Enterotp(String Otp)
        {
            var view = "";

            SqlConnection connection = new SqlConnection(conn);
            connection.Open();

            string query = "select Count(*) from OTP Where Otp = @Otp";
            SqlCommand cmd3 = new SqlCommand(query, connection);
            cmd3.Parameters.AddWithValue("@Otp", Otp);
            Int32 count = (Int32)cmd3.ExecuteScalar();
            if (count > 0)
            {

                view = "Reset";
            }
            else
            {

                Console.WriteLine("Invalid Otp");
                view = "Enterotp";
            }
            connection.Close();
            return RedirectToAction(view, "Products");

        }

        public IActionResult Enterotp1()
        {


            return View();
        }
        [HttpPost]
        public IActionResult Enterotp1(String Otp)
        {
            var view = "";

            SqlConnection connection = new SqlConnection(conn);
            connection.Open();

            string query = "select Count(*) from OTP Where Otp = @Otp";
            SqlCommand cmd3 = new SqlCommand(query, connection);
            cmd3.Parameters.AddWithValue("@Otp", Otp);
            Int32 count = (Int32)cmd3.ExecuteScalar();
            if (count > 0)
            {

                view = "Reset1";
            }
            else
            {

                Console.WriteLine("Invalid Otp");
                view = "Enterotp1";
            }
            connection.Close();
            return RedirectToAction(view, "Products");

        }


       


        public IActionResult Reset()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Reset(string Repass)
        {
            string uname = HttpContext.Session.GetString("MyUserName");
            SqlConnection connection = new SqlConnection(conn);
            connection.Open();
            string query4 = "Update Login_User set Password = @Password where Username = @Username";
            SqlCommand cmd4 = new SqlCommand(query4, connection);
            cmd4.Parameters.AddWithValue("@Password", Repass);
            cmd4.Parameters.AddWithValue("@Username", uname);

            cmd4.ExecuteNonQuery();
            connection.Close();
            return RedirectToAction("Checkout1", "Products");
        }


        public IActionResult Reset1()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Reset1(string Repass)
        {
            string uname = HttpContext.Session.GetString("MyUserName");
            SqlConnection connection = new SqlConnection(conn);
            connection.Open();
            string query4 = "Update Login_User set Password = @Password where Username = @Username";
            SqlCommand cmd4 = new SqlCommand(query4, connection);
            cmd4.Parameters.AddWithValue("@Password", Repass);
            cmd4.Parameters.AddWithValue("@Username", uname);

            cmd4.ExecuteNonQuery();
            connection.Close();
            return RedirectToAction("UserLogin", "Products");
        }






    }
}
