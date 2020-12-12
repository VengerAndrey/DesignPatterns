using System;
using System.Collections.Generic;

namespace Memento
{
    class Program
    {
        static void Main(string[] args)
        {
            Caretaker caretaker = new Caretaker();

            Originator originator = new Originator(new Laptop("Acer Nitro 5", 15.6, "Intel Core i5"));
            Console.WriteLine(originator);

            caretaker.AddMemento(originator.Save());

            originator.SetLaptop(new Laptop("Apple MacBook 2020", 17, "Apple M1"));
            Console.WriteLine(originator);

            caretaker.AddMemento(originator.Save());

            originator.Restore(caretaker.GetMemento(0));
            Console.WriteLine(originator);
        }
    }

    class Laptop
    {
        private string model;
        private double inches;
        private string CPU;

        public Laptop(string model, double inches, string cpu)
        {
            this.model = model;
            this.inches = inches;
            CPU = cpu;
        }

        public override string ToString()
        {
            return $"Laptop: Model [{model}], Inches [{inches}], CPU [{CPU}]";
        }
    }

    class Originator
    {
        private Laptop laptop;

        public Originator(Laptop laptop)
        {
            this.laptop = laptop;
        }

        public void SetLaptop(Laptop laptop)
        {
            this.laptop = laptop;
        }

        public Memento Save()
        {
            return new Memento(laptop);
        }

        public void Restore(Memento memento)
        {
            laptop = memento.Laptop;
        }

        public override string ToString()
        {
            return "Originator contains " + laptop.ToString();
        }
    }

    class Memento
    {
        public Laptop Laptop { get; private set; }

        public Memento(Laptop laptop)
        {
            Laptop = laptop;
        }
    }

    class Caretaker
    {
        private List<Memento> mementoes = new List<Memento>();

        public void AddMemento(Memento memento)
        {
            mementoes.Add(memento);
        }

        public Memento GetMemento(int index)
        {
            return mementoes[index];
        }

        public int GetCount()
        {
            return mementoes.Count;
        }
    }
}
