﻿using Gladiators.Common.Characters;
using Gladiators.Common.Characters.Enum;
using Gladiators.Common.SkillContracts;
using Gladiators.Common.SkillContracts.BasedOnClass;

namespace Gladiators.Common.Skills.Archer
{
    public class Parasite : BaseSkill, IArcherSkill
    {
        const string name = "Parasite";
        const int manaCost = 3;
        const int value = 25;
        public Parasite() : base(name, manaCost, value) { }

        public override void Use(Character attacker, Character target)
        {
            base.UpdateCharacterManaAndSkillStat(attacker);

            Console.WriteLine($"Attacker {attacker.Name} used {Name}");
            int totalDamage = GetTotalDamage(attacker, target);

            Console.WriteLine($"Defender {target.Name}. Old defender health: {target.Health}. New defender health: {target.Health -= attacker.PhysicalDamage + totalDamage + value}");
            Console.WriteLine($"Attacker {attacker.Name}. Old attacker health: {target.Health}. New attacker health: {target.Health += value}\n");
        }

        protected override int GetTotalDamage(Character attacker, Character target)
        {
            return target.Class switch
            {
                CharacterClassesEnum.Warrior => Value,
                CharacterClassesEnum.Mage => Value + attacker.MagicalDamage,
                CharacterClassesEnum.Archer => Value,
                _ => -1,
            };
        }
    }
}
