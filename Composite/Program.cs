using System;
using System.Collections.Generic;

namespace Composite
{
    class Program
    {
        static void Main(string[] args)
        {
            Team team = new Team();
            team.Add(new Developer("Max"));
            team.Add(new Developer("Alex"));

            Team outerTeam = new Team();
            outerTeam.Add(team);
            outerTeam.Add(new Developer("Andrey"));

            IDeveloper developer = outerTeam;

            developer.Develop();
            Console.WriteLine();

            /* tests for composite + visitor

            developer.Accept(new AddingVisitor("Additional developer"));

            developer.Develop();
            */
        }
    }

    interface IDeveloper
    {
        void Develop();
    }

    class Developer : IDeveloper
    {
        public string Name { get; }

        public Developer(string name)
        {
            Name = name;
        }

        public void Develop()
        {
            Console.WriteLine($"Developer {Name} writes code.");
        }
    }

    class Team : IDeveloper
    {
        private List<IDeveloper> developers = new List<IDeveloper>();

        public void Add(IDeveloper developer)
        {
            developers.Add(developer);
        }

        public void Develop()
        {
            foreach (var developer in developers)
            {
                developer.Develop();
            }
        }
    }

    /* Composite + Visitor 

    interface IDeveloper
    {
        void Develop();
        void Accept(IDeveloperVisitor visitor);
    }

    interface IDeveloperVisitor
    {
        void Visit(Developer developer);
        void Visit(Team team);
    }

    class AddingVisitor : IDeveloperVisitor
    {
        private string name;

        public AddingVisitor(string name)
        {
            this.name = name;
        }

        public void Visit(Developer developer)
        {
            // do nothing
        }

        public void Visit(Team team)
        {
            team.Add(new Developer(name));
        }
    }

    class Developer : IDeveloper
    {
        public string Name { get; }

        public Developer(string name)
        {
            Name = name;
        }

        public void Develop()
        {
            Console.WriteLine($"Developer {Name} writes code.");
        }

        public void Accept(IDeveloperVisitor visitor)
        {
            visitor.Visit(this);
        }
    }

    class Team : IDeveloper
    {
        private List<IDeveloper> developers = new List<IDeveloper>();

        public void Add(IDeveloper developer)
        {
            developers.Add(developer);
        }

        public void Develop()
        {
            foreach (var developer in developers)
            {
                developer.Develop();
            }
        }

        public void Accept(IDeveloperVisitor visitor)
        {
            visitor.Visit(this);
            foreach (var developer in developers)
            {
                developer.Accept(visitor);
            }
        }
    }

    */
}
