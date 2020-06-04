using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Web;

namespace ClassEX3.Models
{
    public class Discount
    {

        private int id;
        private string airlineName;
        private string origin;
        private string destination;
        private DateTime discountStart;
        private DateTime discountEnd;
        private int airlineDiscount;


        public Discount()
        {



        }

        public Discount(int id, string airlineName, string origin, string destination, DateTime discountStart, DateTime discountEnd, int airlineDiscount)
        {
            this.Id = id;
            this.AirlineName = airlineName;
            this.Origin = origin;
            this.Destination = destination;
            this.DiscountStart = discountStart;
            this.DiscountEnd = discountEnd;
            this.AirlineDiscount = airlineDiscount;
        }

        public int Id { get => id; set => id = value; }
        public string AirlineName { get => airlineName; set => airlineName = value; }
        public string Origin { get => origin; set => origin = value; }
        public string Destination { get => destination; set => destination = value; }
        public DateTime DiscountStart { get => discountStart; set => discountStart = value; }
        public DateTime DiscountEnd { get => discountEnd; set => discountEnd = value; }
        public int AirlineDiscount { get => airlineDiscount; set => airlineDiscount = value; }




        public void insertDiscount(Discount discount)
        {
            DBservices dbs = new DBservices();
            dbs.insertDiscount(discount);
           
        }

        public List<Discount> getAllDiscounts()
        {
            DBservices dbs = new DBservices();
            return dbs.getDiscounts();
        }

        public int UpdateDiscounts(Discount discount)
        {

            DBservices dbs = new DBservices();
            dbs = dbs.readDiscounts();
            dbs.dt = DiscountTable(discount, dbs.dt);
            dbs.update();
            return 0;
        }

        public DataTable DiscountTable(Discount discount, DataTable dt)
        {
            int id;
            foreach (DataRow dr in dt.Rows)
            {
                id=Convert.ToInt32(dr["DiscountId"]);
                if (id==discount.Id)
                {
                    dr["AirlineName"] = discount.AirlineName;
                    dr["Origin"] = discount.Origin;
                    dr["Destination"] = discount.Destination;
                    dr["DiscountStart"] = discount.DiscountStart;
                    dr["DiscountEnd"] = discount.DiscountEnd;
                    dr["AirlineDiscount"] = discount.AirlineDiscount;
                }                         
            }
            return dt;
        }

    }
}