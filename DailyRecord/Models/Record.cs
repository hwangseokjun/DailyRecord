using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyRecord.Models
{
    public enum Weahter 
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

    public class Record
    {
        public int Id { get; set; }
        public Weahter Weahter { get; set; }
        public DateTime DateTime { get; set; }
        public string Contents { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? ModifedAt { get; set; }
        public int? CategoryId { get; set; }
    }
}
