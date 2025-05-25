using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Chapter3
{
    public class Actor
    {
        private string id;
        private char gender;
        private int numFilms;

        public Actor(string id, char gender, int numFilms)
        {
            this.id = id;
            this.gender = gender;
            this.numFilms = numFilms;
        }

        public string GetId()
        {
            return id;
        }

        public void SetId(string value)
        {
            id = value;
        }

        public char GetGender()
        {
            return gender;
        }

        public void SetGender(char value)
        {
            gender = value;
        }

        public int GetNumFilms()
        {
            return numFilms;
        }

        public void SetNumFilms(int value)
        {
            numFilms = value;
        }
    }
}
