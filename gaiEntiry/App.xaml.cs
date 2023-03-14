using gaiEntiry.Base.DependencyInjection;
using gaiEntiry.Base.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace gaiEntiry
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        public static bool IsDesignTime { get; internal set; }
        public static Window ActiveWindow => Application.Current.Windows
               .OfType<Window>()
               .FirstOrDefault(w => w.IsActive);

        public static Window FocusedWindow => Application.Current.Windows
           .OfType<Window>()
           .FirstOrDefault(w => w.IsFocused);

        public static Window CurrentWindow => FocusedWindow ?? ActiveWindow;


        //private static IHost __Host => Program.CreateHostBuilder(Environment.GetCommandLineArgs()).Build();
        private static IHost __Host;

        /*internal static void ConfigureServices(HostBuilderContext host, IServiceCollection services) => services
           .AddServices()
           .AddViewModels()
        ;*/



        public static IHost Host => __Host
            ?? Program.CreateHostBuilder(Environment.GetCommandLineArgs()).Build();
        //public static IHost Host; 

        public static IServiceProvider Services => Host.Services;


        protected override async void OnStartup(StartupEventArgs e)
        {
            IsDesignTime = false;
            var host = Host;
            base.OnStartup(e);
            await host.StartAsync();
            
        }
    }
}
