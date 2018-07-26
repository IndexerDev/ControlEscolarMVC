using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class PersonalService
    {
        private readonly ControlEscolarContext _context;
        private readonly PersonalRepository _personal;

        public PersonalService()
        {
            _context = new ControlEscolarContext();
            _personal = new PersonalRepository(_context);
        }

        Personal GetPersonal(int id)
        {
            return _personal.Get(id);
            
        }
            
        
    }
}
