using System;

namespace lab2
{
	public class Person
	{
        private string name;
        private int age;

        protected string Name { get => name; set => name = value; }
        protected int Age { get => age; set => age = value; }

        public Person(string name, int age)
		{
			this.Name = name;
			this.Age = age;
		}

		public Person() { }

		public override string ToString()
		{
			return "Person: " + Name + " " + Age;
		}

        public override bool Equals(object obj)
        {
            return obj is Person person &&
                   name == person.name &&
                   age == person.age;
        }

        
    }
}
