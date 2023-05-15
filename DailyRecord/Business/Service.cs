using DailyRecord.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyRecord.Business
{
    public class Service : IDataService
    {
        private readonly Repository _repository = new Repository();

        public void GetRecord() 
        {
            var d = _repository.FindAllRecord();

            d.ForEach(x => Console.WriteLine(x.Contents));
        }
    }
}
