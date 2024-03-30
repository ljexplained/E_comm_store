using radiobutton.Models;
using System.Data.SqlClient;
using iTextSharp.text;
using iTextSharp.text.pdf;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;
using radiobutton.Sessions;
using Microsoft.AspNetCore.Http;
using System.Drawing;

namespace radiobutton.Report
{
    public class StudentReport
    {
        private readonly IHostingEnvironment _environment;
        public StudentReport(IHostingEnvironment environment)
        {
            //_logger = logger;
            _environment = environment;
            
        }

        


        #region Declaration
        int _totalColumn = 4;
        Document document;
        
        Font font;
        Font font1 = FontFactory.GetFont("tahoma", 8f,BaseColor.WHITE);
        PdfPTable table = new PdfPTable(4);
        PdfPCell cell;
        MemoryStream _memoryStream = new MemoryStream();
        List<MyStudent> _students = new List<MyStudent>();
        #endregion

        public byte[] PrepareReport(List<MyStudent> myStudents)
        {

            _students = myStudents;
            #region
            document = new Document(PageSize.A5, 0f, 0f, 0f, 0f);
            document.SetPageSize(PageSize.A5);
            document.SetMargins(40f, 40f, 40f, 40f);
             var filepath = Path.Combine(_environment.ContentRootPath, "wwwroot\\images\\logo\\1.png");
            iTextSharp.text.Image jpg = iTextSharp.text.Image.GetInstance(filepath);
            jpg.ScaleToFit(90f, 50f);

            //Give space before image

            jpg.SpacingBefore = 10f;

            //Give some space after the image

            jpg.SpacingAfter = 50f;

            

            jpg.Alignment = Element.ALIGN_LEFT;
            
            table.WidthPercentage = 100;
            table.HorizontalAlignment = Element.ALIGN_LEFT;
            font = FontFactory.GetFont("Tahoma", 8f, 1);
            PdfWriter.GetInstance(document, _memoryStream);
            document.Open();
            table.SetWidths(new float[] { 50f, 50f, 120f, 100f });
            #endregion

            this.ReportHeader();
            this.ReportBody();
            table.HeaderRows = 2;
            document.Add(jpg);
            document.Add(table);
            document.Close();
            return _memoryStream.ToArray();
        }

        private void ReportHeader()
        {
            int i = 0;
            int id = 0;
            int day = 0;
            int month = 0;
            int year = 0;
            string uname = "";
            string username = "";
            string payType = "";
            foreach (MyStudent student in _students)
            {
                if (i == 0)
                {

                    id = student.Id;
                    uname = student.Uname;
                    username = student.Username;
                    day = student.Datecreated.Day;
                    month = student.Datecreated.Month;
                    year = student.Datecreated.Year;
                    payType = student.payType;


                }

                i = i + 1;


            }

            string street = "";
            string city = "";
            string post = "";
            string phone = "";

        string conn = "Data Source=SQL5110.site4now.net,1433;Initial Catalog=db_a9eacf_brainoservices;User Id=db_a9eacf_brainoservices_admin;Password=xAb@by#web1;";
        //string conn = "Data Source=DESKTOP-6LQD0UJ\\SQLEXPRESS;Initial Catalog=MyUser;Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(conn);
            sqlConnection.Open();
            string query = "select * from RegisteredUser where email =@email";
            SqlCommand command = new SqlCommand(query, sqlConnection);
            command.Parameters.AddWithValue("@email", username);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                street = reader.GetString(4);
                city = reader.GetString(5);
                post = reader.GetString(6);
                phone = reader.GetString(7);

            }


            sqlConnection.Close();

            /***********shopgems address************************/


            font = FontFactory.GetFont("Tahoma", 9f, 1);
            cell = new PdfPCell(new Phrase("Braino Services", font));
            cell.Colspan = _totalColumn;
            cell.HorizontalAlignment = Element.ALIGN_RIGHT;
            cell.Border = 0;
            cell.BackgroundColor = BaseColor.WHITE;
            cell.ExtraParagraphSpace = 2;
            table.AddCell(cell);
            table.CompleteRow();


