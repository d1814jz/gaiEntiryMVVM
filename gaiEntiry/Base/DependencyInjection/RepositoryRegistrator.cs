using gaiEntiry.Base.Repository;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gaiEntiry.Base.DependencyInjection
{
    public static class RepositoryRegistrator
    {
        public static IServiceCollection AddRepositoriesInProject(this IServiceCollection services) => services
            .AddTransient<IRepository<Auto>, DbRepository<Auto>>();
        //.AddTransient<IRepository<Auto>, AutosRepository>();
    }
}
