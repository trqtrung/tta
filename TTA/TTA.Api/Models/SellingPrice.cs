using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TTA.Api.Models
{
    [Table("selling_prices")]
    public class SellingPrice
    {
        [Column("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        [Column("customer_id")]
        public int CustomerId { get; set; }

        public virtual Customer Customer { get; set; }

        [Column("quantity_from")]
        public int QuantityFrom { get; set; }

        [Column("quantity_to")]
        public int QuantityTo { get; set; }

        [Column("product_id")]
        public int ProductId { get; set; }

        public virtual Product Product { get; set; }

        [Column("price_date")]
        public DateTime PriceDate { get; set; }
    }
}
