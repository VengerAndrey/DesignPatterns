using System;

namespace Command
{
    class Program
    {
        static void Main(string[] args)
        {
            Car car = new Car();
            Driver driver = new Driver(car);

            driver.PressStartButton();

            driver.PressDrivePedal();

            driver.PressBreaks();

            driver.PressDrivePedal();

            driver.PressStopButton();
        }
    }

    class Car
    {
        public void StartEngine()
        {
            Console.WriteLine("Engine started.");
        }

        public void Drive()
        {
            Console.WriteLine("Driving...");
        }

        public void Stop()
        {
            Console.WriteLine("Stopped.");
        }

        public void StopEngine()
        {
            Console.WriteLine("Engine stopped.");
        }
    }

    abstract class CarCommand
    {
        protected Car car;

        protected CarCommand(Car car)
        {
            this.car = car;
        }

        public abstract void Execute();
    }

    class StartEngine : CarCommand
    {
        public StartEngine(Car car) : base(car) { }

        public override void Execute()
        {
            car.StartEngine();
        }
    }

    class Drive : CarCommand
    {
        public Drive(Car car) : base(car) { }

        public override void Execute()
        {
            car.Drive();
        }
    }

    class Stop : CarCommand
    {
        public Stop(Car car) : base(car) { }

        public override void Execute()
        {
            car.Stop();
        }
    }

    class StopEngine : CarCommand
    {
        public StopEngine(Car car) : base(car) { }

        public override void Execute()
        {
            car.StopEngine();
        }
    }

    class Driver
    {
        private Car car;

        public Driver(Car car)
        {
            this.car = car;
        }

        public void PressStartButton()
        {
            new StartEngine(car).Execute();
        }

        public void PressStopButton()
        {
            new Stop(car).Execute();
            new StopEngine(car).Execute();
        }

        public void PressDrivePedal()
        {
            new Drive(car).Execute();
        }

        public void PressBreaks()
        {
            new Stop(car).Execute();
        }
    }
}
