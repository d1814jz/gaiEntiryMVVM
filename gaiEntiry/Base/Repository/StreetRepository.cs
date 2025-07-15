using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace gaiEntiry.Base.Repository
{
    class StreetRepository : DbRepository<Street>
    {
        public override IQueryable<Street> Items => base.Items
            .Include(item => item.District)
            ;
        public StreetRepository(gaiEngEntities db) : base(db) { }
    }
}
