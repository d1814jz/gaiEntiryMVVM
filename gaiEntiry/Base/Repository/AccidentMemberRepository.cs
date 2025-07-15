using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace gaiEntiry.Base.Repository
{
    class AccidentMemberRepository : DbRepository<AccidentMember>
    {
        public override IQueryable<AccidentMember> Items => base.Items
            .Include(item => item.Auto)
            .Include(item => item.Driver)
            .Include(item => item.Accident)
            ;
        public AccidentMemberRepository(gaiEngEntities db) : base(db) { } 
    }
}
