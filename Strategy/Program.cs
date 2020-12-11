using System;

namespace Strategy
{
    class Program
    {
        static void Main(string[] args)
        {
            Warrior warrior = new Warrior();

            warrior.UseWeapon();

            warrior.Weapon = new Knife();
            warrior.UseWeapon();

            warrior.Weapon = new Pistol();
            warrior.UseWeapon();

            warrior.Weapon = new Grenade();
            warrior.UseWeapon();
        }
    }

    interface IWeapon
    {
        void Attack();
    }

    class Warrior
    {
        public IWeapon Weapon { get; set; }

        public void UseWeapon()
        {
            if(Weapon != null)
                Weapon.Attack();
            else
                Console.WriteLine("No weapon to use!");
        }
    }

    class Knife : IWeapon
    {
        public void Attack()
        {
            Console.WriteLine($"Attacking using knife. DMG: {new Random().Next(10)}");
        }
    }

    class Pistol : IWeapon
    {
        public void Attack()
        {
            Console.WriteLine($"Attacking using pistol. DMG: {new Random().Next(50) + 20}");
        }
    }
    
    class Grenade : IWeapon
    {
        public void Attack()
        {
            Console.WriteLine($"Attacking using grenade. DMG: {new Random().Next(100) + 50}");
        }
    }
}
