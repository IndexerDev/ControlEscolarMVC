using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public interface IPersonalRepo : IRepository<Personal>
    {
        IEnumerable<Personal> GetPersonalConSueldos();        

        List<int> ProcesoRegistroPersonal(Personal personal, decimal sueldo);

        List<int> ProcesoActualizacionPersonal(Personal personal, decimal sueldo);

        PersonalSueldo GetPersonalSueldo(int id);

        void RemoveSueldo(PersonalSueldo personalSueldo);


    }
}
