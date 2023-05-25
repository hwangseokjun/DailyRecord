using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    [Table("records")]
    public class Record
    {
        [Column("id")]
        [Key]
        public int Id { get; set; }

        [Column("date")]
        [Required]
        public DateTime Date { get; set; }

        [Column("contents")]
        [Required]
        public string Contents { get; set; }

        [Column("created_at")]
        [Required]
        public DateTime CreatedAt { get; set; }

        [Column("modified_at")]
        [Required]
        public DateTime ModifiedAt { get; set; }

        public virtual ICollection<Task> Tasks { get; set; }
    }
}
