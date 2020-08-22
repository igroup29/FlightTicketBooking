using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ClassEX3.Models;

namespace ClassEX3.Controllers
{
    public class ToursController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<Tours> Get()
        {
            Tours tour = new Tours();
            return tour.getAllTour();
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public List<Tours> Post([FromBody]Tours tour)
        {
            Tours t = new Tours();
            t.InsertTour(tour);
            return null;
        }

        // PUT api/<controller>/5
        public List<Tours> Put(Tours tour)
        {
            Tours t = new Tours();
            t.UpdateTour(tour);
            return t.getAllTour();
        }

        // DELETE api/<controller>/5
        public List<Tours> Delete(Tours tour)
        {
            Tours t = new Tours();
            t.deleteTour(tour.Id);
            return t.getAllTour();
        }
    }
}