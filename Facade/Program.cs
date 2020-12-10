using System;
using System.Threading;

namespace Facade
{
    class Program
    {
        static void Main(string[] args)
        {
            Manager manager = new Manager();
            manager.CreateProject();
        }
    }

    class Programmer
    {
        public void Pay()
        {
            Console.WriteLine("Salary is received.");
        }

        public void LearnStack()
        {
            Console.WriteLine("Learning required stack...");
            Thread.Sleep(500);
            Console.WriteLine("Required stack is learned.");
        }

        public void DesignProject()
        {
            Console.WriteLine("Design of the project is done.");
        }

        public void WriteCode()
        {
            Console.WriteLine("Coding...");
            Thread.Sleep(500);
            Console.WriteLine("Coding is successfully finished.");
        }

        public void TestCode()
        {
            Console.WriteLine($"Code is successfully tested: {new Random().Next(10)} bugs were found.");
        }

        public void Release()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Project is released.");
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }

    class Manager
    {
        public void CreateProject()
        {
            Programmer programmer = new Programmer();
            programmer.LearnStack();
            programmer.DesignProject();
            programmer.WriteCode();
            programmer.TestCode();
            programmer.Pay();
            programmer.Release();
        }
    }
}
