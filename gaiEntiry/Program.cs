using gaiEntiry.Base;
using gaiEntiry.Base.DependencyInjection;
using gaiEntiry.Base.Repository;
using gaiEntiry.Base.Service;
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
                    AppSettings.Configuration = configuration;
                    AppSettings.ConnectionString = configuration.GetConnectionString("gaiEngEntities");


                    var optionBuilder = new DbContextOptionsBuilder<DbContext>();
                    optionBuilder.UseSqlServer("gaiEngEntities");

                    services.AddTransient<IUserDialog, UserDialogService>();

                    services.AddScoped<gaiEngEntities>(d => new gaiEngEntities());
                    services.AddScoped<AutoBaseViewModel>();
                    services.AddScoped<AutoBaseEditViewModel>();
                    services.AddScoped<DriverBaseViewModel>();
                    services.AddScoped<DriverBaseEditViewModel>();
                    services.AddScoped<IllegalTypeBaseViewModel>();
                    services.AddScoped<IllegalTypeBaseEditViewModel>();
                    services.AddScoped<RankBaseViewModel>();
                    services.AddScoped<RankBaseEditViewModel>();
                    services.AddScoped<WorkerBaseViewModel>();
                    services.AddScoped<WorkerBaseEditViewModel>();
                    services.AddScoped<DutyBaseViewModel>();
                    services.AddScoped<DutyBaseEditViewModel>();
                    services.AddScoped<IllegalBaseViewModel>();
                    services.AddScoped<IllegalBaseEditViewModel>();
                    services.AddScoped<AccountingBaseViewModel>();
                    services.AddScoped<AccountingBaseEditViewModel>();

                    services.AddScoped<MenuBaseViewModel>();

                    services.AddTransient<IRepository<Auto>, DbRepository<Auto>>();
                    services.AddTransient<IRepository<Driver>, DbRepository<Driver>>();
                    services.AddTransient<IRepository<IllegalType>, DbRepository<IllegalType>>();
                    services.AddTransient<IRepository<Rank>, DbRepository<Rank>>();
                    services.AddTransient<IRepository<Worker>, DbRepository<Worker>>();
                    services.AddTransient<IRepository<Worker>, DbRepository<Worker>>();
                    services.AddTransient<IRepository<Duty>, DbRepository<Duty>>();
                    services.AddTransient<IRepository<Worker>, DbRepository<Worker>>();
                    services.AddTransient<IRepository<Illegal>, DbRepository<Illegal>>();
                    services.AddTransient<IRepository<Accounting>, DbRepository<Accounting>>();
                    services.ToList();



                });
    }
}