            font = FontFactory.GetFont("Tahoma", 8f, 0);
            cell = new PdfPCell(new Phrase("GSTIN:07AAOFB5676M2ZP", font));
            cell.Colspan = _totalColumn;
            cell.HorizontalAlignment = Element.ALIGN_RIGHT;
            cell.Border = 0;
            cell.BackgroundColor = BaseColor.WHITE;
            cell.ExtraParagraphSpace = 1;
            table.AddCell(cell);
            table.CompleteRow();
             

            font = FontFactory.GetFont("Tahoma", 8f, 0);
            cell = new PdfPCell(new Phrase("Building No. 135,Basement, Street No. 54 T,", font));
            cell.Colspan = _totalColumn;
            cell.HorizontalAlignment = Element.ALIGN_RIGHT;
            cell.Border = 0;
            cell.BackgroundColor = BaseColor.WHITE;
            cell.ExtraParagraphSpace = 1;
            table.AddCell(cell);
            table.CompleteRow();


            font = FontFactory.GetFont("Tahoma", 8f, 0);
            cell = new PdfPCell(new Phrase(" Ist, 2nd 60 Feet Rd, Block G, ", font));
            cell.Colspan = _totalColumn;
            cell.HorizontalAlignment = Element.ALIGN_RIGHT;
            cell.Border = 0;
            cell.BackgroundColor = BaseColor.WHITE;
            cell.ExtraParagraphSpace = 1;
            table.AddCell(cell);
            table.CompleteRow();

            font = FontFactory.GetFont("Tahoma", 8f, 0);
            cell = new PdfPCell(new Phrase("Molar band Extension, Badarpur,", font));
            cell.Colspan = _totalColumn;
            cell.HorizontalAlignment = Element.ALIGN_RIGHT;
            cell.Border = 0;
            cell.BackgroundColor = BaseColor.WHITE;
            cell.ExtraParagraphSpace = 1;
            table.AddCell(cell);
            table.CompleteRow();


            font = FontFactory.GetFont("Tahoma", 8f, 0);
            cell = new PdfPCell(new Phrase("Delhi, New Delhi, Delhi 110044", font));
            cell.Colspan = _totalColumn;
            cell.HorizontalAlignment = Element.ALIGN_RIGHT;
            cell.Border = 0;
            cell.BackgroundColor = BaseColor.WHITE;
            cell.ExtraParagraphSpace = 5;
            table.AddCell(cell);
            table.CompleteRow();

            /***********shopgems address************************/







            font = FontFactory.GetFont("Tahoma", 12f, 1);
            cell = new PdfPCell(new Phrase("INVOICE", font));
            cell.Colspan = _totalColumn;
            cell.HorizontalAlignment = Element.ALIGN_LEFT;
            cell.Border = 0;
            cell.BackgroundColor = BaseColor.WHITE;
            cell.ExtraParagraphSpace = 5;
            table.AddCell(cell);
            table.CompleteRow();


            font = FontFactory.GetFont("Tahoma", 9f, 1);
            cell = new PdfPCell(new Phrase("Shipping Address:", font));
            cell.Colspan = _totalColumn;
            cell.HorizontalAlignment = Element.ALIGN_LEFT;
            cell.Border = 0;
            cell.BackgroundColor = BaseColor.WHITE;
            cell.ExtraParagraphSpace = 5;
            table.AddCell(cell);
            table.CompleteRow();


           


            font = FontFactory.GetFont("Tahoma", 8f, 0);
            cell = new PdfPCell(new Phrase(uname, font));
            cell.Colspan = 3;
            cell.HorizontalAlignment = Element.ALIGN_LEFT;
            cell.Border = 0;
            cell.BackgroundColor = BaseColor.WHITE;
            cell.ExtraParagraphSpace = 0;
            table.AddCell(cell);

