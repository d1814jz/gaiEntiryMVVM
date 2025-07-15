using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace gaiEntiry.Base
{
    internal class DbRepository<T> : IRepository<T> where T : class, new()
    {
        public gaiEngEntities _db;
        public DbSet<T> _Set;

        public bool AutoSaveChanges { get; set; } = true;

        public DbRepository(gaiEngEntities db)
        {
            _db = db;
            _Set = db.Set<T>();
        }

        public virtual IQueryable<T> Items => _db.Set<T>();
        
        /*public async Task<T> AddAsync(T item, CancellationToken Cancel = default)
        {
            if (item is null) throw new ArgumentNullException(nameof(item));
            _db.Entry(item).State = EntityState.Added;
            if (AutoSaveChanges)
                await _db.SaveChangesAsync(Cancel).ConfigureAwait(false);
            return item;
        }*/

        public T Get(int id) => _Set.Find(id);
     
        public T Add(T item)
        {
            if (item is null) throw new ArgumentNullException(nameof(item));
            _db.Entry(item).State = EntityState.Added;
            if (AutoSaveChanges)
                _db.SaveChanges();
            return item;
        }



        public void Update(T item)
        {
            if (item is null) throw new ArgumentNullException(nameof(item));
            _db.Entry(item).State = EntityState.Modified;
            if (AutoSaveChanges)
                _db.SaveChanges();
        }


        public void Remove(int id)
        {
            var item = Get(id);
            _Set.Remove(item);
            //var item = _Set.Local.FirstOrDefault(i => i.Id == id) ?? new T { Id = id };

            if (AutoSaveChanges)
                _db.SaveChanges();
        }
    }
}
