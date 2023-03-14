using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gaiEntiry.Base
{
    class AppSettings
    {
        public static IConfiguration Configuration { get; set; }
        public static string ConnectionString { get; set; }
    }
}
