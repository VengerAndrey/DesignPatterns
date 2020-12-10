using System;

namespace Decorator
{
    class Program
    {
        static void Main(string[] args)
        {
            Pizza pizza = new HawaiianPizza();
            Console.WriteLine("Standard pizza");
            Print(pizza);

            pizza = new CheeseDecorator(pizza);
            Console.WriteLine("Decorated with CheeseDecorator");
            Print(pizza);

            pizza = new HamDecorator(pizza);
            Console.WriteLine("Decorated with HamDecorator");
            Print(pizza);

            pizza = new CheeseDecorator(pizza);
            Console.WriteLine("Decorated with CheeseDecorator");
            Print(pizza);
        }

        static void Print(Pizza pizza)
        {
            Console.WriteLine("--------------------------");
            Console.WriteLine(pizza);
            Console.WriteLine("--------------------------");
            Console.WriteLine();
        }
    }
}

abstract class Pizza
{
    public string Name { get; set; }

    public override string ToString()
    {
        return $"Pizza \"{Name}\"";
    }
}

class HawaiianPizza : Pizza
{
    public HawaiianPizza()
    {
        Name = "Hawaiian";
    }
}

abstract class PizzaDecorator : Pizza
{
    protected Pizza pizza;

    protected PizzaDecorator(Pizza pizza)
    {
        this.pizza = pizza;
    }
}

class CheeseDecorator : PizzaDecorator
{
    public CheeseDecorator(Pizza pizza) : base(pizza) { }

    public override string ToString()
    {
        return pizza.ToString() + "\nwith cheese";
    }
}

class HamDecorator : PizzaDecorator
{
    public HamDecorator(Pizza pizza) : base(pizza) { }

    public override string ToString()
    {
        return pizza.ToString() + "\nwith ham";
    }
}