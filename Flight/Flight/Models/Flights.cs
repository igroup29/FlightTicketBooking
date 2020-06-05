using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClassEX3.Models
{
    public class Flights
    {
        private int orderID;
        private string name;
        private string email;
        private string flightID;
        private string airlineName;
        private string airportFrom;
        private string airportTo;
        private double price;
        private string duration;
        private DateTime departure;
        private DateTime arrival;
        private Leg[] legs;
 

        //No Arguments Constructor
        public Flights()
        {



        }

        public Flights(int orderID, string name, string email, string flightID, string airlineName, string airportFrom, string airportTo, double price, string duration, DateTime departure, DateTime arrival, Leg[] legs)
        {
            OrderID = orderID;
            Name = name;
            Email = email;
            FlightID = flightID;
            AirlineName = airlineName;
            AirportFrom = airportFrom;
            AirportTo = airportTo;
            Price = price;
            Duration = duration;
            Departure = departure;
            Arrival = arrival;
            Legs = legs;
        }
        public int OrderID { get => orderID; set => orderID = value; }
        public string Name { get => name; set => name = value; }
        public string Email { get => email; set => email = value; }
        public string FlightID { get => flightID; set => flightID = value; }
        public string AirportFrom { get => airportFrom; set => airportFrom = value; }
        public string AirportTo { get => airportTo; set => airportTo = value; }
        public double Price { get => price; set => price = value; }
        public string Duration { get => duration; set => duration = value; }
        public DateTime Departure { get => departure; set => departure = value; }
        public DateTime Arrival { get => arrival; set => arrival = value; }
        public Leg[] Legs { get => legs; set => legs = value; }
        public string AirlineName { get => airlineName; set => airlineName = value; }

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
        public List<Flights> getAllOrders()
        {
            DBservices dbs = new DBservices();
            return dbs.getOrders();
        }

    }
}