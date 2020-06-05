﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Data;
using System.Text;
using ClassEX3.Models;

/// <summary>
/// DBServices is a class created by me to provides some DataBase Services
/// </summary>
public class DBservices
{
    public SqlDataAdapter da;
    public DataTable dt;

    public DBservices()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    //--------------------------------------------------------------------------------------------------
    // This method creates a connection to the database according to the connectionString name in the web.config 
    //--------------------------------------------------------------------------------------------------
    public SqlConnection connect(String conString)
    {

        // read the connection string from the configuration file
        string cStr = WebConfigurationManager.ConnectionStrings[conString].ConnectionString;
        SqlConnection con = new SqlConnection(cStr);
        con.Open();
        return con;
    }

    // Create the SqlCommand
    //---------------------------------------------------------------------------------
    private SqlCommand CreateCommand(String CommandSTR, SqlConnection con)
    {

        SqlCommand cmd = new SqlCommand(); // create the command object

        cmd.Connection = con;              // assign the connection to the command object

        cmd.CommandText = CommandSTR;      // can be Select, Insert, Update, Delete 

        cmd.CommandTimeout = 10;           // Time to wait for the execution' The default is 30 seconds

        cmd.CommandType = System.Data.CommandType.Text; // the type of the command, can also be stored procedure

        return cmd;
    }


   
    public int deleteSelectedDiscount(int id)
    {

        SqlConnection con;
        SqlCommand cmd;

        try
        {
            con = connect("DBConnectionString"); // create the connection
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        String cStr = BuildDeleteCommandDiscounts(id);      // helper method to build the insert string

        cmd = CreateCommand(cStr, con);             // create the command

        try
        {
            int numEffected = cmd.ExecuteNonQuery(); // execute the command
            return numEffected;
        }
        catch (Exception ex)
        {
            return 0;
            //Console.WriteLine("Inside catch block. Exception: {0}", ex.Message);
            throw (ex);
        }

        finally
        {
            if (con != null)
            {
                // close the db connection
                con.Close();
            }
        }

    }
    //--------------------------------------------------------------------
    // Build the Insert command String
    //--------------------------------------------------------------------
    private String BuildDeleteCommandDiscounts(int id)
    {
        String command;     
        StringBuilder sb = new StringBuilder();
        // use a string builder to create the dynamic string
        String prefix = "Delete From Discounts_CS WHERE DiscountsID = '"+id+"'";
        command = prefix;

        return command;
    }

    //Insert AirportsMethod
    public int insertDiscount(Discount discount)
    {

        SqlConnection con;
        SqlCommand cmd;

        try
        {
            con = connect("DBConnectionString"); // create the connection
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        String cStr = BuildInsertCommandDiscounts(discount);      // helper method to build the insert string

        cmd = CreateCommand(cStr, con);             // create the command

        try
        {
            int numEffected = cmd.ExecuteNonQuery(); // execute the command
            return numEffected;
        }
        catch (Exception ex)
        {
            return 0;
            //Console.WriteLine("Inside catch block. Exception: {0}", ex.Message);
            throw (ex);
        }

        finally
        {
            if (con != null)
            {
                // close the db connection
                con.Close();
            }
        }

    }
    //--------------------------------------------------------------------
    // Build the Insert command String
    //--------------------------------------------------------------------
    private String BuildInsertCommandDiscounts(Discount discount)
    {
        String command;
        string format = "yyyy-MM-dd HH:mm:ss";
        StringBuilder sb = new StringBuilder();
        // use a string builder to create the dynamic string
        sb.AppendFormat("Values('{0}', '{1}', '{2}', '{3}', '{4}', {5})", discount.AirlineName,discount.From, discount.To, discount.DiscountStart.ToString(format), discount.DiscountEnd.ToString(format), discount.AirlineDiscount.ToString());
        String prefix = "INSERT INTO Discounts_CS " + "(AirlineName, Origin,Destination, DiscountStart,DiscountEnd,AirlineDiscount)";
        command = prefix + sb.ToString();

        return command;
    }

    //getOrders
    public List<Flights> getOrders()
    {
        List<Flights> OrderList = new List<Flights>();
        SqlConnection con = null;

        try
        {
            con = connect("DBConnectionString"); // create a connection to the database using the connection String defined in the web config file

            String selectSTR = "SELECT * FROM MyFlights_CS";
            SqlCommand cmd = new SqlCommand(selectSTR, con);

            // get a reader
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection); // CommandBehavior.CloseConnection: the connection will be closed after reading has reached the end

            while (dr.Read())
            {   // Read till the end of the data into a row
                Flights order = new Flights();

                order.OrderID = Convert.ToInt32(dr["OrderID"]);
                order.Name = (string)dr["ClientName"];
                order.Email = (string)dr["Email"];
                order.FlightID = (string)dr["FlightID"];
                order.AirlineName = (string)dr["AirlineName"];
                order.AirportFrom = (string)dr["Origin"];
                order.AirportTo = (string)dr["Destination"];
                order.Departure = Convert.ToDateTime(dr["DepartureTime"]);
                order.Arrival = Convert.ToDateTime(dr["ArrivalTime"]);
                order.Price = Convert.ToDouble(dr["Price"]);
                OrderList.Add(order);
            }

            return OrderList;
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }
        finally
        {
            if (con != null)
            {
                con.Close();
            }

        }
    }

    //getDiscounts
    public List<Discount> getDiscounts()
    {
        List<Discount> DiscountList = new List<Discount>();
        SqlConnection con = null;

        try
        {
            con = connect("DBConnectionString"); // create a connection to the database using the connection String defined in the web config file

            String selectSTR = "SELECT * FROM Discounts_CS";
            SqlCommand cmd = new SqlCommand(selectSTR, con);

            // get a reader
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection); // CommandBehavior.CloseConnection: the connection will be closed after reading has reached the end

            while (dr.Read())
            {   // Read till the end of the data into a row
                Discount dis = new Discount();

                dis.Id = Convert.ToInt32(dr["DiscountsId"]);
                dis.AirlineName = (string)dr["AirlineName"];
                dis.From = (string)dr["Origin"];
                dis.To = (string)dr["Destination"];           
                dis.DiscountStart = Convert.ToDateTime(dr["DiscountStart"]);
                dis.DiscountEnd = Convert.ToDateTime(dr["DiscountEnd"]);
                dis.AirlineDiscount = Convert.ToInt32(dr["AirlineDiscount"]);
                DiscountList.Add(dis);
            }

            return DiscountList;
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }
        finally
        {
            if (con != null)
            {
                con.Close();
            }

        }
    }


