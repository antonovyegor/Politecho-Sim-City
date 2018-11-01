using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PoliCityEm.BaseClass
{
    public class City
    {


        public int CityId;//{ get; set; }
        //public User user { get; set; }
        public string name;//{ get; set; }
        public string[] Fields;//{ get; set; }


        public City()
        {

        }
        //public City()
        //{
        //    this.CityId = -1;
        //    this.name = "DefaultName";
        //    this.Fields = new string[64];
        //}
        public City(int id, string name)
        {
            this.CityId = id;
            this.name = name;
            this.Fields = new string[64];
        }
        public City(int id)
        {
            this.CityId = id;
            this.name = "DefaultName";
            this.Fields = new string[64];
        }
    }
}