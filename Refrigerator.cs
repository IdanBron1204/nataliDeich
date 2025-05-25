using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Chapter3
{
    public class Refrigerator
    {

        public Dictionary<string, double> FoodNum { get; set; }
        public Dictionary<string, double> DrinkNum { get; set; }
        public ExpirationManager ExpirationD;
        public Dictionary<string, double> ListToBuyFood { get; set; }
        public Dictionary<string, double> ListToBuyDrink { get; set; }
        public Dictionary<string, double> Prices = new Dictionary<string, double>
        {
            { "Coffee", 90.5 },
            { "Tea", 60.0 },
            { "Sugar", 10.2 },
            { "Rice", 7.5 },
            { "Flour", 6.8 },
            { "Milk", 45.0 },
            { "Cheese", 55.3 },
            { "Chicken", 25.0 },
            { "Beef", 80.0 },
            { "Fish", 65.5 },
            { "Apples", 12.0 },
            { "Bananas", 8.5 },
            { "Tomatoes", 6.0 },
            { "Cucumbers", 5.0 },
            { "Oranges", 10.0 },
            { "Potatoes", 4.5 },
            { "Carrots", 5.5 },
            { "Onions", 4.8 },
            { "Peppers", 15.0 },
            { "Bread", 20.0 },
            { "Honey", 50.0 },
            { "Olive Oil", 100.0 },
            { "Pasta", 9.0 },
            { "Lentils", 13.5 },
            { "Chickpeas", 11.0 },
            { "Chocolate", 75.0 },
            { "Yogurt", 10.5 },
            { "Eggs", 18.0 },
            { "Watermelon", 3.5 },
            { "Pineapple", 25.0 },
            { "Strawberries", 35.0 },
            { "Avocados", 30.0 },
            { "Nuts", 120.0 },
            { "Dates", 40.0 }
        };
        public UserProfile User { get; set; }
        public Dictionary<int, string> Notes;
        public int NumNotes;
        public bool IsClosed = true;

        public Refrigerator(Dictionary<string, double> foodNum, Dictionary<string, double> drinkNum, Dictionary<string, double> listToBuyFood, Dictionary<string, double> listToBuyDrink)
        {
            FoodNum = foodNum;
            DrinkNum = drinkNum;
            ExpirationD = new ExpirationManager();
            ListToBuyFood = listToBuyFood;
            ListToBuyDrink = listToBuyFood;
            User = new UserProfile();
            Notes = new Dictionary<int, string>();
            NumNotes = 0;
        }
        public Refrigerator()
        {
            FoodNum = null;
            DrinkNum = null;
            ExpirationD = new ExpirationManager();
            ListToBuyFood = null;
            ListToBuyDrink = null;
            User = new UserProfile();
            Notes = new Dictionary<int, string>();
            NumNotes = 0;
        }
        public double GetFoodNum(string value)
        {
            try
            {
                return FoodNum[value];
            }
            catch (Exception e)
            {

                return 0.0;
            }
        }
        public double GetDrinkNum(string value)
        {
            try
            {
                return DrinkNum[value];
            }
            catch (Exception e)
            {
                return 0.0;
            }
        }
        public void TakeFood(string value, double num)
        {
            try
            {
                if (FoodNum[value] - num < 0)
                    Console.WriteLine("there is not enough");
                else if (FoodNum[value] == num)
                {
                    FoodNum.Remove(value);
                    ExpirationD.Remove(value);
                }
                else
                    FoodNum[value] -= num;
            }
            catch (Exception e)
            {
                Console.WriteLine("there is no food of that kind");
            }

        }
        public void TakeDrink(string value, double num)
        {
            try
            {
                if (DrinkNum[value] - num < 0)
                    Console.WriteLine("there is not enough");
                else if (DrinkNum[value] == num)
                {
                    DrinkNum.Remove(value);
                    ExpirationD.Remove(value);
                }
                else
                    DrinkNum[value] -= num;


            }
            catch (Exception e)
            {
                Console.WriteLine("there is no drink of that kind");
            }
        }
        public void PutFood(string value, double num)
        {
            try
            {
                FoodNum[value] += num;
            }
            catch (Exception e)
            {
                FoodNum.Add(value, num);
                ExpirationD.Add(value, DateTime.Now.AddDays(12));
            }
        }
        public void PutDrink(string value, double num)
        {
            try
            {
                DrinkNum[value] += num;
            }
            catch (Exception e)
            {
                DrinkNum.Add(value, num);
                ExpirationD.Add(value, DateTime.Now.AddDays(12));
            }
        }
        public string GetFoodList()
        {
            string list = "**Food:\n";
            double totalSum = 0;
            foreach (var item in ListToBuyFood)
            {
                if (item.Value > GetFoodNum(item.Key))
                {
                    list += item.Value + ", " + (item.Value - GetFoodNum(item.Key)) * Prices[item.Key] + "\n";
                    totalSum += (item.Value - GetFoodNum(item.Key)) * Prices[item.Key];
                }
            }
            list += "**Drinks:\n";
            foreach (var item in ListToBuyDrink)
            {
                if (item.Value < GetDrinkNum(item.Key))
                {
                    list += item.Value+ ", " + (item.Value - GetDrinkNum(item.Key)) * Prices[item.Key] + "\n";
                    totalSum += (item.Value - GetDrinkNum(item.Key)) * Prices[item.Key];
                }
            }
            list += "**total price:" + totalSum;
            return list;

        }

        public void Menu()
        {
            switch (Console.ReadLine())
            {
                case "Home":
                    Console.WriteLine("Hi, enter the option you want to see");
                    break;
                case "Inventory check":
                    Console.WriteLine(ToString());
                    break;
                case "Soon expired":
                    ExpirationD.ExpirationDateChecker();
                    break;
                case "To buy list":
                    Console.WriteLine(GetFoodList());
                    break;
                case "Dietary restrictions":                  
                        Console.WriteLine(User.DietaryRestrictions);
                    break;
                case "Favorite":
                    Console.WriteLine(User.GetFavorite());
                    break;
                case "Notes":
                    switch (Console.ReadLine())
                    {
                        case "Show":
                            foreach(var item in Notes)
                                Console.WriteLine($"{item.Key} - {item.Value}");
                            break;
                        case "Remove":
                            Notes.Remove(int.Parse(Console.ReadLine()));
                            break;
                        case "Create":
                            Notes.Add(NumNotes, Console.ReadLine());
                            NumNotes++;
                            break;
                        case "Add to":
                            Notes[int.Parse(Console.ReadLine())] += Console.ReadLine();
                            break;
                    }
                    break;
            }
        }
        public string SendToStore()
        {
            string list = "";
            foreach (var item in ListToBuyFood)
            {
                if (item.Value > GetFoodNum(item.Key))                
                    list += item.Value +", " +(item.Value - GetFoodNum(item.Key))+ "\n";                                    
            }
            foreach (var item in ListToBuyDrink)
            {
                if (item.Value < GetDrinkNum(item.Key))             
                    list += item.Value+", "+(item.Value - GetDrinkNum(item.Key)) + "\n";                               
            }
            return list;
        }
        public override string ToString()
        {
            string str = "Food:\n";
            foreach (var item in FoodNum)
                str += $"{item.Key}, {item.Value}\n";
            str += "Drink:\n";
            foreach (var item in DrinkNum)
                str += $"{item.Key}, {item.Value}\n";
            return str;
        }

    }
}
