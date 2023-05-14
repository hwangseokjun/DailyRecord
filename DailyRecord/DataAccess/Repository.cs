using DailyRecord.Models;
using Dapper;
using Dapper.Contrib.Extensions;

using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyRecord.DataAccess
{
    public class Repository
    {
        private readonly string _connectionString;

        public Repository()
        {
            _connectionString = $"Data Source={Constants.DATABASE_PATH};Version=3;";
        }

        public List<Record> FindAllRecord()
        {
            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();

                return connection.GetAll<Record>().ToList();
            }
        }

        public void Save() 
        {
        
        }
    }
}
