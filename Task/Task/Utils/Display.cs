using Task.Models;
using Task.Enums;

namespace Task.Utils
{
    public static class Display
    {

        public static void FullInfo(Character character)
        {
            CharacterInfo(character);
            StatInfo(character);
        }

        public static void CharacterInfo(Character character)
        {
            Console.WriteLine(new string('-', 20));
            Console.WriteLine($"[{character.Name} info]");
            printStatPretty(nameof(character.Name), character.Name);
            printStatPretty(nameof(character.Race), character.Race);
            printStatPretty(nameof(character.Class), character.Class);
            printStatPretty(nameof(character.Status), character.Status);
        }

        public static void StatInfo(Character character)
        {
            Console.WriteLine(new string('-', 20));
            Console.WriteLine($"[{character.Name} stats]");
            printStatPretty(nameof(character.Health), character.Health.CurrentValue, character.Health.MaxValue);
            printStatPretty(nameof(character.Resource), character.Resource.CurrentValue, character.Resource.MaxValue);
            printStatPretty(nameof(character.Armor), character.Armor.CurrentValue);
            printStatPretty(nameof(character.MagicResist), character.MagicResist.CurrentValue);
            printStatPretty(nameof(character.Strength), character.Strength.CurrentValue);
            printStatPretty(nameof(character.Dexterity), character.Dexterity.CurrentValue);
            printStatPretty(nameof(character.Intelligence), character.Intelligence.CurrentValue);
            printStatPretty(nameof(character.Faith), character.Faith.CurrentValue);
        }

        public static void LevelUpStatInfo(Character character)
        {
            Console.WriteLine(new string('-', 20));
            Console.WriteLine($"[{character.Name} stats]");
            printStatPretty("1."+nameof(character.Health), character.Health.CurrentValue, character.Health.MaxValue);
            printStatPretty("2." + nameof(character.Resource), character.Resource.CurrentValue, character.Resource.MaxValue);
            printStatPretty("3." + nameof(character.Armor), character.Armor.CurrentValue);
            printStatPretty("4." + nameof(character.MagicResist), character.MagicResist.CurrentValue);
            printStatPretty("5." + nameof(character.Strength), character.Strength.CurrentValue);
            printStatPretty("6." + nameof(character.Dexterity), character.Dexterity.CurrentValue);
            printStatPretty("7." + nameof(character.Intelligence), character.Intelligence.CurrentValue);
            printStatPretty("8." + nameof(character.Faith), character.Faith.CurrentValue);

            Console.Write($"Select which stat to level up (1-8): ");
        }

        public static void chooseStatToLevelUp(Character character)
        {
            LevelUpStatInfo(character);
            int choice = int.Parse(Console.ReadLine());
            switch(choice)
            {
                case 1: 
                    character.Health.MaxValue++;
                    character.Health.CurrentValue++; break;
                case 2: 
                    character.Resource.MaxValue++;
                    character.Resource.CurrentValue++; break;
                case 3: 
                    character.Armor.MaxValue++;
                    character.Armor.CurrentValue++; break;
                case 4: 
                    character.MagicResist.MaxValue++;
                    character.MagicResist.CurrentValue++; break;
                case 5: 
                    character.Strength.MaxValue++;
                    character.Strength.CurrentValue++; break;
                case 6: 
                    character.Dexterity.MaxValue++;
                    character.Dexterity.CurrentValue++; break;
                case 7: 
                    character.Intelligence.MaxValue++;
                    character.Intelligence.CurrentValue++; break;
                case 8: 
                    character.Faith.MaxValue++;
                    character.Faith.CurrentValue++; break;
                default:
                    break;

            }
        }

        public static int ChooseElement(Character character)
        {
            Console.WriteLine($"[{character.Name} available elements]");
            printStatPretty("1." + nameof(Elements.Fire), "(Deals bonus burn damage to target)");
            printStatPretty("2." + nameof(Elements.Ice), "(Stuns target making them unable to attack)");
            printStatPretty("3." + nameof(Elements.Electricity), "(Deals high damage, pierces through resistances)");

            Console.Write("Choose element (1-3): ");
            int choice = int.Parse(Console.ReadLine());
            return choice;
        }

        public static void printStatPretty(string stat, object value)
        {
            Console.WriteLine("{0,-20} {1}", stat + ":", value.ToString());
        }

        public static void printStatPretty(string stat, double value, double baseValue)
        {
            Console.WriteLine("{0,-20} {1}/{2}", stat + ":", ((float)value),(float)baseValue);
        }

        public static void LogAction(Character character, string action, object cost)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"{character.Name} is using {action} (Cost: {cost} Resource)");
            Console.ResetColor();
        }

        public static void LogDamage(Character character, Character enemy, float damage, string action)
        {
            Console.ResetColor();
            Console.WriteLine($"{enemy.Name} took {damage} damage from {character.Name}'s {action}");
        }

        public static void LogStatus(Character character, Statuses status)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"{character.Name} is {status}");
            Console.ResetColor();
        }

    }
}
