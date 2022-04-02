using System;
using System.Collections.Generic;
using System.Text;

namespace lab_2_zadanie
{
    public class Meat : Product
    {
        private double weight;

        public Meat(string name, double weight): base(name)
        {
            Name = name;
            Weight = weight;
        }

        public double  Weight { get => weight; set => weight = value; }

        public override void Print()
        {
            base.Print();
            Console.WriteLine($"({ Weight} kg)");
        }
    }
}
