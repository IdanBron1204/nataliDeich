using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter3
{
    public class UserProfile
    {
        public Dictionary<string, string> DietaryRestrictions { get; set; }
        public string[] Favorite { get; set; }
        public UserProfile(string foodRes, string drinkres, string[] favorite)
        {
            DietaryRestrictions = new Dictionary<string, string>
        {
            {"Food",foodRes },
            {"Drink",drinkres}
        };
            Favorite = favorite;
        }
        public UserProfile()
        {
            Favorite = null;
            DietaryRestrictions = new Dictionary<string, string>
        {
            {"Food",null },
            {"Drink",null}
        };

        }
        public string GetFavorite()
        {
            string str = "";
            for (int i = 0; i < Favorite.Length; i++)
                str += Favorite[i] + ", ";
            return str;
        }
    }
}
