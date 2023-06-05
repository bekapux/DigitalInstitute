using System;
using Task.Data;
using Task.Enums;
using Task.Utils;

namespace Task.Models
{
    public abstract class Character
    {
        private int _skillPoints;

        public string Name { get; init; }
        public Races Race { get; init; }
        public Classes Class { get; init; }
        public Statuses Status { get; set; }

        public Stat Health { get; set; }
        public Stat Resource { get; set; }
        public Stat Armor { get; set; }
        public Stat MagicResist {get; set; }
        public Stat Strength { get; set; }
        public Stat Dexterity { get; set; }
        public Stat Intelligence { get; set; }
        public Stat Faith { get; set; }
        public int SkillPoints { get => _skillPoints; set => _skillPoints = value; }

        public Character()
        {
            Name = StatRandomizer.GetRandomName();
            Race = StatRandomizer.GetRandomRace();
            Class = StatRandomizer.GetRandomClass();
            Status = Statuses.Alive;

            Health = new Stat(HealthStat.defaultBaseHealth, HealthStat.defaultBaseHealth);
            Resource = new Stat(ResourceStat.defaultBaseResource, ResourceStat.defaultBaseResource);
            Armor = new Stat(ArmorStat.defaultBaseArmor, ArmorStat.defaultBaseArmor);
            MagicResist = new Stat(MagicResistStat.defaultBaseMagicResist, MagicResistStat.defaultBaseMagicResist);
            Strength = new Stat(StrengthStat.defaultBaseStrength, StrengthStat.defaultBaseStrength);
            Dexterity = new Stat(DexterityStat.barbarianBaseDexterity, DexterityStat.defaultBaseDexterity);
            Intelligence = new Stat(IntelligenceStat.defaultBaseIntelligence, IntelligenceStat.defaultBaseIntelligence);
            Faith = new Stat(FaithStat.defaultBaseFaith, FaithStat.defaultBaseFaith);
            SkillPoints = 0;
        }

        public Character(string name, Races raceName, Classes className)
        {
            Name = name;
            Race = raceName;
            Class = className;
            Status = Statuses.Alive;
            SkillPoints = 0;
        }

        public abstract void BasicAttack(Character enemy);

        public void LevelUp(int increase)
        {
            if (CanPerformAction(0, "Level Up"))
            {
                Console.WriteLine($"{Name} leveled up! Please allocate your skill points");
                SkillPoints += increase;

                while (SkillPoints > 0)
                {
                    Display.chooseStatToLevelUp(this);
                    SkillPoints--;
                }
            }
        }

        public void Rest(int hours)
        {
            if (CanPerformAction(0,"Rest"))
            {
                Console.WriteLine($"{Name} is resting for {hours} hours...");
                Console.WriteLine($"{nameof(Health)} and {nameof(Resource)} restored");

                Health.CurrentValue = Health.MaxValue;
                Resource.CurrentValue = Resource.MaxValue;
            }
        }

        public void TakeDamage(Character attacker, float preMitigationDamage, float postMitigationDamage, float damageMitigated, string skill)
        {
            float healthBefore = Health.CurrentValue;

            float nonMitigatedDamage = preMitigationDamage - damageMitigated;
            if (nonMitigatedDamage >= 0 && !Status.Equals(Statuses.Invulnerable)) Health.CurrentValue -= (nonMitigatedDamage + postMitigationDamage);

            Display.LogDamage(attacker, this, healthBefore - Health.CurrentValue, skill);

            if (Health.CurrentValue <= 0)
            {
                Health.CurrentValue = 0;
                Status = Statuses.Dead;
                Display.LogStatus(this,Statuses.Dead);
            }
        }

        public void Heal(float amount)
        {
            Health.CurrentValue += amount;
            if(Health.CurrentValue > Health.MaxValue) Health.CurrentValue = Health.MaxValue;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{Name} healed for {amount} HP");
            Console.ResetColor();
        }

        public static void BuffResistances(Character character, float armorBuffAmount, float magicResistBuffAmount)
        {
            character.Armor.CurrentValue += armorBuffAmount;
            character.MagicResist.CurrentValue += magicResistBuffAmount;
            Console.WriteLine($"{character.Name} gained +{armorBuffAmount} armor and +{magicResistBuffAmount} magic resist");
        }

        public static void DebuffResistances(Character character, float armorDebuffAmount, float magicResistDebuffAmount)
        {
            armorDebuffAmount = character.Armor.CurrentValue < armorDebuffAmount ? character.Armor.CurrentValue : armorDebuffAmount;
            magicResistDebuffAmount = character.MagicResist.CurrentValue < magicResistDebuffAmount ? character.MagicResist.CurrentValue : magicResistDebuffAmount;
            character.Armor.CurrentValue -= armorDebuffAmount;
            character.MagicResist.CurrentValue -= magicResistDebuffAmount;
            Console.WriteLine($"{character.Name} lost -{armorDebuffAmount} armor and -{magicResistDebuffAmount} magic resist");
        }

        public bool CanPerformAction(double cost, string action)
        {
            if(Status.Equals(Statuses.Dead))
            {
                Display.LogStatus(this,Statuses.Dead);
                return false;
            }
            else if (Status.Equals(Statuses.Stunned))
            {
                Display.LogStatus(this, Statuses.Stunned);
                return false;
            }
            else if(cost > Resource.CurrentValue)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{Name} does not have enough {nameof(Resource)} to use {action}");
                Console.ResetColor();
                return false;
            }
            return true;
        }
    }
}
