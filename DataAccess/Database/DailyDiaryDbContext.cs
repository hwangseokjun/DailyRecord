using DataAccess.Models;
using DataAccess.Properties;
using MySql.Data.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace DataAccess.Database
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class DailyRecordDbContext : DbContext
    {
        public DailyRecordDbContext() : base(Settings.Default.CONNECTION_STRING)
        {
        }

        // DbSet
        public DbSet<Record> Records { get; set; }
        public DbSet<Task> Tasks { get; set; }
    }
}
