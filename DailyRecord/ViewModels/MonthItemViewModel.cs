using DailyRecord.DataAccess;
using DailyRecord.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyRecord.ViewModels
{
    public class MonthItemViewModel : DirectoryItemViewModel
    {
        private readonly Month _month;
        private readonly IRepository _repository;

        public MonthItemViewModel(Month month, YearItemViewModel parent, IRepository repository)
            : base(parent, true)
        {
            _month = month;
            _repository = repository;
        }

        public string Name
        {
            get => _month.Name;
        }

        protected override void LoadChildren()
        {
            foreach (Record record in _repository.GetRecords(_month)) 
            {
                Children.Add(new RecordItemViewModel(record, this));
            }
        }
    }
}
