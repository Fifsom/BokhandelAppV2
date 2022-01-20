using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BokhandelV2.Models
{
    public partial class Shop
    {
        public Shop()
        {
            StockBlances = new HashSet<StockBlance>();
        }

        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [StringLength(50)]
        public string? Name { get; set; }
        [StringLength(50)]
        public string? Address { get; set; }
        [Column("CountryID")]
        public int? CountryId { get; set; }

        [ForeignKey(nameof(CountryId))]
        [InverseProperty("Shops")]
        public virtual Country? Country { get; set; }
        [InverseProperty(nameof(StockBlance.Shops))]
        public virtual ICollection<StockBlance> StockBlances { get; set; }
    }
}
