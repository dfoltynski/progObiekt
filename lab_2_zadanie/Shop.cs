using System;
using System.Collections.Generic;
using System.Text;

namespace lab_2_zadanie
{
    public class Shop
    {
        private string name;
        private Person[] people;
        private Product[] products;
        public string Name { get => name; set =>name = value; }


        public Shop(string name, Person[]people, Product[] products)
        {
            this.people = people;
            this.products = products;


            Name = name;
        
        
        }


        public void Print()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Shop: " + Name);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("-- People: --");
            foreach (Person person in people)
            {
                person.Print();
            }

            Console.WriteLine("-- Products: --");
            foreach (Product product in products)
            {
                product.Print();
            }
        }

    }


}
