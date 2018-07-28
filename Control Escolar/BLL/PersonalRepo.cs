using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class PersonalRepo : Repository<Personal>, IPersonalRepo
    {
        public PersonalRepo(ControlEscolarContext context) 
            : base(context)
        {
        }

        public IEnumerable<Personal> GetPersonalConSueldos()
        {            
            return CeContext.Personal
                .Include(t => t.PersonalTipos);
            
        }

        /// <summary>
        /// En proceso de implementación
        /// Regresa una lista con proyección
        /// </summary>        
        /// <returns></returns>
        //public List<T> GetPersonalTipoSueldo<T>()
        //{
        //    var joinResult = CeContext.Personal.GroupJoin(CeContext.PersonalSueldos, p => p.IdPersonal,
        //            s => s.IdPersonal,
        //            (personal, sueldo) => new
        //            {
        //                personal,
        //                sueldo
        //            })
        //        .SelectMany(temp => temp.sueldo.DefaultIfEmpty(),
        //            (temp, sueldo) => new
        //            {
        //                temp.personal.IdPersonal,
        //                temp.personal.Nombre,
        //                temp.personal.Apellidos,
        //                temp.personal.CorreoElectronico,
        //                Puesto = temp.personal.PersonalTipos.PersonalTipoDescripcion,
        //                temp.personal.FechaNacimiento,
        //                temp.personal.NumeroControl,
        //                temp.personal.Estatus,
        //                Sueldo = sueldo == null ? 0 : sueldo.Sueldo
        //            }).AsEnumerable();            

        //    return (List<T>) joinResult;
        //}

        public ControlEscolarContext CeContext => Context as ControlEscolarContext;
    }
}
