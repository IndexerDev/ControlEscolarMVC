using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public interface IPersonalTipoRepo : IRepository<PersonalTipos>
    {
        /// <summary>
        /// Función que regresa un tipo de personal según identificador
        /// </summary>
        /// <param name="id">Identificador para realizar búsqueda en tipos de personal</param>
        /// <returns>Objeto del tipo de personal</returns>
        PersonalTipos SingleOrDefault(int id);

        /// <summary>
        /// Función que regresa una lista con los tipos de personal existentes
        /// </summary>
        /// <returns>Lista con tipos de personal existentes</returns>
        IEnumerable<PersonalTipos> GetPersonalConTabulacion();

    }
}
