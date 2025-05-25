using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter3
{
    public class AllCars
    {
        private Car[] cars;
        private int num;
        public AllCars(int max)
        {
            this.cars = new Car[max];
            this.num = 0;
        }

        public int GetNum()
        {
            return this.num;
        }

        public void SetNum(int value)
        {
            this.num = value;
        }

        public Car[] GetCars()
        {
            return this.cars;
        }

        public void SetCars(Car[] value)
        {
            this.cars = value;
        }
        public bool AddCar(Car car)
        {
            if(this.cars.Length==num)
                return false;
            this.cars[num] = car;
            this.num++;
            return true;
        }
        public void Print(int min, int max)
        {
            for(int i = 0; i < num; i++)
            {
                if (cars[i].Range(min, max) && !cars[i].GetHadAccident())
                    Console.WriteLine(cars[i].GetLicenseNum());
            }
        }
        public override string ToString()
        {
            string str = "";
            for (int i = 0; i < num; i++)
                str += $"{this.cars[i]}, ";
            return str + $"\nnum: {this.num}";          
        }
    }
}
