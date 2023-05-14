using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyRecord.Models
{
    [Table("tree_path")]
    public class DateTreePath
    {
        public int AncestorId { get; set; }
        public int DescendantId { get; set; }
    }
}
