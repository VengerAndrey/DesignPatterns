using System;
using System.Collections.Generic;
using System.Threading;

namespace Mediator
{
    class Program
    {
        static void Main(string[] args)
        {
            IAirTrafficController airTrafficController = new AirTrafficController();

            Plane boeing = new Boeing(airTrafficController);
            Plane airbus = new Airbus(airTrafficController);
            Plane superJet = new SuperJet(airTrafficController);

            boeing.SendMessage("Landing request");

            airbus.SendMessage("Landing request");
        }
    }

    interface IAirTrafficController
    {
        void Register(Plane plane);
        void Notify(string message, Plane sender);
    }

    class AirTrafficController : IAirTrafficController
    {
        private List<Plane> planes = new List<Plane>();

        public void Register(Plane plane)
        {
            planes.Add(plane);
        }

        public void Notify(string message, Plane sender)
        {
            if (message == "Landing request")
            {
                Console.WriteLine($"Plane {sender.Name} is requesting landing");
                
                foreach (var plane in planes)
                {
                    if(plane != sender)
                        plane.ReceiveMessage("Landing blocked");
                    else
                        plane.ReceiveMessage("Landing opened");
                }

                Console.WriteLine();

                Thread.Sleep(1000);

                Console.WriteLine($"Plane {sender.Name} landed");
                foreach (var plane in planes)
                {
                    plane.ReceiveMessage("Landing opened");
                }

                Console.WriteLine();
            }
        }
    }

    abstract class Plane
    {
        public string Name { get; set; }

        protected bool landingAvailable = true;

        private IAirTrafficController mediator;

        protected Plane(IAirTrafficController mediator)
        {
            this.mediator = mediator;
            mediator.Register(this);
        }

        public void SendMessage(string message)
        {
            mediator.Notify(message, this);
        }

        public void ReceiveMessage(string message)
        {
            if (message == "Landing blocked")
            {
                landingAvailable = false;
            }
            else if (message == "Landing opened")
            {
                landingAvailable = true;
            }

            Console.WriteLine($"Plane {Name} landing status: " + (landingAvailable ? "opened" : "blocked"));
        }
    }

    class Boeing : Plane
    {
        public Boeing(IAirTrafficController mediator) : base(mediator)
        {
            Name = "Boeing";
        }
    }

    class Airbus : Plane
    {
        public Airbus(IAirTrafficController mediator) : base(mediator)
        {
            Name = "Airbus";
        }
    }

    class SuperJet : Plane
    {
        public SuperJet(IAirTrafficController mediator) : base(mediator)
        {
            Name = "SuperJet";
        }
    }
}
