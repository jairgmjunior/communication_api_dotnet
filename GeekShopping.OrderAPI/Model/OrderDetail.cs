using GeekShopping.OrderAPI.Model.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace GeekShopping.OrderAPI.Model
{
    public class OrderDetail : BaseEntity
    {
        public long OrderHeaderId { get; set; }

        [ForeignKey("OrderHeaderId")]
        public virtual OrderHeader OrderHeader { get; set; }
        
        public long ProductId { get; set; }
        
        public int Count { get; set; }

        public string ProductName { get; set; }

        [Column(TypeName = "decimal(18,5)")]
        public decimal Price { get; set; }
    }
}