            font = FontFactory.GetFont("Tahoma", 8f, 0);
            cell = new PdfPCell(new Phrase("Invoice Date:" + day + "/" + month + "/" + year, font));
            cell.Colspan = 1;
            cell.HorizontalAlignment = Element.ALIGN_LEFT;
            cell.Border = 0;
            cell.BackgroundColor = BaseColor.WHITE;
            cell.ExtraParagraphSpace = 0;
            table.AddCell(cell);
            table.CompleteRow();
           


            font = FontFactory.GetFont("Tahoma", 8f, 0);
            cell = new PdfPCell(new Phrase(street, font));
            cell.Colspan = 3;
            cell.HorizontalAlignment = Element.ALIGN_LEFT;
            cell.Border = 0;
            cell.BackgroundColor = BaseColor.WHITE;
            cell.ExtraParagraphSpace = 0;
            table.AddCell(cell);



            font = FontFactory.GetFont("Tahoma", 8f, 0);
            cell = new PdfPCell(new Phrase("Invoice Number:" + id, font));
            cell.Colspan = 1;
            cell.HorizontalAlignment = Element.ALIGN_LEFT;
            cell.Border = 0;
            cell.BackgroundColor = BaseColor.WHITE;
            cell.ExtraParagraphSpace = 0;
            table.AddCell(cell);
            table.CompleteRow();



            font = FontFactory.GetFont("Tahoma", 8f, 0);
            cell = new PdfPCell(new Phrase(city, font));
            cell.Colspan = 3;
            cell.HorizontalAlignment = Element.ALIGN_LEFT;
            cell.Border = 0;
            cell.BackgroundColor = BaseColor.WHITE;
            cell.ExtraParagraphSpace = 0;
            table.AddCell(cell);



            
            font = FontFactory.GetFont("Tahoma", 8f, 0);
            cell = new PdfPCell(new Phrase("Order Date:" + day + "/" + month + "/" + year, font));
            cell.Colspan = 1;
            cell.HorizontalAlignment = Element.ALIGN_LEFT;
            cell.Border = 0;
            cell.BackgroundColor = BaseColor.WHITE;
            cell.ExtraParagraphSpace = 0;
            table.AddCell(cell);


            table.CompleteRow();

            font = FontFactory.GetFont("Tahoma", 8f, 0);
            cell = new PdfPCell(new Phrase(post, font));
            cell.Colspan = 3;
            cell.HorizontalAlignment = Element.ALIGN_LEFT;
            cell.Border = 0;
            cell.BackgroundColor = BaseColor.WHITE;
            cell.ExtraParagraphSpace = 0;
            table.AddCell(cell);



            font = FontFactory.GetFont("Tahoma", 8f, 0);
            cell = new PdfPCell(new Phrase("Order Number:" + id, font));
            cell.Colspan = 1;
            cell.HorizontalAlignment = Element.ALIGN_LEFT;
            cell.Border = 0;
            cell.BackgroundColor = BaseColor.WHITE;
            cell.ExtraParagraphSpace = 0;
            table.AddCell(cell);



            table.CompleteRow();






            font = FontFactory.GetFont("Tahoma", 8f, 0);
            cell = new PdfPCell(new Phrase(phone, font));
            cell.Colspan = 3;
            cell.HorizontalAlignment = Element.ALIGN_LEFT;
            cell.Border = 0;
            cell.BackgroundColor = BaseColor.WHITE;
            cell.ExtraParagraphSpace = 20;
            table.AddCell(cell);



            font = FontFactory.GetFont("Tahoma", 8f, 0);
            cell = new PdfPCell(new Phrase("Payment Method:" + payType, font));
            cell.Colspan = 1;
            cell.HorizontalAlignment = Element.ALIGN_LEFT;
            cell.Border = 0;
            cell.BackgroundColor = BaseColor.WHITE;
            cell.ExtraParagraphSpace = 0;
            table.AddCell(cell);
            table.CompleteRow();












        }

