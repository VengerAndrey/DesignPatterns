using System;

namespace TemplateMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            Meal breakfast = new Breakfast();
            Console.WriteLine($"Breakfast: {breakfast.GetMeal()}\n");

            Meal lunch = new Lunch();
            Console.WriteLine($"Lunch: {lunch.GetMeal()}\n");

            Meal dinner = new Dinner();
            Console.WriteLine($"Dinner: {dinner.GetMeal()}\n");
        }
    }

    abstract class Meal
    {
        public string GetMeal()
        {
            var meal = "";

            meal += GetMainCourse();
            meal += GetSecondCourse();
            meal += GetDrink();
            meal += GetDessert();

            return meal;
        }

        protected abstract string GetMainCourse();

        protected abstract string GetSecondCourse();

        private string GetDrink()
        {
            return "\nSimple drink";
        }

        private string GetDessert()
        {
            return "\nDelicious dessert";
        }
    }

    class Breakfast : Meal
    {
        protected override string GetMainCourse()
        {
            return "\nOmelet with ham";
        }

        protected override string GetSecondCourse()
        {
            return "";
        }
    }

    class Lunch : Meal
    {
        protected override string GetMainCourse()
        {
            return "\nCheese cream soup";
        }

        protected override string GetSecondCourse()
        {
            return "\nBeef steak with cranberry sauce";
        }
    }

    class Dinner : Meal
    {
        protected override string GetMainCourse()
        {
            return "\nRice with chicken wings";
        }

        protected override string GetSecondCourse()
        {
            return "\nCaesar salad";
        }
    }
}
