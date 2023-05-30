using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Warrior : Character, ISkill
    {
        public int Armor { get; set; }

        public Warrior()
        {
            Armor = 0;
        }

        public Warrior(string name, int health, int strength, int availablePoints, int armor)
            : base(name, health, strength, availablePoints)
        {
            Armor = armor;
        }

        public override void Attack(Character target)
        {
            if (Health <= 0)
            {
                Console.WriteLine($"{Name} is unable to attack as their Health is 0.");
                return;
            }

            int damage = Strength;

            if (Armor > 50)
            {
                damage += 10; // Bonus damage if Armor is above 50
            }

            target.Health -= damage;
            Console.WriteLine($"{Name} attacked {target.Name} for {damage} damage.");
        }

        public void UseSkill()
        {
            if (AvailablePoints <= 0)
            {
                Console.WriteLine($"{Name} does not have any available points to use the skill.");
                return;
            }

            Armor += 10;
            AvailablePoints--;
            Console.WriteLine($"{Name} used a skill. Armor increased by 10. Available points: {AvailablePoints}");
        }
    }
}
