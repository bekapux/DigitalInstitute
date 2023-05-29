﻿using Gladiators.Common.Characters.Base;
using Gladiators.Common.SkillContracts;

namespace Gladiators.Common.Characters
{
    public abstract class Character : BaseCharacter
    {
        public Character() {}
        public int Health { get; set; }
        protected int HealthRegen { get; set; }

        public int Mana { get; protected set; }
        protected int ManaRegen { get; set; }

        public int PhysicalDamage { get; set; }
        public int MagicalDamage { get; set; }

        public int CritRate { get; set; }
        public int CritDamage { get; set; }

        public List<ISkill> Skills { get; set; }

        public abstract int Attack(Character target);

        #region Protected abstracts

        protected abstract void CalculateHealth();
        protected abstract void CalculateDamage();
        protected abstract void CalculateMana();
        protected abstract void CalculateHealthRegen();
        protected abstract void CalculateManaRegen();
        protected abstract void CalculateCritRate();
        protected abstract void CalculateCritDamage();
        public abstract void UseSkill(ISkill skill, Character target);

        #endregion

        #region public methods
        public bool IsAlive()
        {
            return Health > 0;
        }
        public bool IsDraw(Character opponent)
        {
            return !IsAlive() && !opponent.IsAlive();
        }
        public void DecreaseManaPoints(int manaCost)
        {
            Mana -= manaCost;
        }

        public void RegenManaAndHealth()
        {
            Health += HealthRegen;
            Mana += ManaRegen;
        }
        #endregion
    }
}
