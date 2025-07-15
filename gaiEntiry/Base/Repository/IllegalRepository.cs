using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace gaiEntiry.Base.Repository
{
    class IllegalRepository : DbRepository<Illegal>
    {
        /*public override IQueryable<Book> Items => base.Items.Include(item => item.Category);

        public BooksRepository(BookinistDB db) : base(db) { }*/
        //public override IQueryable<Illegal> Items => _db.Illegal.Include(u => u.Auto).Include(u => u.Driver).Include(u => u.IllegalIllegalType);
        public override IQueryable<Illegal> Items => base.Items
            .Include(item => item.Auto)
            .Include(item => item.Driver)
            .Include(item => item.IllegalType)
            .Include(item => item.Duty)
            ;
        public IllegalRepository(gaiEngEntities db) : base(db) { }
    }
}
