using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DAL;
using BLL;

namespace Control_Escolar.Controllers
{
    [RoutePrefix("api/personal")]
    public class PersonalController : ApiController
    {
        private readonly ControlEscolarContext _context;
        private readonly PersonalRepository _personal;

        public PersonalController(ControlEscolarContext context)
        {
            _context = new ControlEscolarContext();
            _personal = new PersonalRepository(_context);
        }

        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var personal = _personal.Get(id);

            return Ok(personal);
        }

    }
}
