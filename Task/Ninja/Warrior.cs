﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ninja
{
    public class Warrior : Character, ISkill
    {
        public int Level { get; set; } = 1;
        public int Armor { get; set; }
        /// <summary>
        /// Calculate damage coefficient value. 
        /// </summary>
        /// <param name="warrior"></param>
        public override int Attack(ref Warrior warrior)
        {
            Random random = new Random();
            double k = random.Next(0, 10) / 10;
            int attakPoint = Level * (int)(Strength * k);
            warrior.Health -= attakPoint;
            AvailablePoints += attakPoint;
            return attakPoint;
        }
        /// <summary>
        /// Increase level. cost is 100 points.
        /// </summary>
        public void IncreaseLevel()
        {
            if(AvailablePoints >= 100)
            {
                Level++;
                AvailablePoints -= 100;
                Armor += 3;
                Strength += 1;
            }
        }

        public int IncreaseArmor(int availablePoints)
        {
            if (availablePoints >= 20)
            {
                availablePoints -= 20;
                return 1;
            }
            return 0;
        }

        public new int IncreaseStrength(int availablePoints)
        {
            if (availablePoints >= 50)
            {
                availablePoints -= 50;
                return 1;
            }
            return 0;
        }
    }
}
