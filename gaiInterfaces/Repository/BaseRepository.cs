using gaiEntiry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gaiInterfaces.Repository
{
    class BaseRepository<T> : IRepository<T> where T: class, new()
    {
        private readonly gaiEngEntities _db;
        private readonly DbSet<T> _Set;
    }
}
