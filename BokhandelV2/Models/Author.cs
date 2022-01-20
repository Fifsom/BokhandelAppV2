using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BokhandelV2.Models
{
    [Table("Author")]
    public partial class Author
    {
        public Author()
        {
            Books = new HashSet<Book>();
        }

        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [StringLength(50)]
        public string FirstName { get; set; } = null!;
        [StringLength(50)]
        public string? LastName { get; set; }
        [Column(TypeName = "date")]
        public DateTime? Birthdate { get; set; }

        [InverseProperty(nameof(Book.Author))]
        public virtual ICollection<Book> Books { get; set; }
    }
}
