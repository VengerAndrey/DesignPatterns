using System;
using System.Collections.Generic;

namespace Observer
{
    class Program
    {
        static void Main(string[] args)
        {
            WeatherStation station = new WeatherStation();

            station.Subscribe(new Gismeteo());
            station.Subscribe(new StreetWeatherStand());
            station.Subscribe(new WeatherForecast());

            station.Notify(new WeatherInfo() {Temperature = 30, WindSpeed = 2});
            Console.WriteLine("----------------------------------------------------\n");
            station.Notify(new WeatherInfo() {Temperature = -5, WindSpeed = 12});
        }
    }

    struct WeatherInfo
    {
        public int Temperature { get; set; }
        public int WindSpeed { get; set; }
    }

    interface IObserver
    {
        void Update(WeatherInfo info);
    }

    class WeatherStation
    {
        private List<IObserver> observers = new List<IObserver>();

        public void Subscribe(IObserver observer)
        {
            observers.Add(observer);
        }

        public void Notify(WeatherInfo info)
        {
            foreach (var observer in observers)
            {
                observer.Update(info);
            }
        }
    }

    class Gismeteo : IObserver
    {
        public void Update(WeatherInfo info)
        {
            Console.WriteLine($"Gismeteo website: Temperature [{info.Temperature}], Wind speed [{info.WindSpeed}]\n");
        }
    }

    class StreetWeatherStand : IObserver
    {
        public void Update(WeatherInfo info)
        {
            Console.WriteLine("--- Street stand ---");
            Console.WriteLine($"Temperature: {info.Temperature}");
            Console.WriteLine($"Wind speed: {info.WindSpeed}");
            Console.WriteLine("--------------------");
            Console.WriteLine("          |         ");
            Console.WriteLine();
        }
    }

    class WeatherForecast : IObserver
    {
        public void Update(WeatherInfo info)
        {
            Console.Write("Weather forecast: ");
            if(info.Temperature < 10)
                Console.Write("Cold");
            else if(info.Temperature < 25)
                Console.Write("Warm");
            else
                Console.Write("Hot");

            Console.Write(" and ");
            if(info.WindSpeed < 5)
                Console.WriteLine("Windless");
            else
                Console.WriteLine("Windy");

            Console.WriteLine();
        }
    }
}
