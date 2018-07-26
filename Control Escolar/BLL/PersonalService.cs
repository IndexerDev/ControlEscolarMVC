using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class PersonalService
    {
        private readonly ControlEscolarContext _context = new ControlEscolarContext();
        private readonly PersonalRepository _personal;

        public PersonalService()
        {            
            _personal = new PersonalRepository(_context);
        }

        public Personal GetPersonal(int id) => _personal.Get(id);

        //public Personal GetPersonalAndSalary(int id)
        //{
            
            
            
        //}

    }
}
