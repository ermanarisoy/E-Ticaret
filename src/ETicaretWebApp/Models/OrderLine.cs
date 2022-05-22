using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ETicaretWebApp.Models
{
    public class OrderLine
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Order")]
        public int OrderId { get; set; }
        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public decimal PricePerUnit { get; set; }
        public int Quantity { get; set; }
        public decimal Discount { get; set; }
        public Product Product { get; set; }
        public Order Order { get; set; }
    }
}
