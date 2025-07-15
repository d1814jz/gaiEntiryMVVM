using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace gaiEntiry.Base.Repository
{
    class AccidentRepository : DbRepository<Accident>
    {
        public override IQueryable<Accident> Items => base.Items
            .Include(item => item.Street)
            .Include(item => item.Worker)
            ;
        public AccidentRepository(gaiEngEntities db) : base(db) { }
    }
}
