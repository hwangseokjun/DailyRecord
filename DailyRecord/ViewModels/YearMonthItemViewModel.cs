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
    public class YearMonthItemViewModel : ViewModelBase
    {
        private readonly IRepository _repository;

        private readonly ObservableCollection<YearItemViewModel> _years;
        public ObservableCollection<YearItemViewModel> Years
        {
            get => _years;
        }

        public YearMonthItemViewModel(IRepository repository)
        {
            _repository = repository;
            Year[] years = _repository.GetYears();

            _years = new ObservableCollection<YearItemViewModel>(
                (from year in years
                 select new YearItemViewModel(year, _repository))
                .ToList());
        }
    }
}
