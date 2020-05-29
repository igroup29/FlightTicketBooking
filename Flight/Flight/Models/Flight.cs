using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClassEX3.Models
{
    public class Flight
    {
        string from;
        string to;
        string[] stops;
        string departureTime;
        string arrivalTime;
        string airlineName;        
        string price;     
        static public List<Flight> list = new List<Flight>();
        

        //No Arguments Constructor
        public Flight()
        {



        }


        public Flight(string from, string to, string[] stops, string departureTime, string arrivalTime, string airlineName, string price)
        {
            this.From = from;
            this.To = to;
            this.Stops = stops;
            this.DepartureTime = departureTime;
            this.ArrivalTime = arrivalTime;
            this.AirlineName = airlineName;
            this.Price = price;
        }

        public static bool checkIfExist(Flight flight)
        {
            bool flag = false;
           

            foreach (Flight item in list) // Loop through List with foreach
            {
                if (item.AirlineName == flight.AirlineName && item.ArrivalTime == flight.ArrivalTime)
                {
                    if (item.From == flight.From && item.Price == flight.Price)
                    {
                        if (item.To == flight.To && item.DepartureTime == flight.DepartureTime)
                        {
                            for (int i = 0; i < item.stops.Length; i++)
                            {
                                if (item.stops[i] != flight.stops[i])
                                {
                                    break;
                                }
                            }
                            return true;
                        }
                    }
                }         
            }

            return flag;
          
        }

        public string From { get => from; set => from = value; }
        public string To { get => to; set => to = value; }
        public string[] Stops { get => stops; set => stops = value; }
        public string DepartureTime { get => departureTime; set => departureTime = value; }
        public string ArrivalTime { get => arrivalTime; set => arrivalTime = value; }
        public string AirlineName { get => airlineName; set => airlineName = value; }
        public string Price { get => price; set => price = value; }


        public int insert() {

            list.Add(this);
            return 1;
        }
    }
}