using DailyRecord.TypeHandlers;
using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace DailyRecord
{
    /// <summary>
    /// App.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            /* 
             * HACK: WPF의 텍스트 렌더링이 단일코어에서 최적의 성능을 내기때문에 해당 코드 필요
             * 그러나, 이 옵션을 사용하면 복잡한 애니메이션을 사용하기 어려워진다.
            */
            Process.GetCurrentProcess().ProcessorAffinity = new IntPtr(1);

            #region Dapper에 TypeHandler 등록
            SqlMapper.AddTypeHandler(new WeatherTypeHandler());
            SqlMapper.AddTypeHandler(new IsoDateTimeHandler());
            #endregion

            base.OnStartup(e);
        }
    }
}