    //
    public DBservices readDiscounts()
    {
        SqlConnection con = null;
        try
        {
            con = connect("DBConnectionString");
            da = new SqlDataAdapter("select * from Discounts_CS", con);
            SqlCommandBuilder builder = new SqlCommandBuilder(da);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dt = ds.Tables[0];
        }

        catch (Exception ex)
        {
            // write errors to log file
            // try to handle the error
            throw ex;
        }

        finally
        {
            if (con != null)
            {
                con.Close();
            }
        }
        return this;
    }
    public void update()
    {
        da.Update(dt);
    }



    //Insert AirlinesMethod
    public int insertAirlines(Airlines airline)
    {

        SqlConnection con;
        SqlCommand cmd;

        try
        {
            con = connect("DBConnectionString"); // create the connection
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        String cStr = BuildInsertCommandAirlines(airline);      // helper method to build the insert string

        cmd = CreateCommand(cStr, con);             // create the command

        try
        {
            int numEffected = cmd.ExecuteNonQuery(); // execute the command
            return numEffected;
        }
        catch (Exception ex)
        {
            return 0;
//            Console.WriteLine("Inside catch block. Exception: {0}", ex.Message);
            throw (ex);
        }

        finally
        {
            if (con != null)
            {
                // close the db connection
                con.Close();
            }
        }

    }
    //--------------------------------------------------------------------
    // Build the Insert command String
    //--------------------------------------------------------------------
    private String BuildInsertCommandAirlines(Airlines airline)
    {
        String command;

        StringBuilder sb = new StringBuilder();
        // use a string builder to create the dynamic string
        sb.AppendFormat("Values('{0}', '{1}')", airline.AirlineID, airline.AirlineName);
        String prefix = "INSERT INTO Airlines_CS " + "(AirlineID, AirlineName)";
        command = prefix + sb.ToString();

        return command;
    }


    //Insert AirportsMethod
    public int insertAirport(Airports airport)
    {

        SqlConnection con;
        SqlCommand cmd;

        try
        {
            con = connect("DBConnectionString"); // create the connection
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        String cStr = BuildInsertCommandAirports(airport);      // helper method to build the insert string

        cmd = CreateCommand(cStr, con);             // create the command

        try
        {
            int numEffected = cmd.ExecuteNonQuery(); // execute the command
            return numEffected;
        }
        catch (Exception ex)
        {
            return 0;
            //Console.WriteLine("Inside catch block. Exception: {0}", ex.Message);
            throw (ex);
        }

        finally
        {
            if (con != null)
            {
                // close the db connection
                con.Close();
            }
        }

    }
    //--------------------------------------------------------------------
    // Build the Insert command String
    //--------------------------------------------------------------------
    private String BuildInsertCommandAirports(Airports airport)
    {
        String command;

        StringBuilder sb = new StringBuilder();
        // use a string builder to create the dynamic string
        sb.AppendFormat("Values('{0}', '{1}', {2}, {3}, '{4}', '{5}')", airport.AirportID, airport.AirportName, airport.AirportLong.ToString(), airport.AirportLat.ToString(),airport.City,airport.Country);
        String prefix = "INSERT INTO Airports_CS " + "(AirportID, AirportName, AirportLong, AirportLat,City,Country)";
        command = prefix + sb.ToString();

        return command;
    }






    //Insert flightMethod
    public int insertFlight(Flights flight)
    {

        SqlConnection con;
        SqlCommand cmd;

        try
        {
            con = connect("DBConnectionString"); // create the connection
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        String cStr = BuildInsertCommandFlights(flight);      // helper method to build the insert string

        cmd = CreateCommand(cStr, con);             // create the command

        try
        {
            int numEffected = cmd.ExecuteNonQuery(); // execute the command
            return numEffected;
        }
        catch (Exception ex)
        {
            return 0;
            //Console.WriteLine("Inside catch block. Exception: {0}", ex.Message);
            throw (ex);
        }

        finally
        {
            if (con != null)
            {
                // close the db connection
                con.Close();
            }
        }

    }
    //--------------------------------------------------------------------
    // Build the Insert command String
    //--------------------------------------------------------------------
    private String BuildInsertCommandFlights(Flights flight)
    {
        String command;

        StringBuilder sb = new StringBuilder();
        // use a string builder to create the dynamic string
        string format = "yyyy-MM-dd HH:mm:ss";
        sb.AppendFormat("Values('{0}', '{1}', '{2}', {3}, '{4}', '{5}' ,'{6}')", flight.FlightID, flight.AirportFrom, flight.AirportTo, flight.Price.ToString(), flight.Duration, flight.Departure.ToString(format),flight.Arrival.ToString(format));
        String prefix = "INSERT INTO MyFlights_CS " + "(FlightID,AirportFrom,AirportTo,Price,Duration,Departure,Arrival)";
        command = prefix + sb.ToString();

        return command;
    }

    //Insert LegMethod
    public int insertLeg(Leg leg)
    {

        SqlConnection con;
        SqlCommand cmd;

        try
        {
            con = connect("DBConnectionString"); // create the connection
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        String cStr = BuildInsertCommandLegs(leg);      // helper method to build the insert string

        cmd = CreateCommand(cStr, con);             // create the command

        try
        {
            int numEffected = cmd.ExecuteNonQuery(); // execute the command
            return numEffected;
        }
        catch (Exception ex)
        {
            return 0;
          //  Console.WriteLine("Inside catch block. Exception: {0}", ex.Message);
            throw (ex);
        }

        finally
        {
            if (con != null)
            {
                // close the db connection
                con.Close();
            }
        }

    }
    //--------------------------------------------------------------------
    // Build the Insert command String
    //--------------------------------------------------------------------
    private String BuildInsertCommandLegs(Leg leg)
    {
        String command;

        StringBuilder sb = new StringBuilder();
        // use a string builder to create the dynamic string
        string format = "yyyy-MM-dd HH:mm:ss";
        sb.AppendFormat("Values('{0}',{1},'{2}',{3},'{4}','{5}','{6}','{7}','{8}','{9}')", leg.LegID, leg.LegNum.ToString(), leg.FlightID, leg.Flight_no.ToString(), leg.AirportFrom, leg.AirportTo, leg.Duration,leg.Departure.ToString(format),leg.Arrival.ToString(format),leg.AirlineID);
        String prefix = "INSERT INTO Leg_CS " + "(LegID,LegNum,FlightID,Flight_no,AirportFrom, AirportTo,Duration,Departure,Arrival,AirlineID) ";
        command = prefix + sb.ToString();

        return command;
    }

    //---------------------------------------------------------------------------------
    // Read Loans using a DataSet
    //---------------------------------------------------------------------------------
    public DBservices getAllAirports()
    {
        SqlConnection con = null;
        try
        {
            con = connect("DBConnectionString");
            da = new SqlDataAdapter("select * from Airports_CS", con);
            SqlCommandBuilder builder = new SqlCommandBuilder(da);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dt = ds.Tables[0];
        }

        catch (Exception ex)
        {
            //Console.WriteLine("Inside catch block. Exception: {0}", ex.Message);
            // try to handle the error
            throw ex;
        }

        finally
        {
            if (con != null)
            {
                con.Close();
            }
        }
        return this;

    } 

    public DBservices ManagerIfExits(Manager manager)
    {
        SqlConnection con = null;
        try
        {
            con = connect("DBConnectionString");
            da = new SqlDataAdapter("select * from Managers_CS where UserName= '"+manager.Username +"' and ManagerPassword='"+manager.Password+"'", con);
            SqlCommandBuilder builder = new SqlCommandBuilder(da);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dt = ds.Tables[0];
           
             
        }

        catch (Exception ex)
        {
            Console.WriteLine("Inside catch block. Exception: {0}", ex.Message);
            // try to handle the error
            throw ex;
        }

        finally
        {
            if (con != null)
            {
                con.Close();
            }
        }
        return this;

    } 
}

        
    

