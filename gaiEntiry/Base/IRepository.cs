using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gaiEntiry.Base
{
    interface IRepository<T> where T : class, new()
    {
        IQueryable<T> Items { get; }

        T Get(int id);

        T Add(T item);

        void Update(T item);

        void Remove(int id);
    }
}
