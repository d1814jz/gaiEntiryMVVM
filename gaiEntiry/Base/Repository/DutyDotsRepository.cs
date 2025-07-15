using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace gaiEntiry.Base.Repository
{
    class DutyDotsRepository : DbRepository<DutyDots>
    {
        public override IQueryable<DutyDots> Items => base.Items
            .Include(item => item.DutyDotsType)
            .Include(item => item.District)
            ;
        public DutyDotsRepository(gaiEngEntities db) : base(db) { }
    }
}
