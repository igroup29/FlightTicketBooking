using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace first_proj.Models
{
    public class Player
    {

        static public List<Player> list = new List<Player>();

        string name;
        double age;

        public Player(string name, double age)
        {
            this.Name = name;
            this.Age = age;
        }

        public string Name { get => name; set => name = value; }
        public double Age { get => age; set => age = value; }

        public int insert() {
            list.Add(this);
            return 1;
        }

    }
}