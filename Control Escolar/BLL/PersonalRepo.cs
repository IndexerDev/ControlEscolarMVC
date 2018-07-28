using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using System.Data.Entity.Migrations;

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
        

        public List<int> ProcesoRegistroPersonal(Personal personal, decimal sueldo)
        {
            var validaciones = new List<int>();            
                                        
            if (GetCorreoElectronico(personal.CorreoElectronico))
                validaciones.Add(Enums.Validaciones.Correo.GetHashCode());
                        
            if (GetNumeroControl(personal.NumeroControl))
                validaciones.Add(Enums.Validaciones.NumeroControl.GetHashCode());

            var isPersonalLaboral = CeContext.PersonalTipos.Where(pt => pt.IdPersonalTipo == personal.IdPersonalTipo)
                .Single().IsPersonalLaboral;

            if (validaciones.Count == 0)
            {
                validaciones.Add(Enums.Validaciones.Exito.GetHashCode());

                if (isPersonalLaboral)
                {                    
                    CeContext.Personal.Add(personal);
                    CeContext.SaveChanges();

                    var personalSueldo = new PersonalSueldo
                    {
                        IdPersonal = personal.IdPersonal,
                        Sueldo = sueldo
                    };
                    
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


        public List<int> ProcesoActualizacionPersonal(Personal personal, decimal sueldo)
        {
            var validaciones = new List<int>();

            var personalUpdate = CeContext.Personal.SingleOrDefault(p => p.IdPersonal == personal.IdPersonal);

            if (GetCorreoElectronico(personal.CorreoElectronico))
                if (personalUpdate.CorreoElectronico == personal.CorreoElectronico)
                    validaciones.Add(Enums.Validaciones.Correo.GetHashCode());

            if (GetNumeroControl(personal.NumeroControl))
                if (personalUpdate.NumeroControl == personal.NumeroControl)
                    validaciones.Add(Enums.Validaciones.NumeroControl.GetHashCode());

            var isPersonalLaboral = CeContext.PersonalTipos.Where(pt => pt.IdPersonalTipo == personal.IdPersonalTipo)
                .Single().IsPersonalLaboral;

            if (validaciones.Count == 0)
            {
                validaciones.Add(Enums.Validaciones.Exito.GetHashCode());
                
                personalUpdate.Nombre = personal.Nombre;
                personalUpdate.Apellidos = personal.Apellidos;
                personalUpdate.CorreoElectronico = personal.CorreoElectronico;
                personalUpdate.IdPersonalTipo = personal.IdPersonalTipo;
                personalUpdate.FechaNacimiento = personal.FechaNacimiento;
                personalUpdate.NumeroControl = personal.NumeroControl;
                personalUpdate.Estatus = personal.Estatus;

                CeContext.SaveChanges();

                if (isPersonalLaboral)
                {
                    var personalSueldo = GetPersonalSueldo(personal.IdPersonal);
                    personalSueldo.Sueldo = sueldo;
                    
                    CeContext.SaveChanges();
                }
              
            }

            return validaciones;
        }

        public PersonalSueldo GetPersonalSueldo(int id)
        {
            var resultado = CeContext.PersonalSueldos.SingleOrDefault(p => p.IdPersonal == id);

            return resultado;
        }

        public void RemoveSueldo(PersonalSueldo personalSueldo)
        {
            CeContext.PersonalSueldos.Remove(personalSueldo);
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
        

        public ControlEscolarContext CeContext => Context as ControlEscolarContext;


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


    }
}
