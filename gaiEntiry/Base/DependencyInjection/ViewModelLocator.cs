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
    }
}
