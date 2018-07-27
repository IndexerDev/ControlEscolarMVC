using System;
using System.Collections.Generic;
using System.EnterpriseServices;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Web.Http;
using BLL;
using Control_Escolar.Models;
using DAL;

namespace Control_Escolar.Controllers
{
    [RoutePrefix("api/personal")]
    public class PersonalController : ApiController
    {        
        private readonly PersonalService _personal;
        

        public PersonalController() => _personal = new PersonalService();

        [HttpGet]
        [Route("{id}")]
        public IHttpActionResult Get(int id)
        {

            var personal = _personal.GetPersonal(id);
            if (personal == null)
                return NotFound();

            var personalModel = new PersonalModel
            {
                IdPersonal = personal.IdPersonal,
                Nombre = personal.Nombre,
                Apellidos = personal.Apellidos,
                CorreoElectronico = personal.CorreoElectronico,
                Estatus = personal.Estatus,
                FechaNacimiento = personal.FechaNacimiento,                
                NumeroControl = personal.NumeroControl
            };

            return Ok(personalModel);
        }

        [HttpGet]
        public IHttpActionResult GetAll()
        {
            var personalSueldos = _personal.GerPersonalConSueldos();
            if (personalSueldos == null)
                return NotFound();

            var personalModel = new List<PersonalModel>();
            foreach (var personalSueldo in personalSueldos)
            {
                var model = new PersonalModel
                {
                    IdPersonal = personalSueldo.IdPersonal,
                    Nombre = personalSueldo.Nombre,
                    Apellidos = personalSueldo.Apellidos,
                    CorreoElectronico = personalSueldo.CorreoElectronico,
                    FechaNacimiento = personalSueldo.FechaNacimiento,
                    Estatus = personalSueldo.Estatus,                    
                    NumeroControl = personalSueldo.NumeroControl,
                    //PersonalSueldo = personalSueldo.PersonalSueldos.Sueldo
                };

                personalModel.Add(model);
            }

            return Ok(personalModel);
        }

        [HttpPost]
        public IHttpActionResult Add(PersonalModel personalModel)
        {
            if (!ModelState.IsValid)
                return BadRequest("Error al insertar, corriga la información");
            
            var personal = new Personal();
            personal.Nombre = personalModel.Nombre;
            personal.Apellidos = personalModel.Apellidos;
            personal.CorreoElectronico = personalModel.CorreoElectronico;
            personal.FechaNacimiento = personalModel.FechaNacimiento;
            personal.Estatus = personalModel.Estatus;
            personal.NumeroControl = personalModel.NumeroControl;
            personal.IdPersonalTipo = personalModel.IdPersonalTipo;
            



            //var personal = new Personal
            //{
            //    Nombre = personalModel.Nombre,
            //    Apellidos = personalModel.Apellidos,
            //    CorreoElectronico = personalModel.CorreoElectronico,
            //    FechaNacimiento = personalModel.FechaNacimiento,
            //    Estatus = personalModel.Estatus,
            //    NumeroControl = personalModel.NumeroControl,
            //    IdPersonalTipo = personalModel.IdPersonalTipo,
            //    PersonalSueldos = {Sueldo = personalModel.PersonalSueldo}
            //};

            _personal.Add(personal);

            return StatusCode(HttpStatusCode.NoContent);
        }

    }
}
