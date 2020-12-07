using System;

namespace FactoryMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            TransportFactory currentFactory;
            Transport currentTransport;

            currentFactory = new TruckFactory();
            currentTransport = currentFactory.CreateTransport();
            currentTransport.Deliver();

            currentFactory = new ShipFactory();
            currentTransport = currentFactory.CreateTransport();
            currentTransport.Deliver();

            currentFactory = new PlaneFactory();
            currentTransport = currentFactory.CreateTransport();
            currentTransport.Deliver();
        }
    }

    abstract class Transport
    {
        public abstract void Deliver();
    }

    class Truck : Transport
    {
        public override void Deliver()
        {
            Console.WriteLine("Truck is delivering something...");
        }
    }

    class Ship : Transport
    {
        public override void Deliver()
        {
            Console.WriteLine("Ship is delivering something...");
        }
    }

    class Plane : Transport
    {
        public override void Deliver()
        {
            Console.WriteLine("Plane is delivering something...");
        }
    }

    abstract class TransportFactory
    {
        public abstract Transport CreateTransport();
    }

    class TruckFactory : TransportFactory
    {
        public override Transport CreateTransport()
        {
            return new Truck();
        }
    }

    class ShipFactory : TransportFactory
    {
        public override Transport CreateTransport()
        {
            return new Ship();
        }
    }

    class PlaneFactory : TransportFactory
    {
        public override Transport CreateTransport()
        {
            return new Plane();
        }
    }
}