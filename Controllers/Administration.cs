using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using radiobutton.Models;
using System.Data.SqlClient;
using System.Security.Claims;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;
using radiobutton.Sessions;
using Microsoft.AspNetCore.Authorization;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Net.Mail;
using System.Net.Mime;
using System.Net;
using System.Data;
using radiobutton.Report;
using System;
using Razorpay.Api;
using System.Security.Cryptography;

namespace radiobutton.Controllers
{ 
    public class Administration : Controller
    {
        //private readonly ILogger<Administration> _logger;
        private readonly IHostingEnvironment _environment;
        private IAccountServices _accountService;
      public string conn = "Data Source=SQL5110.site4now.net,1433;Initial Catalog=db_a9eacf_brainoservices;User Id=db_a9eacf_brainoservices_admin;Password=xAb@by#web1;"; 
   //public string conn = "Data Source=DESKTOP-6LQD0UJ\\SQLEXPRESS;Initial Catalog=MyUser;Integrated Security=True";
        public Administration( IHostingEnvironment environment, IAccountServices accountService)
        {
            //_logger = logger;
            _environment = environment;
            _accountService = accountService;
        }

        [Authorize(Roles ="admin")]
        public IActionResult AddProducts()
        {
            SqlConnection connection = new SqlConnection(conn);
            connection.Open();
            var Categories = new List<Category>();
            string query = "select * from Category";
            SqlCommand cmd = new SqlCommand(query, connection);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Category cat = new Category();
                cat.categories = reader.GetString(1);
                Categories.Add(cat);
                ViewData["Categories"] = Categories;
                


            }
            connection.Close();

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddProducts(List<IFormFile> files, string Pname, int Pqty, string Pcategory, float saleprice, string Type, string Sku, String Dimension, string Saler, string Brand, string weight, string pcolor, string pmodel, string c_origin, string Pdesc, string Premark, string Premark1, string Premark2, string Premark3, string Premark4, string Premark5, string Premark6)
        {

            if (pcolor == null)
            { pcolor = ""; }

            if (pmodel == null)
            { pmodel = ""; }

            if (c_origin == null)
            { c_origin = ""; }

            if (weight == null)
            { weight = ""; }

            if (Premark == null)
            { Premark = ""; }

            if (Premark1 == null)
            { Premark1 = ""; }

            if (Premark2 == null)
            { Premark2 = ""; }

            if (Premark3 == null)
            { Premark3 = ""; }

            if (Premark4 == null)
            { Premark4 = ""; }

            if (Premark5 == null)
            { Premark5 = ""; }





            var size = files.Sum(f => f.Length);

            var filepaths = new List<string>();
            foreach (var formFile in files)
            {

                if (formFile.Length > 0)
                {
                    var filepath = Path.Combine(_environment.ContentRootPath, "wwwroot\\images\\product", formFile.FileName);

                    filepaths.Add(filepath);
                    using var stream = new FileStream(filepath, FileMode.Create);
                    await formFile.CopyToAsync(stream);


                    ViewBag.profile = formFile.FileName;
                }






            }

            /*string query1 = "Update uloadfile set img = @img where Id= @Id";
                   SqlCommand sqlCommand1 = new SqlCommand(query1, connection);
                   sqlCommand1.Parameters.AddWithValue("@img", formFile.FileName);
                   sqlCommand1.Parameters.AddWithValue("@Id", 1);
                   sqlCommand1.ExecuteNonQuery();*/

           // string connectionstring = "Data Source=SQL5111.site4now.net,1433;Initial Catalog=db_a9eacf_shopgems1;User Id=db_a9eacf_shopgems1_admin;Password=mj5shweta;";
            SqlConnection connection = new SqlConnection(conn);
            connection.Open();




            string query = "insert into Products (img,pname,pqty,Pcategory,saleprice,Type,Sku,Dimension,saler,brand, pdesc,premark, col1,col2,col3,col4,col5,col6,col7,col8,col9,col10) values (@img,@pname,@pqty,@Pcategory,@saleprice,@Type,@Sku,@Dimension,@saler,@brand ,@pdesc,@premark, @weight,@color,@model,@c_origin,@premark1,@premark2,@premark3,@premark4,@premark5,@premark6)";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@img", ViewBag.profile);
            cmd.Parameters.AddWithValue("@pname", Pname);
            cmd.Parameters.AddWithValue("@pqty", Pqty);
            cmd.Parameters.AddWithValue("@Pcategory", Pcategory);
            cmd.Parameters.AddWithValue("@saleprice", saleprice);
            cmd.Parameters.AddWithValue("@Type", Type);
            cmd.Parameters.AddWithValue("@Sku", Sku);
            cmd.Parameters.AddWithValue("@Dimension", Dimension);
            cmd.Parameters.AddWithValue("@saler", Saler);
            cmd.Parameters.AddWithValue("@brand", Brand);

            cmd.Parameters.AddWithValue("@weight", weight);
            cmd.Parameters.AddWithValue("@color", pcolor);

            cmd.Parameters.AddWithValue("@model", pmodel);

            cmd.Parameters.AddWithValue("@c_origin", c_origin);

            cmd.Parameters.AddWithValue("@pdesc", Pdesc);
            cmd.Parameters.AddWithValue("@premark", Premark);
            cmd.Parameters.AddWithValue("@premark1", Premark1);
            cmd.Parameters.AddWithValue("@premark2", Premark2);
            cmd.Parameters.AddWithValue("@premark3", Premark3);
            cmd.Parameters.AddWithValue("@premark4", Premark4);
            cmd.Parameters.AddWithValue("@premark5", Premark5);
            cmd.Parameters.AddWithValue("@premark6", Premark6);
            cmd.ExecuteNonQuery();
            connection.Close();
            return RedirectToAction("Products", "Administration");

        }
        [Authorize(Roles = "admin")]
        public IActionResult Products()
        {
            
            
                SqlConnection connection = new SqlConnection(conn);
                connection.Open();
                var box = new List<Box>();
                string query = "select * from Products";
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {

                    Box box1 = new Box();
                box1.Id = (Int32)reader.GetValue(0);
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
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Admin()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Admin(string Username,string Password)
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
                    claims.Add(new Claim(ClaimTypes.Role, "admin"));
                    folder = "Administration";
                    url = "Products";

                }
                else
                {
                    claims.Add(new Claim(ClaimTypes.Role, "user"));
                    folder = "Administration";
                    url = "Admin";
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
        [Authorize(Roles = "admin")]
        public IActionResult Orders()
        {

            SqlConnection connection = new SqlConnection(conn);
            connection.Open();
            var orders = new List<Orders>();
            string query = "select *, CONVERT(VARCHAR(10), datecreated, 103) + ' ' + RIGHT(CONVERT(VARCHAR, datecreated, 100), 7) as rec_time  from MyOrder Order By Id desc";
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                 
                Orders order = new Orders();
                order.Id = (Int32)reader.GetValue(0);
                
                //order.orderName = (String)reader.GetValue(2);   
                order.Username = (String)reader.GetValue(2);
               // order.Uname = (String)reader.GetValue(4);   
               // order.Img = (String)reader.GetValue(5);
               // order.Qty = (Int32)reader.GetValue(6);
               // order.Saleprice = (float)(Double)reader.GetValue(7);
               
                order.Paytype = (String)reader.GetValue(4); 
                order.OrerStatus = (String)reader.GetValue(5);
                order.PaymentStatus = (String)reader.GetValue(6);

               order.Trackno = (String)reader.GetValue(7); 
               order.Trackurl = (String)reader.GetValue(9);
                order.dateoforder = reader.GetString(11);
                orders.Add(order);
                ViewData["orders"] = orders;

            }



            connection.Close();

            return View();
        }





        public IActionResult OrderDetails()
        {

            string  id = Request.Query["Value"];
            ViewBag.orderId = id;
            string uname = "";
            SqlConnection connection = new SqlConnection(conn);
            connection.Open();
            var orders = new List<Orders>();
            string query = "select *,CONVERT(VARCHAR(10), datecreated, 103) + ' ' + RIGHT(CONVERT(VARCHAR, datecreated, 100), 7) as rec_time from Orders where OrderId = @OrderId ";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@OrderId",id);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {

                Orders order = new Orders();
               order.Id = (Int32)reader.GetValue(0);
                order.orderName = (String)reader.GetValue(2);   
                order.Username = (String)reader.GetValue(3);
                uname = order.Username;
                 order.Uname = (String)reader.GetValue(4);   
                 order.Img = (String)reader.GetValue(5);
                 order.Qty = (Int32)reader.GetValue(6);
                int qty = (Int32)reader.GetValue(6);    
                 order.Saleprice = (float)(Double)reader.GetValue(7);
                float price = (float)(Double)reader.GetValue(7);
                price = qty* price; 
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
            reader.Close();

            string query1 = "select * from RegisteredUser where email=@email";
            SqlCommand command1 = new SqlCommand(query1, connection);
            command1.Parameters.AddWithValue("@email", uname);
            if (uname != null)
            {
                SqlDataReader sqlDataReader = command1.ExecuteReader();
                while (sqlDataReader.Read())
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


         public IActionResult ChangeOrderStatus()
         {


             return View();
         }
         [HttpPost]
         public IActionResult ChangeOrderStatus(int OrderIds,string orderStatus)
         {
             string uname = "";

             Console.WriteLine(orderStatus+OrderIds);
             SqlConnection connection = new SqlConnection(conn);
             connection.Open();
             string query = "update Orders set Orderstatus=@Orderstatus where OrderId = @Id";
             SqlCommand command = new SqlCommand(query, connection);
             command.Parameters.AddWithValue("@Orderstatus",orderStatus);
             command.Parameters.AddWithValue("@Id", OrderIds);
             command.ExecuteNonQuery();

            string query4 = "update MyOrder set Orderstatus = @Orderstatus where Id = @Id";
            SqlCommand command2 = new SqlCommand(query4, connection);
            command2.Parameters.AddWithValue("@Orderstatus", orderStatus);
            command2.Parameters.AddWithValue("@Id", OrderIds);
            command2.ExecuteNonQuery();

            if (orderStatus=="Completed")
             {

                 string query3 = "update Orders set Paymentstatus = @Paymentstatus where OrderId = @Id";
                 SqlCommand command1 = new SqlCommand(query3, connection);
                 command1.Parameters.AddWithValue("@Paymentstatus ", "Completed");
                 command1.Parameters.AddWithValue("@Id",OrderIds);
                 command1.ExecuteNonQuery();

                string query5 = "update MyOrder set Paymentstatus = @Paymentstatus where Id = @Id";
                SqlCommand command3 = new SqlCommand(query5, connection);
                command3.Parameters.AddWithValue("@Paymentstatus ", "Completed");
                command3.Parameters.AddWithValue("@Id", OrderIds);
                command3.ExecuteNonQuery();

            }






            float total = 0;    
            var carts = new List<Box>();
            string query1 = "select * from orders where OrderId = @ID";
             SqlCommand sqlCommand = new SqlCommand(query1, connection);
             sqlCommand.Parameters.AddWithValue("@Id", OrderIds);
             SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
             while (sqlDataReader.Read()) {
                Box box = new Box();
                 box.Pname = sqlDataReader.GetString(2);
                 uname = sqlDataReader.GetString(3); 
                 int  Qty = (Int32)sqlDataReader.GetValue(6);
                 box.Pqty = Qty;  
                 float Price = (float)(Double)sqlDataReader.GetValue(7);
                 Price = Qty * Price;
                 box.oldPrice = Price;
                
                 total = total + Price;
                ViewBag.total = total;
                carts.Add(box);

            }
             sqlDataReader.Close();

             
             string query2 = "select * from RegisteredUser where email  = @email";
             SqlCommand sqlCommand2 = new SqlCommand(query2, connection);
             sqlCommand2.Parameters.AddWithValue("@email", uname);
             SqlDataReader sqlDataReader2 = sqlCommand2.ExecuteReader();
             while (sqlDataReader2.Read())
             {

                ViewBag.street = sqlDataReader2.GetString(4);    
                 ViewBag.city = sqlDataReader2.GetString(5); 
                 ViewBag.post = sqlDataReader2.GetString(6); 
                 ViewBag.phone = sqlDataReader2.GetString(7);    


             }
             sqlDataReader2.Close();

             StringBuilder sb = new StringBuilder();
             sb.Append("<h2>Order #:"+OrderIds+"</h2>");
             string addr = ViewBag.street + " " + ViewBag.city + " " + ViewBag.post + " " + ViewBag.phone;
             sb.Append("<div style=\"width:450px;height:auto;border:1px solid #686868;\">");
             sb.Append("<div style=\"width:450px;height:50px;color:#fff;text-align:center;font-size:16px;padding-top:15px;padding-bottom:15px; background:#C43B68;\"><h3>Hi,"+uname+"Your Order Is"+orderStatus+"</h3></div>");
             sb.Append("<h6>Shipping Address:</h6><p  style=\"width:150px; font-size:13px;font-weight:300;\">" + addr + "</p>");


             sb.Append("<table style=\"border:0.5px solid #C43B68;width:450px;height:auto;background:#F1F3F4;\"><tr><th style=\"font-size:11px; width:300px; border-bottom:0.5px solid black;\" >Product Name</th><th style=\" font-size:11px; width:300px; border-bottom:0.5px solid black;\">Quantity</th><th style=\" font-size:11px; width:300px; border-bottom:0.5px solid black;\">Amount(Rs)</th></tr>");


            foreach (var item in carts)
            {


                sb.Append("<tr><td  style=\"font-size:11px; width:300px; border-bottom:0.5px solid black;text-align: center;\">" + item.Pname + "</td>" + "<td style=\"font-size:11px; width:300px; border-bottom:0.5px solid black; text-align: center;\">" + item.Pqty + "</td>" + "<td style=\"font-size:11px; width:300px; border-bottom:0.5px solid black; text-align: center;\">Rs" + item.oldPrice + "</td></tr>");
            }

             sb.Append("<tr><td  style=\"font-size:11px; width:300px; border-bottom:0.5px solid black;text-align: center;\">Order Total</td><td style=\"font-size:11px; width:300px; border-bottom:0.5px solid black; text-align: center;\">Rs" + ViewBag.total + "</td></tr>");
             sb.Append("</table></div>");

             string sbs = sb.ToString();
             MailMessage mail1 = new MailMessage("shopgems02@gmail.com", uname);
             mail1.Subject = "New Email";
             mail1.Subject = "Orders";
             mail1.Body = "hello";


             mail1.AlternateViews.Add(AlternateView.CreateAlternateViewFromString(sbs, null, MediaTypeNames.Text.Html));



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


            connection.Close();

             return RedirectToAction("Orders","Administration");



         }
        

           public IActionResult AddTrackingNo()
           {
               string id = Request.Query["id"];
               HttpContext.Session.SetString("productid",id);
               return View();

           }
           [HttpPost]
           public IActionResult AddTrackingNo(string TrackNo,string Shippingp,string Trackurl,DateTime Shippingdate)
           {
               string id = HttpContext.Session.GetString("productid");
               SqlConnection sqlConnection = new SqlConnection(conn);
               sqlConnection.Open();
               string query = "update MyOrder set TrackNo = @TrackNo, Shippingp = @Shippingp, Trackurl = @Trackurl, Shippingdate = @Shippingdate where Id = @Id";
               SqlCommand command = new SqlCommand(query,sqlConnection);
               command.Parameters.AddWithValue("@TrackNo",TrackNo);
               command.Parameters.AddWithValue("@Shippingp", Shippingp);
               command.Parameters.AddWithValue("@Trackurl", Trackurl);
               command.Parameters.AddWithValue("@Shippingdate", Shippingdate);
               command.Parameters.AddWithValue("@Id",id);
               command.ExecuteNonQuery();
               sqlConnection.Close();
               return RedirectToAction("Orders","Administration");

           }


        public IActionResult Report()
        {
            string i = Request.Query["id"];
            int id = Int32.Parse(i);
            List<MyStudent> myStudents = new List<MyStudent>();
            MyStudent myStudent = new MyStudent();
            myStudent.Id = id;    
            myStudents.Add(myStudent);    

            StudentReport studentReport = new StudentReport(_environment);
            myStudents = GetStudents(myStudents);
            byte[] abytes = studentReport.PrepareReport(myStudents);
            return File(abytes, "application/pdf");

        }

       /* public IActionResult Report1()
        {
            string i = Request.Query["id"];
            int id = Int32.Parse(i);
            List<MyStudent> myStudents = new List<MyStudent>();
            MyStudent myStudent = new MyStudent();
            myStudent.Id = id;
            myStudents.Add(myStudent);

            StudentReport studentReport = new StudentReport();
            myStudents = GetStudents(myStudents);
            byte[] abytes = studentReport.PrepareReport(myStudents);
            return File(abytes, "application/pdf");

        }*/



        public List<MyStudent> GetStudents(List<MyStudent> myStudents)
        {
            int i = 0;
            int id = 0;
            foreach(MyStudent s in myStudents) { 
            
                if(i==0)
                {
                    id = s.Id;   
                }
                i = i + 1;

            }


            float ordertotal = 0;
            //string conn = "Data Source=DESKTOP-6LQD0UJ\\SQLEXPRESS;Initial Catalog=MyUser;Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(conn);
            sqlConnection.Open();
            string query = "select * from Orders where OrderId=@OrderId";
            SqlCommand cmd = new SqlCommand(query, sqlConnection);
            cmd.Parameters.AddWithValue("@OrderId",id);
            SqlDataReader reader = cmd.ExecuteReader();
            List<MyStudent> mystudents = new List<MyStudent>();
            MyStudent mystudent = new MyStudent();
            while (reader.Read())
            {
                mystudent = new MyStudent();
                mystudent.Id = reader.GetInt32(1);
                mystudent.Name = reader.GetString(2);
                mystudent.Username = reader.GetString(3);
                mystudent.Uname = reader.GetString(4);
                mystudent.qty = reader.GetInt32(6);
                int qty = (Int32)reader.GetValue(6);
              
                float price = (float)(Double)reader.GetValue(7);
                price = price * qty;
                mystudent.price = price;
                mystudent.Datecreated = (DateTime)reader.GetValue(8);
                mystudent.payType = reader.GetString(9);    
                mystudents.Add(mystudent);
                ordertotal += price;
            }
            mystudent = new MyStudent();
            mystudent.Name = "Order Total";
            mystudent.price = ordertotal;
            mystudents.Add(mystudent);

            // MyStudent mystudent = new MyStudent(); 
            // for(int i=0;i<=10;i++)
            // {
            //   mystudent = new MyStudent();
            // mystudent.Id = i;
            // mystudent.Name = "Student" + i;
            // mystudent.rollno = "Roll" + i;
            // mystudents.Add(mystudent);
            // }*/







            sqlConnection.Close();

            return mystudents;

        }



        public IActionResult Extra()
        {
            return View();  
        }


        [Authorize(Roles = "admin")]
        public IActionResult Usersmaster()
        {

            SqlConnection connection = new SqlConnection(conn);
            connection.Open();
            var customers = new List<Customers>();   
            string query = "select * from RegisteredUser";
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {

                Customers customer = new Customers();
                customer.Id = (Int32)reader.GetValue(0);
                customer.custname = (String)reader.GetValue(1);
                customer.email = (String)reader.GetValue(2);
                customer.street = (String)reader.GetValue(4);
                customer.city = (String)reader.GetValue(5);
                customer.post = (String)reader.GetValue(6);
                customer.phone = (String)reader.GetValue(7);
                customers.Add(customer);
                ViewData["customers"] = customers;

            }



            connection.Close();

            return View();
        }


        public IActionResult SearchOrder()
        {
            return View();
        }



      [HttpGet]
     public  IActionResult SearchOrder(string orderSearch)
        {






            SqlConnection connection = new SqlConnection(conn);
            connection.Open();

            string query1 = "select * from RegisteredUser Where  phone = @orderSearch";
            SqlCommand command1 = new SqlCommand(query1, connection);
            command1.Parameters.AddWithValue("@orderSearch", orderSearch);
            SqlDataReader reader1 = command1.ExecuteReader();
            while (reader1.Read())
            {
                ViewBag.email = (String)reader1.GetValue(2);    

            }

            reader1.Close();

            if(ViewBag.email!=null)
            {
                var orders = new List<Orders>();
                string query = "select *, CONVERT(VARCHAR(10), datecreated, 103) + ' ' + RIGHT(CONVERT(VARCHAR, datecreated, 100), 7) as rec_time  from MyOrder Where Username = @orderSearch";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@orderSearch", ViewBag.email);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {

                    Orders order = new Orders();
                    order.Id = (Int32)reader.GetValue(0);

                    //order.orderName = (String)reader.GetValue(2);   
                    order.Username = (String)reader.GetValue(2);
                    // order.Uname = (String)reader.GetValue(4);   
                    // order.Img = (String)reader.GetValue(5);
                    // order.Qty = (Int32)reader.GetValue(6);
                    // order.Saleprice = (float)(Double)reader.GetValue(7);

                    order.Paytype = (String)reader.GetValue(4);
                    order.OrerStatus = (String)reader.GetValue(5);
                    order.PaymentStatus = (String)reader.GetValue(6);

                    order.Trackno = (String)reader.GetValue(7);
                    order.Trackurl = (String)reader.GetValue(9);
                    order.dateoforder = reader.GetString(11);
                    orders.Add(order);
                    ViewData["orders"] = orders;

                }

                reader.Close();


 
            }



            else
            {
                var orders = new List<Orders>();
                string query = "select *, CONVERT(VARCHAR(10), datecreated, 103) + ' ' + RIGHT(CONVERT(VARCHAR, datecreated, 100), 7) as rec_time  from MyOrder Where Username = @orderSearch";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@orderSearch", orderSearch);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {

                    Orders order = new Orders();
                    order.Id = (Int32)reader.GetValue(0);

                    //order.orderName = (String)reader.GetValue(2);   
                    order.Username = (String)reader.GetValue(2);
                    // order.Uname = (String)reader.GetValue(4);   
                    // order.Img = (String)reader.GetValue(5);
                    // order.Qty = (Int32)reader.GetValue(6);
                    // order.Saleprice = (float)(Double)reader.GetValue(7);

                    order.Paytype = (String)reader.GetValue(4);
                    order.OrerStatus = (String)reader.GetValue(5);
                    order.PaymentStatus = (String)reader.GetValue(6);

                    order.Trackno = (String)reader.GetValue(7);
                    order.Trackurl = (String)reader.GetValue(9);
                    order.dateoforder = reader.GetString(11);
                    orders.Add(order);
                    ViewData["orders"] = orders;

                }
                reader.Close();

            }


          



            connection.Close();

            return View();
        }

        public IActionResult EditCust()
        {
            string Usid = Request.Query["Usid"];

            SqlConnection connection = new SqlConnection(conn);
            connection.Open();
            var customers = new List<Customers>();
            string query = "select * from RegisteredUser where email=@email";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@email",Usid);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {

                Customers customer = new Customers();
                customer.Id = (Int32)reader.GetValue(0);
                customer.custname = (String)reader.GetValue(1);
                customer.email = (String)reader.GetValue(2);
                customer.password = (String)reader.GetValue(3);
                customer.street = (String)reader.GetValue(4);
                customer.city = (String)reader.GetValue(5);
                customer.post = (String)reader.GetValue(6);
                customer.phone = (String)reader.GetValue(7);
                customers.Add(customer);
                ViewData["customers"] = customers;

            }



            connection.Close();

            return View();
        }

