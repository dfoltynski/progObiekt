using System;
using System.Collections.Generic;
using System.Text;

namespace lab_2_zadanie
{
    public class Fruit : Product
    {

        private int count;


        public int Count { get => count; set => count = value; }

        public Fruit(string name, int count) : base(name)
        {
            Name = name;
            Count = count;
        }

        public override void Print()
        {
            base.Print();
            Console.WriteLine($"({Count} fruits)");
        }
    }
}
