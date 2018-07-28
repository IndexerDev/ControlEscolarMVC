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
        public PersonalTipoRepo(DbContext context) : base(context)
        {
        }

        private ControlEscolarContext CeContext => Context as ControlEscolarContext;
    }
}