        public IActionResult changeCust()
        {
            return View();
        }

        [HttpPost]
        public IActionResult changeCust(string custname,string email,string street,string city, string post,string phone)
        {

            SqlConnection connection = new SqlConnection(conn);
            connection.Open();

            string query = "update RegisteredUser set custname=@custname,email=@email,street=@street,city=@city,post=@post,phone=@phone where email=@emails";
            SqlCommand command = new SqlCommand(query,connection);
            command.Parameters.AddWithValue("@custname",custname);
            command.Parameters.AddWithValue("@email", email);
            command.Parameters.AddWithValue("@street", street);
            command.Parameters.AddWithValue("@city", city);
            command.Parameters.AddWithValue("@post", post);
            command.Parameters.AddWithValue("@phone", phone);
            command.Parameters.AddWithValue("@emails",email);
            command.ExecuteNonQuery();
            connection.Close();
            return RedirectToAction("Orders","Administration");
        }


        public IActionResult EditOrder()
        {

            string id = Request.Query["id"];
            var orders = new List<Orders>();
            SqlConnection connection = new SqlConnection(conn);
            connection.Open();
            string query = "select * from orders where id = @id";
            SqlCommand command = new SqlCommand(query,connection);
            command.Parameters.AddWithValue("@id",id);
            SqlDataReader dataReader = command.ExecuteReader();
            while(dataReader.Read())
            
            { 
                  Orders order = new Orders();
                order.Id = (Int32)dataReader.GetValue(0);
                 order.Qty = (Int32)dataReader.GetValue(6);
                orders.Add(order);  
                ViewData["orders"] = orders; 
            }

            dataReader.Close();
            connection.Close();
            return View();

        }

