using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyRecord.Models
{
    public class Work
    {
        public int Id { get; set; }
        public DateTime StartedAt { get; set; }
        public DateTime EndAt { get; set; }
        public bool IsCompleted { get; set; }
    }
}
