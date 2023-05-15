using DailyRecord.Business;
using DailyRecord.DataAccess;
using DailyRecord.TypeHandlers;
using DailyRecord.ViewModels;
using DailyRecord.Views;
using Dapper;
using Microsoft.Extensions.DependencyInjection;
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
        public new static App Current => (App)Application.Current;
        public IServiceProvider Services { get; }

        public App() 
        {
            Services = ConfigureServices();
            var mainWindow = Services.GetRequiredService<MainWindow>();
            mainWindow.DataContext = Services.GetRequiredService<IDataService>();
            mainWindow.Show();
        }

        private IServiceProvider ConfigureServices() 
        {
            var services = new ServiceCollection();

            // DataAcess
            services.AddSingleton<IRepository, MockRepository>();

            // Business
            services.AddSingleton<IDataService, Service>();

            // ViewModel
            services.AddSingleton<MainWindowViewModel>();

            // View
            services.AddSingleton(s => new MainWindow
            {
                DataContext = s.GetRequiredService<MainWindowViewModel>()
            });

            return services.BuildServiceProvider();
        }

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

            var repository = Services.GetRequiredService<IRepository>();

            base.OnStartup(e);
        }
    }
}
