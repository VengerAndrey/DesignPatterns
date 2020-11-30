using System;

namespace Singleton
{
    class Program
    {
        static void Main(string[] args)
        {
            Singleton instance = Singleton.GetInstance();
            instance.Test();

            Singleton.GetInstance().Test();
        }
    }

    class Singleton
    {
        private static Singleton instance;

        private Singleton()
        {

        }

        public static Singleton GetInstance()
        {
            if (instance == null)
            {
                Console.WriteLine("Initialization of local static field");
                instance = new Singleton();
            }

            return instance;
        }

        public void Test()
        {
            Console.WriteLine("Testing from singleton...");
        }
    }
}