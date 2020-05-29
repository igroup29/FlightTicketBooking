using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ClassEX3.Models;

namespace ClassEX3.Controllers
{
    public class AirlinesController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        // public void Post([FromBody]string value)
        public void Post([FromBody]Airlines[] airlines)
        {
            for (int i = 0; i < airlines.Length; i++)
            {
                airlines[i].InsertAirline();
            }  
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}