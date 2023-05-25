using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    [Table("tasks")]
    public class Task
    {
        [Column("id")]
        [Key]
        public int Id { get; set; }

        [Column("contents")]
        [Required]
        [MaxLength(50)]
        public string Contents { get; set; }

        [Column("started_at")]
        public DateTime StartedAt { get; set; }

        [Column("ended_at")]
        public DateTime EndedAt { get; set; }

        [Column("record_id")]
        public int RecordId { get; set; }

        [ForeignKey("RecordId")]
        public virtual Record Record { get; set; }
    }
}
