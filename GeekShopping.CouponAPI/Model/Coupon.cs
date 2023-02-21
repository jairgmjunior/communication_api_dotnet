using GeekShopping.CouponAPI.Model.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GeekShopping.CouponAPI.Model
{
    public class Coupon : BaseEntity
    {
        [Required]
        [MaxLength(30)]
        public string CouponCode { get; set; }

        [Column(TypeName = "decimal(18,5)")]
        [Required]
        public decimal DiscountAmount { get; set; }
    }
}
