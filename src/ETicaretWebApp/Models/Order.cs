using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ETicaretWebApp.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public DateTime OrderedAt { get; set; }
        public DateTime RequireAt { get; set; }
        public DateTime? ShippedAt { get; set; }
        [ForeignKey("Address")]
        public int AddressId { get; set; }
        public decimal Freight { get; set; }
        public ICollection<OrderLine> OrderLines { get; set; }
        public Address Address { get; set; }
    }
}
