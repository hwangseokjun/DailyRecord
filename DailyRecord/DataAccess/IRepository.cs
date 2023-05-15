using DailyRecord.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyRecord.DataAccess
{
    public interface IRepository
    {
        Year[] GetYears();
        Month[] GetMonths(Year year);
        Record[] GetRecords(Month month);
    }
}
