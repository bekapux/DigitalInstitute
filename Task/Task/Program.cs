using System.Buffers.Text;
using System.Collections;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Reflection.Metadata;
using static System.Net.Mime.MediaTypeNames;
using System.Runtime.Intrinsics.X86;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace Task
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--Welcome to World Of Sharpcraft--");
          
        }
    }


    abstract class Character
    {
        private string _name;
        private int _health;
        private int _strength;
        private int _availablepoints;


        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                if(!string.IsNullOrEmpty(value))
                {
                    _name = value;
                }
                else
                {
                    throw new ArgumentException();
                }
            }
        }

        public int Health
        {
            get
            {
                return _health;
            }
            set
            {
                if (value >= 0 && value <= _availablepoints - _strength){
                    _health = value;
                }
                else
                {
                    throw new ArgumentException();
                }
            }
        }

        public int Strength
        {
            get
            {
                return _strength;
            }
            set
            {
                if (value >= 0 && value <= _availablepoints - _health)
                {
                    _strength = value;
                }
                else
                {
                    throw new ArgumentException();
                }
            }
        }

        public int Availablepoints
        {
            get
            {
                return _availablepoints;
            }
            set
            {
                if (value >= 0 && _health + _strength <= value)
                {
                    _availablepoints = value;
                }
                else
                {
                    throw new ArgumentException();
                }
            }
        }


        public Character(string name, int health, int strength, int availablepoints)
        {
            Name = name;
            Health = health;
            Strength = strength;
            Availablepoints = availablepoints;
        }

        public Character()
        {
            Name = "NOOB";
            Health = 3;
            Strength = 2;
            Availablepoints = 5;
        }

        public virtual void Attack(Character C)
        {

        }

        public virtual void Stats()
        {

        }

    }

    class Warrior : Character, Iskill
    {
        private int _armor;
        private int SkillUseCount = 1;

        public int Armor
        {
            get
            {
                return _armor;  
            }
            set
            {
                if(value >= 0 && value <= 100)
                {
                    _armor = value;
                }
            }
        }

        public Warrior(string name, int health, int strength, int availablepoints, int armor) : base(name, health, strength, availablepoints)
        {
            Armor = armor;
        }

        public Warrior() : base() 
        {
            Armor = 1;
        }

        
        public override void Attack(Character C)
        {
            if (Health <= 0)
            {
                Console.WriteLine("Can not attack while health is 0");
            }
            else
            {
                //bonus damage doubled          
                if (Armor >= 20)
                {
                    C.Health = C.Health - Strength/5 * 2;
                    Console.WriteLine($"you did {Strength * 2} damage to {C.Name}");
                }
                //default damage
                else
                {
                    C.Health = C.Health - Strength/5;
                    Console.WriteLine($"you did {Strength} damage to {C.Name}");
                }
            }
        }
        //increases available points to increase attack and armor, you can use it only 3 times
        public void UseSkill()
        {
            if(SkillUseCount > 3)
            {
                Console.WriteLine("You already used your skill move 3 times");
            }
            else
            {
                Availablepoints += 10;
                Armor += 5;
                Health += 5;
                Console.WriteLine($"Your armor increased by 5 points and strength by 5. Skill used: {SkillUseCount} times. {3 - SkillUseCount} uses left");
            }
            SkillUseCount++;
        }

        public override void Stats()
        {
            Console.WriteLine("Your Stats Now:");
            Console.WriteLine($"Health : {Health} Strength : {Strength} Armor : {Armor}");
        }
    }

    class Mage : Character, Iskill
    {
        private int _mana;
        private int SkillUseCount;

        public int Mana
        {
            get
            {
                return _mana;
            }
            set
            {
                if (value >= 0 && value <= 100)
                {
                    _mana = value;
                }
                else
                {
                    throw new ArgumentException();
                }
            }
        }

            public Mage(string name, int health, int strength, int availablepoints, int mana) : base(name, health, strength, availablepoints)
        {
            _mana = mana;
        }

        public Mage() : base()
        {
            _mana = 5;
        }

        //Mage's ability to attack costs 10 mana
        public override void Attack(Character C)
        {
            if (Health <= 0)
            {
                Console.WriteLine("Can not attack while health is 0");
            }
            else
            {
                if (Mana < 10)
                {
                    Console.WriteLine("Not enough mana");
                }
                else
                {
                    Mana = Mana - 10;
                    C.Health = C.Health - Strength/5;
                    Console.WriteLine($"you did {Strength/5} damage to {C.Name}");
                }
            }
        }
        // for mage +15 availablepoints, 10 mana 5 strength
        public void UseSkill()
        {
            if (SkillUseCount > 3)
            {
                Console.WriteLine("You already used your skill move 3 times");
            }
            else
            {
                Availablepoints += 15;
                Mana += 10;
                Strength += 5;
                Console.WriteLine($"Your mana increased by 10 points and strength by 5. Skill used: {SkillUseCount} times. {3 - SkillUseCount} uses left");
            }
            SkillUseCount++;
        }

        public override void Stats()
        {
            Console.WriteLine("Your Stats Now:");
            Console.WriteLine($"Health : {Health} Strength : {Strength} Mana : {Mana}");
        }
    }
    interface Iskill
    {
        void UseSkill();
    }
}
