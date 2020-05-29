using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ClassEX3.Models;
namespace ClassEX3.Controllers
{
    public class FlightController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<Flight> Get()
        {
            return Flight.list;
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public bool Post([FromBody]Flight flight)
        {
           if(Flight.checkIfExist(flight))
            {
                return false;
            }
            else
            {
                flight.insert();
                return true;
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