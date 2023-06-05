using Task.Enums;
using Task.Utils;
using Task.Data;
using Task.Interfaces;

namespace Task.Models
{
    public class Warrior : Character, ISkill
    {
        public Warrior() : base() { Class = Classes.Warrior; }

        public Warrior(string name, Races raceName) : base(name, raceName, Classes.Warrior)
        {
            Health = new Stat(HealthStat.warriorBaseHealth, HealthStat.warriorBaseHealth);
            Resource = new Stat(ResourceStat.warriorBaseResource*5, ResourceStat.warriorBaseResource*5);
            Armor = new Stat(ArmorStat.warriorBaseArmor, ArmorStat.warriorBaseArmor);
            MagicResist = new Stat(MagicResistStat.warriorBaseMagicResist, MagicResistStat.warriorBaseMagicResist);
            Strength = new Stat(StrengthStat.warriorBaseStrength, StrengthStat.warriorBaseStrength);
            Dexterity = new Stat(DexterityStat.warriorBaseDexterity, DexterityStat.warriorBaseDexterity);
            Intelligence = new Stat(IntelligenceStat.warriorBaseIntelligence, IntelligenceStat.warriorBaseIntelligence);
            Faith = new Stat(FaithStat.warriorBaseFaith, FaithStat.warriorBaseFaith);
        }

        public override void BasicAttack(Character enemy)
        {
            if (CanPerformAction(0, "Basic attack"))
            {
                Display.LogAction(this, "Basic attack", 0);
                using Weapon sword = new Weapon("Long sword", Strength.CurrentValue);
                float damageSent = sword.Damage;
                enemy.TakeDamage(this, damageSent, 0, enemy.Armor.CurrentValue, "Basic attack");
            }
        }
        
        /*
        * Basic Skill - Bloody Slash (20 resource)
        * 
        * Warrior draws his double blades to deal moderately high damage to enemy.
        * if enemy armor is pierced, they bleed for bonus damage.
        * 
        * scales with Strength and Dexterity
        */
        public void UseBasicSkill(Character enemy)
        {
            if (CanPerformAction(20, "Bloody Slash"))
            {
                Display.LogAction(this, "Bloody Slash", 20);
                Resource.CurrentValue -= 20;
                using Weapon doubleBlades = new Weapon("Double blades", Strength.CurrentValue / 2 + Dexterity.CurrentValue / 2);
                float damageSent = doubleBlades.Damage;
                float bonusBleedDamage = Dexterity.CurrentValue /2;

                enemy.TakeDamage(this, damageSent, bonusBleedDamage, enemy.Armor.CurrentValue, "Bloody Slash");
            }
        }

        /*
        * Empowered Skill - Break Skulls (40 resource)
        * 
        * Warrior gains bonus resistances
        * Warrior uses his whole strength to attack the enemy with great mace
        * if enemie is hit in the head, this skill deals DOUBLE damage instead
        * 
        * scales with Strength
        */
        public void UseEmpoweredSkill(Character enemy)
        {
            if (CanPerformAction(40, "Break Skulls"))
            {
                Display.LogAction(this, "Break Skulls", 40);
                Resource.CurrentValue -= 40;
                BuffResistances(this, Strength.CurrentValue / 4, Strength.CurrentValue / 4);

                using Weapon greatMace = new Weapon("Great mace", Strength.CurrentValue * 2);
                float damageSent = greatMace.Damage;
                float headShot = (float)new Random().NextDouble();
                if (headShot > 0.66) damageSent = Strength.CurrentValue * 4;

                enemy.TakeDamage(this, damageSent, 0, enemy.Armor.CurrentValue, "Break Skulls");
            }
        }

        /*
        * Ultimate Skill - Fear The Blade (80 resource)
        * 
        * Warrior reduces physical resistances of all enemies around them
        * Warrior showcases the real weapon mastery by piercing through multiple enemies with deadly speed and accuracy
        * Enemies with less hp take more damage
        * Every takedown heals warrior for a small amount
        * 
        * scales with Dexterity
        */
        public void UseUltimateSkill(List<Character> enemies)
        {
            if (CanPerformAction(80, "Fear The Blade"))
            {
                Display.LogAction(this, "Fear The Blade", 80);
                Resource.CurrentValue -= 80;

                using Weapon stinger = new Weapon("Stinger", Dexterity.CurrentValue * 2);
                foreach (Character enemy in enemies)
                {
                    DebuffResistances(enemy, Dexterity.CurrentValue, 0);

                    float damageSent = stinger.Damage + Dexterity.CurrentValue * (1 - (enemy.Health.CurrentValue / enemy.Health.MaxValue));
                    enemy.TakeDamage(this, damageSent, 0, enemy.Armor.CurrentValue, "Fear the blade");
                    if (enemy.Status == Statuses.Dead) Heal(Dexterity.CurrentValue / 2);
                }
            }
        }
    }
}
