using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BokhandelV2.Models
{
    public partial class Order
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Column("OrderDetailsID")]
        public int? OrderDetailsId { get; set; }
        [Column("CustomerID")]
        public int? CustomerId { get; set; }

        [ForeignKey(nameof(CustomerId))]
        [InverseProperty("Orders")]
        public virtual Customer? Customer { get; set; }
        [ForeignKey(nameof(OrderDetailsId))]
        [InverseProperty(nameof(OrderDetail.Orders))]
        public virtual OrderDetail? OrderDetails { get; set; }
    }
}
