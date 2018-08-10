﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TTA.Api.Models
{
    [Table("orders")]
    public partial class Order:EntityBase
    {       
        public Order()
        {
            this.OrderItems = new HashSet<OrderItem>();
        }

        [Column("client_order_id")]
        public string ClientOrderId { get; set; }

        [Column("client")]
        public string Client { get; set; }

        [Column("stage")]
        public string Stage { get; set; }

        [Column("customer_id")]
        public Guid? CustomerId { get; set; }

        [Column("order_no")]
        [Key]
        public string OrderNo { get; set; }

        [Column("note")]
        public string Note { get; set; }
        
        [Column("shipping_service")]
        public string ShippingService { get; set; }

        //log time when the order is delivered to customer, when customer receive the order
        [Column("delivered")]
        public DateTime? Delivered { get; set; }

        [Column("receive_payment")]
        public DateTime? ReceivePayment { get; set; }

        [Column("total")]
        public decimal? Total { get; set; }

        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
}
