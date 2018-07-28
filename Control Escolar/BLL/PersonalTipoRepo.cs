using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class PersonalTipoRepo : Repository<PersonalTipos>, IPersonalTipoRepo
    {
        public PersonalTipoRepo(ControlEscolarContext context) : base(context)
        {
        }


        public PersonalTipos SingleOrDefault(int id)
        {
            var personalTipo = CeContext.PersonalTipos.SingleOrDefault(t => t.IdPersonalTipo == id);
            if (personalTipo == null)
                return null;

            return personalTipo;
        }

        public IEnumerable<PersonalTipos> GetPersonalConTabulacion()
        {
            var personalTipo = CeContext.PersonalTipos.Include(t => t.SueldosTabulacion);

            return personalTipo;
        }

        private ControlEscolarContext CeContext => Context as ControlEscolarContext;

        
    }
}
