using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace gaiEntiry.Base.Repository
{
    class AccountingRepository : DbRepository<Accounting>
    {
        public override IQueryable<Accounting> Items => base.Items
            .Include(item => item.Auto)
            .Include(item => item.Driver)
            .Include(item => item.Worker)          
            ;
        public AccountingRepository(gaiEngEntities db) : base(db) { }
    }
}
