using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace gaiEntiry.Base.Repository
{
    class DutyRepository : DbRepository<Duty>
    {
        public override IQueryable<Duty> Items => base.Items
            .Include(item => item.Worker)
            .Include(item => item.ServiceCar)
            .Include(item => item.DutyDots)
            ;
        public DutyRepository(gaiEngEntities db) : base(db) { }
    }
}
