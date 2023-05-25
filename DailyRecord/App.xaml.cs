using DailyRecord.Services;
using DailyRecord.Stores;
using DailyRecord.UserControls;
using DailyRecord.ViewModels;
using DailyRecord.Views;
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

        public App() 
        {
            Services = ConfigureServices();

            var mainView = Services.GetRequiredService<MainView>();
            mainView.Show();
        }

        private IServiceProvider ConfigureServices()
        {
            var services = new ServiceCollection();

            // Stores
            services.AddSingleton<MainNavigationStore>();

            // Services
            services.AddSingleton<INavigationService, NavigationService>();

            // ViewModels
            services.AddSingleton<DiaryViewModel>();
            services.AddSingleton<MainViewModel>();
            services.AddSingleton<RegisterViewModel>();
            services.AddSingleton<StatisticsViewModel>();
            services.AddSingleton<TasksViewModel>();
            services.AddSingleton<TextEditorViewModel>();

            // Views
            services.AddSingleton(s => new MainView 
            { 
                DataContext = s.GetRequiredService<MainViewModel>()
            });

            // UserControls
            services.AddSingleton(s => new Register 
            { 
                DataContext = s.GetRequiredService<RegisterViewModel>()
            });

            return services.BuildServiceProvider();
        }

        public IServiceProvider Services { get; }

        protected override void OnStartup(StartupEventArgs e)
        {
            /* 
             * HACK: WPF의 텍스트 렌더링이 단일코어에서 최적의 성능을 내기때문에 해당 코드 필요
             * 그러나, 이 옵션을 사용하면 복잡한 애니메이션을 사용하기 어려워진다.
            */
            Process.GetCurrentProcess().ProcessorAffinity = new IntPtr(1);
            base.OnStartup(e);
        }
    }
}