        [HttpPost]
        public IActionResult changeOrder(int Id, int Qty)
        {


            string query = "Update Orders set Qty = @Qty where Id = @Id";
            SqlConnection connection = new SqlConnection(conn);
            connection.Open();
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Id", Id);
            command.Parameters.AddWithValue("@Qty", Qty);
          
            command.ExecuteNonQuery();

            string query1 = "select * from orders where Id = @Id";
            SqlCommand command1 = new SqlCommand(query1, connection);
            command1.Parameters.AddWithValue("@Id", Id);
            SqlDataReader dataReader = command1.ExecuteReader();
            while (dataReader.Read())

            {

                ViewBag.Value = dataReader.GetValue(1);


            }

            dataReader.Close();
            connection.Close();



            return RedirectToAction("OrderDetails", "Administration", new { Value = ViewBag.Value });
        }


        public IActionResult Orderdelete()
        {
            string id = Request.Query["id"];


            SqlConnection connection = new SqlConnection(conn);
            connection.Open();




            string query1 = "select * from orders where Id = @Id";
            SqlCommand command1 = new SqlCommand(query1, connection);
            command1.Parameters.AddWithValue("@Id", id);
            SqlDataReader dataReader = command1.ExecuteReader();
            while (dataReader.Read())

            {

                ViewBag.Value = dataReader.GetValue(1);


            }
            dataReader.Close();

            string query2 = "select Count(*) from orders where OrderId = @Id";
            SqlCommand command2 = new SqlCommand(query2, connection);
            command2.Parameters.AddWithValue("@Id", ViewBag.Value);
            int count = (Int32)command2.ExecuteScalar();


            if (count > 1)
            {
                string query = "delete from orders where Id = @Id";
                SqlCommand sqlCommand = new SqlCommand(query, connection);
                sqlCommand.Parameters.AddWithValue("@id", id);
                sqlCommand.ExecuteNonQuery();
            }

            Console.WriteLine(count);

            connection.Close();



            return RedirectToAction("OrderDetails", "Administration", new { Value = ViewBag.Value });
        }



        public IActionResult Usermessages()
        {

            SqlConnection connection = new SqlConnection(conn);
            connection.Open();
            var messages = new List<Messages>();
            string query = "select * , CONVERT(VARCHAR(10), datecreated, 103) + ' ' + RIGHT(CONVERT(VARCHAR, datecreated, 100), 7) as rec_time from Cmessage";
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {

                Messages message = new Messages();
                message.id = (Int32)reader.GetValue(0);
                message.cname = reader.GetString(1);
                message.cemail = reader.GetString(2);
                message.decript = reader.GetString(3);
                message.dt = reader.GetString(5);

                messages.Add(message);
                ViewData["messages"] = messages;

            }



            connection.Close();

            return View();
        }









    }
}
