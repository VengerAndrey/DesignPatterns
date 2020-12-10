using System;

namespace Bridge
{
    class Program
    {
        static void Main(string[] args)
        {
            Project[] projects = {new AndroidApplication(new KotlinDeveloper()), new UnityGame(new CSharpDeveloper())};
            foreach (var project in projects)
            {
                project.Develop();
            }
        }
    }

    interface IDeveloper
    {
        void Code();
    }

    abstract class Project
    {
        protected IDeveloper developer;

        protected Project(IDeveloper developer)
        {
            this.developer = developer;
        }

        public abstract void Develop();
    }

    class KotlinDeveloper : IDeveloper
    {
        public void Code()
        {
            Console.WriteLine("Kotlin developer writes code...");
        }
    }

    class CSharpDeveloper : IDeveloper
    {
        public void Code()
        {
            Console.WriteLine("C# developer writes code");
        }
    }

    class AndroidApplication : Project
    {
        public AndroidApplication(IDeveloper developer) : base(developer) { }

        public override void Develop()
        {
            Console.WriteLine("Android application development started.");
            developer.Code();
            Console.WriteLine();
        }
    }

    class UnityGame : Project
    {
        public UnityGame(IDeveloper developer) : base(developer) { }

        public override void Develop()
        {
            Console.WriteLine("Unity game development started.");
            developer.Code();
            Console.WriteLine();
        }
    }
}
