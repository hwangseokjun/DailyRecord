using Dapper;

using DailyRecord.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyRecord.TypeHandlers
{
    public class WeatherTypeHandler : SqlMapper.TypeHandler<Weather?>
    {
        public override Weather? Parse(object value)
        {
            if (value == null || value == DBNull.Value)
            {
                return null;
            }

            return (Weather?)Convert.ToInt32(value);
        }

        public override void SetValue(IDbDataParameter parameter, Weather? value)
        {
            if (value.HasValue)
            {
                parameter.Value = (int)value.Value;
                return;
            }

            parameter.Value = DBNull.Value;
        }
    }
}
