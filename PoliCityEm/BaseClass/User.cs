using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PoliCityEm.Controllers;

namespace PoliCityEm.BaseClass
{
    public class User
    {

        public int UserId; //{ get; set; }
        public string name;//{ get; set; }
        public string password; //{ get; set; }
        public City city;// { get; set; }
        public int points;// { get; set; }

        public List<int> Friends;//{ get; set; }

        public User(string name, string password)
        {
            this.UserId = Start.LastID;
            Start.LastID++;
            this.name = name;
            this.password = password;
            this.points = 100;
            this.city = new City(this.UserId);
        }

        public User()
        {

        }

        public static implicit operator User(UserViewModel v)
        {
            throw new NotImplementedException();
        }
    }
}