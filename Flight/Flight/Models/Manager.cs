using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace ClassEX3.Models
{
    public class Manager
    {

        private string username;
        private string password;

        public Manager(string username, string password)
        {
            this.Username = username;
            this.Password = password;
        }

        public string Password { get => password; set => password = value; }
        public string Username { get => username; set => username = value; }


        public int checkManager()
        {

            DBservices dbs = new DBservices();
            dbs = dbs.ManagerIfExits(this);
             
            if (dbs.dt.Rows.Count != 1)
            {
                return 0;
            }      
                return 1; 
        } 
    }
}