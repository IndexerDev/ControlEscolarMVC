using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public interface IPersonalService
    {
        Personal GetPersonal(int id);

        IEnumerable<Personal> GetPersonalConSueldos();

        void Add(Personal personal);

        void Update();

        bool Delete(int id);

    }
}
