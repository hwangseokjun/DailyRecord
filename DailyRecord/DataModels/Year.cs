﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyRecord.DataModels
{
    public class Year
    {
        public int RecordId { get; set; }
        public string Name { get; set; }
        public List<Month> Months { get; set; } = new List<Month>();
    }
}
