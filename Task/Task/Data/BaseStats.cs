using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task.Data
{
    public class HealthStat
    {
        public const float warriorBaseHealth = 90;
        public const float barbarianBaseHealth = 95;
        public const float rogueBaseHealth = 80;
        public const float sorcererBaseHealth = 70;
        public const float clericBaseHealth = 65;

        public const float defaultBaseHealth = 80;
    }

    public class ResourceStat
    {
        public const float warriorBaseResource = 16;
        public const float barbarianBaseResource = 20;
        public const float rogueBaseResource = 16;
        public const float sorcererBaseResource = 20;
        public const float clericBaseResource = 18;

        public const float defaultBaseResource = 18;
    }

    public class ArmorStat
    {
        public const float warriorBaseArmor = 10;
        public const float barbarianBaseArmor = 12;
        public const float rogueBaseArmor = 6;
        public const float sorcererBaseArmor = 4;
        public const float clericBaseArmor = 4;

        public const float defaultBaseArmor = 8;
    }

    public class MagicResistStat
    {
        public const float warriorBaseMagicResist = 10;
        public const float barbarianBaseMagicResist = 12;
        public const float rogueBaseMagicResist = 6;
        public const float sorcererBaseMagicResist = 4;
        public const float clericBaseMagicResist = 4;

        public const float defaultBaseMagicResist = 8;
    }

    public class StrengthStat
    {
        public const float warriorBaseStrength = 18;
        public const float barbarianBaseStrength = 16;
        public const float rogueBaseStrength = 12;
        public const float sorcererBaseStrength = 6;
        public const float clericBaseStrength = 4;

        public const float defaultBaseStrength = 10;
    }

    public class DexterityStat
    {
        public const float warriorBaseDexterity = 16;
        public const float barbarianBaseDexterity = 12;
        public const float rogueBaseDexterity = 18;
        public const float sorcererBaseDexterity = 8;
        public const float clericBaseDexterity = 8;

        public const float defaultBaseDexterity = 10;
    }

    public class IntelligenceStat
    {
        public const float warriorBaseIntelligence = 8;
        public const float barbarianBaseIntelligence = 6;
        public const float rogueBaseIntelligence = 10;
        public const float sorcererBaseIntelligence = 18;
        public const float clericBaseIntelligence = 16;

        public const float defaultBaseIntelligence = 10;
    }

    public class FaithStat
    {
        public const float warriorBaseFaith = 6;
        public const float barbarianBaseFaith = 4;
        public const float rogueBaseFaith = 10;
        public const float sorcererBaseFaith = 16;
        public const float clericBaseFaith = 18;

        public const float defaultBaseFaith = 10;
    }
}
