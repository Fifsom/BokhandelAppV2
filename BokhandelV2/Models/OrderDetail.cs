using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BokhandelV2.Models
{
    public partial class OrderDetail
    {
        public OrderDetail()
        {
            Orders = new HashSet<Order>();
        }

        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Column("BooksISBN13")]
        [StringLength(17)]
        [Unicode(false)]
        public string? BooksIsbn13 { get; set; }
        public int? Quantity { get; set; }

        [ForeignKey(nameof(BooksIsbn13))]
        [InverseProperty(nameof(Book.OrderDetails))]
        public virtual Book? BooksIsbn13Navigation { get; set; }
        [InverseProperty(nameof(Order.OrderDetails))]
        public virtual ICollection<Order> Orders { get; set; }
    }
}
