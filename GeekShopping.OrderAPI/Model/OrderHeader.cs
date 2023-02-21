using GeekShopping.OrderAPI.Model.Base;
using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using GeekShopping.MessageBus;

namespace GeekShopping.OrderAPI.Model
{
    public class OrderHeader : BaseEntity
    {
        public string UserId { get; set; }

        public string CouponCode { get; set; }

        [Column(TypeName = "decimal(18,5)")]
        public decimal PurchaseAmount { get; set; }

        [Column(TypeName = "decimal(18,5)")]
        public decimal DiscountAmount { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime DateTime { get; set; }

        public DateTime OrderTime { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public string CardNumber { get; set; }

        public string CVV { get; set; }

        public string ExpiryMonthYear { get; set; }

        public int CartTotalItens { get; set; }

        public List<OrderDetail> OrderDetails { get; set; }

        public bool PaymentStatus {  get; set; }

        public static explicit operator OrderHeader(BaseMessage v)
        {
            throw new NotImplementedException();
        }
    }
}
