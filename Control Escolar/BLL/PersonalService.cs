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
    public class PersonalService : IPersonalService
    {
        private readonly ControlEscolarContext _context = new ControlEscolarContext();
        private readonly PersonalRepository _personal;

        public PersonalService()
        {            
            _personal = new PersonalRepository(_context);
        }

        public Personal GetPersonal(int id) => _personal.Get(id);

        public IEnumerable<Personal> GetPersonalConSueldos()
        {                       
            return _personal.GetPersonalConSueldos();
        }

        public void Add(Personal personal)
        {            
            _personal.Add(personal);
            _personal.Save();            
        }
        
        public bool Delete(int id)
        {
            var personalEliminar = _personal.Get(id);
            if (personalEliminar == null)
                return false;

            _personal.Remove(personalEliminar);
            _personal.Save();

            return true;
        }

    }
}
