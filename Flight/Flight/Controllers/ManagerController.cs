using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ClassEX3.Models;


namespace ClassEX3.Controllers
{
    public class ManagerController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<Flights> Get()
        {
            Flights order = new Flights();
            return order.getAllOrders();
        }
       
        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public Manager Post([FromBody]Manager Man)
        {
            if (Man.checkManager())
            {
                return Man;

            }
            return null;
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