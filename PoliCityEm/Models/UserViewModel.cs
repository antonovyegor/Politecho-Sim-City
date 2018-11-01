
using PoliCityEm.Models;
using System.Collections.Generic;


namespace PoliCityEm.Controllers
{
    public class UserViewModel

    {
        public int UserId { get; set; }
        public string name { get; set; }
        public string password { get; set; }
        public CityViewModel city { get; set; }
        public int points { get; set; }
       
        public List<int> Friends { get; set; }

        public UserViewModel(string name, string password)
        {
            this.UserId = Start.LastID;
            Start.LastID++;
            this.name = name;
            this.password = password;
            this.points = 100;
            this.city = new CityViewModel(this.UserId);
        }

        public UserViewModel()
        {
            
        }

    }
}