using AutoMapper;
using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Control_Escolar.Controllers
{
    [RoutePrefix("api/personalTipo")]
    public class PersonalTipoController : ApiController
    {
        private readonly IPersonalTipoRepo _repo;
        private readonly IMapper _mapper;

        public PersonalTipoController(IPersonalTipoRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet]
        public IHttpActionResult Get()
        {
            return Ok();
        }



    }
}
