using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyRecord.DataModels
{
    public class Month
    {
        public int RecordId { get; set; }
        public string Name { get; set; }
        public List<Record> Records { get; set; } = new List<Record>();
    }
}