        private void ReportBody()
        {

            #region Table header
           // font = FontFactory.GetFont("Tahoma", 8f, 1);
            cell = new PdfPCell(new Phrase("Serial Number", font1));
            cell.Border = 0;
            cell.HorizontalAlignment = Element.ALIGN_LEFT;
            cell.VerticalAlignment = Element.ALIGN_MIDDLE;
            cell.BackgroundColor = BaseColor.BLACK;
            table.AddCell(cell);



            cell = new PdfPCell(new Phrase("Quantity", font1));
            cell.Border = 0;
            cell.HorizontalAlignment = Element.ALIGN_LEFT;
            cell.VerticalAlignment = Element.ALIGN_MIDDLE;
            cell.BackgroundColor = BaseColor.BLACK;
            table.AddCell(cell);



            cell = new PdfPCell(new Phrase("Product Name", font1));
            cell.Border = 0;
            cell.HorizontalAlignment = Element.ALIGN_LEFT;
            cell.VerticalAlignment = Element.ALIGN_MIDDLE;
            cell.BackgroundColor = BaseColor.BLACK;
            
            table.AddCell(cell);





            cell = new PdfPCell(new Phrase("Amount", font1));
            cell.Border = 0;
            cell.HorizontalAlignment = Element.ALIGN_LEFT;
            cell.VerticalAlignment = Element.ALIGN_MIDDLE;
            cell.BackgroundColor = BaseColor.BLACK;
            table.AddCell(cell);
            table.CompleteRow();

            #endregion

            #region Table Body
            font = FontFactory.GetFont("Tahoma", 8f, 0);
            int serialNumber = 1;
            for (int i =0; i < _students.Count-1;i++)
            {

                cell = new PdfPCell(new Phrase(serialNumber++.ToString(), font));
                cell.HorizontalAlignment = Element.ALIGN_LEFT;
                cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell.Border = 2;
                cell.PaddingTop = 6;
                cell.PaddingBottom = 6;
                cell.BackgroundColor = BaseColor.WHITE;
                table.AddCell(cell);

                cell = new PdfPCell(new Phrase(_students[i].qty.ToString(), font));
                cell.HorizontalAlignment = Element.ALIGN_LEFT;
                cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell.Border = 2;
                cell.PaddingTop = 6;
                cell.PaddingBottom = 6;
                cell.BackgroundColor = BaseColor.WHITE;
                table.AddCell(cell);

                cell = new PdfPCell(new Phrase(_students[i].Name, font));
                cell.HorizontalAlignment = Element.ALIGN_LEFT;
                cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell.Border = 2;
                cell.PaddingTop = 6;
                cell.PaddingBottom = 6;
                cell.BackgroundColor = BaseColor.WHITE;
                table.AddCell(cell);


                cell = new PdfPCell(new Phrase("Rs"+_students[i].price, font));
                cell.HorizontalAlignment = Element.ALIGN_LEFT;
                cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell.Border = 2;
                cell.PaddingTop = 6;
                cell.PaddingBottom = 6;
                cell.BackgroundColor = BaseColor.WHITE;
                table.AddCell(cell);
                table.CompleteRow();

               
                


            }

              int j = _students.Count-1;


            cell = new PdfPCell(new Phrase("", font));
            cell.HorizontalAlignment = Element.ALIGN_CENTER;
            cell.VerticalAlignment = Element.ALIGN_MIDDLE;
            cell.Border = 0;
            cell.PaddingTop = 6;
            cell.PaddingBottom = 6;
            cell.BackgroundColor = BaseColor.WHITE;
            table.AddCell(cell);


            cell = new PdfPCell(new Phrase("", font));
            cell.HorizontalAlignment = Element.ALIGN_CENTER;
            cell.VerticalAlignment = Element.ALIGN_MIDDLE;
            cell.Border = 0;
            cell.PaddingTop = 6;
            cell.PaddingBottom = 6;
            cell.BackgroundColor = BaseColor.WHITE;
            table.AddCell(cell);



            cell = new PdfPCell(new Phrase(_students[j].Name, font));
                cell.HorizontalAlignment = Element.ALIGN_LEFT;
                cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell.Border = 2;
                cell.PaddingTop = 6;
                cell.PaddingBottom = 6;
                cell.BackgroundColor = BaseColor.WHITE;
                table.AddCell(cell);

            cell = new PdfPCell(new Phrase("Rs" + _students[j].price, font));
            cell.HorizontalAlignment = Element.ALIGN_LEFT;
            cell.VerticalAlignment = Element.ALIGN_MIDDLE;
            cell.Border = 2;
            cell.PaddingTop = 6;
            cell.PaddingBottom = 6;
            cell.BackgroundColor = BaseColor.WHITE;
            table.AddCell(cell);
            table.CompleteRow();







            font = FontFactory.GetFont("Tahoma", 8f, 0);
            cell = new PdfPCell(new Phrase("TERMS AND CONDITIONS:", font));
            cell.Colspan = _totalColumn;
            cell.HorizontalAlignment = Element.ALIGN_CENTER;
            cell.Border = 0;
            cell.BackgroundColor = BaseColor.WHITE;
            cell.PaddingTop = 120f;
            cell.ExtraParagraphSpace = 2;
            table.AddCell(cell);
            table.CompleteRow();


            font = FontFactory.GetFont("Tahoma", 7f, 0);
            cell = new PdfPCell(new Phrase("Sold Goods Will Not Be Replaced or Return", font));
            cell.Colspan = _totalColumn;
            cell.HorizontalAlignment = Element.ALIGN_CENTER;
            cell.Border = 0;
            cell.BackgroundColor = BaseColor.WHITE;
            cell.ExtraParagraphSpace = 1;
            table.AddCell(cell);
            table.CompleteRow();


            font = FontFactory.GetFont("Tahoma", 7f, 0);
            cell = new PdfPCell(new Phrase("Damage Product Don't Have Any Guarantee and Warranty**", font));
            cell.Colspan = _totalColumn;
            cell.HorizontalAlignment = Element.ALIGN_CENTER;
            cell.Border = 0;
            cell.BackgroundColor = BaseColor.WHITE;
            cell.ExtraParagraphSpace = 1;
            table.AddCell(cell);
            table.CompleteRow();


            font = FontFactory.GetFont("Tahoma", 7f, 0);
            cell = new PdfPCell(new Phrase("1 month warranty in Laptops**T&C", font));
            cell.Colspan = _totalColumn;
            cell.HorizontalAlignment = Element.ALIGN_CENTER;
            cell.Border = 0;
            cell.BackgroundColor = BaseColor.WHITE;
            cell.ExtraParagraphSpace = 1;
            table.AddCell(cell);
            table.CompleteRow();


            font = FontFactory.GetFont("Tahoma", 7f, 0);
            cell = new PdfPCell(new Phrase("Terms And Conditions Apply in All Products", font));
            cell.Colspan = _totalColumn;
            cell.HorizontalAlignment = Element.ALIGN_CENTER;
            cell.Border = 0;
            cell.BackgroundColor = BaseColor.WHITE;
            cell.ExtraParagraphSpace = 1;
            table.AddCell(cell);
            table.CompleteRow();

            font = FontFactory.GetFont("Tahoma", 7f, 0);
            cell = new PdfPCell(new Phrase("All disputes are subject to Delhi jurisdiction only", font));
            cell.Colspan = _totalColumn;
            cell.HorizontalAlignment = Element.ALIGN_CENTER;
            cell.Border = 0;
            cell.BackgroundColor = BaseColor.WHITE;
            cell.ExtraParagraphSpace = 1;
            table.AddCell(cell);
            table.CompleteRow();


            #endregion

        }



    }
}
