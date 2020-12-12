using System;

namespace State
{
    class Program
    {
        static void Main(string[] args)
        {
            Car car = new Car();
            Console.WriteLine(car);

            car.StartEngine();
            Console.WriteLine(car);

            car.PushPedal();
            Console.WriteLine(car);

            car.PushPedal();
            Console.WriteLine(car);

            car.HitBreak();
            Console.WriteLine(car);

            car.PushPedal();
            Console.WriteLine(car);

            car.StopEngine();
            Console.WriteLine(car);

            car.StartEngine();
            Console.WriteLine(car);

            car.PushPedal();
            Console.WriteLine(car);

            car.HitBreak();
            Console.WriteLine(car);

            car.StopEngine();
            Console.WriteLine(car);
        }
    }

    class Car
    {
        private State state;

        public int Speed { get; set; }

        public Car()
        {
           state = new EngineStopped(this);
        }

        public void SetState(State state)
        {
            this.state = state;
        }

        public void StartEngine()
        {
            Console.WriteLine("Pushed engine start button");
            state.StartEngine();
        }

        public void PushPedal()
        {
            Console.WriteLine("Pushed pedal");
            state.PushPedal();
        }

        public void HitBreak()
        {
            Console.WriteLine("Hit break");
            state.HitBreak();
        }

        public void StopEngine()
        {
            Console.WriteLine("Pushed engine stop button");
            state.StopEngine();
        }

        public override string ToString()
        {
            return $"Car in state [{state}]. Speed [{Speed}]";
        }
    }

    abstract class State
    {
        protected Car car;

        protected State(Car car)
        {
            this.car = car;
        }

        public abstract void StartEngine();
        public abstract void PushPedal();
        public abstract void HitBreak();
        public abstract void StopEngine();
    }

    class EngineStopped : State
    {
        public EngineStopped(Car car) : base(car) { }

        public override void StartEngine()
        {
            car.SetState(new Stopped(car));
        }

        public override void PushPedal()
        {
            // do nothing
        }

        public override void HitBreak()
        {
            // do nothing
        }

        public override void StopEngine()
        {
            // do nothing
        }
    }

    class Driving : State
    {
        public Driving(Car car) : base(car) { }

        public override void StartEngine()
        {
            // do nothing
        }

        public override void PushPedal()
        {
            car.Speed += 10;
        }

        public override void HitBreak()
        {
            car.Speed = 0;
            car.SetState(new Stopped(car));
        }

        public override void StopEngine()
        {
            car.Speed = 0;
            car.SetState(new EngineStopped(car));
        }
    }

    class Stopped : State
    {
        public Stopped(Car car) : base(car) { }

        public override void StartEngine()
        {
            // do nothing
        }

        public override void PushPedal()
        {
            car.Speed += 10;
            car.SetState(new Driving(car));
        }

        public override void HitBreak()
        {
            // do nothing
        }

        public override void StopEngine()
        {
            car.SetState(new EngineStopped(car));
        }
    }
}
