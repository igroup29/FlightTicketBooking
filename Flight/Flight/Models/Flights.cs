using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClassEX3.Models
{
    public class Flights
    {
        private string flightID;
        private string airportFrom;
        private string airportTo;
        private float price;
        private string duration;
        private DateTime departure;
        private DateTime arrival;
        private Leg[] legs;
 

        //No Arguments Constructor
        public Flights()
        {



        }
        public Flights(string flightID, string airportFrom, string airportTo, float price, string duration, DateTime departure, DateTime arrival,Leg[] legs)
        {
        
            FlightID = flightID;
            AirportFrom = airportFrom;
            AirportTo = airportTo;
            Price = price;
            Duration = duration;
            Departure = departure;
            Arrival = arrival;
            Legs = legs;
        }

        public int InsertFlight()
        {
            DBservices dbs = new DBservices();
           
            int numAffected = dbs.insertFlight(this);
            return numAffected;
        }

        public int InsertFlightLegs()
        {
            DBservices dbs = new DBservices();
            int numAffected = 0;
            Leg[] thisLegs = this.Legs;
            for (int i = 0; i < thisLegs.Length; i++)
            {
                numAffected += dbs.insertLeg(thisLegs[i]);
            }
            return numAffected;
        }

        public string FlightID { get => flightID; set => flightID = value; }
        public string AirportFrom { get => airportFrom; set => airportFrom = value; }
        public string AirportTo { get => airportTo; set => airportTo = value; }
        public float Price { get => price; set => price = value; }
        public string Duration { get => duration; set => duration = value; }
        public DateTime Departure { get => departure; set => departure = value; }
        public DateTime Arrival { get => arrival; set => arrival = value; }
        public Leg[] Legs { get => legs; set => legs = value; }
    }
}