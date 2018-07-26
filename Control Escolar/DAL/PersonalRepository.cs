using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class PersonalRepository : Repository<Personal>, IPersonalRepository
    {
        public PersonalRepository(ControlEscolarContext context) 
            : base(context)
        {

        }

        public IEnumerable<Personal> GetPersonalConSueldos()
        {
            throw new NotImplementedException();            
        }

        public ControlEscolarContext ControlEscolarContext { get; }
    }
}
