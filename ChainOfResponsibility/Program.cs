using System;

namespace ChainOfResponsibility
{
    class Program
    {
        static void Main(string[] args)
        {
            Developer juniorDeveloper = new Junior();
            Developer middleDeveloper = new Middle();
            Developer seniorDeveloper = new Senior();
            Developer architectDeveloper = new Architect();

            juniorDeveloper.Next = middleDeveloper;
            middleDeveloper.Next = seniorDeveloper;
            seniorDeveloper.Next = architectDeveloper;

            IDeveloper chainStart = juniorDeveloper;

            var tasks = new[] { "Code class from UML diagram", 
                "Design and code module", 
                "Review junior's code", 
                "Design project structure", 
                "Write a project using JavaScript" };

            foreach (var task in tasks)
            {
                Console.WriteLine($"Task: {task}");
                chainStart.Handle(task);
                Console.WriteLine();
            }
        }
    }

    interface IDeveloper
    {
        void Handle(string task);
    }

    abstract class Developer : IDeveloper
    {
        public Developer Next { get; set; }

        public virtual void Handle(string task)
        {
            if (Next != null)
            {
                Next.Handle(task);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Nobody can handle the task :(");
                Console.ForegroundColor = ConsoleColor.Gray;
            }
        }
    }

    class Junior : Developer
    {
        public override void Handle(string task)
        {
            if (task == "Code class from UML diagram")
                Console.WriteLine("Developer handled the task.");
            else
            {
                Console.WriteLine("Developer can't handle the task.");
                base.Handle(task);
            }
        }
    }

    class Middle : Developer
    {
        public override void Handle(string task)
        {
            if(task == "Design and code module")
                Console.WriteLine("Middle handled the task.");
            else
            {
                Console.WriteLine("Middle can't handle the task.");
                base.Handle(task);
            }
        }
    }

    class Senior : Developer
    {
        public override void Handle(string task)
        {
            if(task == "Review junior's code")
                Console.WriteLine("Senior handled the task.");
            else
            {
                Console.WriteLine("Senior can't handle the task.");
                base.Handle(task);
            }
        }
    }

    class Architect : Developer
    {
        public override void Handle(string task)
        {
            if(task == "Design project structure")
                Console.WriteLine("Architect handled the task.");
            else
            {
                Console.WriteLine("Architect can't handle the task.");
                base.Handle(task);
            }
        }
    }
}
