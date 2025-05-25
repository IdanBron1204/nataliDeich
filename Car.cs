using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter3
{
    public class Car
    {
        private string licenseNum;
        private bool hadAccident;
        private int price;
        public Car(string licenseNum, bool hadAccident, int price)
        {
            this.licenseNum = licenseNum;
            this.hadAccident = hadAccident;
            this.price = price;
        }
        public string GetLicenseNum()
        {
            return this.licenseNum;
        }
        public void SetLicenseNum(string value)
        {
            this.licenseNum = value;
        }
        public bool GetHadAccident()
        {
            return this.hadAccident;
        }
        public void SetHadAccident(bool value)
        {
            this.hadAccident = value;
        }
        public int GetPrice()
        {
            return this.price;
        }
        public void Setprice(int value)
        {
            this.price = value;
        }
        public bool Range(int min,int max)
        {
            return (min <= this.price && max >= this.price);
        }
        public override string ToString()
        {
            return $"licenseNum: {this.licenseNum}\n" +
                $"hadAccident: {this.hadAccident}\n" +
                $"price: {this.price}";
        }

    }
}
