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
        

        public List<int> ProcesoRegistroPersonal(Personal personal)
        {
            var validaciones = new List<int>();

            if (GetCorreoElectronico(personal.CorreoElectronico))
                validaciones.Add(Enum.Validaciones.Correo.GetHashCode());
                        
            if (GetNumeroControl(personal.NumeroControl))
                validaciones.Add(Enum.Validaciones.NumeroControl.GetHashCode());

            var isPersonalLaboral = CeContext.PersonalTipos.Where(pt => pt.IdPersonalTipo == personal.IdPersonalTipo)
                .Single().IsPersonalLaboral;

            if (validaciones.Count == 0)
            {
                validaciones.Add(Enum.Validaciones.Exito.GetHashCode());

                if (isPersonalLaboral)
                {
                    var personalSueldo = new PersonalSueldo
                    {
                        IdPersonal = personal.IdPersonal,
                        Sueldo = personal.PersonalSueldos.Sueldo
                    };

                    CeContext.Personal.Add(personal);
                    CeContext.PersonalSueldos.Add(personalSueldo);
                    CeContext.SaveChanges();
                }
                else
                {
                    CeContext.Personal.Add(personal);
                    CeContext.SaveChanges();
                }
            }
            
            return validaciones;
        }



        private bool GetCorreoElectronico(string correoElectronico)
        {
            var resultado = CeContext.Personal.SingleOrDefault(c => c.CorreoElectronico == correoElectronico);
            
            return resultado != null;
        }

        private bool GetNumeroControl(string numeroControl)
        {
            var resultado = CeContext.Personal.SingleOrDefault(c => c.NumeroControl == numeroControl);

            return resultado != null;
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
