using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface IRepository<Tentity> where Tentity : class
    {
        Tentity Get(int id);
        IEnumerable<Tentity> GetAll();
        IEnumerable<Tentity> Find(Expression<Func<Tentity, bool>> predicate);

        void Add(Tentity entity);

        void Update(Tentity entity);

        void Remove(Tentity entity);

        
    }
}
