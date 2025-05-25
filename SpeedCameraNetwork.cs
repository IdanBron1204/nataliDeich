using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter3
{
    public  class SpeedCameraNetwork
    {
        public CameraSpeed[] Cameras;
        public SpeedCameraNetwork()
        {
            Cameras = new CameraSpeed[100];
        }
        public void AddSpeedCamera(CameraSpeed sc)
        {
            int i = 0;
            while (i < this.Cameras.Length&&this.Cameras[i] != null)
                i++;
            if (i < this.Cameras.Length)
                Cameras[i] = sc;
        }
        private int CountQ(Queue<int> q)
        {
            q.Insert(-999);
            int count = 0;
            while (q.Head() != -999)
            {
                count++;
                q.Insert(q.Remove());
            }
            q.Remove();
            return count;
        }
        public void WorstRoads()
        {
            for (int i = 0; i < this.Cameras.Length; i++)
            {
                if (this.Cameras[i] != null)
                {
                    if (CountQ(this.Cameras[i].GetQueue())>200)
                        Console.WriteLine(this.Cameras[i].GetRoad());
                }
            }
        }
        private bool IsExistQ(Queue<int> q, int num)
        {
            q.Insert(-999);
            bool v = false;
            while (q.Head() != -999)
            {
                if(q.Head()==num)
                    v = true;
                q.Insert(q.Remove());
            }
            q.Remove();
            return v;
        }
        public bool FindCar(int num)
        {
            bool v = false;
            for (int i = 0; i < this.Cameras.Length; i++)
            {
                if (this.Cameras[i] != null)
                {
                    if (IsExistQ(this.Cameras[i].GetQueue(), num))
                    {
                        Console.WriteLine(this.Cameras[i].GetCode());
                        v= true;
                    }
                        
                }
            }
            return v;
        }
    }
}
