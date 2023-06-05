using System.Net.Http.Headers;
using Task.Data;
using Task.Enums;
using Task.Interfaces;
using Task.Utils;

namespace Task.Models
{
    public class Sorcerer : Character, ISkill
    {
        public Elements ActiveElement { get; set; }

        public Sorcerer() : base() { Class = Classes.Sorcerer; }

        public Sorcerer(string name, Races raceName) : base(name, raceName, Classes.Sorcerer)
        {
            Health = new Stat(HealthStat.sorcererBaseHealth, HealthStat.sorcererBaseHealth);
            Resource = new Stat(ResourceStat.sorcererBaseResource*5, ResourceStat.sorcererBaseResource*5);
            Armor = new Stat(ArmorStat.sorcererBaseArmor, ArmorStat.sorcererBaseArmor);
            MagicResist = new Stat(MagicResistStat.sorcererBaseMagicResist, MagicResistStat.sorcererBaseMagicResist);
            Strength = new Stat(StrengthStat.sorcererBaseStrength, StrengthStat.sorcererBaseStrength);
            Dexterity = new Stat(DexterityStat.sorcererBaseDexterity, DexterityStat.sorcererBaseDexterity);
            Intelligence = new Stat(IntelligenceStat.sorcererBaseIntelligence, IntelligenceStat.sorcererBaseIntelligence);
            Faith = new Stat(FaithStat.sorcererBaseFaith,FaithStat.sorcererBaseFaith);
        }

        public override void BasicAttack(Character enemy)
        {
            if (CanPerformAction(0, "Basic attack"))
            {
                Display.LogAction(this, "Basic attack", 0);
                using Weapon runeOfMagic = new Weapon("Rune of lower magic", Intelligence.CurrentValue);
                float damageSent = runeOfMagic.Damage;

                enemy.TakeDamage(this,damageSent,0,enemy.MagicResist.CurrentValue,"Basic attack");
            }
        }

        /*
        * Basic Skill - Choose Element (10 resource)
        * 
        * Sorcerer can activate the element of their choice (Fire, Ice, Electricity)
        * Sorcerer's skills deal damage and apply effects based on the active element
        * 
        */
        public void UseBasicSkill(Character character)
        {
            if (CanPerformAction(10, "Choose Element"))
            {
                Display.LogAction(this, "Choose Element", 10);
                int choice = Display.ChooseElement(this);
                switch (choice)
                {
                    case 1: ActiveElement = Elements.Fire; break;
                    case 2: ActiveElement = Elements.Ice; break;
                    case 3: ActiveElement = Elements.Electricity; break;
                    default: ActiveElement = Elements.Fire; break;
                }
                Console.WriteLine($"{Name} chose {ActiveElement} as their active element!");
            }
        }

        /*
        * Empowered Skill - ELemental Power
        * 
        * Fire - DragonFire (30 resource)
        * 
        * Sorcerer uses fire elemental power to burn through enemies with dragon's fire
        * Enemies affected by this skill have reduced magic resistance and take bonus burn damage for duration.
        * 
        * 
        * Ice - FrostBite (30 resource)
        * 
        * Sorcerer uses ice elemental power to freeze their victims and deal magic damage
        * Enemies affected by this skill are unable to move or use abilities for duration
        * 
        * 
        * Electricity - ThunderBlast (30 resource)
        * 
        * Sorcerer uses electric elemental power to pierce enemies with devastating electic energy from above
        * This attack ignores all enemy resistances
        * Sorcerer regains resource cost of this ability, if the enemy is killed.
        * 
        * 
        * damage scales with intelligence
        */
        public void UseEmpoweredSkill(Character enemy)
        {
            if (CanPerformAction(30, "ELemental Power"))
            {
                Resource.CurrentValue -= 30;

                if (ActiveElement == Elements.Fire)
                {
                    Display.LogAction(this, "ELemental Power - DragonFire", 30);
                    using Weapon fireRune = new Weapon("Rune Of Fire",Intelligence.CurrentValue*1.5f);
                    float damageSent = fireRune.Damage;
                    float bonusBurnDamage = Intelligence.CurrentValue / 2;
                    enemy.TakeDamage(this, damageSent, bonusBurnDamage, enemy.MagicResist.CurrentValue, "DragonFire");

                }
                else if (ActiveElement == Elements.Ice)
                {
                    Display.LogAction(this, "ELemental Power - FrostBite", 30);
                    using Weapon iceRune = new Weapon("Rune Of Ice", Intelligence.CurrentValue);
                    float damageSent = iceRune.Damage;
                    enemy.Status = Statuses.Stunned;
                    enemy.TakeDamage(this, damageSent, 0, enemy.MagicResist.CurrentValue, "FrostBite");

                }
                else if (ActiveElement == Elements.Electricity)
                {
                    Display.LogAction(this, "ELemental Power - ThunderBlast", 30);
                    using Weapon thunderRune = new Weapon("Rune Of Thunder", Intelligence.CurrentValue*2.5f);
                    float damageSent = thunderRune.Damage;
                    enemy.TakeDamage(this, enemy.MagicResist.CurrentValue, damageSent, enemy.MagicResist.CurrentValue, "ThunderBlast");
                    if (enemy.Status == Statuses.Dead) Resource.CurrentValue += 30;
                }
            }
        }

        /*
        * Ultimate Skill - Nature's Wrath (100 resource)
        * 
        * Sorcerer calls the Nature's Wrath upon his foes, combining all types of elemental magic to form a sphere of devastating damage
        * This attack ignores all resistances
        * 
        * scales with intelligence
        */
        public void UseUltimateSkill(List<Character> enemies)
        {
            if (CanPerformAction(100, "Nature's Wrath"))
            {
                Display.LogAction(this, "Nature's Wrath", 100);
                Resource.CurrentValue -= 100;

                using Weapon runeOfWorld = new Weapon("Rune Of World", Intelligence.CurrentValue * 4);
                foreach (Character enemy in enemies)
                {
                    float damageSent = runeOfWorld.Damage;
                    enemy.TakeDamage(this, enemy.MagicResist.CurrentValue, damageSent, enemy.MagicResist.CurrentValue, "Nature's Wrath");
                }
            }
        }
    }
}
