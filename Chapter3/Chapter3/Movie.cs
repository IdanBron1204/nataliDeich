using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Chapter3
{
    public class Movie
    {
        public string Name {  get; set; }
        public int Year {  get; private set; }
        public List<Actor> Actors { get; private set; }
        public Director Director {  get; private set; }
        public List<Enums.Genre> MGenre { get; private set; }

        public Movie(string name, int year, List<Actor> artists, Director director, List<Enums.Genre> mGenre)
        {
            Name = name;
            Year = year;
            Actors = artists;
            Director = director;
            MGenre = mGenre;
        }
        public void Info()
        {
            string names = "",Genres="";
            for (int i = 0; i < Actors.Count; i++)
                names += Actors[i].ToString()+", ";
            for (int i = 0; i < MGenre.Count; i++)
                Genres += MGenre[i].ToString() + ", ";
            Console.WriteLine($"Name: {Name}\n" +
                $"Publishing year: {Year}\n" +
                $"Actors in the movie: {names}\n" +
                $"Director's name: {Director}\n" +
                $"Genre: {Genres}");
        }
    }
}
