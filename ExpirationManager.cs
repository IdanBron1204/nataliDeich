using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter3
{
    public class ExpirationManager
    {
        Dictionary<string, DateTime> ExpirationDate { get; set; }
        public ExpirationManager() 
        {
            ExpirationDate = new Dictionary<string, DateTime>();
        }
        public void Add(string value,DateTime time)
        {
            ExpirationDate.Add(value, time);
        }
        public void Remove(string value)
        {
            ExpirationDate.Remove(value);
        }
        public void ExpirationDateChecker()
        {
            foreach (var item in ExpirationDate)
            {
                if ((item.Value - DateTime.Now).TotalDays < 2 && (item.Value - DateTime.Now).TotalDays > 0)
                {
                    Console.WriteLine($"{item.Key}'s expiration date is in less than 2 days");
                }
                else if (item.Value < DateTime.Now)
                {
                    Console.WriteLine($"{item.Key} is expired");
                }
            }
        }



    }
}
