using DailyRecord.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyRecord.DataAccess
{
    public class MockRepository : IRepository
    {
        public Year[] GetYears()
        {
            return new Year[] 
            { 
                new Year { RecordId = 1, Name = "2020", Months = new List<Month>() },
                new Year { RecordId = 2, Name = "2021", Months = new List<Month>() },
                new Year { RecordId = 3, Name = "2022", Months = new List<Month>() }
            };
        }

        public Month[] GetMonths(Year year)
        {
            switch (year.Name)
            {
                case "2020":
                    return new Month[]
                    {
                        new Month() { RecordId = 4, Name = "2월", Records = new List<Record>() },
                    };
                case "2021":
                    return new Month[]
                    {
                        new Month() { RecordId = 5, Name = "3월", Records = new List<Record>() },
                        new Month() { RecordId = 6, Name = "12월", Records = new List<Record>() }
                    };
                case "2022":
                    return new Month[]
                    {
                        new Month() { RecordId = 7, Name = "5월", Records = new List<Record>() }
                    };
            }

            return null;
        }

        public Record[] GetRecords(Month month)
        {
            switch (month.Name)
            {
                case "2월":
                    return new Record[]
                    {
                        new Record() { RecordId = 8, Name = "7일" }
                    };
                case "3월":
                    return new Record[]
                    {
                        new Record() { RecordId = 9, Name = "12일" },
                        new Record() { RecordId = 10, Name = "14일" }
                    };
                case "5월":
                    return new Record[]
                    {
                        new Record() { RecordId = 11, Name = "30일" }
                    };
                case "12월":
                    return new Record[]
                    {
                        new Record() { RecordId = 12, Name = "24일" }
                    };
            }

            return null;
        }
    }
}
