using Dapper.Contrib.Extensions;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyRecord.Models
{
    public enum Weather
    { 
        Sunny,
        Rainy,
        Cloudy,
        Snow,
        Windy,
        Hot,
        Cold,
        Typhoon
    }

    [Table("record")]
    public class Record
    {
        [Key]
        public int Id { get; set; }
        public Weather? Weather { get; set; }
        public DateTime Date { get; set; }
        public string Contents { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? ModifedAt { get; set; }
        public int? CategoryId { get; set; }
    }
}
