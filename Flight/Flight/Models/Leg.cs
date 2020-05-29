using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClassEX3.Models
{
    public class Leg
    {
        private string legID;
        private string flightID;
        private string airlineID;
        private string airportFrom;
        private string airportTo;
        private string duration;
        private DateTime departure;
        private DateTime arrival;
        private int flight_no;
        private int legNum;

        //No Argument Constructor
        public Leg()
        {


        }

        public Leg(string legID, string flightID, string airlineID, string airportFrom, string airportTo, string duration, DateTime departure, DateTime arrival, int flight_no, int legNum)
        {
            LegID = legID;
            FlightID = flightID;
            AirlineID = airlineID;
            AirportFrom = airportFrom;
            AirportTo = airportTo;
            Duration = duration;
            Departure = departure;
            Arrival = arrival;
            Flight_no = flight_no;
            LegNum = legNum;
        }

        public int InsertLeg()
        {
            DBservices dbs = new DBservices();
            int numAffected = dbs.insertLeg(this);
            return numAffected;
        }

        public string LegID { get => legID; set => legID = value; }
        public string FlightID { get => flightID; set => flightID = value; }
        public string AirlineID { get => airlineID; set => airlineID = value; }
        public string AirportFrom { get => airportFrom; set => airportFrom = value; }
        public string AirportTo { get => airportTo; set => airportTo = value; }
        public string Duration { get => duration; set => duration = value; }
        public DateTime Departure { get => departure; set => departure = value; }
        public DateTime Arrival { get => arrival; set => arrival = value; }
        public int Flight_no { get => flight_no; set => flight_no = value; }
        public int LegNum { get => legNum; set => legNum = value; }
    }
}