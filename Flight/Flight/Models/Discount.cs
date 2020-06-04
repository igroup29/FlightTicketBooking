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
        private string from;
        private string to;
        private DateTime discountStart;
        private DateTime discountEnd;
        private int airlineDiscount;


        public Discount()
        {



        }

        public Discount(int id, string airlineName, string from, string to, DateTime discountStart, DateTime discountEnd, int airlineDiscount)
        {
            this.Id = id;
            this.AirlineName = airlineName;
            this.From = from;
            this.To = to;
            this.DiscountStart = discountStart;
            this.DiscountEnd = discountEnd;
            this.AirlineDiscount = airlineDiscount;
        }

        public int Id { get => id; set => id = value; }
        public string AirlineName { get => airlineName; set => airlineName = value; }
        public string From { get => from; set => from = value; }
        public string To { get => to; set => to = value; }
        public DateTime DiscountStart { get => discountStart; set => discountStart = value; }
        public DateTime DiscountEnd { get => discountEnd; set => discountEnd = value; }
        public int AirlineDiscount { get => airlineDiscount; set => airlineDiscount = value; }


     


        
        public void deleteDiscount(int id)
        {
           DBservices dbs = new DBservices();
           dbs.deleteSelectedDiscount(id);
            
        }

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
                id=Convert.ToInt32(dr["DiscountsId"]);
                if (id==discount.Id)
                {
                    dr["AirlineName"] = discount.AirlineName;
                    dr["Origin"] = discount.From;
                    dr["Destination"] = discount.To;
                    dr["DiscountStart"] = discount.DiscountStart;
                    dr["DiscountEnd"] = discount.DiscountEnd;
                    dr["AirlineDiscount"] = discount.AirlineDiscount;
                }                         
            }
            return dt;
        }

    }
}