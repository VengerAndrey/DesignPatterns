using System;
using System.Collections.Generic;

namespace Prototype
{
    class Program
    {
        static void Main(string[] args)
        {
            var p1 = new Person("Andrey", 17, new Dog("Tuzik", 3));
            p1.Print();

            var p2 = p1.ShallowCopy();

            var p3 = p1.DeepCopy();

            p1.Dog.Name = "123";

            Console.WriteLine("Shallow copy doesn't properly copy inner reference types (except String)!");
            p2.Print();

            Console.WriteLine("Deep copy properly copy inner reference types.");
            p3.Print();

            Console.WriteLine();
            Console.WriteLine("Prototype registry usage");
            Console.WriteLine();

            var registry = new PersonRegistry();

            registry.Add(1, new Person("Alex", 30, new Dog("Ralf", 5)));
            registry.Add(2, new Person("Dasha", 20, new Dog("Barni", 4)));
            registry.Add(3, new Person("Egor", 15, new Dog("Bobik", 8)));

            var p4 = registry.GetById(1);
            var p5 = registry.GetById(1);

            p5.Print();

            p4.Dog.Name = "something else";

            Console.WriteLine("Clones from registry are not connected to each other.");
            p5.Print();
        }
    }

    class Dog
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public Dog(string name, int age)
        {
            Name = name;
            Age = age;
        }
    }

    class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public Dog Dog { get; set; }

        public Person(string name, int age, Dog dog)
        {
            Name = name;
            Age = age;
            Dog = dog;
        }

        public Person ShallowCopy()
        {
            return (Person) MemberwiseClone();
        }

        public Person DeepCopy()
        {
            Person clone = ShallowCopy();
            clone.Dog = new Dog(Dog.Name, Dog.Age);
            return clone;
        }

        public void Print()
        {
            Console.WriteLine("---------------------------");
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Age: {Age}");
            Console.WriteLine($"Dog name: {Dog.Name}");
            Console.WriteLine($"Dog age: {Dog.Age}");
            Console.WriteLine("---------------------------");
        }
    }

    class PersonRegistry
    {
        private Dictionary<int, Person> registry = new Dictionary<int, Person>();

        public void Add(int id, Person person)
        {
            registry.Add(id, person);
        }

        public Person GetById(int id)
        {
            if (registry.ContainsKey(id))
            {
                return registry[id].DeepCopy();
            }
            throw new ArgumentOutOfRangeException();
        }
    }
}
