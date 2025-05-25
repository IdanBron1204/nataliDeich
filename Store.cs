using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter3
{
    public class Store
    {
        public Dictionary<Media, Tuple<Custumer, DateTime>> RentedMedia { get; private set; }
        public Store()
        {
            RentedMedia = new Dictionary<Media, Tuple<Custumer, DateTime>>();
        }
        public void RentMedia(Media media, Custumer custumer)
        {
            if (!media.IsAvailable)
            {
                Console.WriteLine("not available");
                return;
            }
            media.IsAvailable = false;
            RentedMedia.Add(media, new Tuple<Custumer, DateTime>(custumer, DateTime.Now));
        }
        public double ReturnMedia(Media media)
        {
            if (!RentedMedia.ContainsKey(media))
            {
                Console.WriteLine("Not rented");
                return -1;
            }
            media.IsAvailable = true;
            double NumOFDays = (DateTime.Now - RentedMedia[media].Item2).TotalDays;
            double bill = NumOFDays * media.PricePerDay;
            RentedMedia.Remove(media);
            return bill;
        }
        public void MoreThanX(double x)
        {
            foreach (Tuple<Custumer,DateTime> info in RentedMedia.Values)
            {
                if ((DateTime.Now - info.Item2).TotalDays>x)
                    Console.WriteLine(info.Item1);
            }
        }
    }

}
