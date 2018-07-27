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
        private readonly IPersonalService _personal;
        private readonly IMapper _mapper;

        public PersonalController(IPersonalService personal, IMapper mapper)
        {     
            _personal = personal;
            _mapper = mapper;
        } 
           

        [HttpGet]
        [Route("{id}")]
        public IHttpActionResult Get(int id)
        {
            var personal = _personal.GetPersonal(id);
            if (personal == null)
                return NotFound();

            var personalModel = _mapper.Map<Personal, PersonalDto>(personal);            

            return Ok(personalModel);
        }


        [HttpGet]
        public IHttpActionResult GetAll()
        {
            var personalSueldos = _personal.GetPersonalConSueldos();
            if (personalSueldos == null)
                return NotFound();

            var personalModel = _mapper.Map<IEnumerable<Personal>, IEnumerable<PersonalDto>>(personalSueldos);           

            return Ok(personalModel);
        }


        [HttpPost]
        public IHttpActionResult Add(PersonalDto personalDto)
        {
            if (personalDto == null)
                return BadRequest("Error al insertar, corriga la información");

            var personalAdd =_mapper.Map<PersonalDto, Personal>(personalDto);
            
            _personal.Add(personalAdd);

            return StatusCode(HttpStatusCode.NoContent);
        }


        [HttpPut]
        public IHttpActionResult Update(PersonalDto personalDto)
        {
            if (personalDto == null)
                return BadRequest("Introduzca la información de forma correcta");

            var personal = _personal.GetPersonal(personalDto.IdPersonal);
            if (personal == null)
                return BadRequest("Personal no existe");

            _mapper.Map(personalDto, personal);            

            _personal.Update();

            return StatusCode(HttpStatusCode.NoContent);
        }


        [HttpDelete]
        [Route("{id}")]
        public IHttpActionResult Delete(int id)
        {            
            if (!_personal.Delete(id))
                return NotFound();

            return StatusCode(HttpStatusCode.NoContent);
        }

    }
}
