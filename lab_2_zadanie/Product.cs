using System;
using System.Collections.Generic;
using System.Text;

namespace lab_2_zadanie
{
    public class Product : IThing
    {
        private string name;

        public Product()
        {

        }

        public Product(string name)
        {
            this.name = name;
        }

        public string Name { get => name; set => name = value; }

        public virtual void Print()
        {
            Console.Write($"        {Name} ");
        }
    }
}
