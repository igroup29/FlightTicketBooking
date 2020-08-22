using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClassEX3.Models
{
    public class Airlines
    {
        private string airlineID;
        private string airlineName;
        //No Argument Constructor
        public Airlines()
        {

        }

        public Airlines(string airlineID, string airlineName)
        {
            AirlineID = airlineID;
            AirlineName = airlineName;
        }

        public int InsertAirline()
        {
            DBservices dbs = new DBservices();
            int numAffected = dbs.insertAirlines(this);
            return numAffected;
        }

        public List<Airlines> getAllAirlines()
        {
            DBservices dbs = new DBservices();
            return dbs.getAllAirlines();
        }

        public string AirlineID { get => airlineID; set => airlineID = value; }
        public string AirlineName { get => airlineName; set => airlineName = value; }
    }
}