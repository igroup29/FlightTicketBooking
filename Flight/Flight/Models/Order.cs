using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClassEX3.Models
{
    public class Order
    {

        private int id;
        private string airlineName;
        private string from;
        private string to;
        private DateTime departureTime;
        private DateTime arrivalTime;
        private double price;


        public Order()
        {



        }

        public Order(int id, string airlineName, string from, string to, DateTime departureTime, DateTime arrivalTime, double price)
        {
            Id = id;         
            From = from;
            To = to;
            DepartureTime = departureTime;
            ArrivalTime = arrivalTime;
            Price = price;      
        }

        public int Id { get => id; set => id = value; }
        public string AirlineName { get => airlineName; set => airlineName = value; }
        public string From { get => from; set => from = value; }
        public string To { get => to; set => to = value; }
        public DateTime DepartureTime { get => departureTime; set => departureTime = value; }
        public DateTime ArrivalTime { get => arrivalTime; set => arrivalTime = value; }
        public double Price { get => price; set => price = value; }

        public List<Flights> getAllOrders()
        {
            DBservices dbs = new DBservices();
            return dbs.getOrders();
        }
    }
}