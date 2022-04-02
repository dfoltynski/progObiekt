using System;
using System.Collections.Generic;
using System.Text;

namespace lab_2_zadanie
{
    public class Seller : Person
    {

        public Seller(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public override void Print ()
        {
            Console.Write("        Seller: ");
            base.Print();
        }
    }


}
