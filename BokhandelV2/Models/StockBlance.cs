using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BokhandelV2.Models
{
    [Table("Stock Blance")]
    public partial class StockBlance
    {
        [Key]
        [Column("ShopsID")]
        public int ShopsId { get; set; }
        [Key]
        [Column("BooksISBN13")]
        [StringLength(17)]
        [Unicode(false)]
        public string BooksIsbn13 { get; set; } = null!;
        public int? Quantity { get; set; }

        [ForeignKey(nameof(BooksIsbn13))]
        [InverseProperty(nameof(Book.StockBlances))]
        public virtual Book BooksIsbn13Navigation { get; set; } = null!;
        [ForeignKey(nameof(ShopsId))]
        [InverseProperty(nameof(Shop.StockBlances))]
        public virtual Shop Shops { get; set; } = null!;
    }
}
