using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BokhandelV2.Models
{
    [Keyless]
    public partial class VTitlarPerFörfattare
    {
        [StringLength(100)]
        public string? Name { get; set; }
        public int? Age { get; set; }
        public int? Titles { get; set; }
        [Column("Stock Value")]
        public double? StockValue { get; set; }
    }
}
