using gaiEntiry.Base.Repository;
using gaiEntiry.Base.Service;
using gaiEntiry.Base.ViewsModel;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gaiEntiry.Base.DependencyInjection
{
    static class ServicesRegistrator
    {
        public static IServiceCollection AddServices(this IServiceCollection services) => services
           .AddTransient<IUserDialog, UserDialogService>()
           .AddScoped<AutoBaseViewModel>()
           .AddViewModels()
           .AddRepositoriesInProject();

    }
}
