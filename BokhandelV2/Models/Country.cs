using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BokhandelV2.Models
{
    [Table("Country")]
    public partial class Country
    {
        public Country()
        {
            Shops = new HashSet<Shop>();
        }

        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [StringLength(50)]
        public string Name { get; set; } = null!;

        [InverseProperty(nameof(Shop.Country))]
        public virtual ICollection<Shop> Shops { get; set; }
    }
}
