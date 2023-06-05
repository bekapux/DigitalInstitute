using Task.Data;
using Task.Enums;
using Task.Interfaces;
using Task.Utils;

namespace Task.Models
{
    public class Barbarian : Character, ISkill
    {
        public Barbarian() : base() { Class = Classes.Barbarian; }

        public Barbarian(string name, Races raceName) : base(name, raceName, Classes.Barbarian)
        {
            Health = new Stat(HealthStat.barbarianBaseHealth,HealthStat.barbarianBaseHealth);
            Resource  = new Stat(0,ResourceStat.barbarianBaseResource/4);
            Armor = new Stat(ArmorStat.barbarianBaseArmor, ArmorStat.barbarianBaseArmor);
            MagicResist = new Stat(MagicResistStat.barbarianBaseMagicResist, MagicResistStat.barbarianBaseMagicResist);
            Strength = new Stat(StrengthStat.barbarianBaseStrength, StrengthStat.barbarianBaseStrength);
            Dexterity = new Stat(DexterityStat.barbarianBaseDexterity, DexterityStat.barbarianBaseDexterity);
            Intelligence = new Stat(IntelligenceStat.barbarianBaseIntelligence, IntelligenceStat.barbarianBaseIntelligence);
            Faith = new Stat(FaithStat.barbarianBaseFaith, FaithStat.barbarianBaseFaith);
        }

        public override void BasicAttack(Character enemy)
        {
            if (CanPerformAction(0, "Basic attack"))
            {
                Display.LogAction(this, "Basic attack", 0);
                using Weapon battleAxe = new Weapon("Battle axe", Strength.CurrentValue);
                float damageSent = battleAxe.Damage;

                enemy.TakeDamage(this, damageSent, 0, enemy.Armor.CurrentValue, "Basic attack");

                if (Resource.CurrentValue < Resource.MaxValue) Resource.CurrentValue++;
                Console.WriteLine($"{Name} gained 1 stack of rage ({Resource.CurrentValue}/{Resource.MaxValue})");
            }
        }

        /*
        * Basic Skill - Battle Roar
        * 
        * Barbarian points their battle axe to their chest. slices it and adds one more wound to their countless battle scars to sacrifice their hp.
        * Barbarian then enters Rage mode and roars to cause terror in enemies.
        * 
        * Enemies lose the percentage of their damage
        * Barbarian gains resistances
        * 
        * Barbarian gets 1 (one) stack of rage
        */
        public void UseBasicSkill(Character enemy)
        {
            if (CanPerformAction(0, "Battle Roar"))
            {
                Display.LogAction(this, "Battle Roar", 0);
                string mainStat = "";
                Health.CurrentValue = Health.CurrentValue * 0.9f;

                BuffResistances(this, Strength.CurrentValue / 2, Strength.CurrentValue / 2);

                switch (enemy.Class)
                {
                    case Classes.Warrior: enemy.Dexterity.CurrentValue = enemy.Dexterity.CurrentValue * 0.6f; mainStat = nameof(enemy.Dexterity); break;
                    case Classes.Barbarian: enemy.Strength.CurrentValue = enemy.Strength.CurrentValue * 0.6f; mainStat = nameof(enemy.Strength); break;
                    case Classes.Rogue: enemy.Dexterity.CurrentValue = enemy.Dexterity.CurrentValue * 0.6f; mainStat = nameof(enemy.Dexterity); break;
                    case Classes.Sorcerer: enemy.Intelligence.CurrentValue = enemy.Intelligence.CurrentValue * 0.8f; mainStat = nameof(enemy.Intelligence); break;
                    case Classes.Cleric: enemy.Faith.CurrentValue = enemy.Faith.CurrentValue * 0.6f; mainStat = nameof(enemy.Faith); break;
                }
                if (Resource.CurrentValue < Resource.MaxValue) Resource.CurrentValue++;
                Console.WriteLine($"{enemy.Name} lost 40% of {mainStat} from {Name}'s Battle Roar");
                Console.WriteLine($"{Name} gained 1 stack of rage ({Resource.CurrentValue}/{Resource.MaxValue})");
            }
        }

        /*
        * Empowered Skill - God of Thunder
        * 
        * Barbarians bloodflow increases causing all their veins to become visible and pulse with lighting
        * Barbarian combiens their axes to form a double edged axe and jumps at target to strike with all their rage, inflicting lighting damage.
        * 
        * Damage scales with current rage stacks 
        * 
        * Barbarian loses all stacks of rage using this skill, but if the enemy is killed, barbarian regains them.
        */
        public void UseEmpoweredSkill(Character enemy)
        {
            if (CanPerformAction(1, "God Of Thunder"))
            {
                Display.LogAction(this, "God Of Thunder", Resource.CurrentValue);
                using Weapon doubleAxe = new Weapon("Double axe", Strength.CurrentValue + Intelligence.CurrentValue);
                float damageSent = Resource.CurrentValue > 1 ? doubleAxe.Damage * Resource.CurrentValue : doubleAxe.Damage;

                enemy.TakeDamage(this, damageSent, 0, enemy.Armor.CurrentValue / 2 + enemy.MagicResist.CurrentValue / 2, "God Of Thunder");
                if (enemy.Status != Statuses.Dead) Resource.CurrentValue = 0;
            }
        }

        /*
        * Ultimate Skill - Ragnarok
        * 
        * Barbarian Consumes all their rage stacks and they become covered in the blood-red Aura. 
        * In this mode Barbarian is invulnerable and becomes embodiment of the Ragnarok that even gods themselves fear.
        * 
        * Barbarian is IMMUNE TO ALL DAMAGE for duration
        */
        public void UseUltimateSkill(List<Character> enemies)
        {
            if (CanPerformAction(5, "Ragnarok"))
            {
                Resource.CurrentValue = 0;
                Display.LogAction(this, "Ragnarok", 5);
                Status = Statuses.Invulnerable;
                Display.LogStatus(this, Status);
            }
        }
    }
}
