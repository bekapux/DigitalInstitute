﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ninja
{
    public class Mage : Character, ISkill
    {
        public int Mana { get; set; }

        public override int Attack(ref Character character)
        {
            Random random = new Random();
            double k = random.Next(10, 30) / 10;
            int attakPoint = (int)(Strength * k);
            character.Health -= attakPoint;
            AvailablePoints += attakPoint;
            return attakPoint;
        }

        public override int IncreaseArmor(ref int availablePoints)
        {
            if (availablePoints >= 20)
            {
                availablePoints -= 20;
                return 1;
            }
            return 0;
        }

        int ISkill.IncreaseArmor(ref int availablePoints)
        {
            if (availablePoints >= 20)
            {
                availablePoints -= 20;
                return 2;
            }
            return 0;
        }

        int ISkill.IncreaseStrength(ref int availablePoints)
        {
            if (availablePoints >= 50)
            {
                availablePoints -= 50;
                return 2;
            }
            return 0;
        }
    }
}
