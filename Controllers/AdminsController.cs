using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestAPI_ARMAN.Models;
using RestAPI_ARMAN.Processors;

namespace RestAPI_ARMAN.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminsController : ControllerBase
    {
        // GET: api/Admins
        [HttpGet]
        public JsonResult Get(string Username, string Password)
        {
            return new AdminProcessor().LoginAdmin(Username, Password);
        }

        //// GET: api/Admins/5
        //[HttpGet("{id}", Name = "Get")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST: api/Admins
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Admins/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
