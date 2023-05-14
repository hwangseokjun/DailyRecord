using Dapper;

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyRecord.TypeHandlers
{
    public class IsoDateTimeHandler : SqlMapper.TypeHandler<DateTime>
    {
        public override void SetValue(IDbDataParameter parameter, DateTime value)
        {
            parameter.Value = value.ToString("yyyy-MM-ddTHH:mm:ss.fff");
        }

        public override DateTime Parse(object value)
        {
            return DateTime.Parse((string)value);
        }
    }
}
