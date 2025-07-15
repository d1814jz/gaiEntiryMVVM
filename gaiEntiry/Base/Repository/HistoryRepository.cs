using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace gaiEntiry.Base.Repository
{
    class HistoryRepository : DbRepository<History>
    {
        public override IQueryable<History> Items => base.Items
            .Include(item => item.Worker)
            .Include(item => item.Rank)
            .Include(item => item.Position)
            ;
        public HistoryRepository(gaiEngEntities db) : base(db) { }
    }
}
