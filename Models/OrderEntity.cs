using Org.BouncyCastle.Bcpg.OpenPgp;
using System.ComponentModel.DataAnnotations.Schema;

namespace radiobutton.Models
{
    public class OrderEntity
    {
        public int Id { get; set; }
        [NotMapped]
        public string OrderId { get; set; }

        [NotMapped]
      public string  TransactionId { get; set; }    
    }
}
