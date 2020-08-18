using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClassEX3.Models
{
    public class Tours
    {
        private int id;
        private string city;
        private string tourID;
        private string tourName;
        private string tourCategory;
        private string placeCategory;
        private float score;
        private float price;
        private string description;
        private string duration;
        private int transportation;
        private string currency;
        private string image;

        //No Argument Constructor
        public Tours(){}

        public Tours(int id, string city, string tourID, string tourName, string tourCategory, string placeCategory, float score, string description, string duration, int transportation, float price, string currency, string image)
        {
            this.Id = id;
            this.City = city;
            this.TourID = tourID;
            this.TourName = tourName;
            this.TourCategory = tourCategory;
            this.PlaceCategory = placeCategory;
            this.Score = score;
            this.Description = description;
            this.Duration = duration;
            this.Transportation = transportation;
            this.Price = price;
            this.Currency = currency;
            this.Image = image;
        }

        public int Id { get => id; set => id = value; }
        public string City { get => city; set => city = value; }
        public string TourID { get => tourID; set => tourID = value; }
        public string TourName { get => tourName; set => tourName = value; }
        public string TourCategory { get => tourCategory; set => tourCategory = value; }
        public string PlaceCategory { get => placeCategory; set => placeCategory = value; }
        public float Score { get => score; set => score = value; }
        public string Description { get => description; set => description = value; }
        public string Duration { get => duration; set => duration = value; }
        public int Transportation { get => transportation; set => transportation = value; }
        public float Price { get => price; set => price = value; }
        public string Currency { get => currency; set => currency = value; }
        public string Image { get => image; set => image = value; }

        public int InsertTour()
        {
            DBservices dbs = new DBservices();
            int numAffected = dbs.InsertTour(this);
            return numAffected;
        }

    }
}