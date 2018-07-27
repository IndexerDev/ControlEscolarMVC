using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class PersonalRepository : Repository<Personal>, IPersonalRepository
    {
        public PersonalRepository(ControlEscolarContext context) 
            : base(context)
        { }

        public IEnumerable<Personal> GetPersonalConSueldos()
        {
            return ControlEscolarContext.Personal
                .Include(s => s.PersonalSueldos);
        }
        

        public ControlEscolarContext ControlEscolarContext => Context as ControlEscolarContext;

        

    }
}
