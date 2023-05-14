using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyRecord.Models
{
    public enum Icon
    { 
        Directory,
        Document
    }

    public class DateTreeItem
    {
        public int Id { get; set; }
        public Icon Icon { get; set; }
        public DateTime DateTime { get; set; }
    }
}
