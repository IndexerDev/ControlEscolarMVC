using System;
using System.Collections.Generic;
using System.EnterpriseServices;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BLL;
using Control_Escolar.Models;

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

    }
}
