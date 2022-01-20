using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BokhandelV2.Models
{
    public partial class Book
    {
        public Book()
        {
            OrderDetails = new HashSet<OrderDetail>();
            StockBlances = new HashSet<StockBlance>();
        }

        [Key]
        [Column("ISBN13")]
        [StringLength(17)]
        [Unicode(false)]
        public string Isbn13 { get; set; } = null!;
        [StringLength(50)]
        public string? Title { get; set; }
        [StringLength(50)]
        public string Language { get; set; } = null!;
        public double? Price { get; set; }
        [Column("Release date", TypeName = "date")]
        public DateTime? ReleaseDate { get; set; }
        [Column("AuthorID")]
        public int? AuthorId { get; set; }

        [ForeignKey(nameof(AuthorId))]
        [InverseProperty("Books")]
        public virtual Author? Author { get; set; }
        [InverseProperty(nameof(OrderDetail.BooksIsbn13Navigation))]
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        [InverseProperty(nameof(StockBlance.BooksIsbn13Navigation))]
        public virtual ICollection<StockBlance> StockBlances { get; set; }
    }
}
