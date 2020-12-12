using System;
using System.Collections.Generic;

namespace Visitor
{
    class Program
    {
        static void Main(string[] args)
        {
            List<IEntity> entities = new List<IEntity>();

            Group group = new Group();
            group.Add(new Warrior());
            group.Add(new Mage());

            entities.Add(new Warrior());
            entities.Add(group);
            entities.Add(new Mage());

            Console.WriteLine("Start:\n");

            foreach (var entity in entities)
            {
                entity.Print();
            }

            Console.WriteLine("\nBuffVisitor:\n");

            foreach (var entity in entities)
            {
                entity.Accept(new BuffVisitor());
                entity.Print();
            }

            Console.WriteLine("\nAddingVisitor:\n");

            foreach (var entity in entities)
            {
                entity.Accept(new AddingVisitor());
                entity.Print();
            }
        }
    }

    interface IEntity
    {
        void Print();
        void Accept(IEntityVisitor visitor);
    }

    interface IEntityVisitor
    {
        void Visit(Warrior warrior);
        void Visit(Mage mage);
        void Visit(Group group);
    }

    class Warrior : IEntity
    {
        public int Strength { get; set; } = 10;

        public void Print()
        {
            Console.WriteLine($"I'm a warrior. Strength: {Strength}");
        }

        public void Accept(IEntityVisitor visitor)
        {
            visitor.Visit(this);
        }
    }

    class Mage : IEntity
    {
        public int Intellect { get; set; } = 5;

        public void Print()
        {
            Console.WriteLine($"I'm a mage. Intellect: {Intellect}");
        }

        public void Accept(IEntityVisitor visitor)
        {
            visitor.Visit(this);
        }
    }

    class Group : IEntity
    {
        private List<IEntity> entities = new List<IEntity>();

        public void Print()
        {
            Console.WriteLine("---- Group ----");
            foreach (var entity in entities)
            {
                entity.Print();
            }
            Console.WriteLine("---------------");
        }

        public void Accept(IEntityVisitor visitor)
        {
            visitor.Visit(this);
            foreach (var entity in entities)
            {
                entity.Accept(visitor);
            }
        }

        public void Add(IEntity entity)
        {
            entities.Add(entity);
        }
    }

    class BuffVisitor : IEntityVisitor
    {
        public void Visit(Warrior warrior)
        {
            warrior.Strength *= 2;
        }

        public void Visit(Mage mage)
        {
            mage.Intellect *= 2;
        }

        public void Visit(Group group)
        {
            // do nothing
        }
    }

    class AddingVisitor : IEntityVisitor
    {
        public void Visit(Warrior warrior)
        {
            // do nothing
        }

        public void Visit(Mage mage)
        {
            // do nothing
        }

        public void Visit(Group group)
        {
            group.Add(new Warrior());
            group.Add(new Mage());
        }
    }
}
