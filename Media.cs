using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter3
{
    public class Media
    {
        public Enums.MediaType MediaType { get; set; }
        public Movie Movie { get; private set; }
        public double PricePerDay { get; private set; }
        public bool IsAvailable { get; set; }
        public Media(Movie movie, Enums.MediaType mediaType, double pricePerDay)
        {
            Movie = movie;
            MediaType = mediaType;
            PricePerDay = pricePerDay;
            IsAvailable = true;
        }
        
    }
}
