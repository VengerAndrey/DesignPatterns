using System;

namespace AbstractFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Building the car...");
            BuildVehicle(new CarFactory());

            Console.WriteLine();

            Console.WriteLine("Building the plane...");
            BuildVehicle(new PlaneFactory());
        }

        static void BuildVehicle(IVehicleFactory factory)
        {
            Engine engine = factory.CreateEngine();
            InnerPart innerPart = factory.CreateInnerPart();
            OuterPart outerPart = factory.CreateOuterPart();

            engine.CheckEngine();
            innerPart.CheckInnerPart();
            outerPart.CheckOuterPart();
        }
    }

    abstract class Engine
    {
        public abstract void CheckEngine();
    }

    abstract class InnerPart
    {
        public abstract void CheckInnerPart();
    }

    abstract class OuterPart
    {
        public abstract void CheckOuterPart();
    }

    class CarEngine : Engine
    {
        public override void CheckEngine()
        {
            Console.WriteLine("Car engine is working.");
        }
    }

    class CarInnerPart : InnerPart
    {
        public override void CheckInnerPart()
        {
            Console.WriteLine("Car inner part is working.");
        }
    }

    class CarOuterPart : OuterPart
    {
        public override void CheckOuterPart()
        {
            Console.WriteLine("Car outer part is working.");
        }
    }

    class PlaneEngine : Engine
    {
        public override void CheckEngine()
        {
            Console.WriteLine("Plane engine is working.");
        }
    }

    class PlaneInnerPart : InnerPart
    {
        public override void CheckInnerPart()
        {
            Console.WriteLine("Plane inner part is working.");
        }
    }

    class PlaneOuterPart : OuterPart
    {
        public override void CheckOuterPart()
        {
            Console.WriteLine("Plane outer part is working.");
        }
    }

    interface IVehicleFactory
    {
        Engine CreateEngine();
        InnerPart CreateInnerPart();
        OuterPart CreateOuterPart();
    }

    class CarFactory : IVehicleFactory
    {
        public Engine CreateEngine()
        {
            return new CarEngine();
        }

        public InnerPart CreateInnerPart()
        {
            return new CarInnerPart();
        }

        public OuterPart CreateOuterPart()
        {
            return new CarOuterPart();
        }
    }

    class PlaneFactory : IVehicleFactory
    {
        public Engine CreateEngine()
        {
            return new PlaneEngine();
        }

        public InnerPart CreateInnerPart()
        {
            return new PlaneInnerPart();
        }

        public OuterPart CreateOuterPart()
        {
            return new PlaneOuterPart();
        }
    }
}
