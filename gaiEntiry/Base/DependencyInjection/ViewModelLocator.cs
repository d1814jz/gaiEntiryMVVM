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

        public MenuBaseViewModel MenuBaseViewModel => App.Services.GetRequiredService<MenuBaseViewModel>();


    }
}
