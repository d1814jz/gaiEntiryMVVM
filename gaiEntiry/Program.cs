using gaiEntiry.Base;
using gaiEntiry.Base.DependencyInjection;
using gaiEntiry.Base.ViewsModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gaiEntiry
{
    class Program
    {
        /*public static IHostBuilder CreateHostBuilder(string[] args) => Host
           .CreateDefaultBuilder(args)
           .ConfigureServices(App.ConfigureServices);*/


        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    IConfiguration configuration = hostContext.Configuration;
                    services.AddScoped<AutoBaseViewModel>();
                    services.AddRepositoriesInProject();
                    services.AddViewModels();
                    services.AddServices();
                    AppSettings.Configuration = configuration;
                    AppSettings.ConnectionString = configuration.GetConnectionString("gaiEngEntities");


                    var optionBuilder = new DbContextOptionsBuilder<DbContext>();
                    optionBuilder.UseSqlServer("gaiEngEntities");

                    services.AddScoped<gaiEngEntities>(d => new gaiEngEntities());
                    services.ToList();



                });
    }
}
