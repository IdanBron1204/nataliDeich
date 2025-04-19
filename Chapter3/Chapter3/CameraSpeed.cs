using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Chapter3
{
    public class CameraSpeed
    {
        private string Code;
        private int Road;
        private int MaxSpeed;
        private Queue<int> Queue;
        public CameraSpeed(string code, int road, int maxSpeed)
        {
            this.Code = code;
            this.Road = road;
            this.MaxSpeed = maxSpeed;
            this.Queue = new Queue<int>();
        }
        public string GetCode()
        {
            return this.Code;
        }
        public void SetCode(string value)
        {
            this.Code = value;
        }
        public int GetRoad()
        {
            return this.Road;
        }
        public void SetRoad(int value)
        {
            this.Road = value;
        }
        public int GetMaxSpeed()
        {
            return this.MaxSpeed;
        }
        public void SetMaxSpeed(int value)
        {
            this.MaxSpeed = value;
        }
        public Queue<int> GetQueue()
        {
            return this.Queue;
        }
        public void SetQueue(Queue<int> q)
        {
            this.Queue = q;
        }
        public void AddCar(int speed,int num) 
        {
            if (speed > this.MaxSpeed)
                Queue.Insert(num);
        }
    }
}
