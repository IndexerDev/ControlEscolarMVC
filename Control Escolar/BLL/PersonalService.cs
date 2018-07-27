using System;
using DAL;
using System.Collections.Generic;
using System.Data;
using System.Linq;

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


        public Personal GetPersonal(int id)
        {
            return _personal.Get(id);
        } 


        public IEnumerable<Personal> GetPersonalConSueldos()
        {
            return _personal.GetPersonalConSueldos().ToList();
        }


        public IList<T> GetPersonalTipoSueldo<T>()
        {
            throw new NotImplementedException();
        }


        public void Add(Personal personal)
        {            
            _personal.Add(personal);
            _personal.Save();            
        }


        public void Update()
        {
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


        private bool BuscaCorreoElectronico(string correoElectronico)
        {            
            var objetosEncontrados =
                _personal.Find(personal => personal.CorreoElectronico == correoElectronico).ToList();

            return objetosEncontrados.Count != 0 ? true : false;
        }

    }
}
