using System;
using System.Collections.Generic;
using System.Text;

namespace lab_2_zadanie
{
    public class Buyer : Person
    {

        private List<Product> tasks = new List<Product>();

        public Buyer(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public void AddProduct(Product product)
        {
            tasks.Add(product);
        }

        public void RemoweProduct(int index)
        {
            tasks.Remove(tasks[index]);


        }

        public override void Print()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("        Buyer: ");
            Console.ForegroundColor = ConsoleColor.White;
            base.Print();
            if (tasks.Count >0)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("               -- Products: --");
                Console.ForegroundColor = ConsoleColor.White;
                foreach (Product product in tasks)
                {
                    Console.Write("               ");
                    product.Print();
                }
            }
        }
    }
}
