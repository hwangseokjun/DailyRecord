using DailyRecord.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyRecord.ViewModels
{
    public class RecordItemViewModel : DirectoryItemViewModel
    {
        private readonly Record _record;

        public RecordItemViewModel(Record record, MonthItemViewModel parent)
            : base(parent, false)
        {
            _record = record;
        }

        public string Name
        {
            get => _record.Name; 
        }
    }
}
