using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClassEX3.Models
{
    public class Airports
    {
        private string airportID;
        private string airportName;
        private string city;
        private string country;
        private float airportLong;
        private float airportLat;

        //No Argument Constructor 
        public Airports()
        {
        }

        public Airports(string airportID, string airportName, string city, string country, float airportLong, float airportLat)
        {
            AirportID = airportID;
            AirportName = airportName;
            City = city;
            Country = country;
            AirportLong = airportLong;
            AirportLat = airportLat;
        }

        public int InsertAirport()
        {
            DBservices dbs = new DBservices();
            int numAffected = dbs.insertAirport(this);
            return numAffected;
        }

        public string AirportID { get => airportID; set => airportID = value; }
        public string AirportName { get => airportName; set => airportName = value; }
        public string City { get => city; set => city = value; }
        public string Country { get => country; set => country = value; }
        public float AirportLong { get => airportLong; set => airportLong = value; }
        public float AirportLat { get => airportLat; set => airportLat = value; }
    }
}