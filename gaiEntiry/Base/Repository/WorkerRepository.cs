using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace gaiEntiry.Base.Repository
{
    class WorkerRepository : DbRepository<Worker>
    {
        public WorkerRepository(gaiEngEntities db) : base(db) { }
    }
}
