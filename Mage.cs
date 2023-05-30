using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Mage : Character, ISkill
    {
        public int Mana { get; set; }

        public Mage()
        {
            Mana = 100;
        }

        public Mage(string name, int health, int strength, int availablePoints, int mana)
            : base(name, health, strength, availablePoints)
        {
            Mana = mana;
        }

        public override void Attack(Character target)
        {
            if (Health <= 0)
            {
                Console.WriteLine($"{Name} is unable to attack as their Health is 0.");
                return;
            }

            int damage = Strength;

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

            Mana -= 20;
            AvailablePoints--;
            Console.WriteLine($"{Name} used a skill. Mana decreased by 20. Available points: {AvailablePoints}");
        }


    }
}
