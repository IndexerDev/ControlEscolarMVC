using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface IPersonalRepository : IRepository<Personal>
    {
        IEnumerable<Personal> GetPersonalConSueldos();

    }
}
