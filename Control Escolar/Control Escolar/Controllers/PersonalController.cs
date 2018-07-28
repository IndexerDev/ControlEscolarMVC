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
using AutoMapper;

namespace Control_Escolar.Controllers
{
    [RoutePrefix("api/personal")]
    public class PersonalController : ApiController
    {                
        private readonly IPersonalRepo _repo;
        private readonly IMapper _mapper;
        
        public PersonalController(IPersonalRepo repo , IMapper mapper)
        {                 
            _repo = repo;
            _mapper = mapper;
        } 
           

        [HttpGet]
        [Route("{id}")]
        public IHttpActionResult Get(int id)
        {
            var personal = _repo.Get(id);
            if (personal == null)
                return NotFound();
            
            var personalModel = _mapper.Map<Personal, PersonalDto>(personal);

            return Ok(personalModel);
        }


        [HttpGet]
        public IHttpActionResult GetAll()
        {
            var personalSueldos = _repo.GetPersonalConSueldos();
            if (personalSueldos == null)
                return NotFound();
            
            var personalModel = _mapper.Map<IEnumerable<Personal>, IEnumerable<PersonalDto>>(personalSueldos);           

            return Ok(personalModel);
        }


        [HttpPost]
        public IHttpActionResult Add(PersonalDto personalDto)
        {
            if (!ModelState.IsValid)
                return BadRequest("El formato introducido es incorrecto");

            var personalToAdd =_mapper.Map<PersonalDto, Personal>(personalDto);

            var resultado = new List<int>();
            resultado = _repo.ProcesoRegistroPersonal(personalToAdd, personalDto.PersonalSueldo);

            if (resultado.Contains(Enums.Validaciones.Correo.GetHashCode()))
                return BadRequest("El Correo Electrónico ya existe");

            if (resultado.Contains(Enums.Validaciones.NumeroControl.GetHashCode()))
                return BadRequest("El Número de Control ya existe");

            return StatusCode(HttpStatusCode.NoContent);
        }


        [HttpPut]
        public IHttpActionResult Update(PersonalUpdateDto personalDto)
        {
            if (!ModelState.IsValid)
                return BadRequest("Introduzca la información de forma correcta");

            var personalToUpdate = _mapper.Map<PersonalUpdateDto, Personal>(personalDto);            

            var resultado = new List<int>();
            resultado = _repo.ProcesoActualizacionPersonal(personalToUpdate, personalDto.PersonalSueldo);

            if (resultado.Contains(Enums.Validaciones.Correo.GetHashCode()))
                return BadRequest("El Correo Electrónico ya existe");

            if (resultado.Contains(Enums.Validaciones.NumeroControl.GetHashCode()))
                return BadRequest("El Número de Control ya existe");

            return StatusCode(HttpStatusCode.NoContent);
        }


        [HttpDelete]
        [Route("{id}")]
        public IHttpActionResult Delete(int id)
        {            
            var personalEliminar = _repo.Get(id);
            if (personalEliminar == null)
                return NotFound();

            var personalSueldo = _repo.GetPersonalSueldo(id);

            if (personalSueldo != null)
                _repo.RemoveSueldo(personalSueldo);

            _repo.Remove(personalEliminar);
            _repo.Save();

            return StatusCode(HttpStatusCode.NoContent);
        }

    }
}
