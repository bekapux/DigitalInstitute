﻿using Gladiators.Common.Characters;
using Gladiators.Common.Characters.Enum;
using Gladiators.Common.SkillContracts;
using Gladiators.Common.Skills.Mage;

namespace Gladiators.Common.Classes
{
    public class Mage : Character
    {
        public Mage(string name, int armor, int crit, int dexterity, int intelligence, int strength, int vigor) : base()
        {
            Class = CharacterClassesEnum.Mage;
            SkillCooldown = 2;
            Name = name;
            Armor = armor;
            Crit = crit;
            Dexterity = dexterity;
            Intelligence = intelligence;
            Strength = strength;
            Vigor = vigor;

            Skills = new List<BaseSkill>() {
                new Earthshock(),
                new ShockWave(),
                new IceArrow()
            };

            CalculateStats();
        }

        #region Calculations

        protected override void CalculateDamage()
            => PhysicalDamage = Strength;
        protected override void CalculateMagicalDamage()
            => MagicalDamage = Intelligence + Intelligence / 2 + Intelligence * 2;

        protected override void CalculateHealth()
            => Health = Strength * 100;

        protected override void CalculateHealthRegen()
            => HealthRegen = Vigor;

        protected override void CalculateMana()
            => Mana = Intelligence * 2 * 50;

        protected override void CalculateManaRegen()
            => ManaRegen = Dexterity + 10;

        protected override void CalculateCritRate()
            => CritRate = 5;

        protected override void CalculateCritDamage()
            => CritDamage = PhysicalDamage * 10;

        #endregion

        #region Actions
        public override void Attack(Character target)
        {
            int dmgToTarget = target is Warrior ? PhysicalDamage + MagicalDamage : PhysicalDamage;

            if (PhysicalDamage <= target.Armor * 2)
            {
                target.Armor -= dmgToTarget;
            }
            else
            {
                if (target.Armor > 0)
                {
                    dmgToTarget = Math.Abs(target.Armor * 2 - PhysicalDamage);
                    target.Armor -= dmgToTarget / 2;
                    target.Health -= dmgToTarget;
                }
                else
                {
                    target.Armor = 0;
                    target.Health -= dmgToTarget;
                }
            }

            Console.WriteLine($"Attacker {Name} used normal attack on {target.Name} with {dmgToTarget} targets health is {target.Health} \n");
        }

        public override void UseSkill(BaseSkill skill, Character target)
        {
            if(Mana >= skill?.ManaCost)
            {
                skill.Use(this, target);
                return;
            }
            Attack(target);
            return;
        }

        #endregion
    }
}
