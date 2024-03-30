namespace radiobutton.Models
{
    public class Orders
    {
        public  string dateoforder;

        public int Id { get; set; } 
        public string orderName { get; set; }
        public string Username { get; set; }

        public string Uname { get; set; }

        public string Img { get; set; }
        
        public int  Qty { get; set; }

        public float Saleprice { get; set; }

        public DateTime orderDate { get; set; }

        public string Paytype { get; set; }

        public string OrerStatus { get; set; } 

        public string PaymentStatus { get; set; }

        public string Trackno { get; set; }
        public string Shippingp { get; set; }
        public string Trackurl { get; set; }
        public DateTime Shippingdate { get; set; }
    }
}
