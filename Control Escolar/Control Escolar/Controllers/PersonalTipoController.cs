using AutoMapper;
using BLL;
using Control_Escolar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DAL;

namespace Control_Escolar.Controllers
{
    [RoutePrefix("api/personaltipo")]
    public class PersonalTipoController : ApiController
    {
        private readonly IPersonalTipoRepo _repo;
        private readonly IMapper _mapper;

        public PersonalTipoController(IPersonalTipoRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }


        [HttpPost]
        public IHttpActionResult Add(PersonalTipoBaseDto personalTipo)
        {
            if (!ModelState.IsValid)
                return BadRequest("El formulario introducido es incorrecto");

            var tipo = _mapper.Map<PersonalTipoBaseDto, PersonalTipos>(personalTipo);

            _repo.Add(tipo);
            _repo.Save();

            return StatusCode(HttpStatusCode.NoContent);
        }


        [HttpGet]
        [Route("{id}")]
        public IHttpActionResult Get(int id)
        {
            var tipo = _repo.Get(id);
            if (tipo == null)
                return NotFound();

            var personalModel = _mapper.Map<PersonalTipos, PersonalTipoBaseDto>(tipo);

            return Ok(personalModel);
        }

        [HttpGet]
        public IHttpActionResult GetAll()
        {
            var personalTipo = _repo.GetAll();
            if (personalTipo == null)
                return NotFound();

            var personalModel = _mapper.Map<IEnumerable<PersonalTipos>, IEnumerable<PersonalTipoBaseDto>>(personalTipo);

            return Ok(personalModel);
        }

        [HttpPut]
        public IHttpActionResult Update(PersonalTipoBaseUpdateDto tipoDto)
        {
            if (!ModelState.IsValid)
                return BadRequest("El formulario introducido es incorrecto");

            var tipo = _mapper.Map<PersonalTipoBaseUpdateDto, PersonalTipos>(tipoDto);

            var tipoToUpdate = _repo.SingleOrDefault(tipo.IdPersonalTipo);
            if (tipoToUpdate == null)
                return NotFound();

            tipoToUpdate.PersonalTipoDescripcion = tipoDto.PersonalTipoDescripcion;
            tipoToUpdate.IsPersonalLaboral = tipoDto.IsPersonalLaboral;
            tipoToUpdate.IdSueldosTabulacion = tipoDto.IdSueldosTabulacion;

            _repo.Save();

            return StatusCode(HttpStatusCode.NoContent);

        }

        [HttpDelete]
        [Route("{id}")]
        public IHttpActionResult Delete(int id)
        {
            var tipoToDelete = _repo.Get(id);
            if (tipoToDelete == null)
                return NotFound();

            _repo.Remove(tipoToDelete);
            _repo.Save();

            return StatusCode(HttpStatusCode.NoContent);
        }
        

    }
}
