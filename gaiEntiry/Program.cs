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

                    #region ViewModel
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
                    services.AddScoped<DistrictBaseViewModel>();
                    services.AddScoped<DistrictBaseEditViewModel>();
                    services.AddScoped<PositionBaseViewModel>();
                    services.AddScoped<PositionBaseEditViewModel>();
                    services.AddScoped<TypesOfIAPBaseEditViewModel>();
                    services.AddScoped<TypesOfIAPBaseViewModel>();
                    services.AddScoped<DutyDotsTypeBaseEditViewModel>();
                    services.AddScoped<DutyDotsTypeBaseViewModel>();
                    services.AddScoped<StreetBaseViewModel>();
                    services.AddScoped<StreetBaseEditViewModel>();
                    services.AddScoped<HistoryBaseViewModel>();
                    services.AddScoped<HistoryBaseEditViewModel>();
                    services.AddScoped<ServiceCarBaseViewModel>();
                    services.AddScoped<ServiceCarBaseEditViewModel>();
                    services.AddScoped<IAPBaseViewModel>();
                    services.AddScoped<IAPBaseEditViewModel>();
                    services.AddScoped<UserBaseViewModel>();
                    services.AddScoped<UserBaseEditViewModel>();
                    services.AddScoped<AccidentMemberBaseViewModel>();
                    services.AddScoped<AccidentMemberBaseEditViewModel>();
                    services.AddScoped<DutyDotsBaseViewModel>();
                    services.AddScoped<DutyDotsBaseEditViewModel>();
                    services.AddScoped<AccidentBaseViewModel>();
                    services.AddScoped<AccidentBaseEditViewModel>();
                    services.AddScoped<AuthorizationBaseViewModel>();
                    services.AddScoped<AccidentReportViewModel>();
                    services.AddScoped<IllegalReportViewModel>();
                    services.AddScoped<DutyReportViewModel>();
                    services.AddScoped<AccountingReportViewModel>();
                    services.AddScoped<LogBaseViewModel>();

                    services.AddScoped<MenuBaseViewModel>();

                    #endregion

                    #region Repositories
                    services.AddTransient<IRepository<Auto>, DbRepository<Auto>>();
                    services.AddTransient<IRepository<Driver>, DbRepository<Driver>>();
                    services.AddTransient<IRepository<IllegalType>, DbRepository<IllegalType>>();
                    services.AddTransient<IRepository<Rank>, DbRepository<Rank>>();
                   //services.AddTransient<IRepository<Worker>, DbRepository<Worker>>();
                    services.AddTransient<IRepository<Worker>, DbRepository<Worker>>();
                    services.AddTransient<IRepository<Duty>, DutyRepository>();
                    //services.AddTransient<IRepository<Worker>, DbRepository<Worker>>();
                    services.AddTransient<IRepository<Worker>, WorkerRepository>();
                    //services.AddTransient<IRepository<Illegal>, DbRepository<Illegal>>();
                    services.AddTransient<IRepository<Illegal>, IllegalRepository>();
                    services.AddTransient<IRepository<Accounting>, AccountingRepository>();
                    services.AddTransient<IRepository<District>, DbRepository<District>>();
                    services.AddTransient<IRepository<Position>, DbRepository<Position>>();
                    services.AddTransient<IRepository<TypesOfIAP>, DbRepository<TypesOfIAP>>();
                    services.AddTransient<IRepository<DutyDotsType>, DbRepository<DutyDotsType>>();
                    services.AddTransient<IRepository<Street>, StreetRepository>();
                    services.AddTransient<IRepository<History>, HistoryRepository>();
                    services.AddTransient<IRepository<ServiceCar>, DbRepository<ServiceCar>>();
                    services.AddTransient<IRepository<IAP>, IAPRepository>();
                    services.AddTransient<IRepository<User>, DbRepository<User>>();
                    services.AddTransient<IRepository<AccidentMember>, AccidentMemberRepository>();
                    services.AddTransient<IRepository<Accident>, AccidentRepository>();
                    services.AddTransient<IRepository<DutyDots>, DutyDotsRepository>();
                    services.AddTransient<IRepository<User>, DbRepository<User>>();
                    services.AddTransient<IRepository<Log>, DbRepository<Log>>();

                    #endregion
                    services.ToList();



                });
    }
}
