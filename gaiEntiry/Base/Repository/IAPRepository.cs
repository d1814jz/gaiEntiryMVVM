using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace gaiEntiry.Base.Repository
{
    class IAPRepository : DbRepository<IAP>
    {
        public override IQueryable<IAP> Items => base.Items
            .Include(item => item.TypesOfIAP)
            .Include(item => item.Worker)
            ;
        public IAPRepository(gaiEngEntities db) : base(db) { }
    }
}
