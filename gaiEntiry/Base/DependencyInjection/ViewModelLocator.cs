using gaiEntiry.Base.ViewsModel;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gaiEntiry.Base.DependencyInjection
{
    class ViewModelLocator
    {
        //public AutoBaseViewModel AutoBaseViewModel => App.Services.GetRequiredService<AutoBaseViewModel>();
        public AutoBaseViewModel AutoBaseViewModel => App.Services.GetRequiredService<AutoBaseViewModel>();
        public AutoBaseEditViewModel AutoBaseEditViewModel => App.Services.GetRequiredService<AutoBaseEditViewModel>();

        public DriverBaseViewModel DriverBaseViewModel => App.Services.GetRequiredService<DriverBaseViewModel>();
        public DriverBaseEditViewModel DriverBaseEditViewModel => App.Services.GetRequiredService<DriverBaseEditViewModel>();
        public IllegalTypeBaseViewModel IllegalTypeBaseViewModel => App.Services.GetRequiredService<IllegalTypeBaseViewModel>();
        public IllegalTypeBaseEditViewModel IllegalTypeBaseEditViewModel => App.Services.GetRequiredService<IllegalTypeBaseEditViewModel>();
        public RankBaseViewModel RankBaseViewModel => App.Services.GetRequiredService<RankBaseViewModel>();
        public RankBaseEditViewModel RankBaseEditViewModel => App.Services.GetRequiredService<RankBaseEditViewModel>();
        public WorkerBaseViewModel WorkerBaseViewModel => App.Services.GetRequiredService<WorkerBaseViewModel>();
        public WorkerBaseEditViewModel WorkerBaseEditViewModel => App.Services.GetRequiredService<WorkerBaseEditViewModel>();
        public DutyBaseViewModel DutyBaseViewModel => App.Services.GetRequiredService<DutyBaseViewModel>();
        public DutyBaseEditViewModel DutyBaseEditViewModel => App.Services.GetRequiredService<DutyBaseEditViewModel>();
        public IllegalBaseViewModel IllegalBaseViewModel => App.Services.GetRequiredService<IllegalBaseViewModel>();
        public IllegalBaseEditViewModel IllegalBaseEditViewModel => App.Services.GetRequiredService<IllegalBaseEditViewModel>();
        public AccountingBaseViewModel AccountingBaseViewModel => App.Services.GetRequiredService<AccountingBaseViewModel>();
        public AccountingBaseEditViewModel AccountingBaseEditViewModel => App.Services.GetRequiredService<AccountingBaseEditViewModel>();
        public DistrictBaseViewModel DistrictBaseViewModel => App.Services.GetRequiredService<DistrictBaseViewModel>();
        public DistrictBaseEditViewModel DistrictBaseEditViewModel => App.Services.GetRequiredService<DistrictBaseEditViewModel>();
        public PositionBaseViewModel PositionBaseViewModel => App.Services.GetRequiredService<PositionBaseViewModel>();
        public PositionBaseEditViewModel PositionBaseEditViewModel => App.Services.GetRequiredService<PositionBaseEditViewModel>();
        public TypesOfIAPBaseViewModel TypesOfIAPBaseViewModel => App.Services.GetRequiredService<TypesOfIAPBaseViewModel>();
        public TypesOfIAPBaseEditViewModel TypesOfIAPBaseEditViewModel => App.Services.GetRequiredService<TypesOfIAPBaseEditViewModel>();
        public DutyDotsTypeBaseViewModel DutyDotsTypeBaseViewModel => App.Services.GetRequiredService<DutyDotsTypeBaseViewModel>();
        public DutyDotsTypeBaseEditViewModel DutyDotsTypeBaseEditViewModel => App.Services.GetRequiredService<DutyDotsTypeBaseEditViewModel>();
        public StreetBaseViewModel StreetBaseViewModel => App.Services.GetRequiredService<StreetBaseViewModel>();
        public StreetBaseEditViewModel StreetBaseEditViewModel => App.Services.GetRequiredService<StreetBaseEditViewModel>();
        public HistoryBaseViewModel HistoryBaseViewModel => App.Services.GetRequiredService<HistoryBaseViewModel>();
        public HistoryBaseEditViewModel HistoryBaseEditViewModel => App.Services.GetRequiredService<HistoryBaseEditViewModel>();
        public ServiceCarBaseViewModel ServiceCarBaseViewModel => App.Services.GetRequiredService<ServiceCarBaseViewModel>();
        public ServiceCarBaseEditViewModel ServiceCarBaseEditViewModel => App.Services.GetRequiredService<ServiceCarBaseEditViewModel>();
        public IAPBaseViewModel IAPBaseViewModel => App.Services.GetRequiredService<IAPBaseViewModel>();
        public IAPBaseEditViewModel IAPBaseEditViewModel => App.Services.GetRequiredService<IAPBaseEditViewModel>();
        public UserBaseViewModel UserBaseViewModel => App.Services.GetRequiredService<UserBaseViewModel>();
        public UserBaseEditViewModel UserBaseEditViewModel => App.Services.GetRequiredService<UserBaseEditViewModel>();
        public AccidentMemberBaseViewModel AccidentMemberBaseViewModel => App.Services.GetRequiredService<AccidentMemberBaseViewModel>();
        public AccidentMemberBaseEditViewModel AccidentMemberBaseEditViewModel => App.Services.GetRequiredService<AccidentMemberBaseEditViewModel>();
        public DutyDotsBaseViewModel DutyDotsBaseViewModel => App.Services.GetRequiredService<DutyDotsBaseViewModel>();
        public DutyDotsBaseEditViewModel DutyDotsBaseEditViewModel => App.Services.GetRequiredService<DutyDotsBaseEditViewModel>();
        public AccidentBaseViewModel AccidentBaseViewModel => App.Services.GetRequiredService<AccidentBaseViewModel>();
        public AccidentBaseEditViewModel AccidentBaseEditViewModel => App.Services.GetRequiredService<AccidentBaseEditViewModel>();
        public AuthorizationBaseViewModel AuthorizationBaseViewModel => App.Services.GetRequiredService<AuthorizationBaseViewModel>();
        public AccidentReportViewModel AccidentReportViewModel => App.Services.GetRequiredService<AccidentReportViewModel>();
        public IllegalReportViewModel IllegalReportViewModel => App.Services.GetRequiredService<IllegalReportViewModel>();
        public DutyReportViewModel DutyReportViewModel => App.Services.GetRequiredService<DutyReportViewModel>();
        public AccountingReportViewModel AccountingReportViewModel => App.Services.GetRequiredService<AccountingReportViewModel>();
        public LogBaseViewModel LogBaseViewModel => App.Services.GetRequiredService<LogBaseViewModel>();


        public MenuBaseViewModel MenuBaseViewModel => App.Services.GetRequiredService<MenuBaseViewModel>();
        


    }
}
