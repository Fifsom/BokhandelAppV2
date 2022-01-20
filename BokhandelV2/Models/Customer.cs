using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BokhandelV2.Models
{
    public partial class Customer
    {
        public Customer()
        {
            Orders = new HashSet<Order>();
        }

        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [StringLength(50)]
        public string FirstName { get; set; } = null!;
        [Column("lastName")]
        [StringLength(50)]
        public string? LastName { get; set; }
        [Column("Phone Number")]
        public int? PhoneNumber { get; set; }

        [InverseProperty(nameof(Order.Customer))]
        public virtual ICollection<Order> Orders { get; set; }
    }
}
