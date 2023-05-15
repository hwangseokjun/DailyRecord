using DailyRecord.DataAccess;
using DailyRecord.DataModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyRecord.ViewModels
{
    public class YearItemViewModel : DirectoryItemViewModel
    {
        private readonly IRepository _repository;
        private Year _year;

        public string Name
        {
            get { return _year.Name; }
        }

        public YearItemViewModel(Year year, IRepository repository)
            : base(null, true)
        {
            _year = year;
            _repository = repository;
        }

        protected override void LoadChildren()
        {
            foreach (Month month in _repository.GetMonths(_year)) 
            {
                Children.Add(new MonthItemViewModel(month, this, _repository));
            }
        }
    }
}
