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
        /// <summary>
        /// Función que regresa una lista de Personal existente
        /// </summary>
        /// <returns>Lista de personal relacionando el salario 
        /// en caso de aplicar según el tipo de personal</returns>
        IEnumerable<Personal> GetPersonalConSueldos();

        /// <summary>
        /// Función que procesa el alta de personal. 
        /// Valida que el correo electrónico no exista además del número de control
        /// Valida que el tipo de personal ingresado sea del tipo laboral o alumnado
        /// y según el caso registra o no el salario
        /// <param name="personal">Objeto de tipo personal que incluye identificadores 
        /// hacia el tipo de personal</param>
        /// <param name="sueldo">En caso de ser un objeto de tipo PersonalLaboral
        /// este parámetro es persistido en tabla PersonalSueldos</param>
        /// <returns>Lista resultante después de validación
        /// Las opciones posibles de regreso son
        /// 1 en caso de existir el correo electrónico (enumerador correo)
        /// 2 en caso de existir el número de control (enumerador numeroControl
        /// 0 en caso de ser exitosa la validación y persistir(enumerador exito)</returns>
        List<int> ProcesoRegistroPersonal(Personal personal, decimal sueldo);

        /// <summary>
        /// Función que actualiza un objeto tipo Personal en la base de datos
        /// </summary>
        /// <param name="personal">Objeto de tipo personal que incluye identificadores 
        /// hacia el tipo de personal</param>
        /// <param name="sueldo">En caso de ser un objeto de tipo PersonalLaboral
        /// este parámetro es actualizado en tabla PersonalSueldos</param>
        /// <returns>Lista resultante después de validación
        /// Las opciones posibles de regreso son:
        /// 1 en caso de existir el correo electrónico (enumerador correo)
        /// 2 en caso de existir el número de control (enumerador numeroControl
        /// 0 en caso de ser exitosa la validación y persistir (enumerador exito)</returns>
        List<int> ProcesoActualizacionPersonal(Personal personal, decimal sueldo);

        /// <summary>
        /// Función que regresa un objeto con la información del sueldo según personal dado
        /// </summary>
        /// <param name="id">Identicador para realizar la búsqueda del objeto</param>
        /// <returns>Un objeto con la información del sueldo</returns>
        PersonalSueldo GetPersonalSueldo(int id);

        /// <summary>
        /// Función que elimina un registro con información del sueldo de un empleado
        /// </summary>
        /// <param name="personalSueldo">Objeto con información del sueldo 
        /// asignado a un empleado</param>
        void RemoveSueldo(PersonalSueldo personalSueldo);


    }
}
